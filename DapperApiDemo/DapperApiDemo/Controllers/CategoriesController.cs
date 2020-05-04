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

        //private readonly IProductRepository _productRepository;

        //public ProductController(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        //[HttpGet]
        //public ActionResult GellAll()
        //{
        //    var products = _productRepository.GetAllProducts();
        //    return Ok(products);
        //}
    }
}