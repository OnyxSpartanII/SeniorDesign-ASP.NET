using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeniorDesignWebApp.Models;

namespace SeniorDesignWebApp.Controllers
{
    public class MotionController : Controller
    {
        private MotionDbContext db = new MotionDbContext();

        // GET: Motion
        public ActionResult Index()
        {
            return View(db.Motions.ToList());
        }

        // GET: Motion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotionModel motionModel = db.Motions.Find(id);
            if (motionModel == null)
            {
                return HttpNotFound();
            }
            return View(motionModel);
        }

        // GET: Motion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Motion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CaseId,Type,Date")] MotionModel motionModel)
        {
            if (ModelState.IsValid)
            {
                db.Motions.Add(motionModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motionModel);
        }

        // GET: Motion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotionModel motionModel = db.Motions.Find(id);
            if (motionModel == null)
            {
                return HttpNotFound();
            }
            return View(motionModel);
        }

        // POST: Motion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CaseId,Type,Date")] MotionModel motionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motionModel);
        }

        // GET: Motion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotionModel motionModel = db.Motions.Find(id);
            if (motionModel == null)
            {
                return HttpNotFound();
            }
            return View(motionModel);
        }

        // POST: Motion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MotionModel motionModel = db.Motions.Find(id);
            db.Motions.Remove(motionModel);
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
