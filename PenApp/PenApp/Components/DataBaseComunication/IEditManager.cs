using PenApp.DataAccess.Data.Entities;

namespace PenApp.Components.DataBaseComunication;

public interface IEditManager<T> where T : class, IEditable
{
    void EditItemFromDb(T item);
}

