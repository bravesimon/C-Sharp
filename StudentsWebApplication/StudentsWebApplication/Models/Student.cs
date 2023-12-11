using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentsWebApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Display(Name = "Családnév")]
        [Required(ErrorMessage = "Családnév kitöltése kötelező!")]
        public string LastName { get; set; }

        [Display(Name = "Keresztnév")]
        [Required(ErrorMessage = "Keresztnév kitöltése kötelező!")]
        public string FirstMidName { get; set; }

        [Display(Name = "Első jelentkezés")]
        [Required(ErrorMessage = "Első jelentkezés kitöltése kötelező!")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Jelentkezések")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
