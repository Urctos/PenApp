using Microsoft.EntityFrameworkCore.Design;
using PenApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenApp.Components.XmlReader;

public  interface IXmlReader 
{
    public void CreateXml(List<Car> records, List<Manufacturer> records2);
    public void QueryXml();
}

