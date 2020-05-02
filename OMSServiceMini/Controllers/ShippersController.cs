using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSServiceMini.Data;

namespace OMSServiceMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        readonly NorthwindContext _northwindContext;

        public ShippersController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        // get api/shippers
        //[HttpGet]
    }
}