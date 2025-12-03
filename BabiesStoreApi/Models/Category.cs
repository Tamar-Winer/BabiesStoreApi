using System.ComponentModel.DataAnnotations;

namespace BabiesStoreApi.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        // קשר אחד לרבים
        ICollection<Product> products { get; set; }= new List<Product>();

        public int? ParentCategoryId { get; set; }  // מגדיר קטגוריה הורה
        public Category ParentCategory { get; set; }  // קשר לקטגוריה הורה
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();  // הקטגוריות הילדים
    }
}
