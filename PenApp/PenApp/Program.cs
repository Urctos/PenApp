
using Microsoft.Extensions.DependencyInjection;
using PenApp;
using PenApp.Components.CsvReader;
using PenApp.Components.DataProviders;
using PenApp.Components.XmlReader;
using PenApp.Data.Entities;
using PenApp.Data.Repositories;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Pen>, ListRepository<Pen>>();
services.AddSingleton<IPenProvider, PenProvider>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IXmlReader, XmlReader>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();

