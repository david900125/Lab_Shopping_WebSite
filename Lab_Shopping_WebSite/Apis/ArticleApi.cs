using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Services;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ArticleApi : IApi
    {
        public ArticleApi(DataContext db, IService services)
        {
            if (db == null)
                throw new ArgumentNullException("db");
            this._db = db;

            if (services == null)
                throw new ArgumentNullException("Services");

        }

        ~ArticleApi()
        {
        }

        private DataContext _db;
        private BlogService _blogService;

        public void Register(WebApplication app)
        {
            app.MapGet("/api/article/GetAllTitles", GetAllTitles);
            app.MapGet("/api/article/{id:int}", GetOneBlog);
            app.MapPost("/api/article/update", UpdateArticle);
        }
    }
}
