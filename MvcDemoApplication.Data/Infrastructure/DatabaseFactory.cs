using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MvcDemoApplicationDbContext dataContext;

        public MvcDemoApplicationDbContext Get()
        {
            return dataContext ?? (dataContext = new MvcDemoApplicationDbContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
