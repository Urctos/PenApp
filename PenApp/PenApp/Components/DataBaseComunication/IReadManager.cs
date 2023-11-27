using PenApp.DataAccess.Data.Entities;
using PenApp.DataAccess.Data.Repositories;

namespace PenApp.Components.DataBaseComunication;

public interface IReadManager<T> where T : EntityBase
{
    void ReadAllFromDb(IRepository<T> repository, Func<T, string> displayFunc);
    void ReadGroupedItemsFromDb(Func<T, object> groupByFunc, Func<T, string> displayFunc);
    void SortAllItemsByPrice();
}

