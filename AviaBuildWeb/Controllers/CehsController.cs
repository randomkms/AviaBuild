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
    public class CehsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: Cehs
        public ActionResult Index()
        {
            return View(db.Cehs.ToList());
        }

        // GET: Cehs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ceh ceh = db.Cehs.Find(id);
            if (ceh == null)
            {
                return HttpNotFound();
            }
            return View(ceh);
        }

        // GET: Cehs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cehs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCeh")] Ceh ceh)
        {
            if (ModelState.IsValid)
            {
                db.Cehs.Add(ceh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ceh);
        }

        // GET: Cehs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ceh ceh = db.Cehs.Find(id);
            if (ceh == null)
            {
                return HttpNotFound();
            }
            return View(ceh);
        }

        // POST: Cehs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCeh")] Ceh ceh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ceh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ceh);
        }

        // GET: Cehs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ceh ceh = db.Cehs.Find(id);
            if (ceh == null)
            {
                return HttpNotFound();
            }
            return View(ceh);
        }

        // POST: Cehs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ceh ceh = db.Cehs.Find(id);
            db.Cehs.Remove(ceh);
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
