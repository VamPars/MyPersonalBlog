using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.DataLayer.Entities;

namespace MyPersonalBlog.Components
{
	[ViewComponent(Name = "GetBlogGroups")]
	public class GetBlogGroupsViewComponent : ViewComponent
	{
		private readonly IBlogGroup _blogGroupServices;
		public GetBlogGroupsViewComponent(IBlogGroup blogGroupServices)
		{
			_blogGroupServices = blogGroupServices;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<BlogGroup> blogGroups = _blogGroupServices.GetBlogGroups().ToList();

			return View("BlogGroupsViewComponent", blogGroups);
		}
	}
}
