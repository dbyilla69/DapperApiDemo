using DapperApiDemo.Models;
using System.Collections.Generic;


namespace DapperApiDemo.Services.Repositories
{
    public interface ICategoriesRepository
    {
        List<Categories> GetAllCategories();

    }
}
