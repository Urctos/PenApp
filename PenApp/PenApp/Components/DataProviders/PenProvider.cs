using PenApp.Data.Entities;
using PenApp.Data.Repositories;

namespace PenApp.Components.DataProviders;

public class PenProvider : IPenProvider
{
    private IRepository<Pen> _penRepository;

    public PenProvider(IRepository<Pen> penRepository)
    {
        _penRepository = penRepository;
    }

    public List<string> DistinctAllColors()
    {
        var pens = _penRepository.GetAll();
        return pens
            .Select(x => x.Color)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public decimal GetMinimumPriceOfAllPens()
    {
        var pens = _penRepository.GetAll();
        return pens.Select(x => x.Price).Min();

    }

    public List<Pen> GetSpecificColumn()
    {
        var pens = _penRepository.GetAll();
        var list = pens.Select(pen => new Pen
        {
            Id = pen.Id,
            Name = pen.Name,
            Brand = pen.Brand
        }).ToList();

        return list;

    }

    public List<string> GetUniquePenColors()
    {
        var pens = _penRepository.GetAll();
        var colors = pens.Select(x => x.Color).Distinct().ToList();
        return colors;
    }

    public List<Pen> OrderByColorAndName()
    {
        var pens = _penRepository.GetAll();
        return pens
            .OrderBy(x => x.Color)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<Pen> OrderByName()
    {
        var pens = _penRepository.GetAll();
        return pens
            .OrderBy(x => x.Name)
            .ToList();
    }

    public List<Pen> OrderByPrice()
    {
        var pens = _penRepository.GetAll();
        return pens
            .OrderBy(x => x.Price)
            .ToList();
    }

    public List<Pen> WhereStartsWith(string prefix)
    {
        var pens = _penRepository.GetAll();
        return pens.Where(x => x.Brand.StartsWith(prefix)).ToList();
    }

    public List<Pen> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal price)
    {
        var pens = _penRepository.GetAll();
        return pens.Where(x => x.Name.StartsWith(prefix) && x.Price > price).ToList();
    }
}

