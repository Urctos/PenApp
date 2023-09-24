
using PenApp.Data;
using PenApp.Entities;
using PenApp.Repositories;

Console.WriteLine("***********************************************************************");
Console.WriteLine("Aplikacja magazynowa Twojego sklepu v.01!");
Console.WriteLine("***********************************************************************");

var penRepository = new SqlRepository<Pen>(new PenAppDbContext());

bool running = true;

while (running)
{
    Console.WriteLine("Wybierz opcję:");
    Console.WriteLine();
    Console.WriteLine("1. Pokaż listę długopisów");
    Console.WriteLine("2. Pokaż listę piór wiecznych");
    Console.WriteLine("3. Wyjście");

    string imput = Console.ReadLine();

    switch (imput)
    {
        case "1":
            Console.Clear();
            AddPen(penRepository);
            WriteAllToConsole(penRepository);
            running = false;
            break;
        case "2":
            Console.Clear();
            AddFountainPen(penRepository);
            WriteAllToConsole(penRepository);
            running = false;
            break;
        case "3":
            running = false;
            break;
        default:
            Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2 lub 3.");
            break;
    }

    static void AddPen(IRepository<Pen> penRepository)
    {
        penRepository.Add(new Pen { Brand = "Parker", Id = 1, Name = "Parker Jotter Special", Price = 49 });
        penRepository.Add(new Pen { Brand = "Parker", Id = 2, Name = "IM Brushed Metal GT", Price = 139 });
        penRepository.Add(new Pen { Brand = "Waterman", Id = 3, Name = "Graduate", Price = 129 });
        penRepository.Save();
    }

    static void AddFountainPen(IWriteRepository<FountainPen> fountainRepository)
    {
        fountainRepository.Add(new FountainPen { Brand = "Parker", Id = 1, Name = "Sonnet GT", Price = 539 });
        fountainRepository.Add(new FountainPen { Brand = "Parker", Id = 2, Name = "Vector", Price = 111 });
        fountainRepository.Add(new FountainPen { Brand = "Artamis", Id = 3, Name = "Optic Fountain", Price = 69 });
        fountainRepository.Add(new FountainPen { Brand = "Waterman", Id = 4, Name = "EXPERT", Price = 549 });
        fountainRepository.Save();
    }

    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}




