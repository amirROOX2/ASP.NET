using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blog.CoreLayer.DTOs.Posts;
using Blog.CoreLayer.DTOs;
using Blog.CoreLayer.Services.Posts;
using Blog.CoreLayer.Services;

namespace Blog.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IMainPageService _mainPageService;
        public IndexModel(IPostService postService, IMainPageService mainPageService)
        {
            _postService = postService;
            _mainPageService = mainPageService;
        }

        public MainPageDto MainPageData { get; set; }

        public void OnGet()
        {
            MainPageData = _mainPageService.GetData();
        }

        public IActionResult OnGetLatestPosts(string categorySlug)
        {
            var filterDto = _postService.GetPostsByFilter(new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageID = 1,
                Take = 6
            });
            return Partial("_LatestPosts", filterDto.Posts);
        }
        public IActionResult OnGetPopularPost()
        {
            return Partial("_PopularPosts", _postService.GetPopularPost());
        }
    }
}
