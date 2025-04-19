using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.DataLayer.Context;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.Core.Services
{
    public class BlogServices : IBlog
    {
        private readonly MyPersonalBlogContext _Context;
        public BlogServices(MyPersonalBlogContext context)
        {
            _Context = context;
        }
        public async Task<bool> CreateBlog(Blog blog)
        {
            try
            {
                _Context.Add(blog);
                await _Context.SaveChangesAsync();
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public async Task<bool> DeleteBlog(int id)
        {
            try
            {
                Blog blog = await GetBlogById(id);
                _Context.Remove(blog);
                _Context.SaveChanges();
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _Context.Blogs.FindAsync(id);
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _Context.Blogs;
        }

        public IEnumerable<Blog> Search(string parameter)
        {
            //var Blogs = GetBlogs();
            //var result = new List<Blog>();
            //string[] Tags;
            //foreach (var blog in Blogs)
            //{
            //    Tags = blog.Tags.Split(',');
            //    foreach (var blogTag in Tags)
            //    {
            //        if (blogTag.Contains(tag))
            //        {
            //            result.Add(blog);
            //        }
            //    }
            //}
            return GetBlogs().Where(b=> b.Tags.Contains(parameter) || b.Description.Contains(parameter)|| b.ShortDescription.Contains(parameter) || b.Title.Contains(parameter)).ToList();

        }

        public async Task IncreaseView(int id)
        {
            Blog blog = await GetBlogById(id);
            blog.Viewes++;
            await _Context.SaveChangesAsync();
        }

        public string SaveImage(IFormFile image)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "Images", "Blog");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string fullPath = Path.Combine(directoryPath, fileName);
            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                image.CopyTo(fs);
            }
            return fileName;
        }




        public async Task<bool> UpdateBlog(Blog blog)
        {
            try
            {
                _Context.Update(blog);
               await _Context.SaveChangesAsync();
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public List<Blog> GetBlogsByFilters(bool? views=false, bool? likes=false, bool? publishDate=false)
        {
            var res = GetBlogs();

            if (views.Value)
            {
                res = res.OrderBy(b => b.Viewes);
            }
            if (likes.Value)
            {
                res = res.OrderBy(b=> b.Likes);
            }
            if (publishDate.Value)
            {
                res = res.OrderByDescending(b => b.PublishDate);
            }
            return res.ToList();
        }
    }
}
