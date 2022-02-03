using Business_Logic_Layer.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        //public void <List<EmployeeEntity>> GetAllEmployee()
        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {

            var employee = await _employeeService.GetAllEmployee();
            return employee;

        }
    }
}