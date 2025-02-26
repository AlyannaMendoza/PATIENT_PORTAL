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
            var patients = db.Patients.Select(p => new
            {
                Id = p.Id,
                FullName = p.LastName + ", " + p.FirstName
            }).ToList();

            ViewBag.PatientId = new SelectList(patients, "Id", "FullName");
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

            var patients = db.Patients.Select(p => new
            {
                Id = p.Id,
                FullName = p.LastName + ", " + p.FirstName
            }).ToList();

            ViewBag.PatientId = new SelectList(patients, "Id", "FullName", vitalSigns.PatientId);
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

            var patients = db.Patients.Select(p => new
            {
                Id = p.Id,
                FullName = p.LastName + ", " + p.FirstName
            }).ToList();

            ViewBag.PatientId = new SelectList(patients, "Id", "FullName", vitalSigns.PatientId);
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

            var patients = db.Patients.Select(p => new
            {
                Id = p.Id,
                FullName = p.LastName + ", " + p.FirstName
            }).ToList();

            ViewBag.PatientId = new SelectList(patients, "Id", "FullName", vitalSigns.PatientId);
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
