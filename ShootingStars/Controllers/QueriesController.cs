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
    public class QueriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Queries
        public async Task<ActionResult> Index()
        {
            return View(await db.Queries.ToListAsync());
        }

        // GET: Queries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = await db.Queries.FindAsync(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // GET: Queries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Queries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QueryID,Message,QueryTypes")] Query query)
        {
            if (ModelState.IsValid)
            {                
                query.StudentEmail = User.Identity.GetStudentEmail();
                query.DateCreated = DateTime.Now;
                db.Queries.Add(query);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Manage");
            }
            return View(query);
        }

        // GET: Queries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = await db.Queries.FindAsync(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: Queries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QueryID,StudentEmail,Message,QueryTypes,Response,DateCreated,CompletionStatus")] Query query)
        {
            query.StudentEmail = query.StudentEmail;
            query.Message = query.Message;
            query.DateCreated = query.DateCreated;
            query.QueryTypes = query.QueryTypes;
            if (ModelState.IsValid)
            {
                db.Entry(query).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(query);
        }

        // GET: Queries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = await db.Queries.FindAsync(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // GET: Queries/Details/5
        public async Task<ActionResult> Success(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Query query = await db.Queries.FindAsync(id);
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query);
        }

        // POST: Queries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Query query = await db.Queries.FindAsync(id);
            db.Queries.Remove(query);
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
