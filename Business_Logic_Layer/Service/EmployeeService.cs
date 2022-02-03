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
    }
}