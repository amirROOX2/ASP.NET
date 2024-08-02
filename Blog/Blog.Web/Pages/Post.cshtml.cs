using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.CoreLayer.DTOs.Comments;
using Blog.CoreLayer.DTOs.Posts;
using Blog.CoreLayer.Services.Comments;
using Blog.CoreLayer.Services.Posts;
using Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages
{
    [ValidateAntiForgeryToken]
    public class PostModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        public PostModel(IPostService postService, ICommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        public PostDto Post { get; set; }

        [Required]
        [BindProperty]
        public string Text { get; set; }
        [BindProperty]
        public int PostID { get; set; }


        public List<CommentDto> Comments { get; set; }
        public List<PostDto> RelatedPosts { get; set; }
        public IActionResult OnGet(string slug)
        {
            Post = _postService.GetPostBySlug(slug);
            if (Post == null)
                return NotFound();

            Comments = _commentService.GetPostComments(Post.PostID);
            RelatedPosts = _postService.GetRelatedPosts(Post.SubCategoryID ?? Post.CategoryID);
            _postService.IncreaseVisit(Post.PostID);
            return Page();
        }

        public IActionResult OnPost(string slug)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("Post", new { slug });

            if (!ModelState.IsValid)
            {
                Post = _postService.GetPostBySlug(slug);
                Comments = _commentService.GetPostComments(Post.PostID);
                RelatedPosts = _postService.GetRelatedPosts(Post.SubCategoryID ?? Post.CategoryID);
                return Page();
            }

            _commentService.CreateComment(new CreateCommentDto()
            {
                PostID = PostID,
                Text = Text,
                UserID = User.GetUserID()
            });

            return RedirectToPage("Post", new { slug });
        }
    }
}
