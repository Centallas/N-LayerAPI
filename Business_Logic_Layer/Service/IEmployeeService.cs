using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Service
{
    public interface IEmployeeService
    {
        Task<List<EmployeeEntity>> GetAllEmployee();
    }
}