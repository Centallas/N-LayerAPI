using Autofac;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Business_Logic_Layer.DTOs;
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
        readonly EmployeeController _controller;
        readonly IEmployeeService _service;
        readonly IEmployee _employee;
        private readonly IMapper _mapper;
        public EmpoyeeControllerTest()
        {
            //Buld container mapper config using AutoMapper.Contrib.Autofac.DependencyInjection;             
            _mapper = SetIMapperType();
            _employee = new Employee();
            _service = new EmployeeService(_employee, _mapper);
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

            Assert.IsType<List<EmployeeDto>>(list.Value);

            var listEmployee = list.Value as List<EmployeeDto>;
            //There are currently 13 records in db. 02-15-2022
            Assert.Equal(16, listEmployee.Count);
        }
        /*InlineData which above our GetEmployeeByIdTest method.So first InlineData value is 
         * correct and second InlineData is wrong.we used wrong value because of NotFound 
         * test,and correct value for Ok test */
        [Theory]
        [InlineData(1, 2)]
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
            Assert.IsType<EmployeeDto>(item.Value);

            //Now, let us check the value itself.
            var employeeItem = item.Value as EmployeeDto;
            Assert.Equal(validInt, employeeItem.ID);
            Assert.Equal("xTestDTO02Edit", employeeItem.TestName);

        }
        [Fact]
        public void AddEmployeeTest()
        {
            //OK RESULT TEST START

            //Arrange
            var completeEmployee = new EmployeeEntity(0)
            {
                ID = 0,
                CompanyId = "1",
                CreatedOn = DateTime.Now,
                DeletedOn = DateTime.Now,
                Email = "xInsertTest@test.tmp",
                Fax = "000.000.000",
                TestName = "xInsertTest",
                LastLogin = DateTime.Now,
                Password = "xInsertTest",
                PortalId = "1",
                RoleId = "2",
                StatusId = "1",
                Telephone = "000.000.000",
                UpdatedOn = DateTime.Now,
                Username = "xInsertTest",
                type = "insert"

            };
            //Act
            var createdResponse = _controller.Post(completeEmployee);

            //var res = createdResponse.Result;

            //Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse.Result);

            //value of the result
            var item = createdResponse.Result as CreatedAtActionResult;
            Assert.IsType<EmployeeDto>(item.Value);

            //check value of this employee
            var employeeItem = item.Value as EmployeeDto;

            Assert.Equal(completeEmployee.TestName, employeeItem.TestName);
            Assert.Equal(completeEmployee.Username, employeeItem.Username);
            Assert.Equal(completeEmployee.Email, employeeItem.Email);

            //OK RESULT TEST END

            //BADREQUEST AND MODELSTATE ERROR TEST START

            var incompleteEmployee = new EmployeeEntity(0)
            {
                Username = "José",
                Email = "Jose@hotmail.com"
            };

            //Act
            _controller.ModelState.AddModelError("TestName", "TestName is a required filed");
            var badResponse = _controller.Post(incompleteEmployee);


            Assert.IsType<BadRequestObjectResult>(badResponse.Result);

            //BADREQUEST AND MODELSTATE ERROR TEST END

            /*Above code,we are tested two cases,Ok return and BadRequest also 
             * Modelstatevalidition.Now time to test our code.*/


        }


        [Theory]
        [InlineData(1)]
        public void EditEmployeeTest(int id)
        {

            //OK RESULT TEST START

            //Arrange
            var completeEmployee = new EmployeeEntity(id)
            {
                ID = 0,
                CompanyId = "1",
                CreatedOn = DateTime.Now,
                DeletedOn = DateTime.Now,
                Email = "xTestEditDTO02@test.tmp",
                Fax = "000.000.000",
                TestName = "xTestDTO02Edit",
                LastLogin = DateTime.Now,
                Password = "xTestEdit",
                PortalId = "1",
                RoleId = "2",
                StatusId = "1",
                Telephone = "000.000.000",
                UpdatedOn = DateTime.Now,
                Username = "XUnitDTO02EditTest",
                type = "update"

            };

            //Act 

            var createdResponse = _controller.Put(id, completeEmployee);

            //Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse.Result);

            //value of the result
            var item = createdResponse.Result as CreatedAtActionResult;
            Assert.IsType<EmployeeDto>(item.Value);


            //check value of this employee
            var employeeItem = item.Value as EmployeeDto;

            Assert.Equal(completeEmployee.TestName, employeeItem.TestName);
            Assert.Equal(completeEmployee.Username, employeeItem.Username);
            Assert.Equal(completeEmployee.Email, employeeItem.Email);

            //OK RESULT TEST END

            //BADREQUEST AND MODELSTATE ERROR TEST START

            var incompleteEmployee = new EmployeeEntity(0)
            {
                Username = "José",
                Email = "Jose@hotmail.com"
            };

            //Act
            _controller.ModelState.AddModelError("TestName", "TestName is a required filed");

            var badResponse = _controller.Put(id, incompleteEmployee);


            Assert.IsType<BadRequestObjectResult>(badResponse.Result);


        }

        //[Theory]
        //[InlineData(45, 2)]
        //public void RemoveEmployeeByIdTest(int id1, int id2)
        //{
        //    //Arrange
        //    var validInt = id1;
        //    var invalidInt = id2;

        //    //Act
        //    var notFoundResult = _controller.Delete(invalidInt);

        //    //Assert
        //    Assert.IsType<NotFoundResult>(notFoundResult.Result);
        //    Assert.Equal(15, _service.GetAllEmployee().Result.Count);

        //    //Act
        //    var okResult = _controller.Delete(validInt);

        //    //Assert
        //    Assert.IsType<OkResult>(okResult.Result);
        //    Assert.Equal(14, _service.GetAllEmployee().Result.Count);

        //}


        //-----https://github.com/alsami/AutoMapper.Contrib.Autofac.DependencyInjection

        [Fact]
        public void ValidateMappingConfig()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAutoMapper(typeof(EmployeeService).Assembly);

            var container = containerBuilder.Build();
            var mapperConfiguration = container.Resolve<MapperConfiguration>();

            // this line will throw when mappings are not working as expected
            // it's wise to write a test for that, which is always executed within a CI pipeline for your project.
            mapperConfiguration.AssertConfigurationIsValid();

        }

        private static IMapper SetIMapperType()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAutoMapper(typeof(EmployeeService).Assembly, propertiesAutowired: true);
            var container = containerBuilder.Build();

            return container.Resolve<IMapper>();

        }
    }
}
