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
            app.MapGet("/api/Commodity/GetTopCommodity", GetCommodities);
            app.MapPost("/api/Commodity/Search", SelectCommodity);
            app.MapPost("/api/Commodity/GetCommodity/full_info/{CommodityID:int}", Get_full_Commodity_info);
            app.MapPost("/api/Commodity/AddCommodity", AddNewCommodity);
        }
    }
}
