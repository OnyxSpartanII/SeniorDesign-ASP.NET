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
    public class SentenceController : Controller
    {
        private SentenceDbContext db = new SentenceDbContext();

        // GET: Sentence
        public ActionResult Index()
        {
            return View(db.Sentences.ToList());
        }

        // GET: Sentence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentenceModel sentenceModel = db.Sentences.Find(id);
            if (sentenceModel == null)
            {
                return HttpNotFound();
            }
            return View(sentenceModel);
        }

        // GET: Sentence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sentence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DispositionDate,SentenceDate,JailTime,ProbationTime,SuspensionTime,Fines,CommunityService,ConditionsOfRelease")] SentenceModel sentenceModel)
        {
            if (ModelState.IsValid)
            {
                db.Sentences.Add(sentenceModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sentenceModel);
        }

        // GET: Sentence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentenceModel sentenceModel = db.Sentences.Find(id);
            if (sentenceModel == null)
            {
                return HttpNotFound();
            }
            return View(sentenceModel);
        }

        // POST: Sentence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DispositionDate,SentenceDate,JailTime,ProbationTime,SuspensionTime,Fines,CommunityService,ConditionsOfRelease")] SentenceModel sentenceModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sentenceModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sentenceModel);
        }

        // GET: Sentence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SentenceModel sentenceModel = db.Sentences.Find(id);
            if (sentenceModel == null)
            {
                return HttpNotFound();
            }
            return View(sentenceModel);
        }

        // POST: Sentence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SentenceModel sentenceModel = db.Sentences.Find(id);
            db.Sentences.Remove(sentenceModel);
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
