using PenApp.DataAccess.Data.Entities;

namespace PenApp.DataAccess.Data.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
