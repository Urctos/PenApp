using PenApp.Components.CsvReader;
using PenApp.Components.UserComunication;
using PenApp.Data;
using PenApp.Data.Entities;

namespace PenApp;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly IUserComunication _userComunication;
    private readonly PenAppDbContext _penAppDbContext;
    public App(ICsvReader csvReader, IUserComunication userComunication, PenAppDbContext penAppDbContext)
    {
        _csvReader = csvReader;
        _userComunication = userComunication;
        _penAppDbContext = penAppDbContext;
        _penAppDbContext.Database.EnsureCreated();
    }

    public void Run()
    {
        //InsertData(); d

        _userComunication.Comunication();
    }

    private void InsertData()
    {
        var pens = _csvReader.ProcessPenFromCsv("Resources\\Files\\pen.csv");

        foreach (var pen in pens)
        {
            _penAppDbContext.Pens.Add(new Pen()
            {
                Name = pen.Name,
                Brand = pen.Brand,
                Color = pen.Color,
                Price = pen.Price,
                TotalSales = pen.TotalSales
            });
        }

        var foutainPens = _csvReader.ProcessFountainPenFromCsv("Resources\\Files\\foutainPen.csv");

        foreach (var fountainPen in foutainPens)
        {
            _penAppDbContext.FountainPens.Add(new FountainPen()
            { 
                Name = fountainPen.Name,
                Brand = fountainPen.Brand,
                Color = fountainPen.Color,
                Price = fountainPen.Price,
                TotalSales = fountainPen.TotalSales
            });
        }
        _penAppDbContext.SaveChanges();
    }
}

