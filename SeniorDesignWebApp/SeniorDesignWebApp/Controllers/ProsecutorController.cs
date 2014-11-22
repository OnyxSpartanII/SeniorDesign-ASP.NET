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
    public class ProsecutorController : Controller
    {
        private ProsecutorDbContext db = new ProsecutorDbContext();

        // GET: Prosecutor
        public ActionResult Index()
        {
            return View(db.Prosecutors.ToList());
        }

        // GET: Prosecutor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsecutorModel prosecutorModel = db.Prosecutors.Find(id);
            if (prosecutorModel == null)
            {
                return HttpNotFound();
            }
            return View(prosecutorModel);
        }

        // GET: Prosecutor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prosecutor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Career")] ProsecutorModel prosecutorModel)
        {
            if (ModelState.IsValid)
            {
                db.Prosecutors.Add(prosecutorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prosecutorModel);
        }

        // GET: Prosecutor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsecutorModel prosecutorModel = db.Prosecutors.Find(id);
            if (prosecutorModel == null)
            {
                return HttpNotFound();
            }
            return View(prosecutorModel);
        }

        // POST: Prosecutor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Career")] ProsecutorModel prosecutorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prosecutorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prosecutorModel);
        }

        // GET: Prosecutor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProsecutorModel prosecutorModel = db.Prosecutors.Find(id);
            if (prosecutorModel == null)
            {
                return HttpNotFound();
            }
            return View(prosecutorModel);
        }

        // POST: Prosecutor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProsecutorModel prosecutorModel = db.Prosecutors.Find(id);
            db.Prosecutors.Remove(prosecutorModel);
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
