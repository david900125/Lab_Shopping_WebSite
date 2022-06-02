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
            app.MapGet("/api/Sales/GetAll", GetAllSales).WithTags("Sales");
            app.MapGet("/api/Sales/GetMySales", GetSales).WithTags("Sales");
            app.MapPost("/api/Sales/checkout",CheckOut).WithTags("Sales");
            app.MapPost("/api/Sales/Update", UpdSales).WithTags("Sales");
        }
    }
}
