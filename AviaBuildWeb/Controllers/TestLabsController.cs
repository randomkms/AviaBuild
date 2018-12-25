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
    public class TestLabsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: TestLabs
        public ActionResult Index()
        {
            return View(db.TestLabs.ToList());
        }

        // GET: TestLabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestLab testLab = db.TestLabs.Find(id);
            if (testLab == null)
            {
                return HttpNotFound();
            }
            return View(testLab);
        }

        // GET: TestLabs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestLabs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTestLab,TestLabName")] TestLab testLab)
        {
            if (ModelState.IsValid)
            {
                db.TestLabs.Add(testLab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testLab);
        }

        // GET: TestLabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestLab testLab = db.TestLabs.Find(id);
            if (testLab == null)
            {
                return HttpNotFound();
            }
            return View(testLab);
        }

        // POST: TestLabs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTestLab,TestLabName")] TestLab testLab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testLab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testLab);
        }

        // GET: TestLabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestLab testLab = db.TestLabs.Find(id);
            if (testLab == null)
            {
                return HttpNotFound();
            }
            return View(testLab);
        }

        // POST: TestLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestLab testLab = db.TestLabs.Find(id);
            db.TestLabs.Remove(testLab);
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
