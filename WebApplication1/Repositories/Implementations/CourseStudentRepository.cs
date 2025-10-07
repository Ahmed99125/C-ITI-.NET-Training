using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Implementations
{
    public class CourseStudentRepository : ICourseStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CourseStudent> GetAll() => _context.CourseStudents.ToList();
        public CourseStudent GetById(int id) => _context.CourseStudents.Find(id);
        public void Add(CourseStudent entity) { _context.CourseStudents.Add(entity); _context.SaveChanges(); }
        public void Update(CourseStudent entity) { _context.CourseStudents.Update(entity); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var entity = _context.CourseStudents.Find(id);
            if (entity != null)
            {
                _context.CourseStudents.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CourseStudent> GetByStudentId(int studentId)
        {
            return _context.CourseStudents.Where(cs => cs.Id == studentId).ToList();
        }

        public IEnumerable<CourseStudent> GetByCourseId(int courseId)
        {
            return _context.CourseStudents.Where(cs => cs.Id == courseId).ToList();
        }
    }
}
