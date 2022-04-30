using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.DTO
{
    public  class BlogDto
    {
        public int BlogID { get; set; }
        public string? Blog_Title { get; set; }
        public List<BlogContentDto>? Contents { get; set; }
        public List<BlogImageDto>? Images { get; set; }
        public List<BlogHrefDto>? Hrefs { get; set; }

        public Tuple<Blogs, List<Blog_Contents>, List<Blog_Images>, List<Blog_Hrefs>> Split(BlogDto dto)
        {
            Blogs blog = new Blogs
            {
                BlogID = dto.BlogID,
                Blog_Title = dto.Blog_Title
            };

            return Tuple.Create(
                blog,
                new BlogContentDto().Split(dto),
                new BlogImageDto().Split(dto),
                new BlogHrefDto().Split(dto)
            );
        }
    }

    public class BlogContentDto
    {
        public int Blog_ContentID { get; set; }
        public string? Blog_Content { get; set; }
        public int Order { get; set; }

        public List<Blog_Contents> Split(BlogDto blogdto)
        {
            List<Blog_Contents> blogs = new List<Blog_Contents>();
            var dtos = blogdto.Contents;

            foreach (var dto in dtos)
            {
                blogs.Add(new Blog_Contents
                {
                    BlogID = blogdto.BlogID,
                    Blog_ContentID = dto.Blog_ContentID,
                    Blog_Content = dto.Blog_Content,
                    Order = dto.Order
                });
            }

            return blogs;
        }
    }
    public class BlogImageDto
    {
        public int BlogID { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public List<Blog_Images> Split(BlogDto blogdto)
        {
            List<Blog_Images> blogs = new List<Blog_Images>();
            var dtos = blogdto.Images;

            foreach (var dto in dtos)
            {
                blogs.Add(new Blog_Images
                {
                    BlogID = blogdto.BlogID,
                    Url = dto.Url,
                    Order = dto.Order
                });
            }

            return blogs;
        }
    }
    public class BlogHrefDto
    {
        public int CommodityID { get; set; }
        public int Order { get; set; }

        public List<Blog_Hrefs> Split(BlogDto blogdto)
        {
            List<Blog_Hrefs> blogs = new List<Blog_Hrefs>();
            var dtos = blogdto.Hrefs;

            foreach (var dto in dtos)
            {
                blogs.Add(new Blog_Hrefs
                {
                    BlogID = blogdto.BlogID,
                    CommodityID = dto.CommodityID,
                    Order = dto.Order
                });
            }

            return blogs;
        }
    }
}
