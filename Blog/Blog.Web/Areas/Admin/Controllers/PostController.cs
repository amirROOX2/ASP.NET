using Blog.CoreLayer.DTOs.Posts;
using Blog.CoreLayer.Services.Posts;
using Blog.CoreLayer.Utilities;
using Blog.Web.Areas.Admin.Models.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class PostController : AdminControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int pageID = 1, string title = "", string categorySlug = "")
        {
            var param = new PostFilterParams()
            {
                CategorySlug = categorySlug,
                PageID = pageID,
                Take = 1,
                Title = title
            };
            var model = _postService.GetPostsByFilter(param);
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreatePostViewModel createViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createViewModel);
            }
            var result = _postService.CreatePost(new CreatePostDto()
            {
                CategoryID = createViewModel.CategoryID,
                Description = createViewModel.Description,
                ImageFile = createViewModel.ImageFile,
                Slug = createViewModel.Slug,
                SubCategoryID = createViewModel.SubCategoryID == 0 ? null : createViewModel.SubCategoryID,
                Title = createViewModel.Title,
                IsSpecial = createViewModel.IsSpecial,
                UserID = User.GetUserID()
            });

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(CreatePostViewModel.Slug), result.Message);
                return View(createViewModel);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var post = _postService.GetPostByID(id);
            if (post == null)
                return RedirectToAction("Index");

            var model = new EditPostViewModel()
            {
                CategoryID = post.CategoryID,
                Description = post.Description,
                Slug = post.Slug,
                SubCategoryID = post.SubCategoryID,
                Title = post.Title,
                IsSpecial = post.IsSpecial
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditPostViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }

            var result = _postService.EditPost(new EditPostDto()
            {
                CategoryID = editViewModel.CategoryID,
                Description = editViewModel.Description,
                ImageFile = editViewModel.ImageFile,
                Slug = editViewModel.Slug,
                SubCategoryID = editViewModel.SubCategoryID == 0 ? null : editViewModel.SubCategoryID,
                Title = editViewModel.Title,
                PostID = id,
                IsSpecial = editViewModel.IsSpecial
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(CreatePostViewModel.Slug), result.Message);
                return View(editViewModel);
            }

            return RedirectToAction("Index");
        }
    }
}