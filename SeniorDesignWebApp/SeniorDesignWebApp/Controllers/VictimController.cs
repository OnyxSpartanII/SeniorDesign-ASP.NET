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
    public class VictimController : Controller
    {
        private VictimDbContext db = new VictimDbContext();

        // GET: Victim
        public ActionResult Index()
        {
            return View(db.Victims.ToList());
        }

        // GET: Victim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimModel victimModel = db.Victims.Find(id);
            if (victimModel == null)
            {
                return HttpNotFound();
            }
            return View(victimModel);
        }

        // GET: Victim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Victim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Total,Minors,Foreigners,Females")] VictimModel victimModel)
        {
            if (ModelState.IsValid)
            {
                db.Victims.Add(victimModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victimModel);
        }

        // GET: Victim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimModel victimModel = db.Victims.Find(id);
            if (victimModel == null)
            {
                return HttpNotFound();
            }
            return View(victimModel);
        }

        // POST: Victim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Total,Minors,Foreigners,Females")] VictimModel victimModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victimModel);
        }

        // GET: Victim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimModel victimModel = db.Victims.Find(id);
            if (victimModel == null)
            {
                return HttpNotFound();
            }
            return View(victimModel);
        }

        // POST: Victim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VictimModel victimModel = db.Victims.Find(id);
            db.Victims.Remove(victimModel);
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
