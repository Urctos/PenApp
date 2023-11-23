using PenApp.Components.CsvReader;
using PenApp.Components.DataBaseComunication;
using PenApp.DataAccess.Data.Entities;
using PenApp.DataAccess.Data.Repositories;
using PenApp.UI.Services;

namespace PenApp.UI;

public class App : IApp
{
    private readonly ICsvReader _csvReader;
    private readonly IUserComunication _userComunication;
    private readonly IRepository<Pen> _penRepository;
    private readonly IRepository<FountainPen> _fountainPenRepository;
    private readonly IInsertDataManager _insertDataManager;
    public App(ICsvReader csvReader, IUserComunication userComunication
    , IRepository<Pen> penRepository, IRepository<FountainPen> fountainPenRepository, IInsertDataManager insertDataManager)
    {
        _csvReader = csvReader;
        _userComunication = userComunication;
        _penRepository = penRepository;
        _fountainPenRepository = fountainPenRepository;
        _insertDataManager = insertDataManager;
    }

    public void Run()
    {
        //_insertDataManager.InsertData();
        _userComunication.Comunication();
    }
}

