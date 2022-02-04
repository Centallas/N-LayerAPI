using Business_Logic_Layer.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]       
        public async Task<List<EmployeeEntity>> GetAllEmployee()
        {

            var employee = await _employeeService.GetAllEmployee();
            return employee;

        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<List<EmployeeEntity>> Get(int id)
        {
            return await _employeeService.GetEmployeeById(id);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<string> Post([FromBody] EmployeeEntity emp)
        {
            return await _employeeService.InsertEmployee(emp);
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] EmployeeEntity emp)
        {
            return await _employeeService.UpdateEmployee(id, emp);
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            return await _employeeService.DeleteEmployee(id);
        }


    }
}