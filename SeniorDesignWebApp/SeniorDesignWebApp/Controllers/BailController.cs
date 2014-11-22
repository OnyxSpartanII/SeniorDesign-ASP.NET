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
    public class BailController : Controller
    {
        private BailDbContext db = new BailDbContext();

        // GET: Bail
        public ActionResult Index()
        {
            return View(db.Bails.ToList());
        }

        // GET: Bail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BailModel bailModel = db.Bails.Find(id);
            if (bailModel == null)
            {
                return HttpNotFound();
            }
            return View(bailModel);
        }

        // GET: Bail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Detained,Amount,ACD_Id")] BailModel bailModel)
        {
            if (ModelState.IsValid)
            {
                db.Bails.Add(bailModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bailModel);
        }

        // GET: Bail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BailModel bailModel = db.Bails.Find(id);
            if (bailModel == null)
            {
                return HttpNotFound();
            }
            return View(bailModel);
        }

        // POST: Bail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,Detained,Amount,ACD_Id")] BailModel bailModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bailModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bailModel);
        }

        // GET: Bail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BailModel bailModel = db.Bails.Find(id);
            if (bailModel == null)
            {
                return HttpNotFound();
            }
            return View(bailModel);
        }

        // POST: Bail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BailModel bailModel = db.Bails.Find(id);
            db.Bails.Remove(bailModel);
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
