using Business_Logic_Layer.DTOs;
using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Service
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployee();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<EmployeeDto> InsertEmployee(EmployeeEntity emp);
        Task<EmployeeDto> UpdateEmployee(int id, EmployeeEntity emp);
        Task DeleteEmployee(int id);
    }
}