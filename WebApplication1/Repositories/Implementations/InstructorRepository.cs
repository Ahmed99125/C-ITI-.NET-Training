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

        public IEnumerable<Instructor> GetAll() => _context.Instructors.ToList();
        public Instructor GetById(int id) => _context.Instructors.Find(id);
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
    }
}
