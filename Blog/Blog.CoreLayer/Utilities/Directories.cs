﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.Utilities
{
    public class Directories
    {
        public const string PostImage = "wwwroot/images/posts";
        public const string PostContentImage = "wwwroot/images/posts/content";
        public static string GetPostImage(string ImageName) => $"{PostImage.Replace("wwwroot", "")}/{ImageName}";
        public static string GetPostContentImage(string ImageName) => $"{PostContentImage.Replace("wwwroot", "")}/{ImageName}";
    }
}
