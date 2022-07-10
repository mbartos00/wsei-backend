using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CvManager.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Pole imię jest wymagane")]

        [StringLength(150)]
        

        [Display(Name = "Imię")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Pole płeć jest wymagane")]

        [StringLength(10)]
        [Display(Name = "Płeć")]

        public string Gender { get; set; } = "";

        [Required]
        [Range(18, 55, ErrorMessage = "Obecnie nie posiadamy wolnych stanowisk dla osoby z twoim wiekiem.")]
        [DisplayName("Age in Years")]
        [Display(Name = "Wiek")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Pole zawód jest wymagane")]

        [StringLength(50)]
        [Display(Name = "Zawód")]

        public string Qualification { get; set; } = "";

     

        public int TotalExperience { get; set; }

        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();


        [Display(Name = "Zdjęcie profilowe")]
        public string PhotoUrl { get; set; }
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }
    }
}
