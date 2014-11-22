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
    public class HearingController : Controller
    {
        private HearingDbContext db = new HearingDbContext();

        // GET: Hearing
        public ActionResult Index()
        {
            return View(db.Hearings.ToList());
        }

        // GET: Hearing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingModel hearingModel = db.Hearings.Find(id);
            if (hearingModel == null)
            {
                return HttpNotFound();
            }
            return View(hearingModel);
        }

        // GET: Hearing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hearing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CaseId,Type,Date")] HearingModel hearingModel)
        {
            if (ModelState.IsValid)
            {
                db.Hearings.Add(hearingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hearingModel);
        }

        // GET: Hearing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingModel hearingModel = db.Hearings.Find(id);
            if (hearingModel == null)
            {
                return HttpNotFound();
            }
            return View(hearingModel);
        }

        // POST: Hearing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CaseId,Type,Date")] HearingModel hearingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hearingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hearingModel);
        }

        // GET: Hearing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HearingModel hearingModel = db.Hearings.Find(id);
            if (hearingModel == null)
            {
                return HttpNotFound();
            }
            return View(hearingModel);
        }

        // POST: Hearing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HearingModel hearingModel = db.Hearings.Find(id);
            db.Hearings.Remove(hearingModel);
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
