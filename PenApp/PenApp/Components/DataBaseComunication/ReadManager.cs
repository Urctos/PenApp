using Microsoft.EntityFrameworkCore;
using PenApp.Data;
using PenApp.Data.Entities;

namespace PenApp.Components.DataBaseComunication;

public class ReadManager<T> : IReadManager<T> where T : EntityBase, IItemWithPrice
{
    private readonly PenAppDbContext _penAppDbContext;

    public ReadManager(PenAppDbContext penAppDbContext)
    {
        _penAppDbContext = penAppDbContext;
    }

    public void ReadAllFromDb(DbSet<T> dbSet, Func<T, string> displayFunc) 
    {
        var itemsFromDb = dbSet.ToList();

        foreach (var itemFromDb in itemsFromDb)
        {
            var displayString = displayFunc(itemFromDb);
            Console.WriteLine(displayString);
        }
    }

    public void ReadGroupedItemsFromDb(Func<T, object> groupByFunc, Func<T, string> displayFunc)
    {
        var groups = _penAppDbContext
            .Set<T>()
            .GroupBy(groupByFunc)
            .Select(x => new
            {
                Name = x.Key,
                Items = x.ToList()
            })
            .ToList();

        foreach (var group in groups)
        {
            Console.WriteLine(group.Name);
            Console.WriteLine("=========");
            foreach (var item in group.Items)
            {
                Console.WriteLine(displayFunc(item));
            }
            Console.WriteLine();
        }
    }

    public void SortAllItemsByPrice() 
    {
        var itemsFromDb = _penAppDbContext.Set<T>().OrderBy(item => ((IItemWithPrice)item).Price).ToList();

        foreach (var itemFromDb in itemsFromDb)
        {
            Console.WriteLine($"{itemFromDb.Id}: {((IItem)itemFromDb).Name}: {((IItem)itemFromDb).Brand}: {((IItem)itemFromDb).Color}: {((IItemWithPrice)itemFromDb).Price}: {((IItem)itemFromDb).TotalSales}");
        }
    }
}

