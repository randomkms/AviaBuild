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
    public class TestersController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: Testers
        public ActionResult Index()
        {
            var testers = db.Testers.Include(t => t.TestLab);
            return View(testers.ToList());
        }

        // GET: Testers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tester tester = db.Testers.Find(id);
            if (tester == null)
            {
                return HttpNotFound();
            }
            return View(tester);
        }

        // GET: Testers/Create
        public ActionResult Create()
        {
            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName");
            return View();
        }

        // POST: Testers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTester,TesterName,TestLabId")] Tester tester)
        {
            if (ModelState.IsValid)
            {
                db.Testers.Add(tester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName", tester.TestLabId);
            return View(tester);
        }

        // GET: Testers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tester tester = db.Testers.Find(id);
            if (tester == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName", tester.TestLabId);
            return View(tester);
        }

        // POST: Testers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTester,TesterName,TestLabId")] Tester tester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName", tester.TestLabId);
            return View(tester);
        }

        // GET: Testers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tester tester = db.Testers.Find(id);
            if (tester == null)
            {
                return HttpNotFound();
            }
            return View(tester);
        }

        // POST: Testers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tester tester = db.Testers.Find(id);
            db.Testers.Remove(tester);
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
