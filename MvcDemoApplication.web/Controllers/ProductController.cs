using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemoApplication.Service.Products;
using MvcDemoApplication.web.Models;
using MvcDemoApplication.Model.Categories;
using MvcDemoApplication.Model.Products;
using MvcDemoApplication.Service.Categories;
using MvcDemoApplication.Data.Infrastructure;

namespace MvcDemoApplication.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService m_ProductService;
        private readonly ICategoryService m_CategoryService;
        private IUnitOfWork uow = null;

        public ProductController(IProductService productService, ICategoryService categoryService,IUnitOfWork unitofwork)
        {
            m_ProductService = productService;
            m_CategoryService = categoryService;
            uow = unitofwork;
        }

        public ActionResult Index(int id=0)
        {
            ViewBag.msg = TempData["msg"] == null ? "" : TempData["msg"] as string;

            ProductViewModel model = new ProductViewModel();
            Product _product = new Product();

            if(id!=0)
            {
              _product = m_ProductService.GetByProductId(Convert.ToInt64(id));
              model.ProductID = _product.ProductID;
              model.CategoryID = _product.CategoryID;
              model.ProductName = _product.ProductName;
            }
            model.CatList = new SelectList(m_CategoryService.GetAllCategory(),"CategoryID","CategoryName",model.CategoryID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ProductViewModel _productViewModel,int id=0)
        {
            int flag = 0;

            if(ModelState.IsValid)
            {
                Product _product = new Product();
                _product.ProductID = _productViewModel.ProductID;
                _product.CategoryID = _productViewModel.CategoryID;
                _product.ProductName = _productViewModel.ProductName;

                //Add
                if (id == 0)
                {
                  flag = 0;
                  m_ProductService.CreateProduct(_product);
                }
                //Update
                else
                {
                  flag = 1;
                  m_ProductService.UpdateProduct(_product);
                }
                uow.Commit();
                if (flag == 0)
                    TempData["msg"] = "Record saved successfully";
                else
                    TempData["msg"] = "Record updated successfully";
                RouteData.Values.Remove("id");
            }
            return RedirectToAction("Index");
        }

        public ActionResult getProductlist()
        {
            List<Product> _productlist = m_ProductService.GetAllProduct().ToList();
            List<ProductViewModel> _productViewModellist = new List<ProductViewModel>();

            foreach(Product _product in _productlist)
            {
                ProductViewModel _productViewModel = new ProductViewModel();
                _productViewModel.ProductID = _product.ProductID;
                _productViewModel.CategoryID = _product.CategoryID;
                _productViewModel.ProductName = _product.ProductName;
                _productViewModellist.Add(_productViewModel);
            }
            return PartialView("_getProductlist", _productViewModellist);
        }

        public ActionResult delete(int id = 0)
        {
            Product _product = new Product();
            if (id != 0)
            {
                _product = m_ProductService.GetByProductId(Convert.ToInt64(id));
                m_ProductService.DeleteProduct(_product);
                uow.Commit();
                TempData["msg"] = "Record deleted successfully";
            }
            return RedirectToAction("index");
        }

      

        public ActionResult fluent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FluentDataModel model)
        {
            if (ModelState.IsValid)
            {

                return this.RedirectToAction("Index");
            }

            return View("fluent", model);
        }

	}
}