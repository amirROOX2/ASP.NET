using System;
using System.Collections.Generic;
using System.Linq;
using Blog.CoreLayer.DTOs.Categories;
using Blog.CoreLayer.Mappers;
using Blog.CoreLayer.Services.Categories;
using Blog.CoreLayer.Utilities;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.CoreLayer.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateCategory(CreateCategoryDto command)
        {
            if (IsSlugExist(command.Slug))
                return OperationResult.Error("Slug Is Exist");

            var category = new Category()
            {
                Title = command.Title,
                IsDelete = false,
                ParentID = command.ParentID,
                Slug = command.Slug.ToSlug(),
                MetaTag = command.MetaTag,
                MetaDescription = command.MetaDescription
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditCategory(EditCategoryDto command)
        {
            var category = _context.Categories.FirstOrDefault(c => c.ID == command.ID);
            if (category == null)
                return OperationResult.NotFound();

            if (command.Slug.ToSlug() != category.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("Slug Is Exist");

            category.MetaDescription = command.MetaDescription;
            category.Slug = command.Slug.ToSlug();
            category.Title = command.Title;
            category.MetaTag = command.MetaTag;

            //_context.Update(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _context.Categories.Select(category => CategoryMapper.Map(category)).ToList();
        }

        public CategoryDto GetCategoryBy(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.ID == id);

            if (category == null)
                return null;

            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public List<CategoryDto> GetChildCategories(int parentID)
        {
            return _context.Categories.Where(r => r.ParentID == parentID)
                .Select(category => CategoryMapper.Map(category)).ToList();
        }

        public bool IsSlugExist(string slug)
        {
            return _context.Categories.Any(c => c.Slug == slug.ToSlug());
        }
    }
}