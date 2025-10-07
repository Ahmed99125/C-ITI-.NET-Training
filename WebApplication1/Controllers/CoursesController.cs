using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Repositories.Implementations;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Instructor")]
    [AuthorizeStudentFilter]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CoursesController(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        //public IActionResult Index()
        //{
        //    var courses = _courseRepository.GetAll();

        //    int? joinedCourseId = HttpContext.Session.GetInt32("SelectedCourseId");
        //    ViewBag.JoinedCourseId = joinedCourseId;

        //    return View(courses);
        //}

        public IActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var courses = _courseRepository.GetAll(search, page, pageSize);
            int totalItems = _courseRepository.GetCount(search);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.Search = search;

            // Keep selected course session for UI highlight
            int? joinedCourseId = HttpContext.Session.GetInt32("SelectedCourseId");
            ViewBag.JoinedCourseId = joinedCourseId;

            return View(courses);
        }
        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(course);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(course);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            _courseRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult JoinCourse(int id)
        {
            // Save selected course ID in session
            HttpContext.Session.SetInt32("SelectedCourseId", id);

            // Redirect back to Index
            return RedirectToAction("Index");
        }
    }
}
