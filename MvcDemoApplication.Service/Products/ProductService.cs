using MvcDemoApplication.Data.Repository.Products;
using MvcDemoApplication.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Service.Products
{
    public class ProductService : IProductService
    {
        IProductRepository m_ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            m_ProductRepository = productRepository;
        }

        public Product GetByProductId(long id)
        {
            return m_ProductRepository.GetByProductId(id);
        }

        public void CreateProduct(Product product)
        {
            //Business logic
            m_ProductRepository.CreateProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            m_ProductRepository.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            m_ProductRepository.DeleteProduct(product);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return m_ProductRepository.GetAllProduct();
        }

        public IEnumerable<Product> GetProductByType(Expression<Func<Product, bool>> exp)
        {
            throw new NotImplementedException();
        }
    }
}
