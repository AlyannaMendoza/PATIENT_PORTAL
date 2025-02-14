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
    public class PatientsController : Controller
    {
        private PATIENT_PORTALContext db = new PATIENT_PORTALContext();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.PATIENT_HealthRecord);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.HealthRecordId = new SelectList(db.PATIENT_HealthRecord, "Id", "Id");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Suffix,BloodType,BirthDate,PlaceOfBirth,Sex,CivilStatus,Nationality,ContactNumber,StreetAddress,City,Province,Region,Country,ZipCode,HealthRecordId,IsActive")] Patient patient, HttpPostedFileBase ProfileImageFile)
        {
            if (ModelState.IsValid)
            { 
                string imagePath = "~/ Content / images / default.png";

                if (patient.ProfileImageFile != null && ProfileImageFile.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var extension = System.IO.Path.GetExtension(patient.ProfileImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("", "Invalid file type. Only images are allowed [jpg, jpeg, png].");
                        return View(patient);
                    }

                    // Ensure folder exists
                    string uploadDir = Server.MapPath("~/Content/images/Patients");
                    if (!System.IO.Directory.Exists(uploadDir))
                    {
                        System.IO.Directory.CreateDirectory(uploadDir);
                    }

                    // Generate a unique file name
                    string fileName = patient.LastName + patient.FirstName + System.IO.Path.GetExtension(patient.ProfileImageFile.FileName);
                    string filePath = System.IO.Path.Combine(uploadDir, fileName);

                    // Save the file
                    patient.ProfileImageFile.SaveAs(filePath);
                    imagePath = "/Content/images/Patients" + fileName;
                }
                patient.ProfileImage = imagePath;
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HealthRecordId = new SelectList(db.PATIENT_HealthRecord, "Id", "Id", patient.HealthRecordId);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.HealthRecordId = new SelectList(db.PATIENT_HealthRecord, "Id", "Id", patient.HealthRecordId);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfileImage,FirstName,MiddleName,LastName,Suffix,BloodType,BirthDate,PlaceOfBirth,Sex,CivilStatus,Nationality,ContactNumber,StreetAddress,City,Province,Region,Country,ZipCode,HealthRecordId,IsActive")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HealthRecordId = new SelectList(db.PATIENT_HealthRecord, "Id", "Id", patient.HealthRecordId);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
