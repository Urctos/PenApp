using PenApp.DataAccess.Data.Entities;

namespace PenApp.DataAccess.Data.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {
    }
}
