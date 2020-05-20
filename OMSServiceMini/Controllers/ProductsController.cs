using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMSServiceMini.Data;
using OMSServiceMini.Models;

namespace OMSServiceMini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly NorthwindContext _northwindContext;
        public ProductsController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        #region GET requests
        // Get api/products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _northwindContext.Products.ToListAsync();
        }

        //// Get api/products/id
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetIdProduct(int id)
        //{
        //    return await _northwindContext.Products.FindAsync(id);
        //}

        // get api/products/name
        [HttpGet("{name}")]
        public async Task<ActionResult<Product>> GetNameProduct(string name)
        {
            return await _northwindContext.Products.FindAsync(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cheapest"></param>
        /// <returns></returns>
        // Get api/products/chaepest
        //[HttpGet("{cheapest}")]
        //public async Task<ActionResult<IEnumerable<Product>>> Cheapest(int cheapest)
        //{
        //    if (cheapest <= 10000)
        //    {
        //        var produscts = _northwindContext.Products.
        //            Count(c => c.UnitPrice <= 10000);
        //        return await produscts;
        //        //return await _northwindContext.Products.FindAsync(cheapest);
        //    }
        //    else
        //        return NotFound();
        //}
        #endregion
    }
}