﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CoreLayer.DTOs.Categories
{
    public class CreateCategoryDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public int? ParentID { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
    }
}
