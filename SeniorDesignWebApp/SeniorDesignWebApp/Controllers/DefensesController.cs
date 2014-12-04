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
    public class DefensesController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Defenses
        public ActionResult Index()
        {
            return View(db.defenses.ToList());
        }

        // GET: Defenses/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defense defense = db.defenses.Find(id);
            if (defense == null)
            {
                return HttpNotFound();
            }
            return View(defense);
        }

        // GET: Defenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Defenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DefenseId,Name,Gender,Career,Counsel")] defense defense)
        {
            if (ModelState.IsValid)
            {
                db.defenses.Add(defense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defense);
        }

        // GET: Defenses/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defense defense = db.defenses.Find(id);
            if (defense == null)
            {
                return HttpNotFound();
            }
            return View(defense);
        }

        // POST: Defenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DefenseId,Name,Gender,Career,Counsel")] defense defense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defense);
        }

        // GET: Defenses/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defense defense = db.defenses.Find(id);
            if (defense == null)
            {
                return HttpNotFound();
            }
            return View(defense);
        }

        // POST: Defenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            defense defense = db.defenses.Find(id);
            db.defenses.Remove(defense);
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
