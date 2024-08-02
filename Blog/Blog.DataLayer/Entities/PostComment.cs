using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataLayer.Entities
{
    public class PostComment : BaseEntity
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        [Required]
        public string Text { get; set; }

        #region Relations
            [ForeignKey("PostID")]
            public Post Post { get; set; }
            [ForeignKey("UserID")]
            public User User { get; set; }
        #endregion
    }
}