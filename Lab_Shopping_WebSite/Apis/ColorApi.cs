using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ColorApi : IApi
    {
        public ColorApi()
        {
        }

        public void Register(WebApplication app)
        {
            app.MapGet("/api/Color/GetAll/{id:int}", GetAll);
        }
    }
}
