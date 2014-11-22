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
    public class DefenseController : Controller
    {
        private DefenseDbContext db = new DefenseDbContext();

        // GET: Defense
        public ActionResult Index()
        {
            return View(db.Defenses.ToList());
        }

        // GET: Defense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefenseModel defenseModel = db.Defenses.Find(id);
            if (defenseModel == null)
            {
                return HttpNotFound();
            }
            return View(defenseModel);
        }

        // GET: Defense/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Defense/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Career,Counsel")] DefenseModel defenseModel)
        {
            if (ModelState.IsValid)
            {
                db.Defenses.Add(defenseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defenseModel);
        }

        // GET: Defense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefenseModel defenseModel = db.Defenses.Find(id);
            if (defenseModel == null)
            {
                return HttpNotFound();
            }
            return View(defenseModel);
        }

        // POST: Defense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Career,Counsel")] DefenseModel defenseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defenseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defenseModel);
        }

        // GET: Defense/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefenseModel defenseModel = db.Defenses.Find(id);
            if (defenseModel == null)
            {
                return HttpNotFound();
            }
            return View(defenseModel);
        }

        // POST: Defense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefenseModel defenseModel = db.Defenses.Find(id);
            db.Defenses.Remove(defenseModel);
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
