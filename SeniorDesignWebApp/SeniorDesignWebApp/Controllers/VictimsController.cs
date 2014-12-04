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
    public class VictimsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Victims
        public ActionResult Index()
        {
            return View(db.victims.ToList());
        }

        // GET: Victims/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            victim victim = db.victims.Find(id);
            if (victim == null)
            {
                return HttpNotFound();
            }
            return View(victim);
        }

        // GET: Victims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Victims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VictimsId,Total,Minor,Foreigner,Female")] victim victim)
        {
            if (ModelState.IsValid)
            {
                db.victims.Add(victim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victim);
        }

        // GET: Victims/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            victim victim = db.victims.Find(id);
            if (victim == null)
            {
                return HttpNotFound();
            }
            return View(victim);
        }

        // POST: Victims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VictimsId,Total,Minor,Foreigner,Female")] victim victim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victim);
        }

        // GET: Victims/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            victim victim = db.victims.Find(id);
            if (victim == null)
            {
                return HttpNotFound();
            }
            return View(victim);
        }

        // POST: Victims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            victim victim = db.victims.Find(id);
            db.victims.Remove(victim);
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
