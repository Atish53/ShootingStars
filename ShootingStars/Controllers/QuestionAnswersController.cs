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
    public class QuestionAnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QuestionAnswers
        public async Task<ActionResult> Index()
        {
            var questionAnswers = db.QuestionAnswers.Include(q => q.Quiz);
            return View(await questionAnswers.ToListAsync());
        }

        // GET: QuestionAnswers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = await db.QuestionAnswers.FindAsync(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // GET: QuestionAnswers/Create
        public ActionResult Create()
        {
            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName");
            return View();
        }

        // POST: QuestionAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QuestionAnswerID,QuizID,Question,Answer")] QuestionAnswer questionAnswer)
        {
            if (ModelState.IsValid)
            {
                db.QuestionAnswers.Add(questionAnswer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName", questionAnswer.QuizID);
            return View(questionAnswer);
        }

        // GET: QuestionAnswers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = await db.QuestionAnswers.FindAsync(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName", questionAnswer.QuizID);
            return View(questionAnswer);
        }

        // POST: QuestionAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QuestionAnswerID,QuizID,Question,Answer")] QuestionAnswer questionAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionAnswer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.QuizID = new SelectList(db.Quizzes, "QuizID", "QuizName", questionAnswer.QuizID);
            return View(questionAnswer);
        }

        // GET: QuestionAnswers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionAnswer questionAnswer = await db.QuestionAnswers.FindAsync(id);
            if (questionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionAnswer);
        }

        // POST: QuestionAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QuestionAnswer questionAnswer = await db.QuestionAnswers.FindAsync(id);
            db.QuestionAnswers.Remove(questionAnswer);
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
