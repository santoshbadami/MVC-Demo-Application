using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using MvcDemoApplication.Model.Products;

namespace MvcDemoApplication.web.Models
{
    public class ProductViewModel 
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage="Please select category")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage="Please enter product name")]
        public string ProductName { get; set; }

        public SelectList CatList { get; set; }
    }
}