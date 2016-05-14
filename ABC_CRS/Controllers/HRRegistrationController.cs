using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABC_CRS;


namespace ABC_CRS.Controllers
{

    public partial class ParentModel
    {
        public CompanyHR companyHR { get; set; }
        public Company company { get; set; }

    }
   
    public class HRRegistrationController : Controller
    {
        private ABC_CRSEntities2 db = new ABC_CRSEntities2();

        // GET: HRRegistration
        public ActionResult Index()
        {
            var companyHRs = db.CompanyHRs.Include(c => c.Company);
            
            return View(companyHRs.ToList());
        }

       

        // GET: HRRegistration/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return HttpNotFound();
            }
            return View(companyHR);
        }




        // GET: HRRegistration/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: HRRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Create([Bind(Include = "HRName,CompanyID,CompanyName,JobTitle,HREmail,ContactNumber,FaxNumber")] CompanyHR companyHR, [Bind(Include = "CompanyID,CompanyName,CompanyUEN,OrganizationSize,CompanyAddress,Country,PostalCode")] Company company)
        {
            if (ModelState.IsValid)
            {


                company.CompanyName = companyHR.CompanyName;
                

                db.Companies.Add(company);
                db.SaveChanges();
                

                db.CompanyHRs.Add(companyHR);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", companyHR.CompanyID);
            return View(companyHR);
        }





        // GET: HRRegistration/_HRRegPartial
        public ActionResult _HRRegPartial()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: HRRegistration/_HRRegPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult _HRRegPartial([Bind(Include = "HRName,CompanyID,CompanyName,JobTitle,HREmail,ContactNumber,FaxNumber")] CompanyHR companyHR, [Bind(Include = "CompanyID,CompanyName,CompanyUEN,OrganizationSize,CompanyAddress,Country,PostalCode")] Company company)
        {
            if (ModelState.IsValid)
            {

                db.Companies.Add(company);
                db.SaveChanges();

                db.CompanyHRs.Add(companyHR);
                db.SaveChanges();

                return RedirectToAction("~/Views/HRRegistration/Index.cshtml");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", companyHR.CompanyID);
            return View(companyHR);
        }



       













        // GET: HRRegistration/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", companyHR.CompanyID);
            return View(companyHR);
        }

        // POST: HRRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HRName,CompanyID,ComapanyName,JobTitle,HREmail,ContactNumber,FaxNumber")] CompanyHR companyHR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyHR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", companyHR.CompanyID);
            return View(companyHR);
        }

        // GET: HRRegistration/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            if (companyHR == null)
            {
                return HttpNotFound();
            }
            return View(companyHR);
        }

        // POST: HRRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CompanyHR companyHR = db.CompanyHRs.Find(id);
            db.CompanyHRs.Remove(companyHR);
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
