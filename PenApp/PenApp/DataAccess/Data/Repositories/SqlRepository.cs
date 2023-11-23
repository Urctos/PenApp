using Microsoft.EntityFrameworkCore;
using PenApp.DataAccess.Data.Entities;

namespace PenApp.DataAccess.Data.Repositories;

public class SqlRepository<T> : IRepository<T> 
    where T : class, IEntity, new()
{
    private readonly PenAppDbContext _penAppDbContext;
    private readonly DbSet<T> _dbSet;

    public event EventHandler<T>? ItemAdded;

    public SqlRepository(PenAppDbContext penAppDbContext)
    {
        _penAppDbContext = penAppDbContext;
        _dbSet = _penAppDbContext.Set<T>();
        _penAppDbContext.Database.EnsureCreated();
    }

    public IEnumerable<T> GetAll()
    {
        return _penAppDbContext.Set<T>().OrderBy(item => item.Id).ToList();
    }

    public T? GetById(int id)
    {
        return _penAppDbContext.Set<T>().Find(id);
    }

    public void Add(T item)
    {
        _penAppDbContext.Set<T>().Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _penAppDbContext.Set<T>().Remove(item);
    }

    public void Save()
    {
        _penAppDbContext.SaveChanges();
    }
}
