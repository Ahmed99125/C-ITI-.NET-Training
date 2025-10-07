namespace WebApplication1.Repositories.Interfaces
{
    public interface IReadableRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
