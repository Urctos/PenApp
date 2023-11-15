using Newtonsoft.Json;
using PenApp.Data.Entities;
using PenApp.Data.Repositories;
using System.Xml;


namespace PenApp.Data.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }

        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
            where T : class, IEntity
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}
