using Blog.CoreLayer.Services.FileManager;
using Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _fileManager;

        public UploadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [Route("/Upload/Article")]
        [Authorize]
        public IActionResult UploadArticleImage(IFormFile upload)
        {
            if (upload == null)
                return BadRequest();

            var ImageName = _fileManager.SaveFileAndReturnName(upload, Directories.PostContentImage);

            return Json(new { Uploaded = true, url = Directories.GetPostContentImage(ImageName) });
        }
    }
}
