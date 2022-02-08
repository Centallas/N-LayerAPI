using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public interface IEmployee
    {        
        Task<List<EmployeeEntity>> GetAllEmployee();
        Task<EmployeeEntity> GetEmployeeById(int id);
        Task<EmployeeEntity> InsertEmployee(EmployeeEntity emp);
        Task<EmployeeEntity> UpdateEmployee(int id, EmployeeEntity emp);
        Task DeleteEmployee(int id);


    }
}