using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [AuthorizeStudentFilter]
    public class CourseStudentsController : Controller
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;

        public CourseStudentsController(ICourseStudentRepository courseStudentRepository, ICourseRepository courseRepository, IStudentRepository studentRepository)
        {
            _courseStudentRepository = courseStudentRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            var list = _courseStudentRepository.GetAll();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewBag.Courses = _courseRepository.GetAll();
            ViewBag.Students = _studentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseStudent cs)
        {
            if (ModelState.IsValid)
            {
                _courseStudentRepository.Add(cs);
                return RedirectToAction(nameof(Index));
            }
            return View(cs);
        }

        // Fix: Updated the Delete action to accept both stdId and crsId to work with the composite key.
        public IActionResult Delete(int stdId, int crsId)
        {
            _courseStudentRepository.Delete(stdId, crsId);
            return RedirectToAction(nameof(Index));
        }
    }
}
