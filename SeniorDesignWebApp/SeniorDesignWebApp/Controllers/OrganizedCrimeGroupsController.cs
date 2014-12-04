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
    public class OrganizedCrimeGroupsController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: OrganizedCrimeGroups
        public ActionResult Index()
        {
            return View(db.organizedcrimegroups.ToList());
        }

        // GET: OrganizedCrimeGroups/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            organizedcrimegroup organizedcrimegroup = db.organizedcrimegroups.Find(id);
            if (organizedcrimegroup == null)
            {
                return HttpNotFound();
            }
            return View(organizedcrimegroup);
        }

        // GET: OrganizedCrimeGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizedCrimeGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OCGId,Name,Size,Scope,Race")] organizedcrimegroup organizedcrimegroup)
        {
            if (ModelState.IsValid)
            {
                db.organizedcrimegroups.Add(organizedcrimegroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizedcrimegroup);
        }

        // GET: OrganizedCrimeGroups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            organizedcrimegroup organizedcrimegroup = db.organizedcrimegroups.Find(id);
            if (organizedcrimegroup == null)
            {
                return HttpNotFound();
            }
            return View(organizedcrimegroup);
        }

        // POST: OrganizedCrimeGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OCGId,Name,Size,Scope,Race")] organizedcrimegroup organizedcrimegroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizedcrimegroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizedcrimegroup);
        }

        // GET: OrganizedCrimeGroups/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            organizedcrimegroup organizedcrimegroup = db.organizedcrimegroups.Find(id);
            if (organizedcrimegroup == null)
            {
                return HttpNotFound();
            }
            return View(organizedcrimegroup);
        }

        // POST: OrganizedCrimeGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            organizedcrimegroup organizedcrimegroup = db.organizedcrimegroups.Find(id);
            db.organizedcrimegroups.Remove(organizedcrimegroup);
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
