using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //get api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            return await _northwindContext.Categories.ToListAsync();
        }

        #region GET with_image
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

        #region GET id
        // Get api/categories/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryId(int id)
        {
            //return await _northwindContext.Categories.FindAsync(id); // easy version

            var category = await _northwindContext.Categories.FindAsync(id);

            if (category == null)
                return NotFound("Category not found with used Id");
            else
                return new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description,
                    Products = category.Products
                };
        }
        #endregion

        #region POST
        // (POST)Создать новую сущность в таблице Category
        // Ниже приведён запрос в Postman, выбираем пункт POST, в разделе Body выбираем raw и JSON,
        // После выполнения запроса, необходимо создать новый запрос GET, и вывести весь список, в самом низу должна быть добавленная твоя сущность
        // Если присвоить значения не всем свойствам, то незаполненые свойства будут иметь значение Null, \
        // если поле было обязательным для заполнения, а ты не заполнил, то будет ошибка
        // Если всё сделано правильно, то status: 204 No Contant
        //{
        //    "CategoryName": "Name1",
        //    "Description": "Description1"
        //}

        // Post: api/categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category newCategory)
        {
            _northwindContext.Categories.Add(newCategory);
            await _northwindContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllCategory),
                new
                {
                    name = newCategory.CategoryName,
                    description = newCategory.Description
                },
                newCategory);
        }
        #endregion

        #region PUT
        // (PUT) обновить имеющуюся сущность (заменить не отдельные свойства, а все)
        // Запрос выше (POST) добавил новую сущность, её свойство ID = 12, а незаполненные значения равняются Null
        // В этом запросе я хочу дополнить сущность
        // Так как запрос Put может лишь заменить одну сущность на другую, то будем менять
        // В Postman выбираем пункт PUT, в строке поиска пишем запрос "api/categories/12", 12-Id категории, которую я хочу заменить
        // Также как и в запросе POST в разделе Body выбираем raw и JSON
        // Если всё сделано правильно, то status: 204 No Contant
        // Далее отправляйся в запрос GET и в самом низу можешь увидеть изменения
        //{
        // "CategoryId": 12,
        //    "CategoryName": "Name12",
        //    "Description": "Description12"
        //}

        // PUT: api/categories/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category newCategory)
        {
            if (id != newCategory.CategoryId)
            {
                return BadRequest("Категория с данным id не найдена");
            }

            _northwindContext.Entry(newCategory).State = EntityState.Modified;
            await _northwindContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region DELETE
        // Удалить недавно добавленую и обновленную сущность
        // В разделе Body выбираем raw и JSON
        // Никакого кода JSON не нужно, мы лишь удаляем сущность, указав её Id
        // Запусти GET и увидишь что выбранного тобой Id больше нет

        // DELETE: api/categories/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var deleteItem = await _northwindContext.Categories.FindAsync(id);
            if (deleteItem == null)
            {
                return NotFound();
            }

            _northwindContext.Categories.Remove(deleteItem);
            await _northwindContext.SaveChangesAsync();

            //return deleteItem;
            return NoContent();
        }
        #endregion
    }
}