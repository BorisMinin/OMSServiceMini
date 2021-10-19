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

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> AllEmployees()
        //{
        //    return await _northwindContext.Employees.ToListAsync();
        //}
        [Route ("a")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            //return await _northwindContext.Employees.ToListAsync();
            return await _northwindContext.Employees.Select(e => new Employee
            {
                EmployeeId = e.EmployeeId,
                LastName = e.LastName

            }).ToListAsync();
        }

    }
}