using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemoApplication.Service.Categories;
using MvcDemoApplication.web.Models;
using MvcDemoApplication.Model.Categories;
using MvcDemoApplication.Data.Infrastructure;

namespace MvcDemoApplication.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService m_CategoryService = null;
        private IUnitOfWork uow = null;

        
        public CategoryController(ICategoryService categoryService,IUnitOfWork unitofwork)
        {
            m_CategoryService = categoryService;
            uow = unitofwork;
        }

        public ActionResult Index(int id=0)
        {
            ViewBag.msg = TempData["msg"] == null ? "" : TempData["msg"] as string;

            CategoryViewModel _categoryViewModel = new CategoryViewModel();
            Category _category = new Category();
            if(id!=0)
            {                
                _category = m_CategoryService.GetByCategoryId(Convert.ToInt64(id));
                _categoryViewModel.CategoryID = _category.CategoryID;
                _categoryViewModel.CategoryName = _category.CategoryName;
            }
            return View(_categoryViewModel);
        }

        [HttpPost]
        public ActionResult Index(CategoryViewModel _categoryViewModel,int id=0)
        {
            int flag = 0;
            if (ModelState.IsValid)
            {
                Category _category = new Category();
                _category.CategoryID = _categoryViewModel.CategoryID;
                _category.CategoryName = _categoryViewModel.CategoryName;

                //Add
                if (id == 0)
                {
                    flag = 0;
                    m_CategoryService.CreateCategory(_category);
                }
                //Update
                else
                {
                    flag = 1;
                    m_CategoryService.UpdateCategory(_category);
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
        public ActionResult getCategorylist()
        {            
            List<Category> _category_List = new List<Category>();
            List<CategoryViewModel> _categoryViewModel_List = new List<CategoryViewModel>();

            _category_List = m_CategoryService.GetAllCategory().ToList();

            foreach(Category _cat in _category_List )
            {
                CategoryViewModel _categoryViewModel = new CategoryViewModel();
                _categoryViewModel.CategoryID = _cat.CategoryID;
                _categoryViewModel.CategoryName = _cat.CategoryName;
                _categoryViewModel_List.Add(_categoryViewModel);
            }

            return PartialView("_getCategorylist",_categoryViewModel_List);
        }
        public ActionResult delete(int id=0)
        {
            Category _category = new Category();
            if (id != 0)
            {
              _category = m_CategoryService.GetByCategoryId(Convert.ToInt64(id));
              m_CategoryService.DeleteCategory(_category);
              uow.Commit();
              TempData["msg"] = "Record deleted successfully";
            }
            return RedirectToAction("index");
        }
	}
}