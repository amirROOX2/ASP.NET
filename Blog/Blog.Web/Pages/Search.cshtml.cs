using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.CoreLayer.DTOs.Posts;
using Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages
{
    public class SearchModel : PageModel
    {
        private IPostService _postService;

        public SearchModel(IPostService postService)
        {
            _postService = postService;
        }
        public PostFilterDto Filter { get; set; }
        public void OnGet(int pageID = 1, string categorySlug = null, string q = null)
        {
            Filter = _postService.GetPostsByFilter(new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageID = pageID,
                Take = 2,
                Title = q
            });
        }

        public IActionResult OnGetPagination(int pageID = 1, string categorySlug = null, string q = null)
        {
            var model = _postService.GetPostsByFilter(new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageID = pageID,
                Take = 2,
                Title = q
            });
            return Partial("_SearchView", model);
        }
    }
}
