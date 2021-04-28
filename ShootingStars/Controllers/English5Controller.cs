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
    public class English5Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: English5
        public ActionResult Index()
        {
            return View(db.English5s.ToList());
        }

        // GET: English5/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English5 english5 = db.English5s.Find(id);
            if (english5 == null)
            {
                return HttpNotFound();
            }
            return View(english5);
        }

        // GET: English5/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: English5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "English5Id,English5title,English5Descr,English5Doc,English5Image,English5Teacher,English5TeacherImg,ImageFile")] English5 english5)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(english5.ImageFile.FileName);
                string extension = Path.GetExtension(english5.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                english5.English5Image = "~/Content/Subject Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Subject Images/"), fileName);
                english5.ImageFile.SaveAs(fileName);

                db.English5s.Add(english5);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(english5);
        }

        // GET: English5/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English5 english5 = db.English5s.Find(id);
            if (english5 == null)
            {
                return HttpNotFound();
            }
            return View(english5);
        }

        // POST: English5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "English5Id,English5title,English5Descr,English5Doc,English5Image,English5Teacher,English5TeacherImg,ImageFile")] English5 english5)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(english5.ImageFile.FileName);
                string extension = Path.GetExtension(english5.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                english5.English5Image = "~/Content/Subject Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Subject Images/"), fileName);
                english5.ImageFile.SaveAs(fileName);

                db.Entry(english5).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(english5);
        }

        // GET: English5/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English5 english5 = db.English5s.Find(id);
            if (english5 == null)
            {
                return HttpNotFound();
            }
            return View(english5);
        }

        // POST: English5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            English5 english5 = db.English5s.Find(id);
            db.English5s.Remove(english5);
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
    }
}
