using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudentsWebApplication.Data;
using System.Linq;

namespace StudentsWebApplication.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly StudentsDbContext _context;

        public EnrollmentController(StudentsDbContext context)
        {
            _context = context;
        }

        public IActionResult EnrollmentsList(string sortOrder, string searchString)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "NameDesc" : string.Empty;
            ViewBag.CourseSortParam = sortOrder == "Course" ? "CourseDesc" : "Course";

            var enrollments = _context.Enrollments.Include(e => e.Course).Include(e => e.Student).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                enrollments = enrollments.Where(
                                    s => s.Student.LastName.ToUpper().Contains(searchString.ToUpper()) ||
                                    s.Course.Title.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
            case "NameDesc":
                enrollments = enrollments.OrderByDescending(e => e.Student.LastName);
                break;
            case "Course":
                enrollments = enrollments.OrderBy(e => e.Course.Title);
                break;
            case "CourseDesc":
                enrollments = enrollments.OrderByDescending(e => e.Course.Title);
                break;
            default:
                enrollments = enrollments.OrderBy(e => e.Student.LastName);
                break;
            }

            return View(enrollments.ToList());
        }
    }
}
