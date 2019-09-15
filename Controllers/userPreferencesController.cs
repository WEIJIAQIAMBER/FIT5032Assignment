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
    public class userPreferencesController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: userPreferences
        public ActionResult Index()
        {
            return View(db.userPreference.ToList());
        }

        // GET: userPreferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userPreference userPreference = db.userPreference.Find(id);
            if (userPreference == null)
            {
                return HttpNotFound();
            }
            return View(userPreference);
        }

        // GET: userPreferences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userPreferences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "preferenceID,durationDays,attractionName,budget,guideType,generateTime,UID")] userPreference userPreference)
        {
            if (ModelState.IsValid)
            {
                db.userPreference.Add(userPreference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userPreference);
        }

        // GET: userPreferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userPreference userPreference = db.userPreference.Find(id);
            if (userPreference == null)
            {
                return HttpNotFound();
            }
            return View(userPreference);
        }

        // POST: userPreferences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "preferenceID,durationDays,attractionName,budget,guideType,generateTime,UID")] userPreference userPreference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userPreference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userPreference);
        }

        // GET: userPreferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userPreference userPreference = db.userPreference.Find(id);
            if (userPreference == null)
            {
                return HttpNotFound();
            }
            return View(userPreference);
        }

        // POST: userPreferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userPreference userPreference = db.userPreference.Find(id);
            db.userPreference.Remove(userPreference);
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
