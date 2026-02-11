using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _context.Courses.Include(c => c.Department).AsNoTracking().ToListAsync();

            return View(courses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            DepartmentsDropDownList();
            ViewData["SelectedAction"] = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        private void DepartmentsDropDownList(object selectedDepartment = null)
        {
            var department = from x in _context.Departments orderby x.Name select x;

            ViewBag.DepartmentID = new SelectList(department.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            DepartmentsDropDownList(course.DepartmentID);
            ViewData["SelectedAction"] = "Edit";
            return View("Create", course);
        }

        [HttpPost, ActionName("Edit")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ConfirmEdit([Bind("CourseId, Title, Credits, DepartmentID")] Course course)
        {
            if (course.CourseId == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("Create", course);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courses == null)
            {
                return NotFound();
            }
            ViewData["SelectedAction"] = "Delete";
            return View(courses);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);

            ViewData["SelectedAction"] = "Details";
            return View("Delete", course);
        }
    }
}
