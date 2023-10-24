using System.Globalization;

namespace PenApp.Entities
{
    public class Pen : EntityBase
    {
        public Pen()
        {
        }

        public Pen(string Name)
        {

        }

        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int? NameLength { get; set; }
        public decimal TotalSales { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Brand: {Brand}, Price: {Price} zł, NameLength: {NameLength} Total: {TotalSales}";

        //public override string ToString()
        //{
        //    StringBuilder sb = new(1024);
        //    sb.AppendLine($"{Name} ID: {Id}");
        //    sb.AppendLine($"   Brand: {Brand} Price: {Price} Color: {Color}");
        //    if (NameLength.HasValue)
        //    {
        //        sb.AppendLine($"Name Length: {NameLength}");
        //    }
        //    if (TotalSales.HasValue)
        //    {
        //        sb.AppendLine($"Total Sales: {TotalSales}");
        //    }
        //    return sb.ToString();
        //}

    }
}
