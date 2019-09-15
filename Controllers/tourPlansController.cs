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
    public class tourPlansController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: tourPlans
        public ActionResult Index()
        {
            var tourPlan = db.tourPlan.Include(t => t.attraction).Include(t => t.guide).Include(t => t.userPreference);
            return View(tourPlan.ToList());
        }

        // GET: tourPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourPlan tourPlan = db.tourPlan.Find(id);
            if (tourPlan == null)
            {
                return HttpNotFound();
            }
            return View(tourPlan);
        }

        // GET: tourPlans/Create
        public ActionResult Create()
        {
            ViewBag.attractionId = new SelectList(db.attraction, "attractionId", "address");
            ViewBag.guideId = new SelectList(db.guide, "guideId", "guideName");
            ViewBag.preferenceID = new SelectList(db.userPreference, "preferenceID", "attractionName");
            return View();
        }

        // POST: tourPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tourPlanId,attractionDetails,geneateTime,price,calendar,preferenceID,guideId,attractionId")] tourPlan tourPlan)
        {
            if (ModelState.IsValid)
            {
                db.tourPlan.Add(tourPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.attractionId = new SelectList(db.attraction, "attractionId", "address", tourPlan.attractionId);
            ViewBag.guideId = new SelectList(db.guide, "guideId", "guideName", tourPlan.guideId);
            ViewBag.preferenceID = new SelectList(db.userPreference, "preferenceID", "attractionName", tourPlan.preferenceID);
            return View(tourPlan);
        }

        // GET: tourPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourPlan tourPlan = db.tourPlan.Find(id);
            if (tourPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.attractionId = new SelectList(db.attraction, "attractionId", "address", tourPlan.attractionId);
            ViewBag.guideId = new SelectList(db.guide, "guideId", "guideName", tourPlan.guideId);
            ViewBag.preferenceID = new SelectList(db.userPreference, "preferenceID", "attractionName", tourPlan.preferenceID);
            return View(tourPlan);
        }

        // POST: tourPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tourPlanId,attractionDetails,geneateTime,price,calendar,preferenceID,guideId,attractionId")] tourPlan tourPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.attractionId = new SelectList(db.attraction, "attractionId", "address", tourPlan.attractionId);
            ViewBag.guideId = new SelectList(db.guide, "guideId", "guideName", tourPlan.guideId);
            ViewBag.preferenceID = new SelectList(db.userPreference, "preferenceID", "attractionName", tourPlan.preferenceID);
            return View(tourPlan);
        }

        // GET: tourPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourPlan tourPlan = db.tourPlan.Find(id);
            if (tourPlan == null)
            {
                return HttpNotFound();
            }
            return View(tourPlan);
        }

        // POST: tourPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tourPlan tourPlan = db.tourPlan.Find(id);
            db.tourPlan.Remove(tourPlan);
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
