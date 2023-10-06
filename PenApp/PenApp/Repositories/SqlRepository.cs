using Microsoft.EntityFrameworkCore;
using PenApp.Entities;
using System.Xml.Linq;


namespace PenApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
<<<<<<< HEAD
       

        public SqlRepository(DbContext dbContext )
=======

        public SqlRepository(DbContext dbContext)
>>>>>>> 1e6be829fd3e870d584b0928cb1a5971be25b8d0
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

<<<<<<< HEAD
        public event EventHandler<T>? ItemAdded;

=======
>>>>>>> 1e6be829fd3e870d584b0928cb1a5971be25b8d0
        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();   
        }


<<<<<<< HEAD
        public T? GetById(int id)
=======
        public T GetById(int id)
>>>>>>> 1e6be829fd3e870d584b0928cb1a5971be25b8d0
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
<<<<<<< HEAD
            ItemAdded?.Invoke(this, item);
=======
>>>>>>> 1e6be829fd3e870d584b0928cb1a5971be25b8d0
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }


        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
