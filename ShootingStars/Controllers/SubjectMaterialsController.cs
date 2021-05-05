using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShootingStars.Models;

namespace ShootingStars.Controllers
{
    public class SubjectMaterialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectMaterials
        public ActionResult Index()
        {
            var subjectMaterials = db.SubjectMaterials.Include(s => s.Subjects);
            return View(subjectMaterials.ToList());
        }

        // GET: SubjectMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMaterial subjectMaterial = db.SubjectMaterials.Find(id);
            if (subjectMaterial == null)
            {
                return HttpNotFound();
            }
            return View(subjectMaterial);
        }

        // GET: SubjectMaterials/Create
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: SubjectMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectMaterialID,SubjectID,MaterialFile,MaterialName,DocFile")] SubjectMaterial subjectMaterial, HttpPostedFileBase UploadMaterial)
        {
            if (ModelState.IsValid)
            {
                //string fileName = Path.GetFileNameWithoutExtension(subjectMaterial.DocFile.FileName);
                //string extension = Path.GetExtension(subjectMaterial.DocFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //subjectMaterial.MaterialFile = "~/Content/SubjectMaterial/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Content/SubjectMaterial/"), fileName);
                //subjectMaterial.DocFile.SaveAs(fileName);

                if (UploadMaterial != null)
                {
                    UploadMaterial.SaveAs(Server.MapPath("/") + "/Content/SubjectMaterial/" + UploadMaterial.FileName);
                    subjectMaterial.MaterialFile = UploadMaterial.FileName;
                }
                else
                {
                    return View();
                }

                db.SubjectMaterials.Add(subjectMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectMaterial.SubjectID);
            return View(subjectMaterial);
        }

        // GET: SubjectMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMaterial subjectMaterial = db.SubjectMaterials.Find(id);
            if (subjectMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectMaterial.SubjectID);
            return View(subjectMaterial);
        }

        // POST: SubjectMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectMaterialID,SubjectID,MaterialFile,MaterialName")] SubjectMaterial subjectMaterial, HttpPostedFileBase UploadMaterial)
        {
            if (ModelState.IsValid)
            {
                if (UploadMaterial != null)
                {
                    UploadMaterial.SaveAs(Server.MapPath("/") + "/Content/SubjectMaterial/" + UploadMaterial.FileName);
                    subjectMaterial.MaterialFile = UploadMaterial.FileName;
                }
                else
                {
                    return View();
                }

                db.Entry(subjectMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectMaterial.SubjectID);
            return View(subjectMaterial);
        }

        // GET: SubjectMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMaterial subjectMaterial = db.SubjectMaterials.Find(id);
            if (subjectMaterial == null)
            {
                return HttpNotFound();
            }
            return View(subjectMaterial);
        }

        // POST: SubjectMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectMaterial subjectMaterial = db.SubjectMaterials.Find(id);
            db.SubjectMaterials.Remove(subjectMaterial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: SubjectMaterials/Delete/5
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
            return RedirectToAction("Edit","Quiz", id);
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
