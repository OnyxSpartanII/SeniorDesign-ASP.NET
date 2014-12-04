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
    public class CaseTablesController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: CaseTables
        public ActionResult Index()
        {
            var casetables = db.casetables.Include(c => c.arrestchargedetail).Include(c => c.court).Include(c => c.defense).Include(c => c.sentence).Include(c => c.victim);
            return View(casetables.ToList());
        }

        // GET: CaseTables/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            casetable casetable = db.casetables.Find(id);
            if (casetable == null)
            {
                return HttpNotFound();
            }
            return View(casetable);
        }

        // GET: CaseTables/Create
        public ActionResult Create()
        {
            ViewBag.ACDId = new SelectList(db.arrestchargedetails, "ACDId", "ACDId");
            ViewBag.CourtId = new SelectList(db.courts, "CourtId", "Name");
            ViewBag.DefenseId = new SelectList(db.defenses, "DefenseId", "Name");
            ViewBag.SentenceId = new SelectList(db.sentences, "SentenceId", "SentenceId");
            ViewBag.VictimsId = new SelectList(db.victims, "VictimsId", "VictimsId");
            return View();
        }

        // POST: CaseTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseId,Name,Number,Status,Summary,GrandJury,CourtId,DefenseId,VictimsId,ACDId,SentenceId")] casetable casetable)
        {
            if (ModelState.IsValid)
            {
                db.casetables.Add(casetable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ACDId = new SelectList(db.arrestchargedetails, "ACDId", "ACDId", casetable.ACDId);
            ViewBag.CourtId = new SelectList(db.courts, "CourtId", "Name", casetable.CourtId);
            ViewBag.DefenseId = new SelectList(db.defenses, "DefenseId", "Name", casetable.DefenseId);
            ViewBag.SentenceId = new SelectList(db.sentences, "SentenceId", "SentenceId", casetable.SentenceId);
            ViewBag.VictimsId = new SelectList(db.victims, "VictimsId", "VictimsId", casetable.VictimsId);
            return View(casetable);
        }

        // GET: CaseTables/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            casetable casetable = db.casetables.Find(id);
            if (casetable == null)
            {
                return HttpNotFound();
            }
            ViewBag.ACDId = new SelectList(db.arrestchargedetails, "ACDId", "ACDId", casetable.ACDId);
            ViewBag.CourtId = new SelectList(db.courts, "CourtId", "Name", casetable.CourtId);
            ViewBag.DefenseId = new SelectList(db.defenses, "DefenseId", "Name", casetable.DefenseId);
            ViewBag.SentenceId = new SelectList(db.sentences, "SentenceId", "SentenceId", casetable.SentenceId);
            ViewBag.VictimsId = new SelectList(db.victims, "VictimsId", "VictimsId", casetable.VictimsId);
            return View(casetable);
        }

        // POST: CaseTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseId,Name,Number,Status,Summary,GrandJury,CourtId,DefenseId,VictimsId,ACDId,SentenceId")] casetable casetable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casetable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ACDId = new SelectList(db.arrestchargedetails, "ACDId", "ACDId", casetable.ACDId);
            ViewBag.CourtId = new SelectList(db.courts, "CourtId", "Name", casetable.CourtId);
            ViewBag.DefenseId = new SelectList(db.defenses, "DefenseId", "Name", casetable.DefenseId);
            ViewBag.SentenceId = new SelectList(db.sentences, "SentenceId", "SentenceId", casetable.SentenceId);
            ViewBag.VictimsId = new SelectList(db.victims, "VictimsId", "VictimsId", casetable.VictimsId);
            return View(casetable);
        }

        // GET: CaseTables/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            casetable casetable = db.casetables.Find(id);
            if (casetable == null)
            {
                return HttpNotFound();
            }
            return View(casetable);
        }

        // POST: CaseTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            casetable casetable = db.casetables.Find(id);
            db.casetables.Remove(casetable);
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
