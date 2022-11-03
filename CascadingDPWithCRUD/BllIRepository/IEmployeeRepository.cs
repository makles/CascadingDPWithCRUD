using CascadingDPWithCRUD.Models;

namespace CascadingDPWithCRUD.IRepository
{
    public interface IEmployeeRepository
    {
        string InsertData(Employee employee);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        //void NewEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);
        //void Save();
    }
}
