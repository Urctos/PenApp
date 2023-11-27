using PenApp.DataAccess.Data.Entities;
using PenApp.DataAccess.Data.Repositories;

namespace PenApp.Components.DataBaseComunication;

public class EditManager<T> : IEditManager<T> where T : class, IEditable, new()
{
    private readonly IRepository<T> _repository;

    public EditManager(IRepository<T> repository)
    {
        _repository = repository;
    }

    public void EditItemFromDb(T item)
    {
        var itemFromDb = _repository.GetById(item.Id);

        if (itemFromDb != null)
        {
            Console.WriteLine("Podaj nową nazwę:");
            itemFromDb.UpdateName(Console.ReadLine());

            Console.WriteLine("Podaj nową cenę:");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                itemFromDb.UpdatePrice(price);
               _repository.Save();
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
