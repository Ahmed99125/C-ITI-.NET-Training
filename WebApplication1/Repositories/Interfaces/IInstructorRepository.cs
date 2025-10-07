using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    // Fix: Removed GetByApplicationUserId as it's no longer used
    public interface IInstructorRepository : IRepository<Instructor>
    {
        IEnumerable<Instructor> GetInstructorsByDepartment(int departmentId);
        (IEnumerable<Instructor> instructors, int totalCount) GetFiltered(string name, int? departmentId, int page, int pageSize);
    }
}

