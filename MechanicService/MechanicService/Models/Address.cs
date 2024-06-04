using System.ComponentModel.DataAnnotations;

namespace MechanicService.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Display(Name = "Orszag")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public string Country { get; set; }
        
        [Display(Name = "Megye")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public string County { get; set; }

        [Display(Name = "Orszag")]
        [Required(ErrorMessage = "Kitöltése kötelező!")] 
        public string City { get; set; }

        [Display(Name = "Iranyitoszam")]
        [Required(ErrorMessage = "Kitöltése kötelező!")] 
        public string PostalCode { get; set; }

        [Display(Name = "Ut")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public string Road { get; set; }

        [Display(Name = "Hazszam")]
        [Required(ErrorMessage = "Kitöltése kötelező!")] 
        public int HouseNumber { get; set; }

        [Display(Name = "Egyeb informacio")]
        public string? Information { get; set; }
    }
}
