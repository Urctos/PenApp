 
namespace PenApp.Entities
{
    public class Employee : EntityBase
    {
        public Employee()
        {
            
        }

        public Employee(string name)
        {
            
        }

        public string? FirstName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}
