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
    public class EngTehWorkerProfsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: EngTehWorkerProfs
        public ActionResult Index()
        {
            var engTehWorkerProfs = db.EngTehWorkerProfs.Include(e => e.EngTehProf).Include(e => e.EngTehWorker);
            return View(engTehWorkerProfs.ToList());
        }

        // GET: EngTehWorkerProfs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehWorkerProf engTehWorkerProf = db.EngTehWorkerProfs.Find(id);
            if (engTehWorkerProf == null)
            {
                return HttpNotFound();
            }
            return View(engTehWorkerProf);
        }

        // GET: EngTehWorkerProfs/Create
        public ActionResult Create()
        {
            ViewBag.EngTehProfId = new SelectList(db.EngTehProfs, "IdEngTehProf", "EngTehProfName");
            ViewBag.EngTehWorkerId = new SelectList(db.EngTehWorkers, "IdEngTehWorker", "EngTehWorkerName");
            return View();
        }

        // POST: EngTehWorkerProfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EngTehWorkerId,EngTehProfId,StartWorkDate,QuitDate")] EngTehWorkerProf engTehWorkerProf)
        {
            if (ModelState.IsValid)
            {
                db.EngTehWorkerProfs.Add(engTehWorkerProf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EngTehProfId = new SelectList(db.EngTehProfs, "IdEngTehProf", "EngTehProfName", engTehWorkerProf.EngTehProfId);
            ViewBag.EngTehWorkerId = new SelectList(db.EngTehWorkers, "IdEngTehWorker", "EngTehWorkerName", engTehWorkerProf.EngTehWorkerId);
            return View(engTehWorkerProf);
        }

        // GET: EngTehWorkerProfs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehWorkerProf engTehWorkerProf = db.EngTehWorkerProfs.Find(id);
            if (engTehWorkerProf == null)
            {
                return HttpNotFound();
            }
            ViewBag.EngTehProfId = new SelectList(db.EngTehProfs, "IdEngTehProf", "EngTehProfName", engTehWorkerProf.EngTehProfId);
            ViewBag.EngTehWorkerId = new SelectList(db.EngTehWorkers, "IdEngTehWorker", "EngTehWorkerName", engTehWorkerProf.EngTehWorkerId);
            return View(engTehWorkerProf);
        }

        // POST: EngTehWorkerProfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EngTehWorkerId,EngTehProfId,StartWorkDate,QuitDate")] EngTehWorkerProf engTehWorkerProf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engTehWorkerProf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EngTehProfId = new SelectList(db.EngTehProfs, "IdEngTehProf", "EngTehProfName", engTehWorkerProf.EngTehProfId);
            ViewBag.EngTehWorkerId = new SelectList(db.EngTehWorkers, "IdEngTehWorker", "EngTehWorkerName", engTehWorkerProf.EngTehWorkerId);
            return View(engTehWorkerProf);
        }

        // GET: EngTehWorkerProfs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehWorkerProf engTehWorkerProf = db.EngTehWorkerProfs.Find(id);
            if (engTehWorkerProf == null)
            {
                return HttpNotFound();
            }
            return View(engTehWorkerProf);
        }

        // POST: EngTehWorkerProfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EngTehWorkerProf engTehWorkerProf = db.EngTehWorkerProfs.Find(id);
            db.EngTehWorkerProfs.Remove(engTehWorkerProf);
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
