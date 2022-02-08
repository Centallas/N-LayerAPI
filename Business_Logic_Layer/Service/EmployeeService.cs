using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Entity;

namespace Business_Logic_Layer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployee _employee;

        public EmployeeService(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<List<EmployeeEntity>>GetAllEmployee()
        {
            var resService = await _employee.GetAllEmployee();
            return resService;
        }
        public async Task<EmployeeEntity> GetEmployeeById(int id)
        {
            return await _employee.GetEmployeeById(id);
        }
        public async Task<EmployeeEntity> InsertEmployee(EmployeeEntity emp)
        {
            return await _employee.InsertEmployee(emp);
        }
        public async Task<EmployeeEntity> UpdateEmployee(int id, EmployeeEntity emp)
        {
            return await _employee.UpdateEmployee(id, emp);
        }
        public async Task DeleteEmployee(int id)
        {
           await _employee.DeleteEmployee(id);
        }
    }
}