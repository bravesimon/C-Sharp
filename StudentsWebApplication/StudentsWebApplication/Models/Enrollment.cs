using System.ComponentModel.DataAnnotations;

namespace StudentsWebApplication.Models
{
    public enum Grade { A, B, C, D, F }

    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        [Display(Name = "Név")]
        [Required(ErrorMessage = "Név kitöltése kötelező!")]
        public int CourseId { get; set; }

        [Display(Name = "Tanuló azonosító")]
        public int StudentId { get; set; }

        [Display(Name = "Osztályzat")]
        public Grade? Grade { get; set; }

        [Display(Name = "Kurzus")]
        [Required(ErrorMessage = "Kurzus kitöltése kötelező!")]
        public virtual Course Course { get; set; }

        [Display(Name = "Tanuló")]
        [Required(ErrorMessage = "Tanuló kitöltése kötelező!")]
        public virtual Student Student { get; set; }
    }
}
