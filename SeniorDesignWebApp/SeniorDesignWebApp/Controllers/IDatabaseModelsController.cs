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
    public class IDatabaseModelsController : Controller
    {
        private IDbContext db = new IDbContext();

        // GET: IDatabaseModels
        public ActionResult Index()
        {
            return View(db.IDatabaseModels.ToList());
        }

        // GET: IDatabaseModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDatabaseModel iDatabaseModel = db.IDatabaseModels.Find(id);
            if (iDatabaseModel == null)
            {
                return HttpNotFound();
            }
            return View(iDatabaseModel);
        }

        // GET: IDatabaseModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IDatabaseModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] IDatabaseModel iDatabaseModel)
        {
            if (ModelState.IsValid)
            {
                db.IDatabaseModels.Add(iDatabaseModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iDatabaseModel);
        }

        // GET: IDatabaseModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDatabaseModel iDatabaseModel = db.IDatabaseModels.Find(id);
            if (iDatabaseModel == null)
            {
                return HttpNotFound();
            }
            return View(iDatabaseModel);
        }

        // POST: IDatabaseModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] IDatabaseModel iDatabaseModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iDatabaseModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iDatabaseModel);
        }

        // GET: IDatabaseModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDatabaseModel iDatabaseModel = db.IDatabaseModels.Find(id);
            if (iDatabaseModel == null)
            {
                return HttpNotFound();
            }
            return View(iDatabaseModel);
        }

        // POST: IDatabaseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IDatabaseModel iDatabaseModel = db.IDatabaseModels.Find(id);
            db.IDatabaseModels.Remove(iDatabaseModel);
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
