using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetCoursesByDepartment(int departmentId);
        IEnumerable<Course> GetCoursesByInstructor(int instructorId);
        (IEnumerable<Course> Courses, int TotalCount) GetFiltered(string? title, int? departmentId, int? instructorId, int page, int pageSize);
        IEnumerable<Course> GetCoursesByStudentId(int studentId);
        Course? GetById(int id);
    }
}

