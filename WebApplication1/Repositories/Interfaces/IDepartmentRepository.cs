using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department GetDepartmentByName(string name);
        (IEnumerable<Department> Departments, int TotalCount) GetFiltered(string? name, int page, int pageSize);
    }
}
