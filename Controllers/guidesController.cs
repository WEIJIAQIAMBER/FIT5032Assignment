using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032Assignment.Models;

namespace FIT5032Assignment.Controllers
{
    public class guidesController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: guides
        public ActionResult Index()
        {
            return View(db.guide.ToList());
        }

        // GET: guides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guide guide = db.guide.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        // GET: guides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: guides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "guideId,guideName,guidetype,registerDate")] guide guide)
        {
            if (ModelState.IsValid)
            {
                db.guide.Add(guide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guide);
        }

        // GET: guides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guide guide = db.guide.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        // POST: guides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "guideId,guideName,guidetype,registerDate")] guide guide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guide);
        }

        // GET: guides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guide guide = db.guide.Find(id);
            if (guide == null)
            {
                return HttpNotFound();
            }
            return View(guide);
        }

        // POST: guides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            guide guide = db.guide.Find(id);
            db.guide.Remove(guide);
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
