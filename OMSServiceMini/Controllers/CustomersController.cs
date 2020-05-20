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
    public class CustomersController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;

        public CustomersController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }

        #region GET country without fax
        //// get api/customeres/country
        //[HttpGet("{country}")]
        //public async Task<IEnumerable<Customer>> GetWithFax(string country)
        //{
        //    return await _northwindContext.Customers.
        //        Where(c => c.Country == country && c.Fax != null).ToListAsync();
        //    //.Select(s => new Customer{CustomerId = s.CustomerId});
        //}
        #endregion

        #region GET without image
        ////GET: api/categories?with_image=true
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategories(bool with_images = false)
        //{
        //    if (with_images)
        //    {
        //        return await _northwindContext.Categories.ToListAsync();
        //    }
        //    else //if (with_images == false)
        //    {
        //        var categories = _northwindContext.Categories.
        //            Select(
        //            c => new Category
        //            {
        //                CategoryName = c.CategoryName,
        //                CategoryId = c.CategoryId
        //            }
        //            );
        //        return await categories.ToListAsync();
        //    }
        //}
        #endregion

        #region GET FullcompanyName 
        //// get api/customers/companyname
        //[HttpGet("{companyName}")]
        //public async Task<IEnumerable<Customer>> GetCompanyName(string companyName)
        //{
        //    return await _northwindContext.Customers.Where
        //        (c => c.CompanyName == companyName).ToListAsync();
        //}
        #endregion

        #region GET startSymbols search
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="startSymbols">один или несколько символов(не более 5) с которых начинается значения поля таблицы CustomerId</param>
        ///// <returns>информацию о найденных компаниях</returns>
        //// get api/customers/company
        //[HttpGet("{startSymbols}")]
        //public async Task<IEnumerable<Customer>> GetCompany(string startSymbols)
        //{
        //    return await _northwindContext.Customers.Where
        //        (c => c.CompanyName.StartsWith(startSymbols)).ToListAsync();
        //}
        #endregion

        #region GET postalCode search
        //// Get api/customers/postalcode
        //[HttpGet ("{postalCode}")]
        //public async Task<IEnumerable<Customer>> GetPostalName(string postalCode)
        //{
        //    return await _northwindContext.Customers.Where
        //        (c => c.PostalCode.Contains(postalCode)).ToListAsync();
        //}
        #endregion

        // чемпион (customer) по сумме заказов (OrderDetails) за последний год наблюдений (Orders)
        // 1. получить всех customer (id)
        // 2. получить сумму заказов для каждого customer // * учитывать скидку
        // 3. получить все заказы за 1998 год
        // 4. ?объединить все запросы в один
        //public Customer GetChempion(int year)
        //{
        //    Customer result;
        //    result = _northwindContext.Customers;
        //    return result;
        //}

        #region Task 1 completed
        //// Get api/customers
        //[HttpGet]
        //public async Task<IEnumerable<Customer>> GetAllCustomers()
        //{
        //    return await _northwindContext.Customers.ToListAsync();
        //}
        #endregion

        #region Task 2 
        /// <summary>
        /// Получить общую сумму заказов для каждого покупателя
        /// </summary>
        /// <returns>Список id покупателей и общей суммой их заказа</returns>
        
        // get api/customers
        //[HttpGet]
        //public async Task<IEnumerable<OrderDetail>> GetUnitPriceOfCustomers()
        //{

        //}
        #endregion
    }
}