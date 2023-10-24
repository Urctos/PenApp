using PenApp.DataProviders;
using PenApp.Entities;
using PenApp.Repositories;


namespace PenApp;
public class App : IApp
{
    private readonly IRepository<Pen> _penRepository;
    private readonly IPenProvider _penProvider;


    public App(
        IRepository<Pen> penRepository,
        IPenProvider penProvider
        )
    {
        _penRepository = penRepository;
        _penProvider = penProvider;
    }

    public void Run()
    {
        DisplayMenu();
        var pens = GenerateSamplePen();
        foreach (var item in pens)
        {
            _penRepository.Add(item);
        }

        bool running = true;

        while (running)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowAllPens();
                    break;
                case "2":
                    ShowAllUniquePenColor();
                    break;
                case "3":
                    OrderByAllPenByName();
                    break;
                case "4":
                    ShowAllWhereBrandStartWith();
                    break;
                case "5":
                    ShowOrderByPrice();
                    break;
                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2, 3, 4, 5 lub 6.");
                    break;
            }
        }
    }

    private void ShowAllPens()
    {
        Console.Clear();
        var p = _penRepository.GetAll();
        foreach (var item in p)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        DisplayMenu();
    }

    private void ShowAllWhereBrandStartWith()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Wybierz Markę rozpoczynającą się na: ");
            Console.WriteLine("1: B");
            Console.WriteLine("2: P");
            Console.WriteLine("3: Z");
            Console.WriteLine("4: powrót");

            string imput = Console.ReadLine();
            switch (imput)
            {
                case "1":
                    Console.Clear();
                    foreach (var item in _penProvider.WhereStartsWith("B"))
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();

                    break;
                case "2":
                    Console.Clear();
                    foreach (var item in _penProvider.WhereStartsWith("P"))
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    foreach (var item in _penProvider.WhereStartsWith("Z"))
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    break;
                case "4":
                    Console.Clear();
                    running = false;
                    Console.WriteLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2 , 3 lub 4.");
                    break;
            }
        }
        Console.WriteLine();
        DisplayMenu();
    }

    private void ShowOrderByPrice()
    {
        Console.Clear();
        foreach (var item in _penProvider.OrderByPrice())
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        DisplayMenu();
    }

    private void ShowAllUniquePenColor()
    {
        Console.Clear();
        foreach (var item in _penProvider.GetUniquePenColors())
        {
            Console.WriteLine(item);           
        }
        Console.WriteLine();
        DisplayMenu();
    }

    private void OrderByAllPenByName()
    {
        Console.Clear();
        foreach (var item in _penProvider.OrderByName())
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        DisplayMenu();
    }


    private static void DisplayMenu()
    {
        Console.WriteLine("***********************************************************************");
        Console.WriteLine("Aplikacja magazynowa Twojego sklepu v.01!");
        Console.WriteLine("***********************************************************************");
        Console.WriteLine();
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine();
        Console.WriteLine("1. Pokaż listę długopisów!");
        Console.WriteLine("2. Pokaż wszystkie unikalne kolory długopisów!");
        Console.WriteLine("3. Pokaż wszystkie długopisy upożądkowane według imienia!");
        Console.WriteLine("4. Pokaż wszystkie produkty marek zaczynających się na literę P, B lub Z");
        Console.WriteLine("5. Posortuj dugopisy według cenny!");
        Console.WriteLine("6. Wyjście");

    }

    public static List<Pen> GenerateSamplePen()
    {
        return new List<Pen>
        {
            new Pen
            {
                Name = "JOTTER CORE STAINLESS STEEL GT",
                Brand = "Parker",
                Color = "Red",
                Price = 155.89m,
            },
            new Pen
            {
                Id = 11,
                Name = "DŁUGOPIS PARKER JOTTER XL MONOCHROME",
                Brand = "Parker",
                Color = "Blue",
                Price = 184.23m,
            },
            new Pen
            {
                Id = 12,
                Name = "DŁUGOPIS PARKER IM SE ACHROMATIC FULL BLACK",
                Brand = "Parker",
                Color = "Black",
                Price = 125.16m,
            },
            new Pen
            {
                Id = 13,
                Name = "Długopis Zenith pixel",
                Brand = "Zenith",
                Color = "Blue",
                Price = 23m,
            },
            new Pen{
                Id = 14,
                Name = "DŁUGOPIS AUTOMATYCZNY ELEGANCKI ZENITH SILVER",
                Brand = "Zenith",
                Color = "Silver",
                Price = 35.28m,
            },
            new Pen{
                Id = 15,
                Name = "DŁUGOPIS Markus",
                Brand = "PeneLUX",
                Color = "Red",
                Price = 45.88m,
            },
                new Pen{
                Id = 16,
                Name = "DŁUGOPIS Carlos",
                Brand = "PeneLUX",
                Color = "Green",
                Price = 33m,
            },
                new Pen{
                Id = 17,
                Name = "DŁUGOPIS Pawlos",
                Brand = "PeneLUX",
                Color = "Orane",
                Price = 55.25m,
            },
                new Pen{
                Id = 18,
                Name = "NTwo",
                Brand = "Beltimore",
                Color = "Pink",
                Price = 99.23m,
            },
                new Pen{
                Id = 19,
                Name = "NOne",
                Brand = "Beltimore",
                Color = "Pink",
                Price = 103m,
            }

        };

    }
}

