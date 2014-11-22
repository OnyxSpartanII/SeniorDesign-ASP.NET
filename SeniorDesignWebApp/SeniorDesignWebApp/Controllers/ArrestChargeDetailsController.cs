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
    public class ArrestChargeDetailsController : Controller
    {
        private ACDDbContext db = new ACDDbContext();

        // GET: ArrestChargeDetails
        public ActionResult Index()
        {
            return View(db.ACDs.ToList());
        }

        // GET: ArrestChargeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrestChargeDetailsModel arrestChargeDetailsModel = db.ACDs.Find(id);
            if (arrestChargeDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(arrestChargeDetailsModel);
        }

        // GET: ArrestChargeDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArrestChargeDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ChargeDate,ArrestDate,Role,LaborTrafficking,MinorSexTrafficking,AdultSexTrafficking,FelonyCounts,MisdemeanorCounts,FelonySentences,MisdemeanorSentences")] ArrestChargeDetailsModel arrestChargeDetailsModel)
        {
            if (ModelState.IsValid)
            {
                db.ACDs.Add(arrestChargeDetailsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arrestChargeDetailsModel);
        }

        // GET: ArrestChargeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrestChargeDetailsModel arrestChargeDetailsModel = db.ACDs.Find(id);
            if (arrestChargeDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(arrestChargeDetailsModel);
        }

        // POST: ArrestChargeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ChargeDate,ArrestDate,Role,LaborTrafficking,MinorSexTrafficking,AdultSexTrafficking,FelonyCounts,MisdemeanorCounts,FelonySentences,MisdemeanorSentences")] ArrestChargeDetailsModel arrestChargeDetailsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrestChargeDetailsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arrestChargeDetailsModel);
        }

        // GET: ArrestChargeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArrestChargeDetailsModel arrestChargeDetailsModel = db.ACDs.Find(id);
            if (arrestChargeDetailsModel == null)
            {
                return HttpNotFound();
            }
            return View(arrestChargeDetailsModel);
        }

        // POST: ArrestChargeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArrestChargeDetailsModel arrestChargeDetailsModel = db.ACDs.Find(id);
            db.ACDs.Remove(arrestChargeDetailsModel);
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
