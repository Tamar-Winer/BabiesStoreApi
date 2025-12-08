using BabiesStoreApi.Dtos;

namespace BabiesStoreApi.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        bool CreateProduct(CreateProductDto productDto);
        List<ProductDto> GetByCategory(int categoryId);
        List<ProductDto> GetSortedProducts();
        bool DeleteProduct(int productId);
        bool CreateMultipleProducts(CreateMultipleProductsDto dto);
        List<ProductWithCategoryDto> GetProductsIncludingCategories();
    }
}
