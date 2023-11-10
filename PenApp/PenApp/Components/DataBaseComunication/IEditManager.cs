using PenApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenApp.Components.DataBaseComunication;

public interface IEditManager<T> where T : class, IEditable
{
    void EditItemFromDb(T item);
}

