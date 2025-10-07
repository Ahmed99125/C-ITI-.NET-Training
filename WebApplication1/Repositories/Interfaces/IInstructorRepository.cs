using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        IEnumerable<Instructor> GetInstructorsByDepartment(int departmentId);
    }
}
