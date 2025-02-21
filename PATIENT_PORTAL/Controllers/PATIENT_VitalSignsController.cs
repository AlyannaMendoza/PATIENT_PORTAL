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
    public class PATIENT_VitalSignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PATIENT_VitalSigns
        public ActionResult Index()
        {
            var vitalSigns = db.VitalSigns.Include(v => v.Patient);
            return View(vitalSigns.ToList());
        }

        // GET: PATIENT_VitalSigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = db.VitalSigns.Find(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
        }

        // GET: PATIENT_VitalSigns/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", "LastName");
            return View();
        }

        // POST: PATIENT_VitalSigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,DateChecked,BloodPressure,Temperature,PulseRate,RespiratoryRate,OxygenSaturation")] VitalSigns vitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.VitalSigns.Add(vitalSigns);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Vital signs added successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", "LastName", vitalSigns.PatientId);
            return View(vitalSigns);
        }

        // GET: PATIENT_VitalSigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = db.VitalSigns.Find(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", "LastName", vitalSigns.PatientId);
            return View(vitalSigns);
        }

        // POST: PATIENT_VitalSigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,DateChecked,BloodPressure,Temperature,PulseRate,RespiratoryRate,OxygenSaturation")] VitalSigns vitalSigns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vitalSigns).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Vital signs saved!";
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", vitalSigns.PatientId);
            return View(vitalSigns);
        }

        // GET: PATIENT_VitalSigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VitalSigns vitalSigns = db.VitalSigns.Find(id);
            if (vitalSigns == null)
            {
                return HttpNotFound();
            }
            return View(vitalSigns);
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
