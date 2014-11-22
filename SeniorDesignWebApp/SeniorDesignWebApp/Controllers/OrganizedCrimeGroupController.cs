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
    public class OrganizedCrimeGroupController : Controller
    {
        private OCGDbContext db = new OCGDbContext();

        // GET: OrganizedCrimeGroup
        public ActionResult Index()
        {
            return View(db.OCGs.ToList());
        }

        // GET: OrganizedCrimeGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizedCrimeGroupModel organizedCrimeGroupModel = db.OCGs.Find(id);
            if (organizedCrimeGroupModel == null)
            {
                return HttpNotFound();
            }
            return View(organizedCrimeGroupModel);
        }

        // GET: OrganizedCrimeGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizedCrimeGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Size,Race,Scope")] OrganizedCrimeGroupModel organizedCrimeGroupModel)
        {
            if (ModelState.IsValid)
            {
                db.OCGs.Add(organizedCrimeGroupModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizedCrimeGroupModel);
        }

        // GET: OrganizedCrimeGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizedCrimeGroupModel organizedCrimeGroupModel = db.OCGs.Find(id);
            if (organizedCrimeGroupModel == null)
            {
                return HttpNotFound();
            }
            return View(organizedCrimeGroupModel);
        }

        // POST: OrganizedCrimeGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Size,Race,Scope")] OrganizedCrimeGroupModel organizedCrimeGroupModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizedCrimeGroupModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizedCrimeGroupModel);
        }

        // GET: OrganizedCrimeGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizedCrimeGroupModel organizedCrimeGroupModel = db.OCGs.Find(id);
            if (organizedCrimeGroupModel == null)
            {
                return HttpNotFound();
            }
            return View(organizedCrimeGroupModel);
        }

        // POST: OrganizedCrimeGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganizedCrimeGroupModel organizedCrimeGroupModel = db.OCGs.Find(id);
            db.OCGs.Remove(organizedCrimeGroupModel);
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
