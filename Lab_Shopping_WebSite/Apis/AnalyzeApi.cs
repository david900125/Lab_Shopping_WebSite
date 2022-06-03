using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class AnalyzeApi : IApi
    {
        public AnalyzeApi()
        {
        }

        public void Register(WebApplication app)
        {
            app.MapGet("/api/Analyze/GetWeekView", Get_Week_View).WithTags("Analyze");
        }
    }
}
