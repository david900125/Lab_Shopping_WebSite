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
            app.MapGet("/api/Analyze/SalesCount", Sales_Count).WithTags("Analyze");
            app.MapGet("/api/Analyze/UnShipSales", Sales_Unship_Count).WithTags("Analyze");
            app.MapGet("/api/Analyze/UnPaySales", Sales_UnPay_Count).WithTags("Analyze");
            app.MapGet("/api/Analyze/TopCommodity", Get_Top_Commodity).WithTags("Analyze");
            app.MapGet("/api/Analyze/AllInventor", Get_All_Inventor).WithTags("Analyze");
            app.MapGet("/api/Analyze/AllSales", Get_All_Sales).WithTags("Analyze");
        }
    }
}
