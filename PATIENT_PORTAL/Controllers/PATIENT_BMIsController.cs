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
    public class PATIENT_BMIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PATIENT_BMIs
        public ActionResult Index()
        {
            var bMIs = db.BMIs.Include(b => b.Patient);
            return View(bMIs.ToList());
        }

        // GET: PATIENT_BMIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BMI bMI = db.BMIs.Find(id);
            if (bMI == null)
            {
                return HttpNotFound();
            }
            return View(bMI);
        }

        // GET: PATIENT_BMIs/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", "LastName");
            return View();
        }

        // POST: PATIENT_BMIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientId,DateChecked,Height,Weight")] BMI bMI)
        {
            if (ModelState.IsValid)
            {
                db.BMIs.Add(bMI);
                db.SaveChanges();

                TempData["SuccessMessage"] = "BMI added successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", "LastName", bMI.PatientId);
            return View(bMI);
        }

        // GET: PATIENT_BMIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BMI bMI = db.BMIs.Find(id);
            if (bMI == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", "LastName", bMI.PatientId);
            return View(bMI);
        }

        // POST: PATIENT_BMIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientId,DateChecked,Height,Weight")] BMI bMI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bMI).State = EntityState.Modified;
                db.SaveChanges();

                TempData["SuccessMessage"] = "BMI edited successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "FirstName", "LastName", bMI.PatientId);
            return View(bMI);
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
