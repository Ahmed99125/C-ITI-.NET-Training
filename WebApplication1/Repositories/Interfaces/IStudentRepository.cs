using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetStudentsByDepartment(int departmentId);
    }
}
