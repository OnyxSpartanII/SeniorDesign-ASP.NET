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
    public class JudgesController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Judges
        public ActionResult Index()
        {
            return View(db.judges.ToList());
        }

        // GET: Judges/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            judge judge = db.judges.Find(id);
            if (judge == null)
            {
                return HttpNotFound();
            }
            return View(judge);
        }

        // GET: Judges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Judges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JudgeId,Name,Race,Gender,Career")] judge judge)
        {
            if (ModelState.IsValid)
            {
                db.judges.Add(judge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(judge);
        }

        // GET: Judges/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            judge judge = db.judges.Find(id);
            if (judge == null)
            {
                return HttpNotFound();
            }
            return View(judge);
        }

        // POST: Judges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JudgeId,Name,Race,Gender,Career")] judge judge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(judge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(judge);
        }

        // GET: Judges/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            judge judge = db.judges.Find(id);
            if (judge == null)
            {
                return HttpNotFound();
            }
            return View(judge);
        }

        // POST: Judges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            judge judge = db.judges.Find(id);
            db.judges.Remove(judge);
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
