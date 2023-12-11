using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsWebApplication.Data;
using StudentsWebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentsWebApplication.Controllers
{ 
    public class StudentReportController : Controller
    {
        private readonly StudentsDbContext _context;

        public StudentReportController(StudentsDbContext context)
        { 
            _context = context;
        }

        public IActionResult StudentCreditReport()
        {
            var qStudents = _context.Students.Include(x => x.Enrollments).ThenInclude(e => e.Course);
            List<StudentReportVM> result = new List<StudentReportVM>();

            foreach (var qStudent in qStudents)
            {
                string name = qStudent.FirstMidName + " " + qStudent.LastName;
                int sum = qStudent.Enrollments.Where(grade => grade.Grade < Grade.F).Sum(item => item.Course.Credits);
                
                result.Add(new StudentReportVM() { Name=name, CreditsSum = sum });
            }

            return View(result);
        }
    }
}
