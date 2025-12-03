using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BabiesStoreApi.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; } = null!;

        [Required]
        public string description { get; set; } = null!;

        public int price { get; set; }

        public int CategoryId { get; set; }

        // navigation property שמפנה לקטגוריה
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public bool IsDeleted { get; set; } = false;

        //public ICollection<categoryModel> categories { get; set; } = new List<categoryModel>();

    }
}

