using PenApp.UI.Services;

namespace PenApp.UI;

public class App : IApp
{
    private readonly IUserComunication _userComunication;

    public App(IUserComunication userComunication)
    {
        _userComunication = userComunication;
    }

    public void Run()
    {
        //_insertDataManager.InsertData();
        _userComunication.Comunication();
    }
}

