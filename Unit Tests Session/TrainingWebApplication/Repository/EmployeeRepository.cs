using TrainingWebApplication.Models;

namespace TrainingWebApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<EmployeeDB> _employeeDBs;

        public EmployeeRepository()
        {
            _employeeDBs = new List<EmployeeDB>
            {
               new EmployeeDB { EmployeeID = 1, EmployeeName = "John", Department = "IT", Designation = "Software Engineer", Qualification = "B.Tech" },
            };
        }

        public EmployeeDB AddEmployee(EmployeeDB employee)
        {
            // add Employee to DB
            EmployeeDB newEmployee = new EmployeeDB
            {
                EmployeeID = _employeeDBs.Max(e => e.EmployeeID) + 1,
                EmployeeName = employee.EmployeeName,
                Department = employee.Department,
                Designation = employee.Designation,
                Qualification = employee.Qualification
            };

            _employeeDBs.Add(newEmployee);

            return newEmployee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeDBs.FirstOrDefault(e => e.EmployeeID == id);
            if (employee != null)
            {
                _employeeDBs.Remove(employee);
                return true;
            }
            return false;
        }

        public IEnumerable<EmployeeDB> GetAllEmployees()
        {
            return _employeeDBs;
        }

        public EmployeeDB? GetEmployee(int id)
        {
            return _employeeDBs.FirstOrDefault(e => e.EmployeeID == id);
        }

        public EmployeeDB? updateEmployee(EmployeeDB employeeChanges,int idx)
        {
            var employee = _employeeDBs.FirstOrDefault(e => e.EmployeeID == idx);
            if (employee != null)
            {
                employee.EmployeeID = employeeChanges.EmployeeID;
                employee.EmployeeName = employeeChanges.EmployeeName;
                employee.Department = employeeChanges.Department;
                employee.Designation = employeeChanges.Designation;
                employee.Qualification = employeeChanges.Qualification;
            }
            return employee;
        }

    }
}
