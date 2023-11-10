namespace PenApp.Data.Entities
{
    public interface IEditable
    {   
        int Id { get; set; }
        void UpdateName(string newName);
        void UpdatePrice(decimal newPrice);
    }
}
