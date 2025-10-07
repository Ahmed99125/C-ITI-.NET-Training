namespace WebApplication1.Repositories.Interfaces
{
    public interface IRepository<T> : IReadableRepository<T>, IWritableRepository<T> where T : class
    {
    }
}