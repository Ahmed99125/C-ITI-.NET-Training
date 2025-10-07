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

        public IEnumerable<Course> GetAll() => _context.Courses.Include(c => c.Department).ToList();
        public Course GetById(int id) => _context.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
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
            // This logic assumes an instructor is directly linked to one course. 
            // If an instructor can have many courses, this model needs adjustment.
            return _context.Courses.Where(c => c.Instructors.Any(i => i.Id == instructorId)).ToList();
        }

        public IEnumerable<Course> GetCoursesByStudentId(int studentId)
        {
            return _context.CourseStudents
                .Where(cs => cs.StdId == studentId)
                .Select(cs => cs.Course)
                .Include(c => c.Department)
                .ToList();
        }

        public (IEnumerable<Course> Courses, int TotalCount) GetFiltered(string? title, int? departmentId, int? instructorId, int page, int pageSize)
        {
            var query = _context.Courses.Include(c => c.Department).AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(c => c.Name.Contains(title));
            }
            if (departmentId.HasValue)
            {
                query = query.Where(c => c.DeptId == departmentId.Value);
            }
            if (instructorId.HasValue)
            {
                query = query.Where(c => c.Instructors.Any(i => i.Id == instructorId.Value));
            }

            var totalCount = query.Count();
            var courses = query.OrderBy(c => c.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return (courses, totalCount);
        }
    }
}

