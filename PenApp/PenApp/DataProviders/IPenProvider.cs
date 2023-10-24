using PenApp.Entities;

namespace PenApp.DataProviders;

public interface IPenProvider
{
    List<string> GetUniquePenColors();

    decimal GetMinimumPriceOfAllPens();

    List<Pen> GetSpecificColumn();

    List<Pen> OrderByName();

    List<Pen> OrderByPrice();

    List<Pen> OrderByColorAndName();

    List<Pen> WhereStartsWith(string prefix);

    List<Pen> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    List<string> DistinctAllColors();

}

