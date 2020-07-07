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
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            //public async Task<IEnumerable<Product>> GetAllProducts
            return await _northwindContext.Products.ToListAsync(); // easy version, without ActionResult
            //return await _northwindContext.Products.Select(p => new Product
            //{
            //    ProductId = p.ProductId,
            //    ProductName = p.ProductName,
            //    Supplier = p.Supplier,
            //    Category = p.Category,
            //    UnitPrice = p.UnitPrice,
            //    UnitsInStock = p.UnitsInStock,
            //    Discontinued = p.Discontinued
            //}).ToListAsync();
        }

        // Get api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetIdProduct(int id)
        {
            return await _northwindContext.Products.FindAsync(id);
        }

        // get api/products/name
        //[HttpGet("{name}")]
        //public async Task<ActionResult<Product>> GetNameProduct(string name)
        //{
        //    return await _northwindContext.Products.FindAsync(name);
        //}

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

        #region POST
        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            var _product = product;

            _northwindContext.Products.Add(product);
            await _northwindContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllProducts),
                new Product
                {
                    ProductId = product.ProductId
                }, product);
        }
        #endregion
    }
}