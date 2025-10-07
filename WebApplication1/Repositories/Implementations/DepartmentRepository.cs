using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
namespace WebApplication1.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll() => _context.Departments.ToList();
        public Department GetById(int id) => _context.Departments.Find(id);
        public void Add(Department department) { _context.Departments.Add(department); _context.SaveChanges(); }
        public void Update(Department department) { _context.Departments.Update(department); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public Department GetDepartmentByName(string name)
        {
            return _context.Departments.FirstOrDefault(d => d.Name == name);
        }
    }
}
