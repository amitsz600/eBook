using eBook.DAL;
using eBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace eBook.Controllers
{
    public class CommentsController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Comments
        public ActionResult Index(int? ProductId, string Author)
        {
            IQueryable<Comment> query = db.Comments;

            if (ProductId != null)
            {
                query = query.Where(x => x.ProductId == ProductId);
            }

            if(Author != null)
            {
                query = query.Where(x => x.Author.Equals(Author));
            }
            query = query.Include(c => c.RelatedProduct);


            return View(query.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Books, "PostId", "Title");
            return RedirectToAction("Index", "Books");
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Create([Bind(Include = "CommentId,ProductId,Title,Author,Body,Rating")] Comment comment, int ProductId)
        {
            comment.date = DateTime.Now;
            comment.ProductId = ProductId;
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }

            ViewBag.PostId = new SelectList(db.Books, "ProductId", "Title", comment.ProductId);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.Books, "ProductId", "Title", comment.ProductId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,ProductId,Title,Author,Body,Rating")] Comment comment, int ProductId)
        {
            comment.date = DateTime.Now;
            comment.ProductId = ProductId;
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Books", new { id = ProductId });
            }
            ViewBag.PostId = new SelectList(db.Books, "ProductId", "Title", comment.ProductId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
        }

        [HttpGet]
        public ActionResult GetAverageNumberForBooksPerMonth()
        {
            int numberOfBooks = db.Books.Count();
            var groupQuery = (from comment in db.Comments
                             group comment by new {comment.date.Month } into grouped
                             select new
                             {
                                 Month = grouped.Key.Month,
                                 Count = ((double) grouped.Count()) / numberOfBooks
                             });

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