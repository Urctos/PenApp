using PenApp.Components.CsvReader;
using PenApp.DataAccess.Data.Entities;
using PenApp.DataAccess.Data.Repositories;

namespace PenApp.Components.DataBaseComunication;

public class InsertDataManager : IInsertDataManager
{ 
    private readonly IRepository<Pen> _penRepository;
    private readonly IRepository<FountainPen> _fountainPenrepository;
    private readonly ICsvReader _csvReader;
   

    public InsertDataManager(ICsvReader csvReader, IRepository<Pen> penRepository
    , IRepository<FountainPen> fountainPenRepository)
    {
        _csvReader = csvReader;
        _penRepository = penRepository;
        _fountainPenrepository = fountainPenRepository;
        
    }


    public void InsertData()
    {
        var pens = _csvReader.ProcessPenFromCsv("Resources\\Files\\pen.csv");

        foreach (var pen in pens)
        {
            _penRepository.Add(new Pen()
            {
                Name = pen.Name,
                Brand = pen.Brand,
                Color = pen.Color,
                Price = pen.Price,
                TotalSales = pen.TotalSales
            });
        }
        _penRepository.Save();

        var foutainPens = _csvReader.ProcessFountainPenFromCsv("Resources\\Files\\foutainPen.csv");

        foreach (var fountainPen in foutainPens)
        {
            _fountainPenrepository.Add(new FountainPen()
            {
                Name = fountainPen.Name,
                Brand = fountainPen.Brand,
                Color = fountainPen.Color,
                Price = fountainPen.Price,
                TotalSales = fountainPen.TotalSales
            });
        }
        _fountainPenrepository.Save();
    }
}

