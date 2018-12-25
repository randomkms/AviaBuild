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
    public class EngTehProfsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: EngTehProfs
        public ActionResult Index()
        {
            return View(db.EngTehProfs.ToList());
        }

        // GET: EngTehProfs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehProf engTehProf = db.EngTehProfs.Find(id);
            if (engTehProf == null)
            {
                return HttpNotFound();
            }
            return View(engTehProf);
        }

        // GET: EngTehProfs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EngTehProfs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEngTehProf,EngTehProfName")] EngTehProf engTehProf)
        {
            if (ModelState.IsValid)
            {
                db.EngTehProfs.Add(engTehProf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(engTehProf);
        }

        // GET: EngTehProfs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehProf engTehProf = db.EngTehProfs.Find(id);
            if (engTehProf == null)
            {
                return HttpNotFound();
            }
            return View(engTehProf);
        }

        // POST: EngTehProfs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEngTehProf,EngTehProfName")] EngTehProf engTehProf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engTehProf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engTehProf);
        }

        // GET: EngTehProfs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngTehProf engTehProf = db.EngTehProfs.Find(id);
            if (engTehProf == null)
            {
                return HttpNotFound();
            }
            return View(engTehProf);
        }

        // POST: EngTehProfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EngTehProf engTehProf = db.EngTehProfs.Find(id);
            db.EngTehProfs.Remove(engTehProf);
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
