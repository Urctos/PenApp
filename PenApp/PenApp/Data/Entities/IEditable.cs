namespace PenApp.Data.Entities
{
    public interface IEditable
    {
        void UpdateName(string newName);
        void UpdatePrice(decimal newPrice);
    }
}
