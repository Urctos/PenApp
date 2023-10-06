
using Newtonsoft.Json;
using PenApp.Data;
using PenApp.Entities;
using PenApp.Repositories;
using PenApp.Repositories.Extensions;
using PenApp.Entities.Extensions;



string auditFilePath = "D:\\KURS C#\\AuditLog.txt";
using (StreamWriter writer = File.AppendText(auditFilePath))
{
    writer.WriteLine("Rozpoczęto logowanie: " + DateTime.Now);
}


Console.WriteLine("***********************************************************************");
Console.WriteLine("Aplikacja magazynowa Twojego sklepu v.01!");
Console.WriteLine("***********************************************************************");


var penRepository = new SqlRepository<Pen>(new PenAppDbContext());
var fountainPenRepository = new SqlRepository<FountainPen>(new PenAppDbContext());

penRepository.ItemAdded += (sender, e) => PenRepositoryOnItemAdded(sender, e, auditFilePath);
fountainPenRepository.ItemAdded += (sender, e) => FountainPenRepositoryOnItemAdded(sender, e, auditFilePath);


static void PenRepositoryOnItemAdded(object? sender, Pen e, string auditFilePath)
{
    Console.WriteLine($"Pen added => {e.Name} from {sender?.GetType().Name}");
    using (StreamWriter writer = File.AppendText(auditFilePath))
    {
        string auditMessage = $"{DateTime.Now}: Pen added => {e.Name} from {sender?.GetType().Name}";
        writer.WriteLine(auditMessage);
    }
}


static void FountainPenRepositoryOnItemAdded(object? sender, FountainPen e, string auditFilePath)
{
    Console.WriteLine($"FountPen added => {e.Name} from {sender?.GetType().Name}");
    File.AppendAllText(auditFilePath, $"{DateTime.Now}: FountPen added => {e.Name} from {sender?.GetType().Name}");
    using (StreamWriter writer = File.AppendText(auditFilePath))
    {
            string auditMessage = $"{DateTime.Now}: Pen added => {e.Name} from {sender?.GetType().Name}";
            writer.WriteLine(auditMessage);
    }
}


string fountainPenJsonFilePath = "D:\\KURS C#\\JSON\\fountainPens.json";
string penJsonFilePath = "D:\\KURS C#\\JSON\\pens.json";

bool running = true;

while (running)
{
    Console.WriteLine("Wybierz opcję:");
    Console.WriteLine();
    Console.WriteLine("1. Pokaż listę długopisów");
    Console.WriteLine("2. Pokaż listę piór wiecznych");
    Console.WriteLine("3. Wczytaj listę długopisów");
    Console.WriteLine("4. Wczytaj listę piór wiecznych");
    Console.WriteLine("5. Wyjście");

    string imput = Console.ReadLine();

    switch (imput)
    {
        case "1":
            //Console.Clear();
            //AddPen(penRepository, penJsonFilePath, (pens, filePath) => SaveToJson(pens, filePath));
            //Console.WriteLine();
            //WriteAllToConsole(penRepository);

            break;
        case "2":
            Console.Clear();
            AddFountainPen(penRepository, fountainPenJsonFilePath);
            Console.WriteLine();
            WriteAllToConsole(penRepository);
            break;
        case "3":
            Console.Clear();
            IEnumerable<Pen> loadedPens = penJsonFilePath.LoadFromJson<Pen>();
            WriteJsonToConsole(loadedPens);
            break;
        case "4":
            Console.Clear();
            IEnumerable<FountainPen> loadedFountainPens = fountainPenJsonFilePath.LoadFromJson<FountainPen>();
            WriteJsonToConsole(loadedFountainPens);
            break;
        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Nieprawidłowy wybór. Wybierz 1, 2 lub 3.");
            break;

    }
}
static void AddPen(IRepository<Pen> penRepository, string penJsonFilePath, Action<IEnumerable<Pen>, string>  saveFunction )
{
    var pens = new[]
    {
        new Pen {Name = "Parker Jotter Special"},
        new Pen {Name = "IM Brushed Metal GT"},
        new Pen {Name = "Graduate"},
        new Pen {Name = "dddddddddddd"},
    };

    List<Pen> penList = pens.ToList();

    penRepository.AddBatch(pens);
    saveFunction(pens, penJsonFilePath);
}
//string penJsonFile = JsonConvert.SerializeObject(penList, Formatting.Indented);
//File.WriteAllText(penJsonFilePath, penJsonFile);
//SaveToJson<Pen>(pens, penJsonFilePath);

static void AddFountainPen(IWriteRepository<FountainPen> fountainPenRepository, string fountainPenJsonFilePath)
{
    var fountainPens = new[]
    {
        new FountainPen { Brand = "Parker", Id = 1, Name = "Sonnet GT", Price = 539 },
        new FountainPen { Brand = "Parker", Id = 2, Name = "Vector", Price = 111 },
        new FountainPen { Brand = "Artamis", Id = 3, Name = "Optic Fountain", Price = 69 },
        new FountainPen { Brand = "Waterman", Id = 4, Name = "EXPERT", Price = 549 },
    };
    List<FountainPen> fountainPenList = fountainPens.ToList();
    string fountainPenJsonFile = JsonConvert.SerializeObject(fountainPenList, Formatting.Indented);
    File.WriteAllText(fountainPenJsonFilePath, fountainPenJsonFile);
    fountainPenRepository.AddBatch(fountainPens);
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void WriteJsonToConsole<T>(IEnumerable<T> data)
{
    foreach (var item in data)
    {
        Console.WriteLine(item);
    }

}


File.AppendAllText(auditFilePath, "Zakończono działanie aplikacji.");
