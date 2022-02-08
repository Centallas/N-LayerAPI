using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Service
{
    public interface IEmployeeService
    {
        Task<List<EmployeeEntity>> GetAllEmployee();
        Task<EmployeeEntity> GetEmployeeById(int id);
        Task<EmployeeEntity> InsertEmployee(EmployeeEntity emp);
        Task<EmployeeEntity> UpdateEmployee(int id, EmployeeEntity emp);
        Task DeleteEmployee(int id);
    }
}