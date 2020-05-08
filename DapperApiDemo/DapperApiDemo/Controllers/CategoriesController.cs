using DapperApiDemo.Models;
using DapperApiDemo.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var productCategories = _categoriesRepository.GetAllCategories();
            return Ok(productCategories);
        }

        [HttpGet]
        [Route("{categoriesId}")]
        public ActionResult<Categories> GetById(int categoriesId)
        {
            var product = _categoriesRepository.GetById(categoriesId);
            return Ok(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Categories entity)
        {
            _categoriesRepository.AddCategory(entity);
            return Ok(entity);
        }

        [HttpPut("{categoriesId}")]
        public ActionResult<Categories> Update(Categories entity, int categoriesId)
        {
            _categoriesRepository.UpdateCategory(entity, categoriesId);
            return Ok(entity);
        }

        [HttpDelete("{categoriesId}")]
        public ActionResult<Categories> Delete(int categoriesId)
        {
            _categoriesRepository.RemoveCategory(categoriesId);
            return Ok();
        }
    }
}