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
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        public async Task<ActionResult> Index()
        {
            var subjects = db.Subjects.Include(s => s.Teacher);
            return View(await subjects.ToListAsync());
        }

        public ActionResult ViewSubjectMaterial(int id)
        {
            var subjectMaterial = db.SubjectMaterials.Where(x => x.SubjectID == id).ToList();
            var quiz = db.Quizzes.Where(x => x.SubjectID == id).ToList();          
                           
            return View(subjectMaterial);
        }

        // GET: Subjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SubjectID,SubjectName,SubjectGrade,SubjectDescription,TeacherID,SubjectImg")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", subject.TeacherID);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", subject.TeacherID);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SubjectID,SubjectName,SubjectGrade,SubjectDescription,TeacherID,SubjectImg")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", subject.TeacherID);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subject subject = await db.Subjects.FindAsync(id);
            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Subject4()
        {
            var subject = db.Subjects.Where(x => x.SubjectGrade == 4).ToList();

            return View(subject);
        }

        public ActionResult Subject5()
        {
            var subject = db.Subjects.Where(x => x.SubjectGrade == 5).ToList();

            return View(subject);
        }

        // GET: Subjects/AttemptQuiz/5
        public ActionResult AttemptQuiz(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quiz quiz = db.Quizzes.Find(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("AttemptQuiz/" + id, "StudentQuizs");
        }


        [ChildActionOnly]
        public ActionResult StudentScore(string marks, int? id)
        {
            marks = User.Identity.GetStudentEmail();
            var studentQuiz = db.StudentQuizzes.Where(x => x.StudentEmail == marks && x.Quiz.SubjectID == id).ToList();
            return PartialView("StudentScore", db.StudentQuizzes.Where(x => x.StudentEmail == marks && x.Quiz.SubjectID == id).ToList());
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
