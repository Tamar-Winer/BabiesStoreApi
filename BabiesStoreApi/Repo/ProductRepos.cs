using BabiesStoreApi.Data;
using BabiesStoreApi.Dtos;
using BabiesStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BabiesStoreApi.Repo
{
    public class ProductRepos
    {
        private readonly StoreContextDB _storeContext=StoreDbFactory.CreateContext();

        public List<ProductDto> GetProducts()
        {
            return _storeContext.Products.Where(p => !p.IsDeleted).Include(x=> x.Category).Select(

                a=>new ProductDto
                {
                    id=a.id,
                    name=a.name,
                    categoryName=a.Category.name
                }
                ).ToList();
        }


        public bool CreateProduct(CreateProductDto productDto)
        {
            try
            {
                Product product = new Product()
                {
                    name = productDto.name,
                    CategoryId=productDto.categoryId,
                    description=productDto.description
                };
                _storeContext.Products.Add(product);
                _storeContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;

            }
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            return _storeContext.Products
                .Where(p => !p.IsDeleted && p.CategoryId == categoryId)
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    id = p.id,
                    name = p.name,
                    categoryName = p.Category.name
                })
                .ToList();
        }

        public List<ProductDto> GetProductsSorted()
        {
            return _storeContext.Products
                .Where(p => !p.IsDeleted) 
                .Include(p => p.Category)
                .OrderBy(p => p.name) 
                .Select(p => new ProductDto
                {
                    id = p.id,
                    name = p.name,
                    categoryName = p.Category.name
                })
                .ToList();
        }



        public bool DeleteProduct(int productId)
        {
            try
            {
                var product = _storeContext.Products.Find(productId);
                if (product == null)
                    return false;
                // Soft Delete
                product.IsDeleted = true;

                _storeContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool CreateMultipleProducts(CreateMultipleProductsDto dto)
        {
            try
            {
                var products = dto.Products.Select(p => new Product
                {
                    name = p.name,
                    CategoryId = p.categoryId,
                    description = p.description
                }).ToList();

                _storeContext.Products.AddRange(products);
                _storeContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private CategoryDto MapCategoryToDto(Category category)
        {
            if (category == null) return null;

            return new CategoryDto
            {
                name = category.name,
                SubCategories = category.SubCategories?.Select(MapCategoryToDto).ToList() ?? new List<CategoryDto>()
            };
        }

        public List<ProductWithCategoryDto> GetProductsWithCategories()
        {
            return _storeContext.Products
                .Include(p => p.Category)
                .ThenInclude(c => c.SubCategories) // אם יש לך ICollection<SubCategory>
                .Select(p => new ProductWithCategoryDto
                {
                   
                    name = p.name,
                    Category = new CategoryDto
                    {
                        name = p.Category.name,
                        SubCategories = p.Category.SubCategories
                            .Select(sc => new CategoryDto
                            {
                                name = sc.name
                            }).ToList()
                    }
                }).ToList();
        }


    }
}
