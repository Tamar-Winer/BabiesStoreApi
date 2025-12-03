using BabiesStoreApi.Data;
using BabiesStoreApi.Dtos;
using BabiesStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BabiesStoreApi.Repo
{
    public class CategoryRepos
    {
        private readonly StoreContextDB _storeContext = StoreDbFactory.CreateContext();

        public bool CreateCategory(CategoryDto categoryDto)
        {
            try
            {
                Category category = new Category()
                {
                    name = categoryDto.name
                };

                _storeContext.Categories.Add(category);
                _storeContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

    }

}

