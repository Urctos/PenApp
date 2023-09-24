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
        public decimal? Price { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Brand: {Brand}, Price: {Price} zł";
             
    }
}
