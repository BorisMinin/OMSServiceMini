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
    }
}