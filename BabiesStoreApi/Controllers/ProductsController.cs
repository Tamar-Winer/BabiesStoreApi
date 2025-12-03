using BabiesStoreApi.Data;
using BabiesStoreApi.Dtos;
using BabiesStoreApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabiesStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService = new();
        private readonly StoreContextDB _storeContext; // DbContext

        public ProductsController(ProductService productService, StoreContextDB storeContext)
        {
            _productService = productService;
            _storeContext = storeContext; // הזרקה של DbContext
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProductById(int id)
        {
            var product = _productService.GetProducts().FirstOrDefault(p => p.id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto productDto) 
        {
            try
            {
                return Ok(_productService.CreateProduct(productDto));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(false);
            }
        }

        [HttpGet("byCategory/{categoryId}")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            return Ok(_productService.GetByCategory(categoryId));
        }

        [HttpGet("sorted")]
        public IActionResult GetSortedProducts()
        {
            return Ok(_productService.GetSortedProducts());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bool result = _productService.DeleteProduct(id);

            if (!result)
                return NotFound("Product not found or already deleted.");

            return Ok("Product marked as deleted successfully.");
        }


        [HttpPost("multi")]
        public IActionResult CreateMultiple([FromBody] CreateMultipleProductsDto dto)
        {
            var result = _productService.CreateMultipleProducts(dto); 
            if (result)
                return Ok("Products created successfully");
            return BadRequest("Failed to create products");
        }

        [HttpGet("with-categories")]
        public ActionResult<List<ProductWithCategoryDto>> GetProductsWithCategories()
        {
            var products = _productService.GetProductsIncludingCategories(); // כאן צריך פונקציה ב-Service שמביאה את המידע
            return Ok(products);
        }

        //[HttpPut("{id}")]
        //public ActionResult UpdateProduct(int id, [FromBody] CreateProductDto productDto)
        //{
        //    var existingProduct = _productService.GetProducts().FirstOrDefault(p => p.id == id);
        //    if (existingProduct == null)
        //        return NotFound();
        //    existingProduct.name = productDto.name;

        //    return NoContent();
        //}

        [HttpGet("with-pagination")]
        public ActionResult<List<ProductDto>> GetProductsPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var products = _productService.GetProducts();

            var pagedProducts = products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(pagedProducts);
        }

        [HttpGet("productCount")]
        public ActionResult<int> GetProductCount()
        {
            // "OUTPUT" value: סופרת את המוצרים
            int count = _productService.GetProducts().Count;

            return Ok(count); // מחזיר את הערך
        }

        [HttpPost("createProductsTransaction")]
        public ActionResult CreateProductsTransaction()
        {
            using (var transaction = _storeContext.Database.BeginTransaction())
            {
                try
                {
                    // קריאה לפונקציות שונות של Service / Repository
                    _productService.CreateProduct(new CreateProductDto { name = "Hat", categoryId = 1 });
                    _productService.CreateProduct(new CreateProductDto { name = "Shoes", categoryId = 2 });

                    // אם הכל עובר בהצלחה
                    transaction.Commit();
                    return Ok("Products created successfully");
                }
                catch (Exception ex)
                {
                    // במקרה של שגיאה - Rollback
                    transaction.Rollback();
                    return BadRequest($"Error: {ex.Message}");
                }
            }
        }





    }
}
