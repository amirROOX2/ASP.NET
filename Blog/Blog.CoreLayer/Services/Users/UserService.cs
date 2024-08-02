using System;
using System.Linq;
using Blog.CoreLayer.DTOs.Users;
using Blog.CoreLayer.Services.Users;
using Blog.CoreLayer.Utilities;
using Blog.DataLayer.Context;
using Blog.DataLayer.Entities;

namespace Blog.CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;

        public UserService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult EditUser(EditUserDto command)
        {
            var user = _context.Users.FirstOrDefault(c => c.ID == command.UserID);
            if (user == null)
                return OperationResult.NotFound();

            user.FullName = command.FullName;
            user.Role = command.Role;
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult RegisterUser(UserRegisterDto registerDto)
        {
            var isUserNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);

            if (isUserNameExist)
                return OperationResult.Error("نام کاربری تکراری است");

            var passwordHash = registerDto.Password.EncodeToMd5();
            _context.Users.Add(new User()
            {
                FullName = registerDto.FullName,
                IsDelete = false,
                UserName = registerDto.UserName,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = passwordHash
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public UserDto LoginUser(LoginUserDto loginDto)
        {
            var passwordHashed = loginDto.Password.EncodeToMd5();
            var user = _context.Users
                .FirstOrDefault(u => u.UserName == loginDto.UserName && u.Password == passwordHashed);

            if (user == null)
                return null;

            var userDto = new UserDto()
            {
                FullName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName,
                RegisterDate = user.CreationDate,
                UserID = user.ID
            };
            return userDto;
        }

        public UserDto GetUserById(int userId)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.ID == userId);
            if (user == null)
                return null;
            return new UserDto()
            {
                FullName = user.FullName,
                Password = user.Password,
                Role = user.Role,
                UserName = user.UserName,
                RegisterDate = user.CreationDate,
                UserID = user.ID
            };
        }

        public UserFilterDto GetUsersByFilter(int pageId, int take)
        {
            var users = _context.Users.OrderByDescending(d => d.ID)
                .Where(c => !c.IsDelete);

            var skip = (pageId - 1) * take;
            var model = new UserFilterDto()
            {
                Users = users.Skip(skip).Take(take).Select(user => new UserDto()
                {
                    FullName = user.FullName,
                    Password = user.Password,
                    Role = user.Role,
                    UserName = user.UserName,
                    RegisterDate = user.CreationDate,
                    UserID = user.ID
                }).ToList()
            };
            model.GeneratePaging(users, take, pageId);
            return model;
        }
    }
}
