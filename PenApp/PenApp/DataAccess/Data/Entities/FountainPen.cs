namespace PenApp.DataAccess.Data.Entities
{
    public class FountainPen : EntityBase, IEditable, IItemWithPrice
    { 
        public FountainPen()
        {
        }

        public FountainPen(string Name)
        {

        }

        public string? Name { get; set; }
        public string? Brand { get; set; } 
        public string Color { get; set; }
        public decimal Price { get; set; }
        public decimal TotalSales { get; set; }

        public void UpdateName(string newName)
        {
            this.Name = newName;
        }

        public void UpdatePrice(decimal newPrice)
        {
            this.Price = newPrice;
        }
    }
}
