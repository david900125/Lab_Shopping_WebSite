using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class TestApi:IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/api/test/", GetAll);
        }
    }
}
