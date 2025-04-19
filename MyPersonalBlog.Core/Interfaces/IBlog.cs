using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.Core.Interfaces
{
    public interface IBlog
    {
        Task<bool> CreateBlog(Blog blog);
        IEnumerable<Blog> GetBlogs();
        Task<Blog> GetBlogById(int id);
        Task<bool> UpdateBlog(Blog blog);
        Task<bool> DeleteBlog(int id);
        Task IncreaseView(int id);
        string SaveImage(IFormFile image);
        IEnumerable<Blog> Search(string parameter);
        List<Blog> GetBlogsByFilters(bool? views,bool? likes,bool? publishDate);
    }
}
