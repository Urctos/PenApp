using PenApp.Components.CsvReader.Models;

namespace PenApp.Components.CsvReader;

public interface ICsvReader
{
    List<Car> ProcessCars(string filePath);

    List<Manufacturer> ProcessManufacturers(string filePath);

    List<PenFromCsv> ProcessPenFromCsv(string filePath);

    List<FountainPenFromCsv> ProcessFountainPenFromCsv(string filePath);
}

