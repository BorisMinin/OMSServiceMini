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
    public class OrdersController : ControllerBase
    {
        readonly NorthwindContext _northwindContext;

        public OrdersController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        // GET api/orders
    }
}