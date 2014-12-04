using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeniorDesignWebApp;

namespace SeniorDesignWebApp.Controllers
{
    public class ProsecutorsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Prosecutors
        public ActionResult Index()
        {
            return View(db.prosecutors.ToList());
        }

        // GET: Prosecutors/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prosecutor prosecutor = db.prosecutors.Find(id);
            if (prosecutor == null)
            {
                return HttpNotFound();
            }
            return View(prosecutor);
        }

        // GET: Prosecutors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prosecutors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProsecutorId,Name,Gender,Career")] prosecutor prosecutor)
        {
            if (ModelState.IsValid)
            {
                db.prosecutors.Add(prosecutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prosecutor);
        }

        // GET: Prosecutors/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prosecutor prosecutor = db.prosecutors.Find(id);
            if (prosecutor == null)
            {
                return HttpNotFound();
            }
            return View(prosecutor);
        }

        // POST: Prosecutors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProsecutorId,Name,Gender,Career")] prosecutor prosecutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prosecutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prosecutor);
        }

        // GET: Prosecutors/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prosecutor prosecutor = db.prosecutors.Find(id);
            if (prosecutor == null)
            {
                return HttpNotFound();
            }
            return View(prosecutor);
        }

        // POST: Prosecutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            prosecutor prosecutor = db.prosecutors.Find(id);
            db.prosecutors.Remove(prosecutor);
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
