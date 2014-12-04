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
    public class ChargesController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Charges
        public ActionResult Index()
        {
            var charges = db.charges.Include(c => c.arrestchargedetail);
            return View(charges.ToList());
        }

        // GET: Charges/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charge charge = db.charges.Find(id);
            if (charge == null)
            {
                return HttpNotFound();
            }
            return View(charge);
        }

        // GET: Charges/Create
        public ActionResult Create()
        {
            ViewBag.ArrestChargeDetails_Id = new SelectList(db.arrestchargedetails, "ACDId", "ACDId");
            return View();
        }

        // POST: Charges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChargeId,Type,ArrestChargeDetails_Id,Counts,Statute,Details,Plea,Disposition")] charge charge)
        {
            if (ModelState.IsValid)
            {
                db.charges.Add(charge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArrestChargeDetails_Id = new SelectList(db.arrestchargedetails, "ACDId", "ACDId", charge.ArrestChargeDetails_Id);
            return View(charge);
        }

        // GET: Charges/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charge charge = db.charges.Find(id);
            if (charge == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArrestChargeDetails_Id = new SelectList(db.arrestchargedetails, "ACDId", "ACDId", charge.ArrestChargeDetails_Id);
            return View(charge);
        }

        // POST: Charges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChargeId,Type,ArrestChargeDetails_Id,Counts,Statute,Details,Plea,Disposition")] charge charge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArrestChargeDetails_Id = new SelectList(db.arrestchargedetails, "ACDId", "ACDId", charge.ArrestChargeDetails_Id);
            return View(charge);
        }

        // GET: Charges/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charge charge = db.charges.Find(id);
            if (charge == null)
            {
                return HttpNotFound();
            }
            return View(charge);
        }

        // POST: Charges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            charge charge = db.charges.Find(id);
            db.charges.Remove(charge);
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
