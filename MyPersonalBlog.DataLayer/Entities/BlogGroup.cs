using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalBlog.DataLayer.Entities
{
    public class BlogGroup
    {
        public int Id { get; set; }
        public string BlogGroupName { get; set; }
        public List<Blog> Blogs { get; set; }

    }
}
