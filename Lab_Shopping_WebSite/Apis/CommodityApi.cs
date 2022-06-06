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
            app.MapGet("/api/Commodity/GetTopCommodity", GetCommodities).WithTags("Commodity");
            app.MapGet("/api/Commodity/GetCommodity/full_info/{CommodityID:int}", Get_full_Commodity_info).WithTags("Commodity");
            app.MapGet("/api/Commodity/GetByKinds/{KindID:int}", Get_Commodity_By_Kinds).WithTags("Commodity");
            app.MapGet("/api/Commodity/GetRandom/{Count:int}", Get_Random_Commodity).WithTags("Commodity");
            app.MapGet("/api/Commodity/Delete/{CommodityID:int}", Delete_Commodity).WithTags("Commodity");
            app.MapGet("/api/Shopping_Cart/GetAll", GetShoppingCart).WithTags("Shopping Cart");
            app.MapGet("/api/Commodity/View_Recoder", View_Recoder).WithTags("Shopping Cart");
            app.MapGet("/api/Commodity/LikeCommodity/{CommodityID:int}", Like_Commodity).WithTags("Shopping Cart");
            app.MapGet("/api/Commodity/GetLikeCommodity/{CommodityID:int}", Get_Like_Commodity).WithTags("Shopping Cart");
            app.MapGet("/api/Commodity/GetViewRecoder/{CommodityID:int}", Get_Viewed_Commodity).WithTags("Shopping Cart");
            app.MapPost("/api/Commodity/Search", SelectCommodity).WithTags("Commodity");
            app.MapPost("/api/Commodity/AddCommodity", AddNewCommodity).WithTags("Commodity");
            app.MapPost("/api/Commodity/UpdateCommodity", UpdateCommodity).WithTags("Commodity").WithName("UpdateCommodity");
            app.MapPost("/api/Commodity/addshoppingcart", Add_Shopping_Cart).WithTags("Shopping Cart");
            app.MapPost("/api/Inventor/AddInventor", Insert_Inventor).WithTags("Inventor");
            
        }
    }
}
