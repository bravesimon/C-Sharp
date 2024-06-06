using MechanicService.Data;
using MechanicService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MechanicService.Controllers
{
    public class ComplexController : Controller
    {
        private readonly ServiceDbContext _context;
        
        public ComplexController(ServiceDbContext context) 
        {
            _context = context;
        }

        public IActionResult ComplexView()
        {
            var infos = (from clients in _context.Clients
                              join vehicles in _context.Vehicles on clients.Id equals vehicles.ClientID
                              join services in _context.Services on vehicles.Id equals services.VehicleId
                              select new ComplexVM
                              {
                                  FirstName = clients.FirstMidName,
                                  LastName = clients.LastName,
                                  VehicleType = vehicles.Type.ToString(),
                                  IsWarrantyActive = vehicles.IsWarrantyActive,
                                  Date = services.Date.ToLongDateString(),
                                  IsDone = services.IsDone
                              });

            List<ComplexVM> result = [.. infos];

            return View(result);
        }
    }
}
