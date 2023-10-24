
using Microsoft.Extensions.DependencyInjection;
using PenApp;
using PenApp.DataProviders;
using PenApp.Entities;
using PenApp.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Pen>, ListRepository<Pen>>();
services.AddSingleton<IPenProvider, PenProvider>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

