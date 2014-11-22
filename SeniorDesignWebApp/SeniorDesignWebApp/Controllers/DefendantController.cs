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
    public class DefendantController : Controller
    {
        private DefendantDbContext db = new DefendantDbContext();

        // GET: Defendant
        public ActionResult Index()
        {
            return View(db.Defendants.ToList());
        }

        // GET: Defendant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefendantModel defendantModel = db.Defendants.Find(id);
            if (defendantModel == null)
            {
                return HttpNotFound();
            }
            return View(defendantModel);
        }

        // GET: Defendant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Defendant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,firstname,lastname,age,race")] DefendantModel defendantModel)
        {
            if (ModelState.IsValid)
            {
                db.Defendants.Add(defendantModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defendantModel);
        }

        // GET: Defendant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefendantModel defendantModel = db.Defendants.Find(id);
            if (defendantModel == null)
            {
                return HttpNotFound();
            }
            return View(defendantModel);
        }

        // POST: Defendant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,firstname,lastname,age,race")] DefendantModel defendantModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defendantModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defendantModel);
        }

        // GET: Defendant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefendantModel defendantModel = db.Defendants.Find(id);
            if (defendantModel == null)
            {
                return HttpNotFound();
            }
            return View(defendantModel);
        }

        // POST: Defendant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefendantModel defendantModel = db.Defendants.Find(id);
            db.Defendants.Remove(defendantModel);
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
