using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll() => _context.Students.Include(s => s.Department).ToList();

        public Student GetById(int id) => _context.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Student> GetStudentsByDepartment(int DeptId)
        {
            return _context.Students.Where(s => s.DeptId == DeptId).ToList();
        }

        // Fix: Changed tuple element names to match the interface (students, totalCount)
        public (IEnumerable<Student> students, int totalCount) GetFiltered(string? name, int? departmentId, int? courseId, int page, int pageSize)
        {
            var query = _context.Students.Include(s => s.Department).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.Name.Contains(name));
            }
            if (departmentId.HasValue)
            {
                query = query.Where(s => s.DeptId == departmentId.Value);
            }
            if (courseId.HasValue)
            {
                query = query.Where(s => s.CourseStudents.Any(cs => cs.CrsId == courseId.Value));
            }

            var totalCount = query.Count();
            var students = query.OrderBy(s => s.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return (students, totalCount);
        }
    }
}

