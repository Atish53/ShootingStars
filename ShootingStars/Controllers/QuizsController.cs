using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShootingStars.Models;

namespace ShootingStars.Controllers
{
    public class QuizsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quizs
        public async Task<ActionResult> Index()
        {
            var quizzes = db.Quizzes.Include(q => q.Subject);
            return View(await quizzes.ToListAsync());
        }

        // GET: Quizs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = await db.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizs/Create
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: Quizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QuizID,QuizName,Questions,Answers,SubjectID")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Quizzes.Add(quiz);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", quiz.SubjectID);
            return View(quiz);
        }

        // GET: Quizs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = await db.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", quiz.SubjectID);
            return View(quiz);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QuizID,QuizName,SubjectID")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quiz).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", quiz.SubjectID);
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = await db.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Quiz quiz = await db.Quizzes.FindAsync(id);
            db.Quizzes.Remove(quiz);
            await db.SaveChangesAsync();
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
    }
}
