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

        //https://stackoverflow.com/questions/54432916/asp-net-core-api-actionresultt-vs-async-taskt/54432964
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {

            List<EmployeeEntity> employee = await _employeeService.GetAllEmployee();

            if (Equals(employee, null))
            {
                return NotFound();
            }
            return Ok(employee);

        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (Equals(employee, null) || (Equals(employee.ID, 0)))
            {
                return NotFound();
            }
            else
                return Ok(employee);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] EmployeeEntity emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var item = await _employeeService.InsertEmployee(emp);

            return CreatedAtAction("Get", new { id = emp.ID }, item);
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