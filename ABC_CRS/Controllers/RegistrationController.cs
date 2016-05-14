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
    public class RegistrationController : Controller
    {
        private ABC_CRSEntities2 db = new ABC_CRSEntities2();


        public partial class LoginModel
        {
            public Participant participant { get; set; }
            public Login login { get; set; }

        }

        // GET: Registration
        public ActionResult Index()
        {
            var participants = db.Participants.Include(p => p.Company);
            return View(participants.ToList());
        }

        // GET: Registration/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
           
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,Salutation,FullName,Gender,Nationality,DateOfBirth,Email,ContactNumber,EmployementStatus,CompanyID,ComapanyName,OrganizationSize,JobTitle,Department,SalaryRange,DietaryRequirement")] Participant participant)
        {
            
            if (ModelState.IsValid)
            {
                db.Participants.Add(participant);
                db.SaveChanges();

                Login login = new Login();
                login.Username = participant.PID;
                login.Password = "1234";


                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", participant.CompanyID);
            return View(participant);
        }




        // GET: Registration/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", participant.CompanyID);
            return View(participant);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,Salutation,FullName,Gender,Nationality,DateOfBirth,Email,ContactNumber,EmployementStatus,CompanyID,ComapanyName,OrganizationSize,JobTitle,Department,SalaryRange,DietaryRequirement")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", participant.CompanyID);
            return View(participant);
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
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
