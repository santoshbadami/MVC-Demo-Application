using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MvcDemoApplication.Data.Repository.Categories;
using MvcDemoApplication.Model.Categories;

namespace MvcDemoApplication.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository m_CategoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            m_CategoryRepository = categoryRepository;
        }

        public Category GetByCategoryId(long id)
        {
            return m_CategoryRepository.GetByCategoryId(id);
        }

        public void CreateCategory(Category category)
        {
            //Business logic
            m_CategoryRepository.CreateCategory(category);
            
        }

        public void UpdateCategory(Category category)
        {
            m_CategoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            m_CategoryRepository.DeleteCategory(category);
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return m_CategoryRepository.GetAllCategory();
        }

        public IEnumerable<Category> GetCategoryByType(Expression<Func<Category, bool>> exp)
        {
            throw new NotImplementedException();
        }
    }
}
