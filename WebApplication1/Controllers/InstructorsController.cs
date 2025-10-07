using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [AuthorizeStudentFilter]
    [Authorize(Roles = "Admin,HR")]
    public class InstructorsController : Controller
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorsController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public IActionResult Index()
        {
            var instructors = _instructorRepository.GetAll();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Add(instructor);
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        public IActionResult Edit(int id)
        {
            var instructor = _instructorRepository.GetById(id);
            if (instructor == null) return NotFound();
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorRepository.Update(instructor);
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        public IActionResult Delete(int id)
        {
            _instructorRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
