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
    public class EngTehWorkersController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: EngTehWorkers
        public ActionResult Index()
        {
            var engTehWorkers = db.EngTehWorkers.Include(e => e.Area);
            return View(engTehWorkers.ToList());
        }

        // GET: EngTehWorkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehWorker engTehWorker = db.EngTehWorkers.Find(id);
            if (engTehWorker == null)
            {
                return HttpNotFound();
            }
            return View(engTehWorker);
        }

        // GET: EngTehWorkers/Create
        public ActionResult Create()
        {
            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea");
            return View();
        }

        // POST: EngTehWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEngTehWorker,EngTehWorkerName,AreaId,IsHead,IsMaster,UnderHeadId")] EngTehWorker engTehWorker)
        {
            if (ModelState.IsValid)
            {
                db.EngTehWorkers.Add(engTehWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea", engTehWorker.AreaId);
            return View(engTehWorker);
        }

        // GET: EngTehWorkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehWorker engTehWorker = db.EngTehWorkers.Find(id);
            if (engTehWorker == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea", engTehWorker.AreaId);
            return View(engTehWorker);
        }

        // POST: EngTehWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEngTehWorker,EngTehWorkerName,AreaId,IsHead,IsMaster,UnderHeadId")] EngTehWorker engTehWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engTehWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaId = new SelectList(db.Areas, "IdArea", "IdArea", engTehWorker.AreaId);
            return View(engTehWorker);
        }

        // GET: EngTehWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehWorker engTehWorker = db.EngTehWorkers.Find(id);
            if (engTehWorker == null)
            {
                return HttpNotFound();
            }
            return View(engTehWorker);
        }

        // POST: EngTehWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EngTehWorker engTehWorker = db.EngTehWorkers.Find(id);
            db.EngTehWorkers.Remove(engTehWorker);
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
