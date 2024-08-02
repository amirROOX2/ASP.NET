using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Models.Categories
{
    public class EditCategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; }
        [Display(Name = "Slug")]
        [Required]
        public string Slug { get; set; }
        [Display(Name = "Meta Tag (با - از هم جدا کنید)")]
        public string MetaTag { get; set; }
        [Display(Name = "Meta Description")]
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }
    }
}
