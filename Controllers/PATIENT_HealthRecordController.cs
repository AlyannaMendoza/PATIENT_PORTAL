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
    public class PATIENT_HealthRecordController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PATIENT_HealthRecord
        public ActionResult Index()
        {
            return View(db.healthRecords.ToList());
        }

        // GET: PATIENT_HealthRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_HealthRecord pATIENT_HealthRecord = db.healthRecords.Find(id);
            if (pATIENT_HealthRecord == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_HealthRecord);
        }

        // GET: PATIENT_HealthRecord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PATIENT_HealthRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PATIENT_HealthRecord pATIENT_HealthRecord)
        {
            if (ModelState.IsValid)
            {

                db.healthRecords.Add(pATIENT_HealthRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CaseInfoList = new SelectList(db.caseInfos, "Id", "CaseDescription");
            ViewBag.VitalSignsList = new SelectList(db.vitalSigns, "Id", "VitalSummary");
            ViewBag.BMIList = new SelectList(db._BMIs, "Id", "BMIValue");

            return View(pATIENT_HealthRecord);
        }

        // GET: PATIENT_HealthRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_HealthRecord pATIENT_HealthRecord = db.healthRecords.Find(id);
            if (pATIENT_HealthRecord == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_HealthRecord);
        }

        // POST: PATIENT_HealthRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CaseInfoId,VitalSignsId,BMI_Id")] PATIENT_HealthRecord pATIENT_HealthRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATIENT_HealthRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pATIENT_HealthRecord);
        }

        // GET: PATIENT_HealthRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_HealthRecord pATIENT_HealthRecord = db.healthRecords.Find(id);
            if (pATIENT_HealthRecord == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_HealthRecord);
        }

        // POST: PATIENT_HealthRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PATIENT_HealthRecord pATIENT_HealthRecord = db.healthRecords.Find(id);
            db.healthRecords.Remove(pATIENT_HealthRecord);
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
