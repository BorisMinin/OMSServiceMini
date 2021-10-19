using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OMSServiceMini.Data;
using OMSServiceMini.Models;

namespace OMSServiceMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly NorthwindContext _northwindContext;

        public EmployeesController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        #region GET requests

        // GET http://localhost:49681/api/AllEmployees
        /// <summary>
        /// GET запрос возвращает список всех сотрудников
        /// </summary>
        [Route("AllEmployees")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            return await _northwindContext.Employees.ToListAsync();
        }

        // GET http://localhost:49681/api/SimpleEmlployees
        /// <summary>
        /// Get запрос возвращает данные всех сотрудников (id, имя, фамилия, страна)
        /// </summary>
        [Route("SimpleEmlployees")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _northwindContext.Employees.Select(e => new Employee
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Country = e.Country
            }).ToListAsync();
        }


        #endregion

        //POST http://localhost:49681/api/Employees/AddEmployee
        /// <summary>
        /// Создат новую сущность в БД с полями имени и фамилии
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        [Route("AddEmployee")]
        [HttpPost]
        public async Task<ActionResult<Employee>> AddNewEmployee(Employee newEmployee)
        {
            _northwindContext.Employees.Add(newEmployee);
            await _northwindContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllEmployees),
                new
                {
                    firstName = newEmployee.FirstName,
                    lastName = newEmployee.LastName
                }, newEmployee);
        }
    }
}