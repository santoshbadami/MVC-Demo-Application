using MvcDemoApplication.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Service.Categories
{
    public interface ICategoryService
    {
        Category GetByCategoryId(long id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        IEnumerable<Category> GetAllCategory();
        IEnumerable<Category> GetCategoryByType(Expression<Func<Category, bool>> exp);
    }
}
