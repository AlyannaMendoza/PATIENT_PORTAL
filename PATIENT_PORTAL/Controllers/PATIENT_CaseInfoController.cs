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
    public class PATIENT_CaseInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PATIENT_CaseInfo
        public ActionResult Index()
        {
            var caseInfos = db.CaseInfos.Include(c => c.Patient);
            return View(caseInfos.ToList());
        }

        // GET: PATIENT_CaseInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseInfo caseInfo = db.CaseInfos.Find(id);
            if (caseInfo == null)
            {
                return HttpNotFound();
            }
            return View(caseInfo);
        }

        // GET: PATIENT_CaseInfo/Create
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

        // POST: PATIENT_CaseInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,CaseNumber,DateCreated,AttendingPhysician,SignsSymptoms,Diagnosis")] CaseInfo caseInfo)
        {
            if (ModelState.IsValid)
            {
                db.CaseInfos.Add(caseInfo);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Case information created successfully!";
                return RedirectToAction("Index");
            }

            var patients = db.Patients.Select(p => new
            {
                Id = p.Id,
                FullName = p.LastName + ", " + p.FirstName
            }).ToList();

            ViewBag.PatientId = new SelectList(patients, "Id", "FullName", caseInfo.PatientId);
            return View(caseInfo);
        }

        // GET: PATIENT_CaseInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseInfo caseInfo = db.CaseInfos.Find(id);
            if (caseInfo == null)
            {
                return HttpNotFound();
            }

            var patients = db.Patients.Select(p => new
            {
                Id = p.Id,
                FullName = p.LastName + ", " + p.FirstName
            }).ToList();

            ViewBag.PatientId = new SelectList(patients, "Id", "FullName", caseInfo.PatientId);
            return View(caseInfo);
        }

        // POST: PATIENT_CaseInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,CaseNumber,DateCreated,AttendingPhysician,SignsSymptoms,Diagnosis")] CaseInfo caseInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseInfo).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMessage"] = "Case information edited successfully!";
                return RedirectToAction("Index");
            }

            var patients = db.Patients.Select(p => new
            {
                Id = p.Id,
                FullName = p.LastName + ", " + p.FirstName
            }).ToList();

            ViewBag.PatientId = new SelectList(patients, "Id", "FullName", caseInfo.PatientId);
            return View(caseInfo);
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
