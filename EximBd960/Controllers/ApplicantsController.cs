using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EximBd960.Models;

namespace EximBd960.Controllers
{
    
    public class ApplicantsController : Controller
    {
        private Eximbd960DbContext db = new Eximbd960DbContext();

        [AllowAnonymous]
        // GET: Applicants
        public ActionResult Index()
        {
            var applicants = db.Applicants.Include(a => a.Agent).Include(a => a.Company).Include(a => a.Country).Include(a => a.User);
            return View(applicants.ToList());
        }
        public ActionResult Index1()
        {
            var applicants = db.Applicants.Include(a => a.Agent).Include(a => a.Company).Include(a => a.Country).Include(a => a.User);
            return View(applicants.ToList());
        }
        [Authorize(Roles = "Moderator")]
        // GET: Applicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        [Authorize(Roles = "Moderator")]
        // GET: Applicants/Create
        public ActionResult Create()
        {

            var LoggedInUser = db.Users.ToList().Where(d => d.UserName == User.Identity.Name);
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName");
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
           // ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.UserId = new SelectList(LoggedInUser, "UserId", "UserName");
            //ViewBag.UserId = User.Identity;
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicantId,UserId,EntryDate,ApplicantName,ImageURL,PassportNo,PassportValidity,BirthPlace,Age,Child,MobileNo,CountryId,CompanyId,AgentId,MedicalStatus,TcStatus,PcStatus,CvDate,VisaDate,AgreementDate,Finger,EmbassyReport,Manpower,Status,FlightDate,Note")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var LoggedInUser = db.Users.ToList().Where(d => d.UserName == User.Identity.Name);

            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName", applicant.AgentId);
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", applicant.CompanyId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", applicant.CountryId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", applicant.UserId);
            //ViewBag.UserId = new SelectList(LoggedInUser, "User_Id", "UserName");
            return View(applicant);
        }

        [Authorize(Roles = "Moderator")]
        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName", applicant.AgentId);
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", applicant.CompanyId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", applicant.CountryId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", applicant.UserId);
            return View(applicant);
        }

        [Authorize(Roles = "Moderator")]
        // POST: Applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicantId,UserId,EntryDate,ApplicantName,ImageURL,PassportNo,PassportValidity,BirthPlace,Age,Child,MobileNo,CountryId,CompanyId,AgentId,MedicalStatus,TcStatus,PcStatus,CvDate,VisaDate,AgreementDate,Finger,EmbassyReport,Manpower,Status,FlightDate,Note")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName", applicant.AgentId);
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", applicant.CompanyId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", applicant.CountryId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", applicant.UserId);
            return View(applicant);
        }

        [Authorize(Roles = "Moderator")]
        // GET: Applicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        [Authorize(Roles = "Moderator")]
        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
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
