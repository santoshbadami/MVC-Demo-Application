using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T GetById(long id);
        T Add(T entity);
        T Get(Expression<Func<T, bool>> where);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
