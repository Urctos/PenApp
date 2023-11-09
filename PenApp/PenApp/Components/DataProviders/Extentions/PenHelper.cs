using PenApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenApp.Components.DataProviders.Extentions
{
    public static class PenHelper
    {
        public static IEnumerable<Pen> ByColor(this IEnumerable<Pen> query, string color)
        {
            return query.Where(x => x.Color == color);
        }
    }
}
