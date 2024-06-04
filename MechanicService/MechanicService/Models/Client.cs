using System.ComponentModel.DataAnnotations;

namespace MechanicService.Models
{
    public class Client
    {
        public int Id { get; set; }
        
        [Display(Name = "Keresztnev")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public string FirstMidName { get; set; }
        
        [Display(Name = "Csaladnev")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public string LastName { get; set; }
        
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public string Email { get; set; }

        [Display(Name = "Telefonszam (+36-os elotaggal)")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public string PhoneNumber{ get; set; }

        [Display(Name = "Cim azonosito")]
        public int AddressId { get; set; }

        [Display(Name = "Cim")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public virtual Address Address { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}