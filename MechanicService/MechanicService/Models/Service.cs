using System.ComponentModel.DataAnnotations;

namespace MechanicService.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Display(Name = "Szerviz ideje")]
        [Required(ErrorMessage = "Kitöltése kötelező!")] 
        public DateTime Date { get; set; }

        [Display(Name = "Elvegezve?")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public bool IsDone { get; set; }

        [Display(Name = "Egyeb informacio")]
        public string? Information { get; set; }

        public int ServiceHistoryId { get; set; }
        public virtual ServiceHistory ServiceHistory { get; set; }
    }
}
