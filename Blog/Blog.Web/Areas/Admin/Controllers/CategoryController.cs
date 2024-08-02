using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.CoreLayer.DTOs.Categories;
using Blog.CoreLayer.Services.Categories;
using Blog.CoreLayer.Utilities;
using Blog.Web.Areas.Admin.Models.Categories;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class CategoryController : AdminControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        [Route("/admin/category/add/{parentID?}")]
        public IActionResult Add(int? parentID)
        {
            return View();
        }

        [HttpPost("/admin/category/add/{parentID?}")]
        public IActionResult Add(int? parentID, CreateCategoryViewModel createViewModel)
        {
            createViewModel.ParentID = parentID;
            var result = _categoryService.CreateCategory(createViewModel.MapToDto());

            return RedirectAndShowAlert(result, RedirectToAction("Index"));
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryBy(id);
            if (category == null)
                return RedirectToAction("Index");

            var model = new EditCategoryViewModel()
            {
                Slug = category.Slug,
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
                Title = category.Title,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel editModel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Slug = editModel.Slug,
                MetaTag = editModel.MetaTag,
                MetaDescription = editModel.MetaDescription,
                Title = editModel.Title,
                ID = id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

        public IActionResult GetChildCategories(int parentID)
        {
            var categoy = _categoryService.GetChildCategories(parentID);

            return new JsonResult(categoy);
        }
    }
}
