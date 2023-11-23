using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PenApp.Components.DataBaseComunication;
using PenApp.Data;
using PenApp.DataAccess.Data.Entities;
using PenApp.DataAccess.Data.Repositories;

namespace PenApp.UI.Services;

public class UserComunication : IUserComunication
{
    private readonly IRepository<Pen> _penRepository;
    private readonly IRepository<FountainPen> _fountainPenRepository;
    private readonly IReadManager<Pen> _penReadManager;
    private readonly IReadManager<FountainPen> _fountainPenReadManager;
    private readonly IEditManager<Pen> _penEditManager;
    private readonly IEditManager<FountainPen> _fountainPenEditManager;

    public UserComunication(IRepository<Pen> penRepository, IRepository<FountainPen> fountainPenRepository
        , IReadManager<Pen> penReadManager, IReadManager<FountainPen> fountainPenReadManager
        , IEditManager<Pen> penEditManager, IEditManager<FountainPen> fountainPenEditManager)
    {
        _penRepository = penRepository;
        _fountainPenRepository = fountainPenRepository;
        _penReadManager = penReadManager;
        _fountainPenReadManager = fountainPenReadManager;
        _penEditManager = penEditManager;
        _fountainPenEditManager = fountainPenEditManager;
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
                    _penReadManager.ReadAllFromDb(_penRepository, pen => $"\t{pen.GetType().Name}: {pen.Id}: " +
                    $"{pen.Name}: {pen.Brand}: {pen.Color}: {pen.Price}: {pen.Id}: {pen.TotalSales}");
                    break;
                case "2":
                    _penReadManager.ReadGroupedItemsFromDb(pen => pen.Brand, pen => $"\t{pen.Name}: {pen.Price}: {pen.TotalSales}");
                    break;
                case "3":
                    _penReadManager.SortAllItemsByPrice();
                    break;
                case "4":
                    Console.WriteLine($"Podaj ID obiektu {_penEditManager.GetType().GenericTypeArguments[0].Name} do edycji:");
                    if (int.TryParse(Console.ReadLine(), out int itemId))
                    {
                        var penToEdit = _penRepository.GetById(itemId);
                        _penEditManager.EditItemFromDb(penToEdit);
                    }
                    else
                    {
                        Console.WriteLine($"Nieprawidłowe ID {_penEditManager.GetType().GenericTypeArguments[0].Name}. Edycja anulowana.");
                    }
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
                    _fountainPenReadManager.ReadAllFromDb(_fountainPenRepository, fountainPen => $"\t{fountainPen.GetType().Name}: {fountainPen.Id}: " +
                    $"{fountainPen.Name}: {fountainPen.Brand}: {fountainPen.Color}: {fountainPen.Price}: {fountainPen.Id}: {fountainPen.TotalSales}");

                    break;
                case "2":
                    _fountainPenReadManager.ReadGroupedItemsFromDb(fountainPen => fountainPen.Brand, fountainPen => $"\t{fountainPen.Name}: {fountainPen.Price}: {fountainPen.TotalSales}");
                    break;
                case "3":
                    _fountainPenReadManager.SortAllItemsByPrice();
                    break;
                case "4":
                    Console.WriteLine($"Podaj ID obiektu {_fountainPenEditManager.GetType().GenericTypeArguments[0].Name} do edycji:");
                    if (int.TryParse(Console.ReadLine(), out int fountainPenItemId))
                    {
                        var fountainPenToEdit = _fountainPenRepository.GetById(fountainPenItemId);
                        _fountainPenEditManager.EditItemFromDb(fountainPenToEdit);
                    }
                    else
                    {
                        Console.WriteLine($"Nieprawidłowe ID {_fountainPenEditManager.GetType().GenericTypeArguments[0].Name}. Edycja anulowana.");
                    }
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

