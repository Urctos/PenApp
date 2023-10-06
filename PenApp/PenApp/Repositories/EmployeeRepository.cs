using PenApp.Entities;

namespace PenApp.Repositories
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employee = new();

        public void Add(Employee employee)
        {
            employee.Id = _employee.Count + 1;
            _employee.Add(employee);
        }

        public void Save()
        {
            foreach (var employee in _employee)
            {
                Console.WriteLine(employee);
            }
        }

        public Employee GetEmployee(int id)
        {
            return _employee.Single(x => x.Id == id);
        }
    }
}
