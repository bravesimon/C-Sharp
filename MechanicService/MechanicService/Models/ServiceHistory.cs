using System.ComponentModel.DataAnnotations;

namespace MechanicService.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }

        public virtual int ServiceId { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual int VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
