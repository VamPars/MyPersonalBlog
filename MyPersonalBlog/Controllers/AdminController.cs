using Microsoft.AspNetCore.Mvc;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.DataLayer.DTOS;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogGroup _blogGroupServices;
        private readonly IBlog _blogServices;
        public AdminController(IBlogGroup blogGroupServices, IBlog blogServices)
        {
            _blogGroupServices = blogGroupServices;
            _blogServices = blogServices;
        }
        public IActionResult Index()
        {
            ViewBag.blogGroups = _blogGroupServices.GetBlogGroups().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult CreateBlogGroup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlogGroup(CreateBlogGroupViewModel createBlogGroupViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBlogGroupViewModel);
            }
            if (await _blogGroupServices.CreateBlogGroup(createBlogGroupViewModel))
            {
                return Redirect("/admin/index");
            }
            ModelState.AddModelError("BlogGroupName", "عملیات با شکست مواجه شد");
            return View(createBlogGroupViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> EditBlogGroup(int id)
        {
            BlogGroup blogGroup = await _blogGroupServices.GetBlogGroupById(id);
            if (blogGroup == null)
            {
                return BadRequest("این مدل یافت نشد");
            }
            EditBlogGroupViewModel editBlogGroup = new EditBlogGroupViewModel()
            {
                BlogGroupName = blogGroup.BlogGroupName,
                Id = id
            };
            return View(editBlogGroup);
        }
        [HttpPost]
        public async Task<IActionResult> EditBlogGroup(EditBlogGroupViewModel editBlogGroupViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editBlogGroupViewModel);
            }
            if (await _blogGroupServices.UpdateBlogGroup(editBlogGroupViewModel))
            {
                return Redirect("/admin/index");
            }
            ModelState.AddModelError("BlogGroupName", "عملیات با شکست مواجه شد");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogViewModel blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            Blog newBlog = new Blog()
            {
                BlogGroupId = blog.BlogGroupId,
                Description = blog.Description,
                ShortDescription = blog.ShortDescription,
                Tags = blog.Tags,
                Thumbnail = "No.png",
                PublishDate = DateTime.Now,
                Title = blog.Title,
                Likes = 0,
                Viewes = 0
            };
            if (blog.Thumbnail != null && blog.Thumbnail.Length > 0)
            {
                newBlog.Thumbnail = _blogServices.SaveImage(blog.Thumbnail);
            }


            if (await _blogServices.CreateBlog(newBlog))
            {
                return Redirect("/Admin/index");
            }
            return View(newBlog);
        }


    }
}
