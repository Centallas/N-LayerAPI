using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Service
{
    public interface IEmployeeService
    {
        Task<List<EmployeeEntity>> GetAllEmployee();
        Task<List<EmployeeEntity>> GetEmployeeById(int id);
        Task<string> InsertEmployee(EmployeeEntity emp);
        Task<string> UpdateEmployee(int id, EmployeeEntity emp);
        Task<string> DeleteEmployee(int id);
    }
}