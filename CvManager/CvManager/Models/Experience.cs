using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CvManager.Models
{
    public class Experience
    {
        public Experience()
        {
        }

        [Key]
        public int ExperienceId { get; set; }

        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; private set; }

        public string CompanyName { get; set; }
        public string Designation { get; set; }
        [Required]
        [Range(1,25, ErrorMessage ="Ilość przepracowanych lat musi być w zakresie 1 do 25")]
        public int YearsWorked { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}