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
    public class ChargeController : Controller
    {
        private ChargeDbContext db = new ChargeDbContext();

        // GET: Charge
        public ActionResult Index()
        {
            return View(db.Charges.ToList());
        }

        // GET: Charge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeModel chargeModel = db.Charges.Find(id);
            if (chargeModel == null)
            {
                return HttpNotFound();
            }
            return View(chargeModel);
        }

        // GET: Charge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Charge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ACD_Id,Counts,Statute,Details,Plea,Disposition,Sentence,Suspension,Probation")] ChargeModel chargeModel)
        {
            if (ModelState.IsValid)
            {
                db.Charges.Add(chargeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chargeModel);
        }

        // GET: Charge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeModel chargeModel = db.Charges.Find(id);
            if (chargeModel == null)
            {
                return HttpNotFound();
            }
            return View(chargeModel);
        }

        // POST: Charge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ACD_Id,Counts,Statute,Details,Plea,Disposition,Sentence,Suspension,Probation")] ChargeModel chargeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chargeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chargeModel);
        }

        // GET: Charge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChargeModel chargeModel = db.Charges.Find(id);
            if (chargeModel == null)
            {
                return HttpNotFound();
            }
            return View(chargeModel);
        }

        // POST: Charge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChargeModel chargeModel = db.Charges.Find(id);
            db.Charges.Remove(chargeModel);
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
