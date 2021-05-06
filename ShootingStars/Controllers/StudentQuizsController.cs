using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentQuiz studentQuiz)
        {
            if (ModelState.IsValid)
            {
                db.StudentQuizzes.Add(studentQuiz);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studentQuiz);
        }

        // GET: StudentQuizs/AttemptQuiz
        public async Task<ActionResult> AttemptQuiz(int? id)
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
      
            string[] answerArray = new string[5];
            string[] questionArray = new string[5];
            for (int i = 0; i < db.QuestionAnswers.Where((x => x.QuizID == quiz.QuizID)).Count();)
                foreach (var item in db.QuestionAnswers.Where(x => x.QuizID == quiz.QuizID))
                {
                    {
                        answerArray[i] = item.Answer;
                        questionArray[i] = item.Question;
                        i++;
                    }
                }

            ViewData["Q1"] = questionArray[0];
            ViewData["Q2"] = questionArray[1];
            ViewData["Q3"] = questionArray[2];
            ViewData["Q4"] = questionArray[3];
            ViewData["Q5"] = questionArray[4];
            return View(quiz);
        }

        // POST: StudentQuizs/AttemptQuiz/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AttemptQuiz([Bind(Include = "StudentQuizID, QuizID")] Quiz quiz, FormCollection formCollection)
        {
            int count = 0;
            string[] answerArray = new string[5];
            string[] questionArray = new string[5];
            for (int i = 0; i < db.QuestionAnswers.Where((x => x.QuizID == quiz.QuizID)).Count();)
                foreach (var item in db.QuestionAnswers.Where(x => x.QuizID == quiz.QuizID))
                {
                    {
                        answerArray[i] = item.Answer;
                        questionArray[i] = item.Question;
                        i++;
                    }
                }
            ViewData["Q1"] = questionArray[0];
            ViewData["Q2"] = questionArray[1];
            ViewData["Q3"] = questionArray[2];
            ViewData["Q4"] = questionArray[3];
            ViewData["Q5"] = questionArray[4];

            string Answer1 = formCollection["Answer1"];
            string Answer2 = formCollection["Answer2"];
            string Answer3 = formCollection["Answer3"];
            string Answer4 = formCollection["Answer4"];
            string Answer5 = formCollection["Answer5"];
                        
            //Check mark

            if (Answer1 == answerArray[0])
            {
                count++;
            }
            if (Answer2 == answerArray[1])
            {
                count++;
            }
            if (Answer3 == answerArray[2])
            {
                count++;
            }
            if (Answer4 == answerArray[3])
            {
                count++;
            }
            if (Answer5 == answerArray[4])
            {
                count++;
            }            

            StudentQuiz studentQuiz = new StudentQuiz();

            studentQuiz.Mark = Convert.ToInt32(count/5.0*100);
            studentQuiz.QuizID = quiz.QuizID;           
            studentQuiz.StudentEmail = User.Identity.GetStudentEmail();
            studentQuiz.DateAttempted = DateTime.Now;            

            if (ModelState.IsValid)
            {
                db.StudentQuizzes.Add(studentQuiz);
                await db.SaveChangesAsync();
                return RedirectToAction("Success", new { id = studentQuiz.StudentQuizID });
            }
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

        // GET: StudentQuizs/Success/5
        public async Task<ActionResult> Success(int? id)
        {
            string[] answerArray = new string[5];
            string[] questionArray = new string[5];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentQuiz studentQuiz = await db.StudentQuizzes.FindAsync(id);
            if (studentQuiz == null)
            {
                return HttpNotFound();
            }
            int QuizIDs = studentQuiz.QuizID;
            for (int i = 0; i < db.QuestionAnswers.Where((x => x.QuizID == QuizIDs)).Count();)
                foreach (var item in db.QuestionAnswers.Where(x => x.QuizID == QuizIDs))
                {
                    {
                        answerArray[i] = item.Answer;
                        questionArray[i] = item.Question;
                        i++;
                    }
                }

            ViewData["Q1"] = questionArray[0];
            ViewData["Q2"] = questionArray[1];
            ViewData["Q3"] = questionArray[2];
            ViewData["Q4"] = questionArray[3];
            ViewData["Q5"] = questionArray[4];

            ViewData["A1"] = answerArray[0];
            ViewData["A2"] = answerArray[1];
            ViewData["A3"] = answerArray[2];
            ViewData["A4"] = answerArray[3];
            ViewData["A5"] = answerArray[4];

            return View(studentQuiz);
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
