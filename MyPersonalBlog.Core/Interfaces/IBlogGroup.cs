using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPersonalBlog.DataLayer.DTOS;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.Core.Interfaces
{
    public interface IBlogGroup
    {
        //CRUD
        Task<bool> CreateBlogGroup(CreateBlogGroupViewModel blogGroupViewModel);
        IEnumerable<BlogGroup> GetBlogGroups();
        Task<BlogGroup> GetBlogGroupById(int id);
        Task<bool> UpdateBlogGroup(EditBlogGroupViewModel blogGroupViewModel);
        Task<bool> DeleteBlogGroup(int id);
        Task<List<Blog>> GetBlogsByBlogGroupId(int blogGroupId);




    }
}
