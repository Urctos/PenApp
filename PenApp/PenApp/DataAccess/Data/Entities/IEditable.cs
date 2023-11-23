namespace PenApp.DataAccess.Data.Entities
{
    public interface IEditable : IEntity
    {   
        void UpdateName(string newName);
        void UpdatePrice(decimal newPrice);
    }
}
