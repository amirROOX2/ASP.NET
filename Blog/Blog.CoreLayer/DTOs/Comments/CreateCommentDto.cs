using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.DTOs.Comments
{
    public class CreateCommentDto
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        public string Text { get; set; }
    }
}
