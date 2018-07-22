using MvcDemoApplication.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Model.Categories
{
    [Serializable]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
