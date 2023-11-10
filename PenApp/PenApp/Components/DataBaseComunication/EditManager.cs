using PenApp.Data;
using PenApp.Data.Entities;

namespace PenApp.Components.DataBaseComunication;

public class EditManager<T> : IEditManager<T> where T : class, IEditable
{
    private readonly PenAppDbContext _penAppDbContext;

    public EditManager(PenAppDbContext penAppDbContext)
    {
        _penAppDbContext = penAppDbContext;
    }

    public void EditItemFromDb(T item)
    {
        var itemFromDb = _penAppDbContext.Set<T>()
            .Find(item.Id);

        if (itemFromDb != null)
        {
            Console.WriteLine("Podaj nową nazwę:");
            itemFromDb.UpdateName(Console.ReadLine());

            Console.WriteLine("Podaj nową cenę:");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                itemFromDb.UpdatePrice(price);
                _penAppDbContext.SaveChanges();
                Console.WriteLine($"{typeof(T).Name} został zaktualizowany.");
            }
            else
            {
                Console.WriteLine("Nieprawidłowa cena. Edycja anulowana.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"{typeof(T).Name} o podanym identyfikatorze nie istnieje.");
        }
    }
}
