using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin,HR")]
    public class InstructorsController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        private const int PageSize = 10;

        public InstructorsController(
            IInstructorRepository instructorRepository,
            IDepartmentRepository departmentRepository,
            ICourseRepository courseRepository)
        {
            _instructorRepository = instructorRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        public IActionResult Index(string name, int? departmentId, int page = 1)
        {
            var (instructors, totalCount) = _instructorRepository.GetFiltered(name, departmentId, page, PageSize);

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", departmentId);
            ViewBag.NameFilter = name;
            ViewBag.DepartmentFilter = departmentId;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            ViewBag.CurrentPage = page;

            return View(instructors);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name");
            return View(new Instructor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Add(instructor);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", instructor.DeptId);
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name", instructor.CrsId);
            return View(instructor);
        }

        [Authorize(Roles = "Admin,HR")]
        public IActionResult Edit(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            if (instructor == null) return NotFound();

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", instructor.DeptId);
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name", instructor.CrsId);
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Update(instructor);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", instructor.DeptId);
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name", instructor.CrsId);
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _instructorRepository.Delete(id);
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "Could not delete instructor. They may be assigned to departments or courses.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

