using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    // Fix: Removed GetByApplicationUserId as it's no longer used
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetStudentsByDepartment(int departmentId);
        (IEnumerable<Student> students, int totalCount) GetFiltered(string name, int? departmentId, int? courseId, int page, int pageSize);
    }
}

