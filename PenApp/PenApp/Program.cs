
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PenApp;
using PenApp.Components.CsvReader;
using PenApp.Components.DataBaseComunication;
using PenApp.Components.DataProviders;
using PenApp.Components.UserComunication;
using PenApp.Data;
using PenApp.Data.Entities;
using PenApp.Data.Repositories;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Pen>, ListRepository<Pen>>();
services.AddSingleton<IPenProvider, PenProvider>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IUserComunication, UserComunication>();
services.AddSingleton<IEditable, Pen>();
services.AddSingleton<IEditable, FountainPen>();
services.AddSingleton<IItemWithPrice, Pen>();
services.AddSingleton<IItemWithPrice, FountainPen>();
services.AddSingleton<IItem, Pen>();
services.AddSingleton<IItem, FountainPen>();
services.AddSingleton(typeof(IReadManager<>), typeof(ReadManager<>));
services.AddScoped<IEditManager<Pen>, EditManager<Pen>>();
services.AddScoped<IEditManager<FountainPen>, EditManager<FountainPen>>();
//services.AddScoped<SqlRepository<Pen>>();
//services.AddScoped<SqlRepository<FountainPen>>();
services.AddScoped<IRepository<Pen>, SqlRepository<Pen>>();
services.AddScoped<IRepository<FountainPen>, SqlRepository<FountainPen>>();
services.AddDbContext<PenAppDbContext>(options => options

    .UseSqlServer("Data Source=DESKTOP-DNO5S49\\SQLEXPRESS;Initial Catalog=PenAppStorage;Integrated Security=True;TrustServerCertificate=true"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

