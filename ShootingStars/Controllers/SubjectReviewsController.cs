using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShootingStars.Models;

namespace ShootingStars.Controllers
{
    public class SubjectReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectReviews
        public ActionResult Index()
        {
            var subjectReviews = db.SubjectReviews.Include(s => s.Subject);
            return View(subjectReviews.ToList());
        }

        // GET: SubjectReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectReview subjectReview = db.SubjectReviews.Find(id);
            if (subjectReview == null)
            {
                return HttpNotFound();
            }
            return View(subjectReview);
        }

        // GET: SubjectReviews/Create
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: SubjectReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,SubjectID")] SubjectReview subjectReview)
        {
            if (ModelState.IsValid)
            {
                db.SubjectReviews.Add(subjectReview);
                db.SaveChanges();
                return RedirectToAction("Thanks");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectReview.SubjectID);
            return View(subjectReview);
        }

        // GET: SubjectReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectReview subjectReview = db.SubjectReviews.Find(id);
            if (subjectReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectReview.SubjectID);
            return View(subjectReview);
        }

        // POST: SubjectReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Question1,Question2,Question3,Question4,Question5,Question6,Question7,Question8,Question9,Question10,SubjectID")] SubjectReview subjectReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectReview.SubjectID);
            return View(subjectReview);
        }

        // GET: SubjectReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectReview subjectReview = db.SubjectReviews.Find(id);
            if (subjectReview == null)
            {
                return HttpNotFound();
            }
            return View(subjectReview);
        }

        // POST: SubjectReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectReview subjectReview = db.SubjectReviews.Find(id);
            db.SubjectReviews.Remove(subjectReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Thanks()
        {
            return View();
        }
    }
}

