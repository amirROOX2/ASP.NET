using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Blog.CoreLayer.DTOs.Categories;

namespace Blog.Web.Areas.Admin.Models.Categories
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Title { get; set; }
        [Display(Name = "Slug")]
        [Required]
        public string Slug { get; set; }
        public int? ParentID { get; set; }
        [Display(Name = "Meta Tag (با - از هم جدا کنید)")]
        public string MetaTag { get; set; }
        [Display(Name = "Meta Description")]
        [DataType(DataType.MultilineText)]
        public string MetaDescription { get; set; }


        public CreateCategoryDto MapToDto()
        {
            return new CreateCategoryDto
            {
                Title = Title,
                Slug = Slug,
                ParentID = ParentID,
                MetaTag = MetaTag,
                MetaDescription = MetaDescription
            };
        }
    }
}
