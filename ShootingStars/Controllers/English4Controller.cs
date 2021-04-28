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
    public class English4Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: English4
        public ActionResult Index()
        {
            return View(db.English4.ToList());
        }

        // GET: English4/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English4 english4 = db.English4.Find(id);
            if (english4 == null)
            {
                return HttpNotFound();
            }
            return View(english4);
        }

        // GET: English4/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: English4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "English4Id,English4title,English4Descr,English4Doc,English4Image,English4Teacher,English4TeacherImg,ImageFile")] English4 english4)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(english4.ImageFile.FileName);
                string extension = Path.GetExtension(english4.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                english4.English4Image = "~/Content/Subject Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Subject Images/"), fileName);
                english4.ImageFile.SaveAs(fileName); 


                db.English4.Add(english4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(english4);
        }

        // GET: English4/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English4 english4 = db.English4.Find(id);
            if (english4 == null)
            {
                return HttpNotFound();
            }
            return View(english4);
        }

        // POST: English4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "English4Id,English4title,English4Descr,English4Doc,English4Image,English4Teacher,English4TeacherImg,ImageFile")] English4 english4)
        {
            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(english4.ImageFile.FileName);
                string extension = Path.GetExtension(english4.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                english4.English4Image = "~/Content/Subject Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Subject Images/"), fileName);
                english4.ImageFile.SaveAs(fileName);


                db.Entry(english4).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(english4);
        }

        // GET: English4/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            English4 english4 = db.English4.Find(id);
            if (english4 == null)
            {
                return HttpNotFound();
            }
            return View(english4);
        }

        // POST: English4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            English4 english4 = db.English4.Find(id);
            db.English4.Remove(english4);
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
