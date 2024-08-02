using System;
using Blog.CoreLayer.DTOs.Categories;

namespace Blog.CoreLayer.DTOs.Posts
{
    public class PostDto
    {
        public int PostID { get; set; }
        public string UserFullName { get; set; }
        public int CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }
        public bool IsSpecial { get; set; }
        public DateTime CreationDate { get; set; }
        public CategoryDto Category { get; set; }
        public CategoryDto SubCategory { get; set; }
    }
}