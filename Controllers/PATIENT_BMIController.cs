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
    public class PATIENT_BMIController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PATIENT_BMI
        public ActionResult Index()
        {
            return View(db._BMIs.ToList());
        }

        // GET: PATIENT_BMI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_BMI pATIENT_BMI = db._BMIs.Find(id);
            if (pATIENT_BMI == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_BMI);
        }

        // GET: PATIENT_BMI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PATIENT_BMI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateChecked,Height,Weight")] PATIENT_BMI pATIENT_BMI)
        {
            if (ModelState.IsValid)
            {
                db._BMIs.Add(pATIENT_BMI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pATIENT_BMI);
        }

        // GET: PATIENT_BMI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_BMI pATIENT_BMI = db._BMIs.Find(id);
            if (pATIENT_BMI == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_BMI);
        }

        // POST: PATIENT_BMI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateChecked,Height,Weight")] PATIENT_BMI pATIENT_BMI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATIENT_BMI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pATIENT_BMI);
        }

        // GET: PATIENT_BMI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENT_BMI pATIENT_BMI = db._BMIs.Find(id);
            if (pATIENT_BMI == null)
            {
                return HttpNotFound();
            }
            return View(pATIENT_BMI);
        }

        // POST: PATIENT_BMI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PATIENT_BMI pATIENT_BMI = db._BMIs.Find(id);
            db._BMIs.Remove(pATIENT_BMI);
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
