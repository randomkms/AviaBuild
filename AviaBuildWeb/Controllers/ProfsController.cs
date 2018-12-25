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
    public class ProfsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: Profs
        public ActionResult Index()
        {
            return View(db.Profs.ToList());
        }

        // GET: Profs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Profs.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        // GET: Profs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProf,ProfName")] Prof prof)
        {
            if (ModelState.IsValid)
            {
                db.Profs.Add(prof);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prof);
        }

        // GET: Profs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Profs.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        // POST: Profs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProf,ProfName")] Prof prof)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prof).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prof);
        }

        // GET: Profs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prof prof = db.Profs.Find(id);
            if (prof == null)
            {
                return HttpNotFound();
            }
            return View(prof);
        }

        // POST: Profs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prof prof = db.Profs.Find(id);
            db.Profs.Remove(prof);
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
