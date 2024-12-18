using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemv2.Models;
using System.Linq;

namespace SchoolManagementSystemv2.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Populate dropdowns with seeded data
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "FirstName");
            ViewBag.Classrooms = new SelectList(_context.Classrooms, "Id", "RoomNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Repopulate dropdowns in case of validation failure
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "FirstName");
            ViewBag.Classrooms = new SelectList(_context.Classrooms, "Id", "RoomNumber");
            return View(course);
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            // Populate ViewBag with data for dropdowns
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "FirstName", course.TeacherId);
            ViewBag.Classrooms = new SelectList(_context.Classrooms, "Id", "RoomNumber", course.ClassroomId);

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Courses.Update(course);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Courses.Any(c => c.Id == id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            // Repopulate ViewBag if validation fails
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "FirstName", course.TeacherId);
            ViewBag.Classrooms = new SelectList(_context.Classrooms, "Id", "RoomNumber", course.ClassroomId);

            return View(course);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Classroom)
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
