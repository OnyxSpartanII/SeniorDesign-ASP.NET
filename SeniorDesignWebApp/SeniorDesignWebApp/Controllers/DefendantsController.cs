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
    public class DefendantsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Defendants
        public ActionResult Index()
        {
            return View(db.defendants.ToList());
        }

        // GET: Defendants/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defendant defendant = db.defendants.Find(id);
            if (defendant == null)
            {
                return HttpNotFound();
            }
            return View(defendant);
        }

        // GET: Defendants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Defendants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DefendantId,Firstname,Lastname,Gender,Age,Race")] defendant defendant)
        {
            if (ModelState.IsValid)
            {
                db.defendants.Add(defendant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defendant);
        }

        // GET: Defendants/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defendant defendant = db.defendants.Find(id);
            if (defendant == null)
            {
                return HttpNotFound();
            }
            return View(defendant);
        }

        // POST: Defendants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DefendantId,Firstname,Lastname,Gender,Age,Race")] defendant defendant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defendant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defendant);
        }

        // GET: Defendants/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defendant defendant = db.defendants.Find(id);
            if (defendant == null)
            {
                return HttpNotFound();
            }
            return View(defendant);
        }

        // POST: Defendants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            defendant defendant = db.defendants.Find(id);
            db.defendants.Remove(defendant);
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
