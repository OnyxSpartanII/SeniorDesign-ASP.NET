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
    public class SentencesController : Controller
    {
        private judgefrogEntities db = new judgefrogEntities();

        // GET: Sentences
        public ActionResult Index()
        {
            return View(db.sentences.ToList());
        }

        // GET: Sentences/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sentence sentence = db.sentences.Find(id);
            if (sentence == null)
            {
                return HttpNotFound();
            }
            return View(sentence);
        }

        // GET: Sentences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sentences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SentenceId,DispositionDate,SentenceDate,JailTime,ProbationTime,SuspendedTime,Fines,CommServ,COR,CCD_Id")] sentence sentence)
        {
            if (ModelState.IsValid)
            {
                db.sentences.Add(sentence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sentence);
        }

        // GET: Sentences/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sentence sentence = db.sentences.Find(id);
            if (sentence == null)
            {
                return HttpNotFound();
            }
            return View(sentence);
        }

        // POST: Sentences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SentenceId,DispositionDate,SentenceDate,JailTime,ProbationTime,SuspendedTime,Fines,CommServ,COR,CCD_Id")] sentence sentence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sentence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sentence);
        }

        // GET: Sentences/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sentence sentence = db.sentences.Find(id);
            if (sentence == null)
            {
                return HttpNotFound();
            }
            return View(sentence);
        }

        // POST: Sentences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            sentence sentence = db.sentences.Find(id);
            db.sentences.Remove(sentence);
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
