using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public interface IEmployee
    {        
        Task<List<EmployeeEntity>> GetAllEmployee();
        Task<EmployeeEntity> GetEmployeeById(int id);
        Task<string> InsertEmployee(EmployeeEntity emp);
        Task<string> UpdateEmployee(int id, EmployeeEntity emp);
        Task<string> DeleteEmployee(int id);


    }
}