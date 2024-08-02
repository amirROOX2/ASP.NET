using System.Collections.Generic;
using Blog.CoreLayer.DTOs.Posts;
using Blog.CoreLayer.Utilities;

namespace Blog.CoreLayer.Services.Posts
{
    public interface IPostService
    {
        OperationResult CreatePost(CreatePostDto command);
        OperationResult EditPost(EditPostDto command);
        PostDto GetPostByID(int postID);
        PostDto GetPostBySlug(string slug);
        PostFilterDto GetPostsByFilter(PostFilterParams filterParams);
        bool IsSlugExist(string slug);
        List<PostDto> GetRelatedPosts(int groupID);
        List<PostDto> GetPopularPost();
        void IncreaseVisit(int postID);
    }
}
