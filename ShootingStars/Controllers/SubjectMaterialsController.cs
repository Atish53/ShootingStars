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
    public class SubjectMaterialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectMaterials
        public async Task<ActionResult> Index()
        {
            var subjectMaterials = db.SubjectMaterials.Include(s => s.Subjects);
            return View(await subjectMaterials.ToListAsync());
        }

        // GET: SubjectMaterials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMaterial subjectMaterial = await db.SubjectMaterials.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "SubjectMaterialID,SubjectID,MaterialFile,MaterialName")] SubjectMaterial subjectMaterial)
        {
            if (ModelState.IsValid)
            {
                db.SubjectMaterials.Add(subjectMaterial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectMaterial.SubjectID);
            return View(subjectMaterial);
        }

        // GET: SubjectMaterials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMaterial subjectMaterial = await db.SubjectMaterials.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "SubjectMaterialID,SubjectID,MaterialFile,MaterialName")] SubjectMaterial subjectMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectMaterial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", subjectMaterial.SubjectID);
            return View(subjectMaterial);
        }

        // GET: SubjectMaterials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectMaterial subjectMaterial = await db.SubjectMaterials.FindAsync(id);
            if (subjectMaterial == null)
            {
                return HttpNotFound();
            }
            return View(subjectMaterial);
        }

        // POST: SubjectMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubjectMaterial subjectMaterial = await db.SubjectMaterials.FindAsync(id);
            db.SubjectMaterials.Remove(subjectMaterial);
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
