using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.Services
{
    public class BlogService : IService<BlogService>
    {

        public BlogService(DataContext db , AuthDto auth):base(db , auth)
        {
        }

        public async Task<bool> UpdateBlogs(Blogs blog)
        {
            var result = await Updater<Blogs>(blog);
            if (result.Item1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateBlogContents(List<Blog_Contents> Contents)
        {
            foreach(var content in Contents)
            {
                var result = await Updater<Blog_Contents>(content);
                if (!result.Item1)
                {
                    break;
                }
            }        
            return true;
        }

        public async Task<bool> UpdateBlogHrefs(List<Blog_Hrefs> Hrefs)
        {
            foreach(var href in Hrefs)
            {
                var result = await Updater<Blog_Hrefs>(href);
                if (!result.Item1)
                {
                    break;
                }
            }
            return true;
        }

        public async Task<bool> UpdateBlogImages(List<Blog_Images> Images)
        {
            foreach (var Image in Images)
            {
                var result = await Updater<Blog_Images>(Image);
                if (!result.Item1)
                {
                    break;
                }
            }
            return true;
        }
        public async Task<List<BlogDto>> GetArticle()
        {
            var query = (from blogs in _db.Blogs
                         select new BlogDto
                         {
                             BlogID = blogs.BlogID,
                             Blog_Title=blogs.Blog_Title
                         }).ToList();
            foreach (var blog in query)
            {
                blog.Contents = _db.Blog_Contents.Where(n=>n.BlogID == blog.BlogID).OrderBy(n=> n.Order)
                                .Select(n=> new BlogContentDto { 
                                    Blog_ContentID = n.Blog_ContentID,
                                    Blog_Content = n.Blog_Content,
                                    Order = n.Order
                                }).ToList();
                blog.Images = _db.Blog_Images.Where(n => n.BlogID == blog.BlogID).OrderBy(n => n.Order)
                                .Select(n => new BlogImageDto
                                {
                                   BlogID = n.BlogID,
                                   Order = n.Order,
                                   Url = n.Url
                                }).ToList();
            }


            return new List<BlogDto>();
        }
    }
}