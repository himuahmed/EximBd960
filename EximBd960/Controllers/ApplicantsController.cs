using System;
using System.Data.Entity;
using System.IO;
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
            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName");
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobType");
          

            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicantId,ApplicantName,PassportNo,PassportValidity,BirthPlace,Age,Child,MobileNo,CountryId,CompanyId,AgentId,MedicalStatus,Note,JobId,ImageURL")] Applicant applicant,HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                string path = ImageUpload(imageUpload);
                if (path.Equals("-1"))
                {

                }
                else
                {
                    applicant.ImageURL = path;
                    applicant.EntryDate = DateTime.Now;
                    //string user = SignInManagerExtensions.AuthenticationResponseGrant.Identity.GetUserId();
                    //  applicant.UserId =int.Parse(user);
                    User user = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                    applicant.UserId = user.UserId;
                    db.Applicants.Add(applicant);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.AgentId = new SelectList(db.Agents, "AgentId", "AgentName", applicant.AgentId);
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", applicant.CompanyId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", applicant.CountryId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobType",applicant.JobId);
           

            return View(applicant);
        }

        
        //public string UploadImage(HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (file != null)
        //            {
        //                string path = Path.Combine(Server.MapPath("~/Content/ApplicantUpload"), Path.GetFileName(file.FileName));
        //                file.SaveAs(path);
        //            }
        //            return  "File Uploaded successfully";
        //        }
        //        catch (Exception e)
        //        {
        //           return  "Error while uploading";
        //        }
        //    }
        //    else
        //    {
        //        return "Error while uploading";
        //    }
        //}


        public string ImageUpload(HttpPostedFileBase imgFile)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if(imgFile!=null && imgFile.ContentLength>0)
            {
                string extension = Path.GetExtension(imgFile.FileName);
                if(extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".PNG"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/ApplicantUpload"),random + Path.GetFileName(imgFile.FileName));
                        imgFile.SaveAs(path);
                        path= "~/Content/ApplicantUpload/"+ random + Path.GetFileName(imgFile.FileName);
                    }
                    catch(Exception ex) 
                    {
                        path = "-1";
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
            }
            return path;
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
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobType", applicant.JobId);

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
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobType", applicant.JobId);

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

		public ActionResult ApplicantINMedical()
		{
		    var applicant = db.Applicants.Where(x => (x.MedicalStatus == "Need Medical") || (x.MedicalStatus == "In Medical")).ToList();
			ViewBag.Country = new SelectList(db.Countries, "CountryId", "CountryName");
			ViewBag.Company = new SelectList(db.Companies, "CompanyId", "CompanyName");
			ViewBag.Agents = new SelectList(db.Agents, "AgentId", "AgentName");
			return View(applicant);
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
