﻿using PenApp.Components.CsvReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenApp.Components.CsvReader.Extensions
{
    public static class FountainPenFromCsvExtensions
    {
        public static IEnumerable<FountainPenFromCsv> ToFountainPen(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new FountainPenFromCsv
                {
                    Name = columns[0],
                    Brand = columns[1],
                    Color = columns[2],
                    Price = decimal.Parse(columns[3]),
                    TotalSales = decimal.Parse(columns[4])
                };
            }
        }
    }
}
