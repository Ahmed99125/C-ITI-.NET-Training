using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll(string? search = null, int page = 1, int pageSize = 5)
        {
            var query = _context.Courses.Include(c => c.Department).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            return query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetCount(string? search = null)
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            return query.Count();
        }

        public IEnumerable<Course> GetAll() => _context.Courses.ToList();
        public Course GetById(int id) => _context.Courses.Find(id);
        public void Add(Course course) { _context.Courses.Add(course); _context.SaveChanges(); }
        public void Update(Course course) { _context.Courses.Update(course); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetCoursesByDepartment(int departmentId)
        {
            return _context.Courses.Where(c => c.DeptId == departmentId).ToList();
        }

        public IEnumerable<Course> GetCoursesByInstructor(int instructorId)
        {
            return _context.Courses.Where(c => c.DeptId == instructorId).ToList();
        }
    }
}
