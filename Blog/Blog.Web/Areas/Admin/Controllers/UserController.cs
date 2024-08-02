﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.CoreLayer.Services.Users;
using Blog.CoreLayer.Utilities;
using Blog.Web.Areas.Admin;
using Blog.CoreLayer.DTOs.Users;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class UserController : AdminControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int pageId = 1)
        {
            return View(_userService.GetUsersByFilter(pageId, 10));
        }
        [HttpPost]
        public IActionResult Edit(EditUserDto editModel)
        {
            var result = _userService.EditUser(editModel);
            if (result.Status != OperationResultStatus.Success)
            {
                ErrorAlert(result.Message);
                return RedirectToAction("Index");
            }
            return RedirectAndShowAlert(result, RedirectToAction("Index"));
        }
        public IActionResult ShowEditModal(int userId)
        {
            var user = _userService.GetUserById(userId);
            return PartialView("_EditUser", new EditUserDto()
            {
                FullName = user.FullName,
                Role = user.Role,
                UserID = userId
            });
        }
    }
}
