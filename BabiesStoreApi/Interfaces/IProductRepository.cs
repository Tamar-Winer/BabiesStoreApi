using BabiesStoreApi.Dtos;

namespace BabiesStoreApi.Interfaces
{
    public interface IProductRepository
    {
        List<ProductDto> GetProducts();
        bool CreateProduct(CreateProductDto productDto);
        List<ProductDto> GetProductsByCategory(int categoryId);
        List<ProductDto> GetProductsSorted();
        bool DeleteProduct(int productId);
        bool CreateMultipleProducts(CreateMultipleProductsDto dto);
        List<ProductWithCategoryDto> GetProductsWithCategories();
    }
}
