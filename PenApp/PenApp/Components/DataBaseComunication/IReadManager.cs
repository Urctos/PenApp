using Microsoft.EntityFrameworkCore;
using PenApp.Data.Entities;

namespace PenApp.Components.DataBaseComunication;

public interface IReadManager<T> where T : EntityBase
{
    void ReadAllFromDb(DbSet<T> dbSet, Func<T, string> displayFunc);
    void ReadGroupedItemsFromDb(Func<T, object> groupByFunc, Func<T, string> displayFunc);
    void SortAllItemsByPrice();
}

