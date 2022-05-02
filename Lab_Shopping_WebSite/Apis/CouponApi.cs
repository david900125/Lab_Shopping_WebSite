using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class CouponApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/api/Coupon/Create", Create_Coupon);
            app.MapGet("/api/Coupon/GetAll" , GetAllCoupon);
        }
    }
}
