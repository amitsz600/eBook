using System;
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
            string genre,
            string publisher,
            string author)
        {
            IQueryable<Book> query = db.Books;

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


        //[Authorize(Roles = IdentityConfigGlobals.MANAGER_ROLE)]
        //public ActionResult Manager()
        //{
        //    var groupQuery = from Book in db.Books
        //                     group Book by Book.Category into ProductGroup
        //                     orderby ProductGroup.Key
        //                     select ProductGroup;

        //    return View(groupQuery);
        //}

        //public ActionResult GetGroupsByCategories()
        //{
        //    var groupQuery = from Book in db.Books
        //                     group Book by Book.Category into ProductGroup
        //                     orderby ProductGroup.Key
        //                     //select new { Count=ProductGroup.Count(), Category=ProductGroup.First().Category };
        //                     select new { Count = ProductGroup.Count(), Category = ProductGroup.FirstOrDefault().Category };

        //    return Json(groupQuery, JsonRequestBehavior.AllowGet);
        //}

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
        public ActionResult Create([Bind(Include = "ProductId,Title,Author,Site,Body,Image,Video,Category,TwitterWidgets")] Book book)
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
        public ActionResult Edit([Bind(Include = "ProductId,Title,Author,Site,Date,Body,Image,Video")] Book book)
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
        public ActionResult UsersByAddresses()
        {
            return PartialView("_UsersByProductsAddressesPartial");
        }

        //[HttpGet]
        //public ActionResult UsersByProductsAddressesQuery()
        //{
        //    var queryUsersProducts = from user in db.Users
        //                             join Book in db.Books on user.Address equals Book.ProductedFrom
        //                             select new { Address = user.Address, UserEmail = user.Email, ProductTitle = Book.Title };

        //    return Json(queryUsersProducts, JsonRequestBehavior.AllowGet);
        //}



        //[HttpGet]
        //public ActionResult UsersByProductsAddresses()
        //{
        //    var queryUsersProducts = from user in db.Users
        //                             join Book in db.Books on user.Address equals Book.ProductedFrom
        //                             select new { Address = user.Address, UserEmail = user.Email, ProductTitle = Book.Title };

        //    return PartialView("_UsersByProductsAddressesPartial", queryUsersProducts);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // JSON
        //[HttpGet]
        //public ActionResult GetLikesNum(int ProductId)
        //{
        //    return Json(db.Books.Where(p => p.ProductId == ProductId).Select(p => p.Users.Count), JsonRequestBehavior.AllowGet);
        //}


        //private const int POPULAR_ProductS_AMOUNT = 3;
        //[System.Web.Mvc.HttpGet]
        //public ActionResult GetPopularProducts(int? amount)
        //{
        //    return Json(db.Books.OrderByDescending(p => p.Users.Count)
        //            .Select(p => new { p.ProductId, p.Title }).Take(amount ?? POPULAR_ProductS_AMOUNT),
        //        JsonRequestBehavior.AllowGet);
        //}

        
    }
}
