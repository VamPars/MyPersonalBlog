using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.DataLayer.Context;
using MyPersonalBlog.DataLayer.DTOS;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.Core.Services
{
    public class BlogGroupServices : IBlogGroup
    {
        private readonly MyPersonalBlogContext _context;
        public BlogGroupServices(MyPersonalBlogContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateBlogGroup(CreateBlogGroupViewModel blogGroupViewModel)
        {
            try
            {
                BlogGroup blogGroup = new BlogGroup()
                {
                    BlogGroupName = blogGroupViewModel.BlogGroupName,
                };
                _context.BlogGroups.Add(blogGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> DeleteBlogGroup(int id)
        {
            try
            {
                BlogGroup blogGroup = await GetBlogGroupById(id);
                _context.Remove(blogGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<BlogGroup> GetBlogGroupById(int id)
        {
            return await _context.BlogGroups.FindAsync(id);
        }

        public IEnumerable<BlogGroup> GetBlogGroups()
        {
            return _context.BlogGroups;
        }

        public async Task<bool> UpdateBlogGroup(EditBlogGroupViewModel blogGroupViewModel)
        {
            try
            {
                BlogGroup blogGroup = new BlogGroup()
                {
                    BlogGroupName = blogGroupViewModel.BlogGroupName,
                    Id = blogGroupViewModel.Id
                };
                _context.Update(blogGroup);
               await _context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<List<Blog>> GetBlogsByBlogGroupId(int blogGroupId)
		{
            return _context.Blogs.Where(b => b.BlogGroupId == blogGroupId).ToList();
        }
    }
}
