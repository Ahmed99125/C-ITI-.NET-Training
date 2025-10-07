using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetCoursesByDepartment(int departmentId);
        IEnumerable<Course> GetCoursesByInstructor(int instructorId);
        IEnumerable<Course> GetAll(string? search = null, int page = 1, int pageSize = 5);
        int GetCount(string? search = null);
        Course? GetById(int id);
    }
}