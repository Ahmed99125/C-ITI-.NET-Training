using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using System.Linq;

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

        // This method is obsolete because there is no single Id.
        public CourseStudent GetById(int id) => throw new System.NotImplementedException();

        public void Add(CourseStudent entity) { _context.CourseStudents.Add(entity); _context.SaveChanges(); }
        public void Update(CourseStudent entity) { _context.CourseStudents.Update(entity); _context.SaveChanges(); }

        // This method is obsolete because there is no single Id.
        public void Delete(int id) => throw new System.NotImplementedException();

        // Fix: Implemented the correct Delete method that uses the composite key.
        public void Delete(int studentId, int courseId)
        {
            var entity = _context.CourseStudents.FirstOrDefault(cs => cs.StdId == studentId && cs.CrsId == courseId);
            if (entity != null)
            {
                _context.CourseStudents.Remove(entity);
                _context.SaveChanges();
            }
        }


        public IEnumerable<CourseStudent> GetByStudentId(int studentId)
        {
            return _context.CourseStudents.Where(cs => cs.StdId == studentId).ToList();
        }

        public IEnumerable<CourseStudent> GetByCourseId(int courseId)
        {
            return _context.CourseStudents.Where(cs => cs.CrsId == courseId).ToList();
        }
    }
}

