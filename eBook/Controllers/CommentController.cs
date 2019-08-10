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
            var comments = db.Comments;

            if (ProductId != null)
            {
                comments.Where(x => x.ProductId == ProductId);
            }

            if(Author != "")
            {
                comments.Where(x => x.Author.Equals(Author));
            }
            comments.Include(c => c.RelatedProduct);

            return View(comments.ToList());
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
        public ActionResult Create([Bind(Include = "CommentId,ProductId,Title,Author,Body,Rating")] Comment comment, int ProductId)
        {
            comment.ProductId = ProductId;
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", "Books");
            }

            ViewBag.PostId = new SelectList(db.Books, "ProductId", "Title", comment.ProductId);
            return RedirectToAction("Index", "Books");
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
        public ActionResult Edit([Bind(Include = "CommentId,PostId,Title,Author,Body,Rating")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(db.Books, "ProductId", "Title", comment.ProductId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetAverageNumberForBooksPerMonth()
        {
            var groupQuery = (from comment in db.Comments
                             group comment by new {comment.date.Month, comment.ProductId } into grouped
                             select new
                             {
                                 Month = grouped.Key.Month,
                                 ProductId = grouped.Key.ProductId,
                                 Count = grouped.Count()
                             });

            /*groupQuery.GroupBy(g => g.Month).Select(g => new {
                Month = g.Key,
                Count = g.Average(c => c.Count)
            }).OrderBy(g => g.Month);*/

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