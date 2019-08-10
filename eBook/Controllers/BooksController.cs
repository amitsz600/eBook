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
                                     NumberOfComments = grouped.Count()
                                 };
            var favoriteGenre = new {Genre= "", NumberOfComments = -1 };

            foreach (var genreAndNumberOfComments in favoriteGenres)
            {
                if (genreAndNumberOfComments.NumberOfComments > favoriteGenre.NumberOfComments)
                {
                    favoriteGenre = genreAndNumberOfComments;
                }
            }

            IQueryable booksFromFavoriteGenres; 

            if (!favoriteGenre.Genre.Equals(""))
            {
                booksFromFavoriteGenres = (from book in db.Books
                                           where book.genre == favoriteGenre.Genre
                                           join comment in db.Comments on book.ProductId equals comment.ProductId
                                           group comment by new { book.ProductId, book.Title, book.Author, book.Image } into grouped
                                           where grouped.Count(g => g.Author == username) == 0
                                           select new
                                           {
                                               ProductId = grouped.Key.ProductId,
                                               Title = grouped.Key.Title,
                                               Author = grouped.Key.Author,
                                               Image = grouped.Key.Image,
                                               raiting = grouped.Average(c => c.Rating)
                                           }).OrderByDescending(b => b.raiting)
                                           .Take(5);

            } else
            {
                booksFromFavoriteGenres = (from book in db.Books
                                           join comment in db.Comments on book.ProductId equals comment.ProductId
                                           group comment by new { book.ProductId, book.Title, book.Author, book.Image } into grouped
                                           where grouped.Count(g => g.Author == username) == 0
                                           select new
                                           {
                                               ProductId = grouped.Key.ProductId,
                                               Title = grouped.Key.Title,
                                               Author = grouped.Key.Author,
                                               Image = grouped.Key.Image,
                                               raiting = grouped.Average(c => c.Rating)
                                           }).OrderByDescending(b => b.raiting)
                                           .Take(5);
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
        public ActionResult Create([Bind(Include = "ProductId,Title,Author,Price,Description,genre,Image,publisher,TwitterWidgets")] Book book)
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
        public ActionResult Edit([Bind(Include = "ProductId,Title,Author,Price,Description,genre,Image,publisher,TwitterWidgets")] Book book)
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
    }
}
