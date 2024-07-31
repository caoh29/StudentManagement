using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Student> students = _context.GetStudents();
            return View(students);
            //return View(await _context.Students.ToListAsync());
        }

        // Other actions (Create, Edit, Delete) can be added here

    }
}
