using BabiesStoreApi.Dtos;
using BabiesStoreApi.Repo;

namespace BabiesStoreApi.Services
{
    public class CategoryService
    {
        private readonly CategoryRepos _categoryRepos = new CategoryRepos();

        public bool AddCategory(CategoryDto categoryDto)
        {
            if (string.IsNullOrWhiteSpace(categoryDto.name) || categoryDto.name.Length < 3)
                throw new ArgumentException("Category name must be at least 3 characters");

            return _categoryRepos.CreateCategory(categoryDto);
        }
    }
}

