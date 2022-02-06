using Business_Logic_Layer.Service;
using Data_Access_Layer;
using Data_Access_Layer.Repository;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web_API.Controllers;
using Xunit;

namespace Web_API.Test
{
    public class EmpoyeeControllerTest
    {
        EmployeeController _controller;
        IEmployeeService _service;
        IEmployee _employee;

        public EmpoyeeControllerTest()
        {
            _employee = new Employee();
            _service = new EmployeeService(_employee);
            _controller = new EmployeeController(_service);
        }

        [Fact]
        public void GetAllTest()
        {
           
            //Act
            var result = _controller.GetAllEmployee();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var list = result.Result as OkObjectResult;

            Assert.IsType<List<EmployeeEntity>>(list.Value);

            var listEmployee = list.Value as List<EmployeeEntity>;
            //There are currently seven records in db.
            Assert.Equal(7, listEmployee.Count);
        }
        /*InlineData which above our GetEmployeeByIdTest method.So first InlineData value is 
         * correct and second InlineData is wrong.we used wrong value because of NotFound 
         * test,and correct value for Ok test */
        [Theory]
        [InlineData(9,2)]
        public void GetEmployeeByIdTest(int id1, int id2)
        {
            //Arrange
            int validInt = id1;
            int invalidInt = id2;

            //Act
            var notFoundResult = _controller.Get(invalidInt);
            var okResult = _controller.Get(validInt);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
            Assert.IsType<OkObjectResult>(okResult.Result);

            //Now we need to check the value of the result for the ok object result.
            var item = okResult.Result as OkObjectResult;

            //Expecting to return a single employee
            Assert.IsType<List<EmployeeEntity>>(item.Value);

            //Now, let us check the value itself.
            var employeeItem = item.Value as EmployeeEntity;
            Assert.Equal(validInt, employeeItem.ID);
            Assert.Equal("testUpdatedVers2", employeeItem.TestName);



        }
    }
}
