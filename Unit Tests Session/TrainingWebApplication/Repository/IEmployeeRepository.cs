using TrainingWebApplication.Models;

namespace TrainingWebApplication.Repository
{
    public interface IEmployeeRepository
    {
        // create methods for CRUD operations

        IEnumerable<EmployeeDB> GetAllEmployees();

        EmployeeDB? GetEmployee(int id);
        EmployeeDB AddEmployee(EmployeeDB employee);
        EmployeeDB? updateEmployee(EmployeeDB employeeChanges,int idx);
        Boolean DeleteEmployee(int id);
        
    }
}
