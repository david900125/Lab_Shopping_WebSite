using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.Services
{
    public class BlogService : IService<BlogService>
    {

        public BlogService(DataContext db):base(db)
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
    }
}