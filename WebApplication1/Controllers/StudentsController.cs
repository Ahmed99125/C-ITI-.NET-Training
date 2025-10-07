using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Authorize] // All actions require login
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseStudentRepository _courseStudentRepository;
        private const int PageSize = 10;

        public StudentsController(
            IStudentRepository studentRepository,
            IDepartmentRepository departmentRepository,
            ICourseRepository courseRepository,
            ICourseStudentRepository courseStudentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        [Authorize(Roles = "Admin,HR")]
        public IActionResult Index(string name, int? departmentId, int? courseId, int page = 1)
        {
            var (students, totalCount) = _studentRepository.GetFiltered(name, departmentId, courseId, page, PageSize);

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", departmentId);
            ViewBag.Courses = new SelectList(_courseRepository.GetAll(), "Id", "Name", courseId);
            ViewBag.NameFilter = name;
            ViewBag.DepartmentFilter = departmentId;
            ViewBag.CourseFilter = courseId;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            ViewBag.CurrentPage = page;

            return View(students);
        }

        [Authorize(Roles = "Admin,HR")]
        public IActionResult Details(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null)
                return NotFound();

            // Fix: Removed logic that checked for ApplicationUserId
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), "Id", "Name");
            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.Add(student);
                // The SaveChanges in Add() will give the student an Id.
                foreach (var courseId in student.SelectedCourseIds)
                {
                    _courseStudentRepository.Add(new CourseStudent { StdId = student.Id, CrsId = courseId });
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", student.DeptId);
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), "Id", "Name", student.SelectedCourseIds);
            return View(student);
        }

        [Authorize(Roles = "Admin,HR")]
        public IActionResult Edit(int id)
        {
            var student = _studentRepository.GetById(id);
            if (student == null) return NotFound();

            // Fix: Removed logic that checked for ApplicationUserId

            student.SelectedCourseIds = _courseStudentRepository.GetByStudentId(id).Select(sc => sc.CrsId).ToList();

            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", student.DeptId);
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), "Id", "Name", student.SelectedCourseIds);

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult Edit(Student student)
        {
            // Fix: Removed logic that checked for ApplicationUserId

            if (ModelState.IsValid)
            {
                _studentRepository.Update(student);

                // Sync course enrollments
                var existingCourses = _courseStudentRepository.GetByStudentId(student.Id);
                // Remove old courses
                foreach (var courseEnrollment in existingCourses)
                {
                    if (!student.SelectedCourseIds.Contains(courseEnrollment.CrsId))
                    {
                        _courseStudentRepository.Delete(student.Id, courseEnrollment.CrsId);
                    }
                }
                // Add new courses
                foreach (var courseId in student.SelectedCourseIds)
                {
                    if (!existingCourses.Any(c => c.CrsId == courseId))
                    {
                        _courseStudentRepository.Add(new CourseStudent { StdId = student.Id, CrsId = courseId });
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_departmentRepository.GetAll(), "Id", "Name", student.DeptId);
            ViewBag.Courses = new MultiSelectList(_courseRepository.GetAll(), "Id", "Name", student.SelectedCourseIds);
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,HR")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _studentRepository.Delete(id);
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "Could not delete student. They may be enrolled in courses.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

