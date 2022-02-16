using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Business_Logic_Layer.Service;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_API.DTOs;

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
            try
            {
                var employee = await _employeeService.GetAllEmployee();


                if (Equals(employee, null))
                {
                    return NotFound();
                }
                
                return Ok(employee);

            }
            catch (System.Exception exc)
            {

                throw new System.Exception(exc.Message);
            }


        }
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            ///TODO: from now validate with company, then get ride of initialization values 
            ///of EmployeeEntity
            if (Equals(employee.CompanyId, string.Empty))
            {
                return NotFound();
            }
            else
                return Ok(employee);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeEntity emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = await _employeeService.InsertEmployee(emp);

            return CreatedAtAction(nameof(Get), new { id = item.ID }, item);
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeEntity emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = await _employeeService.UpdateEmployee(id, emp);

            return CreatedAtAction(nameof(Put), new { id = item.ID }, item);
        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingItem = _employeeService.GetEmployeeById(id);
            ///TODO: from now validate with company, then get ride of initialization values 
            ///of EmployeeEntity
            if (existingItem.Result.CompanyId == string.Empty)
            {
                return NotFound();

            }
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }

    }
}