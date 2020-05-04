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
    }
    public class SqlConnectionConfiguration
    {
        public SqlConnectionConfiguration(string value) => Value = value;
        public string Value { get; }
    }
}
