using PenApp.Components.CsvReader.Models;

namespace PenApp.Components.CsvReader;

public interface ICsvReader
{
    List<PenFromCsv> ProcessPenFromCsv(string filePath);
    List<FountainPenFromCsv> ProcessFountainPenFromCsv(string filePath);
}

