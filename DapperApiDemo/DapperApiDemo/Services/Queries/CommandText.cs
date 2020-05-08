using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApiDemo.Services.Queries
{
    public class CommandText:ICommandText
    {
        public string GetAllCategories => "select * from Categories";
        public string GetCategoriesById => "Select * from Categories where CategoryId= @CategoryId";
        public string AddCategories => "Insert into  [NORTHWND].[dbo].[Categories] ([CategoryName], Description) values (@CategoryName, @Description)";
        public string UpdateCategories => "Update [NORTHWND].[dbo].[Categories] set CategoryName = @CategoryName, Description = @Description where CategoryId =@CategoryId";
        public string RemoveCategories => "Delete from [NORTHWND].[dbo].[Categories] where CategoryId= @CategoryId";
    }
}
