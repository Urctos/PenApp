using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PenApp.Data;
using PenApp.Data.Entities;

namespace PenApp.Components.UserComunication;

public class UserComunication : IUserComunication
{
    private readonly PenAppDbContext _penAppDbContext;
    //private readonly IEditable _editable;
    //private readonly IItemWithPrice _itemWithPrice;


    public UserComunication(PenAppDbContext penAppDbContext)
    {
        _penAppDbContext = penAppDbContext;
    }


    public void Comunication()
    {
        DisplayMenu();

        bool running = true;

        while (running)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    PensSubmenu();
                    break;
                case "2":
                    Console.Clear();
                    FountainPensSubmenu();                    
                    break;
                case "3":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2, lub 3.");
                    break;
            }
        }
    }


    private void PensSubmenu()
    {
        bool backToMain = false;

        while (!backToMain)
        {
            Console.WriteLine("\n******************** MENU DŁUGOPISÓW ********************");
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Wyświetl wszystkie długopisy");
            Console.WriteLine("2. Wyświetl długopisy w podziale na marki");
            Console.WriteLine("3. Wyświetl długopisy posortowane według ceny");
            Console.WriteLine("4. Edytój wybrany długopis");
            Console.WriteLine("5. Wróć do menu głównego");
            Console.WriteLine("********************************************************");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ReadAllFromDb(_penAppDbContext.Pens, pen => $"\t{pen.GetType().Name}: {pen.Id}: {pen.Name}: {pen.Brand}: {pen.Color}: {pen.Price}: {pen.Id}: {pen.TotalSales}"); // Funkcja wyświetlająca długopisy
                    break;
                case "2":
                    ReadGroupedItemsFromDb<Pen>(
                        pen => pen.Brand,
                        pen => $"\t{pen.Name}: {pen.Price}: {pen.TotalSales}");
                    break;
                case "3":
                    SortAllItemsByPrice<Pen>();
                    break;
                case "4":
                    EditItemFromDb<Pen>();
                    break;
                case "5":
                    backToMain = true;
                    Console.Clear();
                    DisplayMenu();
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz od 1 do 5.");
                    break;
            }
        }
    }

    private void FountainPensSubmenu()
    {
        bool backToMain = false;

        while (!backToMain)
        {
            Console.WriteLine("\n******************** MENU PIÓR WIECZNYCH ********************");
            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Wyświetl wszystkie pióra wieczne");
            Console.WriteLine("2. Wyświetl pióra wieczne w podziale na marki");
            Console.WriteLine("3. Wyświetl pióra wieczne posortowane według ceny");
            Console.WriteLine("4. Edytój wybrane pióro wieczne");
            Console.WriteLine("5. Wróć do menu głównego");
            Console.WriteLine("********************************************************");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ReadAllFromDb(_penAppDbContext.FountainPens, fountainPen => $"\t{fountainPen.GetType().Name}: {fountainPen.Id}: {fountainPen.Name}: {fountainPen.Brand}: {fountainPen.Color}: {fountainPen.Price}: {fountainPen.Id}: {fountainPen.TotalSales}");
                    break;
                case "2":
                    ReadGroupedItemsFromDb<FountainPen>(
                        fountainPen => fountainPen.Brand,
                        fountainPen => $"\t{fountainPen.Name}: {fountainPen.Price}: {fountainPen.TotalSales}");                    
                    break;
                case "3":
                    SortAllItemsByPrice<FountainPen>();
                    break;
                case "4":
                    EditItemFromDb<FountainPen>();
                    break;
                case "5":
                    backToMain = true;
                    Console.Clear();
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz od 1 do 5.");
                    break;
            }
        }
    }


    private void ReadAllFromDb<T>(DbSet<T> dbSet, Func<T, string> displayFunc) where T : class
    {
        var itemsFromDb = dbSet.ToList();

        foreach (var itemFromDb in itemsFromDb)
        {
            var displayString = displayFunc(itemFromDb);
            Console.WriteLine(displayString);
        }
    }


    private void ReadGroupedItemsFromDb<T>(Func<T, object> groupByFunc, Func<T, string> displayFunc) where T : class
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



    private void SortAllItemsByPrice<T>() where T : EntityBase, IItemWithPrice
    {
        var itemsFromDb = _penAppDbContext.Set<T>().OrderBy(item => ((IItemWithPrice)item).Price).ToList();

        foreach (var itemFromDb in itemsFromDb)
        {
            Console.WriteLine($"{itemFromDb.Id}: {((IItem)itemFromDb).Name}: {((IItem)itemFromDb).Brand}: {((IItem)itemFromDb).Color}: {((IItemWithPrice)itemFromDb).Price}: {((IItem)itemFromDb).TotalSales}");
        }
    }


    private T ReadItemFromDb<T>(int id) where T : class
    {
        return _penAppDbContext.Set<T>().Find(id);
    }

    private void EditItemFromDb<T>() where T : class, IEditable
    {
        Console.WriteLine($"Podaj ID obiektu {typeof(T).Name} do edycji:");
        if (int.TryParse(Console.ReadLine(), out int itemId))
        {
            var itemFromDb = _penAppDbContext.Set<T>().Find(itemId);

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
                DisplayMenu();
                Console.WriteLine($"{typeof(T).Name} o podanym identyfikatorze nie istnieje.");
            }
        }
        else
        {
            Console.WriteLine($"Nieprawidłowe ID {typeof(T).Name}. Edycja anulowana.");
        }
    }



    public void DisplayMenu()
    {
        Console.WriteLine("***********************************************************************");
        Console.WriteLine("Aplikacja magazynowa Twojego sklepu v.01!");
        Console.WriteLine("***********************************************************************");
        Console.WriteLine();
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine();
        Console.WriteLine("1. Wybież menu długopisów");
        Console.WriteLine("2. Wybież menu piór wiecznych");
        Console.WriteLine("3. Wyjście");
    }
}

