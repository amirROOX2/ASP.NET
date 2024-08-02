using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Blog.CoreLayer.DTOs.Posts
{
    public class CreatePostDto
    {
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsSpecial { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
