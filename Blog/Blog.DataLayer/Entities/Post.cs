using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DataLayer.Entities;

namespace Blog.DataLayer.Entities
{
    public class Post : BaseEntity
    {
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }
        public bool IsSpecial { get; set; }

        #region Relations

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        [ForeignKey("SubCategoryID")]
        public Category SubCategory { get; set; }
        public ICollection<PostComment> PostComments { get; set; }

        #endregion
    }
}
