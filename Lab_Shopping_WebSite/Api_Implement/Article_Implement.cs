using Microsoft.AspNetCore.Mvc;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DTO;
using AutoMapper;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ArticleApi
    {
        async Task<IResult> GetAllTitles([FromServices] DataContext _db)
        {
            List<Blogs>? blogs = _db.Blogs.OrderByDescending(u => u.BlogID)
                                        .Take(100).ToList();
            return Results.Ok(blogs);
        }

        async Task<IResult> GetOneBlog([FromServices] DataContext _db, int id)
        {
            Blogs? blog = _db.Blogs?.SingleOrDefault(n => n.BlogID == id);

            if (blog == null)
                return Results.NotFound();

            var blog_imgs = _db.Blog_Images?.Where(n => n.BlogID == blog.BlogID).ToList();
            var blog_hrefs = _db.Blog_Hrefs?.Where(n => n.BlogID == blog.BlogID).ToList();
            var blog_contents = _db.Blog_Contents?.Where(n => n.BlogID == blog.BlogID).ToList();

            return Results.Ok(
                new
                {
                    BlogID = blog.BlogID,
                    Blog_Title = blog.Blog_Title,
                    Establish = blog.CreateTime,
                    Blog_Contents = blog_contents,
                    Blog_Hrefs = blog_hrefs,
                    Blog_Images = blog_imgs
                });
        }

        async Task<IResult> UpdateArticle(
            [FromServices] DataContext _db,
            [FromServices] IService<BlogService> service,
            [FromServices] IMapper _mapper,
            [FromBody] BlogDto blogvm)
        {
            BlogService bs = (BlogService)service;
            var blog_col = blogvm.Split(blogvm);

            if (await bs.UpdateBlogs(blog_col.Item1))
                if (await bs.UpdateBlogContents(blog_col.Item2))
                    if (await bs.UpdateBlogImages(blog_col.Item3))
                        if (await bs.UpdateBlogHrefs(blog_col.Item4))
                            return Results.Ok("Success");
                        else
                            return Results.BadRequest();
                    else
                        return Results.BadRequest();
                else
                    return Results.BadRequest();
            else
                return Results.BadRequest();
        }

        async Task<IResult> GetArticle(
            [FromServices] IService<BlogService> service
            )
        {
            BlogService bs = (BlogService)service;
            bs.GetArticle();
            return Results.Ok();
            
        }
    }
}
