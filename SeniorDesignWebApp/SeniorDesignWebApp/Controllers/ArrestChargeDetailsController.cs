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
    public class ArrestChargeDetailsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: ArrestChargeDetails
        public ActionResult Index()
        {
            return View(db.arrestchargedetails.ToList());
        }

        // GET: ArrestChargeDetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arrestchargedetail arrestchargedetail = db.arrestchargedetails.Find(id);
            if (arrestchargedetail == null)
            {
                return HttpNotFound();
            }
            return View(arrestchargedetail);
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
        public ActionResult Create([Bind(Include = "ACDId,ChargeDate,ArrestDate,Detained,Role,LaborTraf,AdultSexTraf,MinorSexTraf,Fel_C,Fel_S")] arrestchargedetail arrestchargedetail)
        {
            if (ModelState.IsValid)
            {
                db.arrestchargedetails.Add(arrestchargedetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arrestchargedetail);
        }

        // GET: ArrestChargeDetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arrestchargedetail arrestchargedetail = db.arrestchargedetails.Find(id);
            if (arrestchargedetail == null)
            {
                return HttpNotFound();
            }
            return View(arrestchargedetail);
        }

        // POST: ArrestChargeDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACDId,ChargeDate,ArrestDate,Detained,Role,LaborTraf,AdultSexTraf,MinorSexTraf,Fel_C,Fel_S")] arrestchargedetail arrestchargedetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrestchargedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arrestchargedetail);
        }

        // GET: ArrestChargeDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            arrestchargedetail arrestchargedetail = db.arrestchargedetails.Find(id);
            if (arrestchargedetail == null)
            {
                return HttpNotFound();
            }
            return View(arrestchargedetail);
        }

        // POST: ArrestChargeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            arrestchargedetail arrestchargedetail = db.arrestchargedetails.Find(id);
            db.arrestchargedetails.Remove(arrestchargedetail);
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
