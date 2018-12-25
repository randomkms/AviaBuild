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
    public class WorkerProfsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: WorkerProfs
        public ActionResult Index()
        {
            var workerProfs = db.WorkerProfs.Include(w => w.Prof).Include(w => w.Worker);
            return View(workerProfs.ToList());
        }

        // GET: WorkerProfs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerProf workerProf = db.WorkerProfs.Find(id);
            if (workerProf == null)
            {
                return HttpNotFound();
            }
            return View(workerProf);
        }

        // GET: WorkerProfs/Create
        public ActionResult Create()
        {
            ViewBag.ProfId = new SelectList(db.Profs, "IdProf", "ProfName");
            ViewBag.WorkerId = new SelectList(db.Workers, "IdWorker", "WorkerName");
            return View();
        }

        // POST: WorkerProfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerId,ProfId,StartWorkDate,QuitDate")] WorkerProf workerProf)
        {
            if (ModelState.IsValid)
            {
                db.WorkerProfs.Add(workerProf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfId = new SelectList(db.Profs, "IdProf", "ProfName", workerProf.ProfId);
            ViewBag.WorkerId = new SelectList(db.Workers, "IdWorker", "WorkerName", workerProf.WorkerId);
            return View(workerProf);
        }

        // GET: WorkerProfs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerProf workerProf = db.WorkerProfs.Find(id);
            if (workerProf == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfId = new SelectList(db.Profs, "IdProf", "ProfName", workerProf.ProfId);
            ViewBag.WorkerId = new SelectList(db.Workers, "IdWorker", "WorkerName", workerProf.WorkerId);
            return View(workerProf);
        }

        // POST: WorkerProfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerId,ProfId,StartWorkDate,QuitDate")] WorkerProf workerProf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerProf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfId = new SelectList(db.Profs, "IdProf", "ProfName", workerProf.ProfId);
            ViewBag.WorkerId = new SelectList(db.Workers, "IdWorker", "WorkerName", workerProf.WorkerId);
            return View(workerProf);
        }

        // GET: WorkerProfs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerProf workerProf = db.WorkerProfs.Find(id);
            if (workerProf == null)
            {
                return HttpNotFound();
            }
            return View(workerProf);
        }

        // POST: WorkerProfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerProf workerProf = db.WorkerProfs.Find(id);
            db.WorkerProfs.Remove(workerProf);
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
