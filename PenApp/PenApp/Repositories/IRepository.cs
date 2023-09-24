using PenApp.Entities;

namespace PenApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class , IEntity
    {
    }
}
