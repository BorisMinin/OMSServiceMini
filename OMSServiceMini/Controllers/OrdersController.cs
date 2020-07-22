using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMSServiceMini.Data;
using OMSServiceMini.Models;

//using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            return await _northwindContext.Orders.ToListAsync();
        }

        // GET api/orders/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderId(int id)
        {
            var order = await _northwindContext.Orders
                .Where(o => o.OrderId == id)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync();

            if (order == null)
                return NotFound("Заказ с данным id не найден");

            return order;
        }

        ////POST api/orders/id
        //[HttpPost ("{id}")]
        //public async Task<ActionResult<Order>> PostOrder()
        //{

        //}
    }
}