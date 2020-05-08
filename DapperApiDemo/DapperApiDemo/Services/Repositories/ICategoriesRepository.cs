using DapperApiDemo.Models;
using System.Collections.Generic;


namespace DapperApiDemo.Services.Repositories
{
    public interface ICategoriesRepository
    {
        List<Categories> GetAllCategories();
        Categories GetById(int categoriesId);
        void AddCategory(Categories entity);
        void UpdateCategory(Categories entity, int categoriesId);
        void RemoveCategory(int categoriesId);

    }
}
