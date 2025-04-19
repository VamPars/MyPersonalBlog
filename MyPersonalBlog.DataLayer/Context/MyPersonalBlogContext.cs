using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.DataLayer.Context
{
    public class MyPersonalBlogContext: DbContext
    {
        public MyPersonalBlogContext
            (DbContextOptions<MyPersonalBlogContext> options)
        : base(options)
        {
        }
        public DbSet<BlogGroup> BlogGroups { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
