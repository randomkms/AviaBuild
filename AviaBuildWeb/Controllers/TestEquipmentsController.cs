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
    public class TestEquipmentsController : Controller
    {
        private AviaBuildDBEntities db = new AviaBuildDBEntities();

        // GET: TestEquipments
        public ActionResult Index()
        {
            var testEquipments = db.TestEquipments.Include(t => t.TestLab);
            return View(testEquipments.ToList());
        }

        // GET: TestEquipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestEquipment testEquipment = db.TestEquipments.Find(id);
            if (testEquipment == null)
            {
                return HttpNotFound();
            }
            return View(testEquipment);
        }

        // GET: TestEquipments/Create
        public ActionResult Create()
        {
            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName");
            return View();
        }

        // POST: TestEquipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTestEquipment,TestEquipmentName,TestLabId")] TestEquipment testEquipment)
        {
            if (ModelState.IsValid)
            {
                db.TestEquipments.Add(testEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName", testEquipment.TestLabId);
            return View(testEquipment);
        }

        // GET: TestEquipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestEquipment testEquipment = db.TestEquipments.Find(id);
            if (testEquipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName", testEquipment.TestLabId);
            return View(testEquipment);
        }

        // POST: TestEquipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTestEquipment,TestEquipmentName,TestLabId")] TestEquipment testEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestLabId = new SelectList(db.TestLabs, "IdTestLab", "TestLabName", testEquipment.TestLabId);
            return View(testEquipment);
        }

        // GET: TestEquipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestEquipment testEquipment = db.TestEquipments.Find(id);
            if (testEquipment == null)
            {
                return HttpNotFound();
            }
            return View(testEquipment);
        }

        // POST: TestEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestEquipment testEquipment = db.TestEquipments.Find(id);
            db.TestEquipments.Remove(testEquipment);
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
