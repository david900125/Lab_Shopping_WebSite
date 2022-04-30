using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class CommodityApi : IApi
    {
        public CommodityApi()
        {
        }

        public void Register(WebApplication app)
        {
            app.MapPost("/api/Commodity/addshoppingcart", Add_Shopping_Cart);
            app.MapGet("/api/Commodity/GetTopCommodity/{count:int}", GetCommodities);
            app.MapPost("/api/Commodity/GetCommodity", SelectionCommodity);
        }
    }
}
