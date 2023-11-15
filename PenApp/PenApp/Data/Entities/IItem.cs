using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenApp.Data.Entities
{
    public interface IItem
    {       
        string Name { get; set; }
        string? Brand { get; set; }
        string Color { get; set; }
        decimal TotalSales { get; set; }
        int Id { get; }
    }
}
