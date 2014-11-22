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
    public class CaseController : Controller
    {
        private CaseDbContext db = new CaseDbContext();

        // GET: Case
        public ActionResult Index()
        {
            return View(db.Cases.ToList());
        }

        // GET: Case/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseModel caseModel = db.Cases.Find(id);
            if (caseModel == null)
            {
                return HttpNotFound();
            }
            return View(caseModel);
        }

        // GET: Case/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Case/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Number,Status,Summary,GrandJury,CourtId,DefenseId,VictimsId,ADCId,SentenceId")] CaseModel caseModel)
        {
            if (ModelState.IsValid)
            {
                db.Cases.Add(caseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caseModel);
        }

        // GET: Case/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseModel caseModel = db.Cases.Find(id);
            if (caseModel == null)
            {
                return HttpNotFound();
            }
            return View(caseModel);
        }

        // POST: Case/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Number,Status,Summary,GrandJury,CourtId,DefenseId,VictimsId,ADCId,SentenceId")] CaseModel caseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caseModel);
        }

        // GET: Case/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseModel caseModel = db.Cases.Find(id);
            if (caseModel == null)
            {
                return HttpNotFound();
            }
            return View(caseModel);
        }

        // POST: Case/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaseModel caseModel = db.Cases.Find(id);
            db.Cases.Remove(caseModel);
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
