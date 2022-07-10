using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CvManager.Data;
using CvManager.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CvManager.Controllers
{
    [Authorize]
    public class CvController : Controller
    {
        private readonly CvDbContext _context;

        private readonly IWebHostEnvironment _webHost;




        public CvController(CvDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;

        }
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicants.ToList();
            return View(applicants);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });

            ViewBag.Gender = GetGender();

            return View(applicant);
        }


        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            applicant.Experiences.RemoveAll(n => n.YearsWorked == 0);
            applicant.Experiences.RemoveAll(n => n.IsDeleted == true);


            string uniqueFileName = GetUploadedFileName(applicant);
            applicant.PhotoUrl = uniqueFileName;

            _context.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("index");

        }


        private string GetUploadedFileName(Applicant applicant)
        {
            string uniqueFileName = null;

            if (applicant.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + applicant.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult Details(int Id)
        {
            Applicant applicant = _context.Applicants
                .Include(e => e.Experiences)
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(applicant);
                
        } 
        
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Applicant applicant = _context.Applicants
                .Include(e => e.Experiences)
                .Where(a => a.Id == Id).FirstOrDefault();
            return View(applicant);
                
        }  
        
        [HttpPost]
        public IActionResult Delete(Applicant applicant)
        {
            _context.Attach(applicant);
            _context.Entry(applicant).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        private List<SelectListItem> GetGender()
        {
            List<SelectListItem> selectGender = new List<SelectListItem>();

            var selectItem = new SelectListItem()
            {
                Value = "",
                Text = "Wybierz Płeć"
            };

            selectGender.Insert(0, selectItem);

           var selectMale = new SelectListItem()
            {
                Value = "Mężczyzna",
                Text = "Mężczyzna"
            };
           var selectFemale = new SelectListItem()
            {
                Value = "Kobieta",
                Text = "Kobieta"
            };
            selectGender.Add(selectMale);
            selectGender.Add(selectFemale);
            
            
            return selectGender;
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Applicant applicant = _context.Applicants
                .Include(e => e.Experiences)
                .Where(a => a.Id == Id).FirstOrDefault();
            ViewBag.Gender = GetGender();
            return View(applicant);

        }


        [HttpPost]
        public IActionResult Edit(Applicant applicant)
        {
            List<Experience> expDetails = _context.Experiences.Where(d => d.ApplicantId == applicant.Id).ToList();
            _context.Experiences.RemoveRange(expDetails);
            _context.SaveChanges();

            applicant.Experiences.RemoveAll(n => n.YearsWorked == 0);
            applicant.Experiences.RemoveAll(n => n.IsDeleted == true);

            if (applicant.ProfilePhoto != null)
            {
                string uniqueFileName = GetUploadedFileName(applicant);
                applicant.PhotoUrl = uniqueFileName;
            }
            

            _context.Attach(applicant);
            _context.Entry(applicant).State = EntityState.Modified;
            _context.Experiences.AddRange(applicant.Experiences);
            _context.SaveChanges();
            return RedirectToAction("index");

        }

    }
}