using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PATIENT_PORTAL.Models;

namespace PATIENT_PORTAL.Controllers
{
    [Authorize]
    public class PATIENT_VitalSignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PATIENT_VitalSigns
        public ActionResult Index()
        {
            return View(db.vitalSigns.ToList());
        }

        // GET: PATIENT_VitalSigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_VitalSigns pATIENT_VitalSigns = db.vitalSigns.Find(id);
            if (pATIENT_VitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_VitalSigns);
        }

        // GET: PATIENT_VitalSigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PATIENT_VitalSigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateChecked,BloodPressure,Temperature,PulseRate,RespiratoryRate,OxygenSaturation")] PATIENT_VitalSigns pATIENT_VitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.vitalSigns.Add(pATIENT_VitalSigns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pATIENT_VitalSigns);
        }

        // GET: PATIENT_VitalSigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_VitalSigns pATIENT_VitalSigns = db.vitalSigns.Find(id);
            if (pATIENT_VitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_VitalSigns);
        }

        // POST: PATIENT_VitalSigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateChecked,BloodPressure,Temperature,PulseRate,RespiratoryRate,OxygenSaturation")] PATIENT_VitalSigns pATIENT_VitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATIENT_VitalSigns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pATIENT_VitalSigns);
        }

        // GET: PATIENT_VitalSigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_VitalSigns pATIENT_VitalSigns = db.vitalSigns.Find(id);
            if (pATIENT_VitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_VitalSigns);
        }

        // POST: PATIENT_VitalSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PATIENT_VitalSigns pATIENT_VitalSigns = db.vitalSigns.Find(id);
            db.vitalSigns.Remove(pATIENT_VitalSigns);
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
