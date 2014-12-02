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
    public class bailsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: bails
        public ActionResult Index()
        {
            return View(db.bails.ToList());
        }

        // GET: bails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bail bail = db.bails.Find(id);
            if (bail == null)
            {
                return HttpNotFound();
            }
            return View(bail);
        }

        // GET: bails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BailId,Type,Detained,Amount")] bail bail)
        {
            if (ModelState.IsValid)
            {
                db.bails.Add(bail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bail);
        }

        // GET: bails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bail bail = db.bails.Find(id);
            if (bail == null)
            {
                return HttpNotFound();
            }
            return View(bail);
        }

        // POST: bails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BailId,Type,Detained,Amount")] bail bail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bail);
        }

        // GET: bails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bail bail = db.bails.Find(id);
            if (bail == null)
            {
                return HttpNotFound();
            }
            return View(bail);
        }

        // POST: bails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            bail bail = db.bails.Find(id);
            db.bails.Remove(bail);
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
