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
    public class MotionsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Motions
        public ActionResult Index()
        {
            return View(db.motions.ToList());
        }

        // GET: Motions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            motion motion = db.motions.Find(id);
            if (motion == null)
            {
                return HttpNotFound();
            }
            return View(motion);
        }

        // GET: Motions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotionId,Type,Date")] motion motion)
        {
            if (ModelState.IsValid)
            {
                db.motions.Add(motion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motion);
        }

        // GET: Motions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            motion motion = db.motions.Find(id);
            if (motion == null)
            {
                return HttpNotFound();
            }
            return View(motion);
        }

        // POST: Motions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotionId,Type,Date")] motion motion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motion);
        }

        // GET: Motions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            motion motion = db.motions.Find(id);
            if (motion == null)
            {
                return HttpNotFound();
            }
            return View(motion);
        }

        // POST: Motions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            motion motion = db.motions.Find(id);
            db.motions.Remove(motion);
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
