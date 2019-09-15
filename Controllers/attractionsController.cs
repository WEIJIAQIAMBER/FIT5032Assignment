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
    public class attractionsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: attractions
        public ActionResult Index()
        {
            return View(db.attraction.ToList());
        }

        // GET: attractions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attraction attraction = db.attraction.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }

        // GET: attractions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: attractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "attractionId,address,attractionName")] attraction attraction)
        {
            if (ModelState.IsValid)
            {
                db.attraction.Add(attraction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attraction);
        }

        // GET: attractions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attraction attraction = db.attraction.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }

        // POST: attractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "attractionId,address,attractionName")] attraction attraction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attraction);
        }

        // GET: attractions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            attraction attraction = db.attraction.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }

        // POST: attractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            attraction attraction = db.attraction.Find(id);
            db.attraction.Remove(attraction);
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
