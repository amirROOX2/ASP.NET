﻿using Blog.DataLayer.Entities;

namespace Blog.CoreLayer.DTOs.Users
{
    public class EditUserDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public UserRole Role { get; set; }

    }
}
