using BabiesStoreApi.Dtos;
using BabiesStoreApi.Models;
using BabiesStoreApi.Repo;
using Microsoft.EntityFrameworkCore;

namespace BabiesStoreApi.Services
{
    public class ProductService
    {
        private readonly ProductRepos repository = new();
        public List<ProductDto> GetProducts()
        {
            return repository.GetProducts();
        }

        public bool CreateProduct(CreateProductDto productDto)
        {
            return repository.CreateProduct(productDto);
        }

        public List<ProductDto> GetByCategory(int categoryId)
        {
            return repository.GetProductsByCategory(categoryId);
        }

        public List<ProductDto> GetSortedProducts()
        {
            return repository.GetProductsSorted();
        }

        public bool DeleteProduct(int productId)
        {
            return repository.DeleteProduct(productId);
        }

        public bool CreateMultipleProducts(CreateMultipleProductsDto dto)
        {
            foreach (var productDto in dto.Products)
            {
                repository.CreateProduct(productDto);
            }
            return true;
        }

        public List<ProductWithCategoryDto> GetProductsIncludingCategories()
        {
            return repository.GetProductsWithCategories(); // קורא לריפוזיטורי שכבר יושב עליו השאילתה
        }






    }
}
