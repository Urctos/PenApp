using PenApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PenApp.Components.XmlReader;

public class XmlReader : IXmlReader
{

    public void CreateXml(List<Car> records, List<Manufacturer> records2)
    {


    var document = new XDocument();

        var manufacturers = new XElement("Manufacturers", records2
            .Select(m =>
                new XElement("Manufacturer",
                    new XAttribute("Name", m.Name),
                    new XAttribute("Country", m.Country),
                    records
                        .Where(c => c.Manufacturer == m.Name)
                        .GroupBy(c => c.Manufacturer)
                        .Select(cg =>
                        new XElement("Cars",
                            new XAttribute("country", m.Country),
                            new XAttribute("CombinedSum", cg.Sum(c => c.Combined)),
                            cg.Select(c =>
                                new XElement("Car",
                                    new XAttribute("Name", c.Name),
                                    new XAttribute("Combined", c.Combined)
                            )))))));

        document.Add(manufacturers);
        document.Save("combined.xml");
    }


    public void QueryXml()
    {
        var document = XDocument.Load("fuel.xml");
        var names = document
            .Element("Cars")?
            .Elements("Car")
            .Where(x => x.Attribute("Manufacturer")?.Value == "BMW")
            .Select(x => x.Attribute("Name")?.Value);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}
