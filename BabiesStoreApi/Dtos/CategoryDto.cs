using System.ComponentModel.DataAnnotations;

namespace BabiesStoreApi.Dtos
{
    public class CategoryDto
    {
        [Required(ErrorMessage = "Category name is required")]
        [MinLength(3, ErrorMessage = "Category name must be at least 3 characters")]
        public string name { get; set; }
        public List<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();

    }
    public class ProductWithCategoryDto
    {
        public string name { get; set; }
        public CategoryDto Category { get; set; }
    }




}
