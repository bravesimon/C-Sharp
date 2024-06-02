using System.ComponentModel.DataAnnotations;

namespace MechanicService.Models
{
    public enum VehicleType { Cabrio, Coupe, Salon, SUV, Combo }
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Vetel ideje")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public DateTime BoughtTime { get; set; }

        [Display(Name = "Garancialis?")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public bool IsWarrantyActive { get; set; }

        [Display(Name = "Tipus")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public VehicleType Type { get; set; }

        public int ClientID { get; set; }

        [Display(Name = "Tulaj")]
        [Required(ErrorMessage = "Kitöltése kötelező!")]
        public virtual Client Client { get; set; }
    }
}
