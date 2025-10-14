using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ApplicationDbContext _context;
        public InstructorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetAll() => _context.Instructors.Include(i => i.Department).Include(i => i.Course).ToList();
        public Instructor GetById(int id) => _context.Instructors.Include(i => i.Department).Include(i => i.Course).FirstOrDefault(i => i.Id == id);
        public void Add(Instructor instructor) { _context.Instructors.Add(instructor); _context.SaveChanges(); }
        public void Update(Instructor instructor) { _context.Instructors.Update(instructor); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Instructor> GetInstructorsByDepartment(int departmentId)
        {
            return _context.Instructors.Where(i => i.DeptId == departmentId).ToList();
        }

        public (IEnumerable<Instructor> instructors, int totalCount) GetFiltered(string? name, int? departmentId, int page, int pageSize)
        {
            var query = _context.Instructors.Include(i => i.Department).Include(i => i.Course).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(i => i.Name.Contains(name));
            }
            if (departmentId.HasValue)
            {
                query = query.Where(i => i.DeptId == departmentId.Value);
            }

            var totalCount = query.Count();
            var instructors = query.OrderBy(i => i.Name).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return (instructors, totalCount);
        }
    }
}

