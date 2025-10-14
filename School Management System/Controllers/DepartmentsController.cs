using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private const int PageSize = 5;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index(string name, int page = 1)
        {
            var (departments, totalCount) = _departmentRepository.GetFiltered(name, page, PageSize);

            ViewBag.NameFilter = name;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            ViewBag.CurrentPage = page;

            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null) return NotFound();
            return View(department);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Edit(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null) return NotFound();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _departmentRepository.Delete(id);
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "This department cannot be deleted because it has instructors or courses assigned to it.";
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

