using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.DataLayer.Entities;
using MyPersonalBlog.Models;

namespace MyPersonalBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogGroup _blogGroupServices;
        private readonly IBlog _blogServices;
        public HomeController(ILogger<HomeController> logger,IBlogGroup blogGroupServices, IBlog blogServices)
        {
            _logger = logger;
            _blogGroupServices = blogGroupServices;
            _blogServices = blogServices;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            List<Blog> blogs = _blogServices.GetBlogs().ToList();
            return View(blogs);
        }
        public async Task<IActionResult> GetBlogByBlogGroups(int id)
        {

            return View(await _blogGroupServices.GetBlogsByBlogGroupId(id));
        }

        public async Task<IActionResult> ShowBlog(int id)
        {
            Blog blog = await _blogServices.GetBlogById(id);
            if (blog==null)
            {
                TempData["ErrorMessage"] = "url را انگلوک نکن";
                return Redirect("/");
            }
            await _blogServices.IncreaseView(id);
             ViewBag.Tags = blog.Tags.Split(',');
           
            return View(blog);
        }

        public IActionResult Search(string id)
        {
            return View("index",_blogServices.Search(id));
        }

        public IActionResult Filter(bool? views=false, bool? likes = false, bool? publishDate = false)
        {
            return View("index", _blogServices.GetBlogsByFilters(views, likes, publishDate));
        }
    }
}