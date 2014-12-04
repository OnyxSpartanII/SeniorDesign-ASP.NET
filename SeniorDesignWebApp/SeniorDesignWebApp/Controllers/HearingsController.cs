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
    public class HearingsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Hearings
        public ActionResult Index()
        {
            return View(db.hearings.ToList());
        }

        // GET: Hearings/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hearing hearing = db.hearings.Find(id);
            if (hearing == null)
            {
                return HttpNotFound();
            }
            return View(hearing);
        }

        // GET: Hearings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hearings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HearingId,Type,Date")] hearing hearing)
        {
            if (ModelState.IsValid)
            {
                db.hearings.Add(hearing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hearing);
        }

        // GET: Hearings/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hearing hearing = db.hearings.Find(id);
            if (hearing == null)
            {
                return HttpNotFound();
            }
            return View(hearing);
        }

        // POST: Hearings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HearingId,Type,Date")] hearing hearing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hearing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hearing);
        }

        // GET: Hearings/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hearing hearing = db.hearings.Find(id);
            if (hearing == null)
            {
                return HttpNotFound();
            }
            return View(hearing);
        }

        // POST: Hearings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            hearing hearing = db.hearings.Find(id);
            db.hearings.Remove(hearing);
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
