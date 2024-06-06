using MechanicService.Data;
using MechanicService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MechanicService.Controllers
{
    
    public class NotDoneServicesController : Controller
    {
        private readonly ServiceDbContext _context;

        public NotDoneServicesController(ServiceDbContext context)
        {
            _context = context;
        }

        public IActionResult NotDoneServicesView()
        {
            var infos = (from clients in _context.Clients
                         join vehicles in _context.Vehicles on clients.Id equals vehicles.ClientID
                         join services in _context.Services on vehicles.Id equals services.VehicleId
                         join addresses in _context.Addresses on clients.AddressId equals addresses.Id
                         where services.IsDone == false
                         select new NotDoneServicesVM
                         {
                             FirstName = clients.FirstMidName,
                             LastName = clients.LastName,
                             Email = clients.Email,
                             Phone = clients.PhoneNumber,
                             City = addresses.City,
                             IsWarrantyActive = vehicles.IsWarrantyActive,
                             Date = services.Date.ToLongDateString(),
                         });

            List<NotDoneServicesVM> result = [.. infos];
            return View(result);
        }
    }
}
