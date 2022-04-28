using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ArticleApi : IApi
    {
        public ArticleApi()
        {
        }

        public void Register(WebApplication app)
        {
            app.MapGet("/api/article/GetAllTitles", GetAllTitles);
            app.MapGet("/api/article/{id:int}", GetOneBlog);
            app.MapPost("/api/article/update", UpdateArticle);
        }
    }
}
