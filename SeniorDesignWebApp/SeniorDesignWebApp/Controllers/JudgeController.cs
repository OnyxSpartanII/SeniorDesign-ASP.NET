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
    public class JudgeController : Controller
    {
        private JudgeDbContext db = new JudgeDbContext();

        // GET: Judge
        public ActionResult Index()
        {
            return View(db.Judges.ToList());
        }

        // GET: Judge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeModel judgeModel = db.Judges.Find(id);
            if (judgeModel == null)
            {
                return HttpNotFound();
            }
            return View(judgeModel);
        }

        // GET: Judge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Judge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Career,Race")] JudgeModel judgeModel)
        {
            if (ModelState.IsValid)
            {
                db.Judges.Add(judgeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(judgeModel);
        }

        // GET: Judge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeModel judgeModel = db.Judges.Find(id);
            if (judgeModel == null)
            {
                return HttpNotFound();
            }
            return View(judgeModel);
        }

        // POST: Judge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Career,Race")] JudgeModel judgeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(judgeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(judgeModel);
        }

        // GET: Judge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JudgeModel judgeModel = db.Judges.Find(id);
            if (judgeModel == null)
            {
                return HttpNotFound();
            }
            return View(judgeModel);
        }

        // POST: Judge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JudgeModel judgeModel = db.Judges.Find(id);
            db.Judges.Remove(judgeModel);
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
