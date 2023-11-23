namespace PenApp.DataAccess.Data.Entities
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
