using Microsoft.AspNetCore.Mvc;
using StudentsWebApplication.Data;
using StudentsWebApplication.Models;
using System;
using System.Linq;

namespace StudentsWebApplication.Controllers
{
    public class DateReportController : Controller
    {
        private readonly StudentsDbContext _context;
        public DateReportController(StudentsDbContext context)
        {
            _context = context;
        }

        public IActionResult EnrollmentDateReport()
        {
            var result = from student in _context.Students.ToList()
                         group student by student.EnrollmentDate into dateGroup
                         select new EnrollmentDateVM
                         {
                             EnrollmentDate = dateGroup.Key,
                             StudentCount = dateGroup.Count()
                         };

            return View(result.ToList());
        }
    }
}
