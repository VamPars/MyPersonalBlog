using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPersonalBlog.DataLayer.DTOS;

namespace MyPersonalBlog.Core.Interfaces
{
    public interface IUser
    {
        bool RegisterUser(RegisterViewModel user);
    }
}
