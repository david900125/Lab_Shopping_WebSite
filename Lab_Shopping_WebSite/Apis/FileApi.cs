using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class FileApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/api/file/upload", UploadFile);
        }
    }
}
