using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsWebApplication.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        [Display(Name = "Név")]
        [Required(ErrorMessage = "Név kitöltése kötelező!")]
        public string Title { get; set; }

        [Display(Name = "Kredit")]
        [Required(ErrorMessage = "Kredit kitöltése kötelező!")]
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
