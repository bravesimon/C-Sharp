using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsWebApplication.Data;
using StudentsWebApplication.Models;
using System.Diagnostics;
using System.Linq;

namespace StudentsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentsDbContext _context;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, StudentsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
