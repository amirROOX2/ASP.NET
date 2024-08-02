using System.Collections.Generic;
using Blog.CoreLayer.DTOs.Posts;
using Blog.CoreLayer.Utilities;

namespace Blog.CoreLayer.DTOs.Posts
{
    public class PostFilterDto : BasePagination
    {
        public List<PostDto> Posts { get; set; }
        public PostFilterParams FilterParams { get; set; }
    }

    public class PostFilterParams
    {
        public string Title { get; set; }
        public string CategorySlug { get; set; }
        public int PageID { get; set; }
        public int Take { get; set; }
    }
}
