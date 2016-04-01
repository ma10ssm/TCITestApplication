using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCIApplication.Controllers;
using TCIApplication.Models;
using TCIApplication.Test.MockRepositories;
using System.Linq;
using System.Web.Mvc;
using Rhino.Mocks;

namespace TCIApplication.Test
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private static EmployeeController GetEmployeeController(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            var controller = new EmployeeController(employeeRepository, departmentRepository);                       
            return controller;
        }


        [TestMethod]
        public void Index_AsksForIndexView()
        {
            // Arrange                        
            var repository = MockRepository.GenerateMock<IEmployeeRepository>();
            var controller = GetEmployeeController(repository, null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void Index_RetrievesAllEmployeesFromRepository()
        {
            // Arrange            
            var employee1 = new Employee { FirstName = "Nick", MiddleName = "Andrew", LastName = "Alexander", Address = "259 Pinner Rd, Harrow, Greater London, UK", StartDate = DateTime.Parse("2011-01-09"), Department = null };
            var employee2 = new Employee { FirstName = "John", MiddleName = null, LastName = "Patterson", Address = "86 York St,Marylebone, London W1H 1QS, UK", StartDate = DateTime.Parse("2015-09-01"), Department = null };
        
            
            var repository = new InMemoryEmployeeRepository();
            repository.Add(employee1);
            repository.Add(employee2);
            var controller = GetEmployeeController(repository, null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            var model = (IEnumerable<Employee>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), employee1);
            CollectionAssert.Contains(model.ToList(), employee2);
        }

        [TestMethod]
        public void Details_RetrievesEmployeeFromRepository()
        {
            // Arrange            
            var employee1 = new Employee { EmployeeId = 1, FirstName = "Nick", MiddleName = "Andrew", LastName = "Alexander", Address = "259 Pinner Rd, Harrow, Greater London, UK", StartDate = DateTime.Parse("2011-01-09"), Department = null };

            var repository = new InMemoryEmployeeRepository();
            repository.Add(employee1);
            var controller = GetEmployeeController(repository, null);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            var model = result.ViewData.Model;            
            Assert.AreEqual(model, employee1);
        }

        [TestMethod]
        public void Create_Employee_Added_To_Repository()
        {
            // Arrange            
            var employee1 = new Employee { EmployeeId = 1, FirstName = "Nick", MiddleName = "Andrew", LastName = "Alexander", Address = "259 Pinner Rd, Harrow, Greater London, UK", StartDate = DateTime.Parse("2011-01-09"), Department = null };

            var employeeRepository = new InMemoryEmployeeRepository();
            var departmentRepository = new InMemoryDepartmentRepository();
            var controller = GetEmployeeController(employeeRepository, departmentRepository);

            // Act
            var result = controller.Create(employee1);

            // Assert
            CollectionAssert.Contains(employeeRepository.GetAll().ToList(), employee1);
        }

        [TestMethod]
        public void Edit_Employee_Edit_View_Returned()
        {
            // Arrange  
            var employee1 = new Employee { EmployeeId = 1, FirstName = "Nick", MiddleName = "Andrew", LastName = "Alexander", Address = "259 Pinner Rd, Harrow, Greater London, UK", StartDate = DateTime.Parse("2011-01-09"), Department = null };

            var employeeRepository = new InMemoryEmployeeRepository();
            employeeRepository.Add(employee1);
            var departmentRepository = new InMemoryDepartmentRepository();
            var controller = GetEmployeeController(employeeRepository, departmentRepository);

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void Delete_Employee_Delete_View_Returned()
        {
            // Arrange            
            var employee1 = new Employee { EmployeeId = 1, FirstName = "Nick", MiddleName = "Andrew", LastName = "Alexander", Address = "259 Pinner Rd, Harrow, Greater London, UK", StartDate = DateTime.Parse("2011-01-09"), Department = null };

            var repository = new InMemoryEmployeeRepository();
            repository.Add(employee1);
            var controller = GetEmployeeController(repository, null);

            // Act
            var result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmed_Employee_Removed_From_Repository()
        {
            // Arrange            
            var employee1 = new Employee { EmployeeId = 1, FirstName = "Nick", MiddleName = "Andrew", LastName = "Alexander", Address = "259 Pinner Rd, Harrow, Greater London, UK", StartDate = DateTime.Parse("2011-01-09"), Department = null };

            var repository = new InMemoryEmployeeRepository();
            repository.Add(employee1);
            var controller = GetEmployeeController(repository, null);

            // Act
            var result = controller.DeleteConfirmed(1);

            // Assert
            CollectionAssert.DoesNotContain(repository.GetAll().ToList(), employee1);
        }
    }
}
