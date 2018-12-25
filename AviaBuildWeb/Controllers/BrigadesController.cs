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
    public class BrigadesController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: Brigades
        public ActionResult Index()
        {
            var brigades = db.Brigades.Include(b => b.Area);
            return View(brigades.ToList());
        }

        // GET: Brigades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brigade brigade = db.Brigades.Find(id);
            if (brigade == null)
            {
                return HttpNotFound();
            }
            return View(brigade);
        }

        // GET: Brigades/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea");
            return View();
        }

        // POST: Brigades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBrigade,AreaId")] Brigade brigade)
        {
            if (ModelState.IsValid)
            {
                db.Brigades.Add(brigade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea", brigade.AreaId);
            return View(brigade);
        }

        // GET: Brigades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brigade brigade = db.Brigades.Find(id);
            if (brigade == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea", brigade.AreaId);
            return View(brigade);
        }

        // POST: Brigades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBrigade,AreaId")] Brigade brigade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brigade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea", brigade.AreaId);
            return View(brigade);
        }

        // GET: Brigades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brigade brigade = db.Brigades.Find(id);
            if (brigade == null)
            {
                return HttpNotFound();
            }
            return View(brigade);
        }

        // POST: Brigades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brigade brigade = db.Brigades.Find(id);
            db.Brigades.Remove(brigade);
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
