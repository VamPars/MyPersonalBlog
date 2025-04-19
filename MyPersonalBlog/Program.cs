using Microsoft.EntityFrameworkCore;
using MyPersonalBlog.Core.Interfaces;
using MyPersonalBlog.Core.Services;
using MyPersonalBlog.DataLayer.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyPersonalBlogContext>(options =>
options.UseSqlServer(
    "server=.;DataBase=MyPersonalBlogDb;" +
    "Initial Catalog=MyPersonalBlogDb;" +
    "Integrated Security=True;MultipleActiveResultSets=True;"));



builder.Services.AddControllersWithViews();

#region IOC
builder.Services.AddTransient<IBlogGroup, BlogGroupServices>();
builder.Services.AddTransient<IBlog, BlogServices>();
builder.Services.AddTransient<IUser, UserServices>();

#endregion

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
