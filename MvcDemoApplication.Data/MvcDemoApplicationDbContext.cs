using MvcDemoApplication.Model.Categories;
using MvcDemoApplication.Model.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Data
{
    public class MvcDemoApplicationDbContext : DbContext
    {
        public MvcDemoApplicationDbContext()
            : base("MvcDemoApplicationDbContext")
        {
            Database.SetInitializer<MvcDemoApplicationDbContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public static MvcDemoApplicationDbContext Create()
        {
            return new MvcDemoApplicationDbContext();
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
       
    }
}
