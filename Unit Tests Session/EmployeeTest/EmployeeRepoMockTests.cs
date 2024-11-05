using NUnit.Framework;
using TrainingWebApplication.Repository;
using TrainingWebApplication.Models;
using Moq;

namespace EmployeeTest
{
    public class EmployeeRepoMockTests
    {
        //AAA
        private readonly Mock<IEmployeeRepository> _mock;

        public EmployeeRepoMockTests()
        {
            _mock = new Mock<IEmployeeRepository>();
        }

        [Test]
        public void Test_GetAllEmployees_IFDataPresentWillCountGreaterThanZero()
        {
            //Arrange
            //Setup the mock objects

            _mock.Setup(repo => repo.GetAllEmployees()).Returns(new List<EmployeeDB> { 
                new EmployeeDB { EmployeeID = 1,Department="RnD",Designation="DEV-1",EmployeeName="Kushal Banik",Qualification="G"}
            });

            var result = _mock.Object;

            //Act 

            var actual = result.GetAllEmployees().Count();

            //Assert

            Assert.That(actual, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetAllEmployees_IFNoDataPresentWillCountAsZero()
        {
            //Arrange
            //Setup the mock objects

            _mock.Setup(repo => repo.GetAllEmployees()).Returns(new List<EmployeeDB> {});

            var result = _mock.Object;

            //Act 

            var actual = result.GetAllEmployees().Count();

            //Assert

            Assert.That(actual, Is.EqualTo(0));
        }
    }
}