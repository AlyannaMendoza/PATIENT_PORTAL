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
    public class PATIENT_CaseInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PATIENT_CaseInfo
        public ActionResult Index()
        {
            return View(db.caseInfos.ToList());
        }

        // GET: PATIENT_CaseInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_CaseInfo pATIENT_CaseInfo = db.caseInfos.Find(id);
            if (pATIENT_CaseInfo == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_CaseInfo);
        }

        // GET: PATIENT_CaseInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PATIENT_CaseInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CaseNumber,DateCreated,AttendingPhysician,Diagnosis,SignsSymptoms")] PATIENT_CaseInfo pATIENT_CaseInfo)
        {
            if (ModelState.IsValid)
            {
                db.caseInfos.Add(pATIENT_CaseInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pATIENT_CaseInfo);
        }

        // GET: PATIENT_CaseInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_CaseInfo pATIENT_CaseInfo = db.caseInfos.Find(id);
            if (pATIENT_CaseInfo == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_CaseInfo);
        }

        // POST: PATIENT_CaseInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CaseNumber,DateCreated,AttendingPhysician,Diagnosis,SignsSymptoms")] PATIENT_CaseInfo pATIENT_CaseInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATIENT_CaseInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pATIENT_CaseInfo);
        }

        // GET: PATIENT_CaseInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_CaseInfo pATIENT_CaseInfo = db.caseInfos.Find(id);
            if (pATIENT_CaseInfo == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_CaseInfo);
        }

        // POST: PATIENT_CaseInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PATIENT_CaseInfo pATIENT_CaseInfo = db.caseInfos.Find(id);
            db.caseInfos.Remove(pATIENT_CaseInfo);
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
