using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.CoreLayer.DTOs.Comments;
using Blog.CoreLayer.Utilities;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Blog.CoreLayer.Services.Comments
{
    public interface ICommentService
    {
        OperationResult CreateComment(CreateCommentDto command);
        List<CommentDto> GetPostComments(int postID);
    }
    public class CommentService : ICommentService
    {
        private readonly BlogContext _context;

        public CommentService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult CreateComment(CreateCommentDto command)
        {
            var comment = new PostComment()
            {
                PostID = command.PostID,
                UserID = command.UserID,
                Text = command.Text
            };
            _context.PostComments.Add(comment);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CommentDto> GetPostComments(int postID)
        {
            return _context.PostComments
                .Include(c => c.User)
                .Where(c => c.PostID == postID)
                .Select(comment => new CommentDto()
                {
                    CommentID = comment.ID,
                    PostID = comment.PostID,
                    UserFullName = comment.User.FullName,
                    Text = comment.Text,
                    CreationDate = comment.CreationDate
                }).ToList();
        }
    }
}
