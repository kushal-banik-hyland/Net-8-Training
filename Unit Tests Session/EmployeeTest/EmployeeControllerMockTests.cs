using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TrainingWebApplication.Controller;
using TrainingWebApplication.Models;
using TrainingWebApplication.Repository;
using NUnit;
namespace EmployeeTest
{
    /*
     *     This class is used to test the EmployeeApiController class using Mock object of IEmployeeRepository
     *     Different Behavior of the IEmployeeRepository is tested using the Mock object
     *      
     */
    [TestFixture]
    public class EmployeeControllerMockTests
    {
        // Mocking the IEmployeeRepository
        private Mock<IEmployeeRepository> _mock;

        public EmployeeControllerMockTests()
        {
            // Create a new mock object for IEmployeeRepository
            _mock = new Mock<IEmployeeRepository>();
        }

        [Test]
        public async Task Test_GetAllEmployees_IFDataPresentInRepository()
        {
            //Arrange
            //Setup the mock objects
            EmployeeDB employee = new EmployeeDB { EmployeeID = 1, Department = "RnD", Designation = "DEV-1", EmployeeName = "Kushal Banik", Qualification = "G" };

            _mock.Setup(repo => repo.GetAllEmployees()).Returns(new List<EmployeeDB>
            {
                employee
            });

            //Inject the mock object into the controller
            EmployeeApiController employeeApiController = new EmployeeApiController(_mock.Object);

            //Act
            //Call the Get method of the controller
            var response = await employeeApiController.Get();

            //Get the result from the response
            var result =  (response as OkObjectResult).Value;

            //Assert
            Assert.That(result, Is.EqualTo(new List<EmployeeDB> { employee }));
        }

        [Test]
        public async Task Test_GetEmployees_WithIdIfThe_Employee_Is_Present()
        {
            //Arrange
            //Setup the mock objects
            EmployeeDB employee = new EmployeeDB { EmployeeID = 1, Department = "RnD", Designation = "DEV-1", EmployeeName = "Kushal Banik", Qualification = "G" };

            _mock.Setup(repo => repo.GetEmployee(1)).Returns(employee);
            EmployeeApiController employeeApiController = new EmployeeApiController(_mock.Object);

            // Act
            //Call the Get method of the controller
            var response = await employeeApiController.Get(1);

            //Get the result from the response
            var result = (response as OkObjectResult).Value;

            //Assert
            Assert.That(result, Is.EqualTo(employee));
        }

        [Test]
        public async Task Test_GetEmployees_WithIdIfThe_Employee_Is_Not_Present()
        {
            //Arrange
            //Setup the mock objects

            EmployeeDB employee = new EmployeeDB { EmployeeID = 1, Department = "RnD", Designation = "DEV-1", EmployeeName = "Kushal Banik", Qualification = "G" };

            _mock.Setup(repo => repo.GetEmployee(1)).Returns(employee);
            EmployeeApiController employeeApiController = new EmployeeApiController(_mock.Object);


            // Act
            var response = await employeeApiController.Get(2);

            //Assert
            Assert.That(response, Is.TypeOf<NotFoundResult>());
        }

        [Test]
        public async Task Test_AddEmployee()
        {
           //Arrange
           //Setup the mock objects
            EmployeeDB employee = new EmployeeDB { EmployeeID = 1, Department = "RnD", Designation = "DEV-1", EmployeeName = "Kushal Banik", Qualification = "G" };

            _mock.Setup(repo => repo.AddEmployee(employee)).Returns(employee);

            //Act
            EmployeeApiController employeeApiController = new EmployeeApiController(_mock.Object);
            var response = await employeeApiController.Post(employee);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response, Is.TypeOf<CreatedAtActionResult>());
                Assert.That((response as CreatedAtActionResult).Value, Is.EqualTo(employee));
            });
        }


    }
}
