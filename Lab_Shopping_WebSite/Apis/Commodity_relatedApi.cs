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
            // Colors
            app.MapGet("/api/Color/GetAll", GetAll).WithTags("Colors").WithName("GetAllColors");
            app.MapGet("/api/Color/GetAll/{id:int}", GetOneColor).WithTags("Colors").WithName("GetOneColors");
            app.MapPost("/api/Color/CreateColor", InsertColor).WithTags("Colors").WithName("CreateNewColor");
            app.MapPost("/api/Color/UpdateColor", UpdateColor).WithTags("Colors").WithName("UpdateColor");
            app.MapPost("/api/Color/DeleteColor", DeleteColor).WithTags("Colors").WithName("DeleteColor");

            // Tags
            app.MapGet("/api/Tags/GetAll", GetAllTags).WithTags("Tags").WithName("GetAllTags");
            app.MapPost("/api/Tags/Insert", InsertTag).WithTags("Tags").WithName("InsertTags");
            app.MapPost("/api/Tags/Update", UpdateTag).WithTags("Tags").WithName("UpdateTags");
        }
    }
}
