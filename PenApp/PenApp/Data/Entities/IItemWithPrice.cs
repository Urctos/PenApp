namespace PenApp.Data.Entities
{
    public interface IItemWithPrice : IItem
    {
        decimal Price { get; set; }
    }
}
