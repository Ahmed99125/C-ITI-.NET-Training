using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ICourseStudentRepository : IRepository<CourseStudent>
    {
        IEnumerable<CourseStudent> GetByStudentId(int studentId);
        IEnumerable<CourseStudent> GetByCourseId(int courseId);
    }
}
