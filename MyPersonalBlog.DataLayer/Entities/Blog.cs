using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonalBlog.DataLayer.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int Viewes { get; set; }
        public int Likes { get; set; }
        public string? Tags { get; set; }
        public DateTime PublishDate { get; set; }
        public int BlogGroupId { get; set; }
        public BlogGroup BlogGroup { get; set; }
    }
}
