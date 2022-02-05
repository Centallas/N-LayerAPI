using Business_Logic_Layer.Service;
using Data_Access_Layer;
using Entity;
using NUnit.Framework;
using System.Collections.Generic;
using Web_API.Controllers;
using Data_Access_Layer.Repository;

namespace UnitTest
{
    [TestFixture]
    public class Tests
    {
        EmployeeController _controller;
        IEmployeeService _service;
        IEmployee _employee;

        public Tests()
        {
            _employee = new Employee();
            _service = new EmployeeService(_employee); 
            _controller = new EmployeeController(_service);
           
        }

        [Test]
        public void GetAllEmployee()
        {
            
            //https://medium.com/c-sharp-progarmming/unit-testing-in-asp-net-core-web-api-b2e6f7bdb860

            var controller = new EmployeeController(_service);
           
            var result = controller.GetAllEmployee();
            //Assert.IsNotNull(result);
            //Assert.AreEqual(false, result.IsCompletedSuccessfully);
            //Assert.AreEqual(true, result.IsCompleted);
             Assert.AreEqual(false, result.IsFaulted);
            

        }
    }
}