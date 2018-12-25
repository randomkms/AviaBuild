using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AviaBuildWeb.Models;

namespace AviaBuildWeb.Controllers
{
    public class RocketsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: Rockets
        public ActionResult Index()
        {
            var rockets = db.Rockets.Include(r => r.Product);
            return View(rockets.ToList());
        }

        // GET: Rockets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rocket rocket = db.Rockets.Find(id);
            if (rocket == null)
            {
                return HttpNotFound();
            }
            return View(rocket);
        }

        // GET: Rockets/Create
        public ActionResult Create()
        {
            ViewBag.RocketProductID = new SelectList(db.Products, "IdProduct", "Category");
            return View();
        }

        // POST: Rockets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRocket,RocketName,RocketType,RocketProductID")] Rocket rocket)
        {
            if (ModelState.IsValid)
            {
                db.Rockets.Add(rocket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RocketProductID = new SelectList(db.Products, "IdProduct", "Category", rocket.RocketProductID);
            return View(rocket);
        }

        // GET: Rockets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rocket rocket = db.Rockets.Find(id);
            if (rocket == null)
            {
                return HttpNotFound();
            }
            ViewBag.RocketProductID = new SelectList(db.Products, "IdProduct", "Category", rocket.RocketProductID);
            return View(rocket);
        }

        // POST: Rockets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRocket,RocketName,RocketType,RocketProductID")] Rocket rocket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rocket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RocketProductID = new SelectList(db.Products, "IdProduct", "Category", rocket.RocketProductID);
            return View(rocket);
        }

        // GET: Rockets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rocket rocket = db.Rockets.Find(id);
            if (rocket == null)
            {
                return HttpNotFound();
            }
            return View(rocket);
        }

        // POST: Rockets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rocket rocket = db.Rockets.Find(id);
            db.Rockets.Remove(rocket);
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
