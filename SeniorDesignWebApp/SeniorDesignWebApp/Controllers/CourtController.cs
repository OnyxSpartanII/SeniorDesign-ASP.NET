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
    public class CourtController : Controller
    {
        private CourtDbContext db = new CourtDbContext();

        // GET: Court
        public ActionResult Index()
        {
            return View(db.Courts.ToList());
        }

        // GET: Court/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtModel courtModel = db.Courts.Find(id);
            if (courtModel == null)
            {
                return HttpNotFound();
            }
            return View(courtModel);
        }

        // GET: Court/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Court/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Type,State,Country")] CourtModel courtModel)
        {
            if (ModelState.IsValid)
            {
                db.Courts.Add(courtModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courtModel);
        }

        // GET: Court/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtModel courtModel = db.Courts.Find(id);
            if (courtModel == null)
            {
                return HttpNotFound();
            }
            return View(courtModel);
        }

        // POST: Court/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,State,Country")] CourtModel courtModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtModel);
        }

        // GET: Court/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtModel courtModel = db.Courts.Find(id);
            if (courtModel == null)
            {
                return HttpNotFound();
            }
            return View(courtModel);
        }

        // POST: Court/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtModel courtModel = db.Courts.Find(id);
            db.Courts.Remove(courtModel);
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
