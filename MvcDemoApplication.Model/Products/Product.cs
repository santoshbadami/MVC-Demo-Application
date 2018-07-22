using MvcDemoApplication.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemoApplication.Model.Products
{
    [Serializable]
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }

        public Category Category { get; set; }
    }
}
