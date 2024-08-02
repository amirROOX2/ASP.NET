using Microsoft.AspNetCore.Http;

namespace Blog.CoreLayer.DTOs.Posts
{
    public class EditPostDto
    {
        public int PostID { get; set; }
        public int CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsSpecial { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
