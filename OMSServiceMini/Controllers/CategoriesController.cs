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
    public class CategoriesController : ControllerBase
    {
        readonly NorthwindContext _northwindContext;

        public CategoriesController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        ////get api/categories
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        //{
        //    return await _northwindContext.Categories.ToListAsync();
        //}

        //GET: api/categories?with_image=true
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(bool with_images = false)
        {
            if (with_images)
            {
                return await _northwindContext.Categories.ToListAsync();
            }
            else //if (with_images == false)
            {
                var categories = _northwindContext.Categories.
                    Select(
                    c => new Category
                    {
                        CategoryName = c.CategoryName,
                        CategoryId = c.CategoryId
                    }
                    );
                return await categories.ToListAsync();
            }
        }

        // Get api/categories/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryId(int id)
        {
            return await _northwindContext.Categories.FindAsync(id);
        }


    }
}