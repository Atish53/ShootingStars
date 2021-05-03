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
    public class TeacherReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeacherReviews
        public ActionResult Index()
        {
            return View(db.TeacherReviews.ToList());
        }

        // GET: TeacherReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherReview teacherReview = db.TeacherReviews.Find(id);
            if (teacherReview == null)
            {
                return HttpNotFound();
            }
            return View(teacherReview);
        }

        // GET: TeacherReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Grade,Class,Name,Q1,Q2,Q3,Q4,Q5,Q6,Q7,Q8,Q9,Q10")] TeacherReview teacherReview)
        {
            if (ModelState.IsValid)
            {
                db.TeacherReviews.Add(teacherReview);
                db.SaveChanges();
                return RedirectToAction("Thanks");
            }

            return View(teacherReview);
        }

        // GET: TeacherReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherReview teacherReview = db.TeacherReviews.Find(id);
            if (teacherReview == null)
            {
                return HttpNotFound();
            }
            return View(teacherReview);
        }

        // POST: TeacherReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Grade,Class,Name,Q1,Q2,Q3,Q4,Q5,Q6,Q7,Q8,Q9,Q10")] TeacherReview teacherReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherReview);
        }

        // GET: TeacherReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherReview teacherReview = db.TeacherReviews.Find(id);
            if (teacherReview == null)
            {
                return HttpNotFound();
            }
            return View(teacherReview);
        }

        // POST: TeacherReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherReview teacherReview = db.TeacherReviews.Find(id);
            db.TeacherReviews.Remove(teacherReview);
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
