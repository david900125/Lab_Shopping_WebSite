using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class SalesApi : IApi
    {
        public SalesApi()
        {
        }


        public void Register(WebApplication app)
        {
            app.MapPost("/api/Sales/checkout",CheckOut);
            app.MapPost("/api/Sales/Update", UpdSales);
            app.MapGet("/api/Sales/GetAll", GetAllSales);
        }
    }
}
