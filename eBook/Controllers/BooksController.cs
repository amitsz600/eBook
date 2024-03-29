﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using eBook.DAL;
using eBook.Models;
using eBook.App_Start;

namespace eBook.Controllers
{
    public class BooksController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Books
        public ActionResult Index(
            string title,
            string genre,
            string publisher,
            string author)
        {
            IQueryable<Book> query = db.Books;

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(p => p.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(p => p.Author.Contains(author));
            }


            if (!string.IsNullOrEmpty(publisher))
            {
                query = query.Where(p => p.publisher.Contains(publisher));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(p => p.genre.Contains(genre));
            }

            foreach (var book in query)
            {
                book.AvarageRating = this.GetRating(book.ProductId);
            }
        
            return View(query.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                book.AvarageRating = this.GetRating(id.Value);
            }

            return View(book);
        }


        // GET: Books/Favorites
        public ActionResult Favorites(String username)
        {
            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            var favoriteGenres = from book in db.Books
                                 join comment in db.Comments on book.ProductId equals comment.ProductId
                                 where comment.Author == username
                                 group comment by new { book.genre } into grouped
                                 select new
                                 {
                                     Genre = grouped.Key.genre,
                                     NumberOfComments = grouped.Count(),
                                     AvgRating = grouped.Average(ed => ed.Rating)
                                 };
            var favoriteGenre = new {Genre= "", NumberOfComments = -1, AvgRating = -1.0 };

            foreach (var genreAndNumberOfComments in favoriteGenres)
            {
                if (genreAndNumberOfComments.NumberOfComments > favoriteGenre.NumberOfComments || 
                    (genreAndNumberOfComments.AvgRating > favoriteGenre.AvgRating && genreAndNumberOfComments.NumberOfComments == favoriteGenre.NumberOfComments))
                {
                    favoriteGenre = genreAndNumberOfComments;
                }
            }

            List<BookAndRaiting> booksFromFavoriteGenres; 

            if (!favoriteGenre.Genre.Equals(""))
            {
                booksFromFavoriteGenres = (from book in db.Books
                                           where book.genre == favoriteGenre.Genre
                                           join comment in db.Comments on book.ProductId equals comment.ProductId
                                           group comment by new { book.ProductId, book.Title, book.Author, book.Image } into grouped
                                           where grouped.Count(g => g.Author == username) == 0
                                           select new BookAndRaiting
                                           {
                                               ProductId = grouped.Key.ProductId,
                                               Title = grouped.Key.Title,
                                               Author = grouped.Key.Author,
                                               Image = grouped.Key.Image,
                                               raiting = grouped.Average(c => c.Rating)
                                           }).OrderByDescending(b => b.raiting)
                                           .Take(2).ToList();

            } else
            {
                booksFromFavoriteGenres = (from book in db.Books
                                           join comment in db.Comments on book.ProductId equals comment.ProductId
                                           group comment by new { book.ProductId, book.Title, book.Author, book.Image } into grouped
                                           where grouped.Count(g => g.Author == username) == 0
                                           select new BookAndRaiting
                                           {
                                               ProductId = grouped.Key.ProductId,
                                               Title = grouped.Key.Title,
                                               Author = grouped.Key.Author,
                                               Image = grouped.Key.Image,
                                               raiting = grouped.Average(c => c.Rating)
                                           }).OrderByDescending(b => b.raiting)
                                           .Take(2).ToList();
            }

            if(booksFromFavoriteGenres.Count() < 2)
            {
                List<int> getAllComments = db.Comments.Select(c => c.ProductId).ToList();
                List<BookAndRaiting> withoutRaiting;

                if (!String.IsNullOrWhiteSpace(favoriteGenre.Genre))
                {
                    withoutRaiting = (from book in db.Books
                                      join comment in db.Comments on book.ProductId equals comment.ProductId into bc
                                      from bcc in bc.DefaultIfEmpty()
                                      where bcc == null && book.genre == favoriteGenre.Genre
                                      select new BookAndRaiting
                                      {
                                          ProductId = book.ProductId,
                                          Title = book.Title,
                                          Author = book.Author,
                                          Image = book.Image,
                                          raiting = 0
                                      }).Take(2 - booksFromFavoriteGenres.Count()).ToList();
                } else
                {
                    withoutRaiting = (from book in db.Books
                                      join comment in db.Comments on book.ProductId equals comment.ProductId into bc
                                      from bcc in bc.DefaultIfEmpty()
                                      where bcc == null
                                      select new BookAndRaiting
                                      {
                                          ProductId = book.ProductId,
                                          Title = book.Title,
                                          Author = book.Author,
                                          Image = book.Image,
                                          raiting = 0
                                      }).Take(2 - booksFromFavoriteGenres.Count()).ToList();
                }

                booksFromFavoriteGenres.AddRange(withoutRaiting);
            }
            
            return Json(booksFromFavoriteGenres, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // Book: Books/Create
        // To protect from overProducting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = IdentityConfigGlobals.MANAGER_ROLE + "," + IdentityConfigGlobals.USER_ROLE)]
        public ActionResult Create([Bind(Include = "ProductId,Title,Author,Price,Description,genre,Image,publisher")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // Book: Books/Edit/5
        // To protect from overProducting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Author,Price,Description,genre,Image,publisher")] Book book)
        { 
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // Book: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetGroupsByGenre()
        {
            var groupQuery = from book in db.Books
                             group book by book.genre into bookGroup
                             orderby bookGroup.Key
                             select new { Count = bookGroup.Count(), genre = bookGroup.FirstOrDefault().genre };

            return Json(groupQuery, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private double GetRating(int ProductId)
        {
            System.Linq.IQueryable<int> results = (from comment in db.Comments where comment.ProductId == ProductId select comment.Rating);

            double result = 0;

            if (results.Any())
            {
                result = results.Average();
            }

            return result;
        }
    }
}
