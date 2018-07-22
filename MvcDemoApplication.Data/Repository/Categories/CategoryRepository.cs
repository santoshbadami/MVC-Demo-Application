using MvcDemoApplication.Data.Infrastructure;
using MvcDemoApplication.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Data.Repository.Categories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public Category GetByCategoryId(long id)
        {
            return this.GetById(id);
        }

        public void CreateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException("category");
            this.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException("category");
            this.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException("category");
            this.Delete(category);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return this.GetAll();
        }

        public IEnumerable<Category> GetCategoryByType(Expression<Func<Category, bool>> exp)
        {
            return this.GetMany(exp);
        }
    }
}
