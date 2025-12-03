using System.ComponentModel.DataAnnotations;

namespace BabiesStoreApi.Dtos
{
    public class ProductDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string categoryName { get; set; }
    }
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MinLength(1, ErrorMessage = "Product name cannot be empty")]
        public string name { get; set; }
        public int categoryId { get; set; }
        public string? description { get; set; }
    }

    public class CreateMultipleProductsDto
    {
        public List<CreateProductDto> Products { get; set; } = new List<CreateProductDto>();
    }

}
