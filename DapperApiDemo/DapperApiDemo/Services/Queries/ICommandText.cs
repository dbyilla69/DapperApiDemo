using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApiDemo.Services.Queries
{
    public interface ICommandText
    {
        string GetAllCategories { get; }
        string GetCategoriesById { get; }
        string AddCategories{ get; }
        string UpdateCategories { get; }
        string RemoveCategories { get; }
    }
}
