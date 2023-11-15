
using PenApp.Components.CsvReader.Extensions;
using PenApp.Components.CsvReader.Models;

namespace PenApp.Components.CsvReader;

public class CsvReader : ICsvReader
{
    public List<PenFromCsv> ProcessPenFromCsv(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<PenFromCsv>();
        }

        var pens = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToPen();

        return pens.ToList();
    }

    public List<FountainPenFromCsv> ProcessFountainPenFromCsv(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<FountainPenFromCsv>();
        }

        var fountainPens = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToFountainPen();

        return fountainPens.ToList();
    }
}

