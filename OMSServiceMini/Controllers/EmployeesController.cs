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

        // GET http://localhost:49681/api/Employees
        /// <summary>
        /// Get запрос возвращает данные всех сотрудников (id, имя, фамилия, страна)
        /// </summary>
        /// <returns></returns>
        [Route("a")]
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

    }
}