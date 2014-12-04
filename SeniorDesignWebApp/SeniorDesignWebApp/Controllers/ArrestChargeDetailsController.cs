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
    public class arrestchargedetailsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: arrestchargedetails
        public ActionResult Index()
        {
            var arrestchargedetails = db.arrestchargedetails.Include(a => a.bail);
            return View(arrestchargedetails.ToList());
        }

        // GET: arrestchargedetails/Details/5
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

        // GET: arrestchargedetails/Create
        public ActionResult Create()
        {
            ViewBag.BailId = new SelectList(db.bails, "BailId", "BailId");
            return View();
        }

        // POST: arrestchargedetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ACDId,ChargeDate,ArrestDate,BailId,Role")] arrestchargedetail arrestchargedetail)
        {
            if (ModelState.IsValid)
            {
                db.arrestchargedetails.Add(arrestchargedetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BailId = new SelectList(db.bails, "BailId", "BailId", arrestchargedetail.BailId);
            return View(arrestchargedetail);
        }

        // GET: arrestchargedetails/Edit/5
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
            ViewBag.BailId = new SelectList(db.bails, "BailId", "BailId", arrestchargedetail.BailId);
            return View(arrestchargedetail);
        }

        // POST: arrestchargedetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACDId,ChargeDate,ArrestDate,BailId,Role")] arrestchargedetail arrestchargedetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arrestchargedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BailId = new SelectList(db.bails, "BailId", "BailId", arrestchargedetail.BailId);
            return View(arrestchargedetail);
        }

        // GET: arrestchargedetails/Delete/5
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

        // POST: arrestchargedetails/Delete/5
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
