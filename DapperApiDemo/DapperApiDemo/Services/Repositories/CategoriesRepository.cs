using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperApiDemo.Models;
using DapperApiDemo.Services.ExecuteCommands;
using DapperApiDemo.Services.Queries;
using Microsoft.Extensions.Configuration;

namespace DapperApiDemo.Services.Repositories
{

    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ICommandText _commandText;
        private readonly string _connStr;
        private readonly IExecuters _executers;

        
        public CategoriesRepository(IConfiguration configuration, ICommandText commandText, IExecuters executers)
        {
            _commandText = commandText;
            _configuration = configuration;
            _connStr = _configuration.GetConnectionString("NORTHWND");
            _executers = executers;
        }


        public List<Categories> GetAllCategories()
        {
            var query = _executers.ExecuteCommand(_connStr,
                conn => conn.Query<Categories>(_commandText.GetAllCategories)).ToList();
            return query;
        }

        public Categories GetById(int categoryId)
        {
            var category = _executers.ExecuteCommand<Categories>(_connStr, conn =>
                conn.Query<Categories>(_commandText.GetCategoriesById, new { @CategoryId = categoryId }).SingleOrDefault());
            return category;
        }

        public void AddCategory(Categories entity)
        {
            _executers.ExecuteCommand(_connStr, conn =>
            {
                var query = conn.Query<Categories>(_commandText.AddCategories,
                    new { CategoryName = entity.CategoryName, Description = entity.Description});
            });
        }

        public void UpdateCategory(Categories entity, int categoryId)
        {
            _executers.ExecuteCommand(_connStr, conn =>
            {
                var query = conn.Query<Categories>(_commandText.UpdateCategories,
                    new { CategoryName = entity.CategoryName, Description = entity.Description, CategoryId = categoryId });
            });
        }

        public void RemoveCategory(int categoryId)
        {
            _executers.ExecuteCommand(_connStr, conn =>
            {
                var query = conn.Query<Categories>(_commandText.RemoveCategories, new { CategoryId = categoryId });
            });
        }
    }
    }
