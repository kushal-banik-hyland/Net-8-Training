using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TrainingWebApplication.Models;
using TrainingWebApplication.Repository;

namespace TrainingWebApplication.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController:ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeApiController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _employeeRepository.GetAllEmployees();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _employeeRepository.GetEmployee(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDB employee)
        {
            var result = _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(Get), new { id = result.EmployeeID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDB employee)
        {
            var result = _employeeRepository.updateEmployee(employee, id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
