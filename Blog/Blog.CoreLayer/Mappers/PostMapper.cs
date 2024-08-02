using Blog.CoreLayer.DTOs.Posts;
using Blog.CoreLayer.Mappers;
using Blog.CoreLayer.Utilities;
using Blog.DataLayer.Entities;

namespace Blog.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post()
            {
                Description = dto.Description,
                CategoryID = dto.CategoryID,
                Slug = dto.Slug.ToSlug(),
                Title = dto.Title,
                UserID = dto.UserID,
                Visit = 0,
                IsDelete = false,
                SubCategoryID = dto.SubCategoryID,
                IsSpecial = dto.IsSpecial
            };
        }
        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                CategoryID = post.CategoryID,
                Slug = post.Slug,
                Title = post.Title,
                UserFullName = post.User?.FullName,
                Visit = post.Visit,
                CreationDate = post.CreationDate,
                Category = post.Category == null ? null : CategoryMapper.Map(post.Category),
                ImageName = post.ImageName,
                PostID = post.ID,
                SubCategoryID = post.SubCategoryID,
                SubCategory = post.SubCategory == null ? null : CategoryMapper.Map(post.SubCategory),
                IsSpecial = post.IsSpecial
            };
        }
        public static Post EditPost(EditPostDto editDto, Post post)
        {
            post.Description = editDto.Description;
            post.Title = editDto.Title;
            post.CategoryID = editDto.CategoryID;
            post.Slug = editDto.Slug.ToSlug();
            post.SubCategoryID = editDto.SubCategoryID;
            post.IsSpecial = editDto.IsSpecial;
            return post;
        }
    }
}