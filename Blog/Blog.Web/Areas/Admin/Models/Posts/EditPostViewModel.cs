using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.Models.Posts
{
    public class EditPostViewModel
    {
        [Display(Name = "انتخاب دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoryID { get; set; }

        [Display(Name = "انتخاب زیر دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? SubCategoryID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "slug")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Slug { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [UIHint("Ckeditor4")]
        public string Description { get; set; }
        [Display(Name = "پست ویژه")]
        public bool IsSpecial { get; set; }

        [Display(Name = "عکس")]
        public IFormFile? ImageFile { get; set; }
    }
}
