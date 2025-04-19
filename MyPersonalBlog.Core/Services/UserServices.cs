using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.Core.Tools;
using MyPersonalBlog.DataLayer.Context;
using MyPersonalBlog.DataLayer.DTOS;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.Core.Services
{
    public class UserServices : IUser
    {
        private readonly MyPersonalBlogContext _context;
        public UserServices(MyPersonalBlogContext context)
        {
            _context = context;
        }
        public bool RegisterUser(RegisterViewModel user)
        {
            try
            {
                User newUser = new User()
                {
                    UserName = user.UserName,
                    Password = user.Password.HashPassword(),
                    Email = user.Email,
                    ActivationCode = Guid.NewGuid(),
                    IsActivated = false
                };
                //Send Email
                _context.Users.Add(newUser);
                _context.SaveChanges(); 
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}
