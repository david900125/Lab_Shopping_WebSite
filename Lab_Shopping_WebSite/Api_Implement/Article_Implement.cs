using Lab_Shopping_WebSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ArticleApi
    {
        async Task<IResult> GetAllTitles()
        {
            List<Blogs>? blogs = _db.Blogs.OrderByDescending(u => u.BlogID)
                                        .Take(100).ToList();
            return Results.Ok(blogs);
        }

        async Task<IResult> GetOneBlog(int id)
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

        // async Task<IResult> UpdateArticle([Bind("Blog_Title")] Blogs blog)
        // {

        // }
    }
}
