using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IInstructorRepository _instructorRepository;
        private const int PageSize = 5;


        public CoursesController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository, IInstructorRepository instructorRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
            _instructorRepository = instructorRepository;
        }

        public IActionResult Index(string title, int? departmentId, int? instructorId, int page = 1)
        {
            // Fix: Removed the role-specific filtering logic that relied on ApplicationUserId
            // Now, all roles will see the same filtered list of courses.

            var (courses, totalCount) = _courseRepository.GetFiltered(title, departmentId, instructorId, page, PageSize);

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", departmentId);
            ViewBag.Instructors = new SelectList(_instructorRepository.GetAll(), "Id", "Name", instructorId);
            ViewBag.TitleFilter = title;
            ViewBag.DepartmentFilter = departmentId;
            ViewBag.InstructorFilter = instructorId;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            ViewBag.CurrentPage = page;

            return View(courses);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", course.DeptId);
            return View(course);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return NotFound();

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", course.DeptId);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                _courseRepository.Update(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", course.DeptId);
            return View(course);
        }

        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

