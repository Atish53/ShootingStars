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
    public class StudentQuizsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentQuizs
        public async Task<ActionResult> Index()
        {
            var studentQuizzes = db.StudentQuizzes.Include(s => s.Quiz);
            return View(await studentQuizzes.ToListAsync());
        }

        // GET: StudentQuizs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentQuiz studentQuiz = await db.StudentQuizzes.FindAsync(id);
            if (studentQuiz == null)
            {
                return HttpNotFound();
            }
            return View(studentQuiz);
        }

        // GET: StudentQuizs/Create
        public ActionResult Create()
        {
            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName");
            return View();
        }

        // POST: StudentQuizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentQuizID,StudentEmail,QuizID,StartTime,EndTime,Duration,Mark")] StudentQuiz studentQuiz)
        {
            if (ModelState.IsValid)
            {
                db.StudentQuizzes.Add(studentQuiz);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName", studentQuiz.QuizID);
            return View(studentQuiz);
        }

        // GET: StudentQuizs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentQuiz studentQuiz = await db.StudentQuizzes.FindAsync(id);
            if (studentQuiz == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName", studentQuiz.QuizID);
            return View(studentQuiz);
        }

        // POST: StudentQuizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentQuizID,StudentEmail,QuizID,StartTime,EndTime,Duration,Mark")] StudentQuiz studentQuiz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentQuiz).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName", studentQuiz.QuizID);
            return View(studentQuiz);
        }

        // GET: StudentQuizs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentQuiz studentQuiz = await db.StudentQuizzes.FindAsync(id);
            if (studentQuiz == null)
            {
                return HttpNotFound();
            }
            return View(studentQuiz);
        }

        // POST: StudentQuizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentQuiz studentQuiz = await db.StudentQuizzes.FindAsync(id);
            db.StudentQuizzes.Remove(studentQuiz);
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
