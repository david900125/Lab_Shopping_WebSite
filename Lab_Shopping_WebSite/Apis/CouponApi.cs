using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class CouponApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.Map("/api/Coupon/Create", Create_Coupon);
        }
    }
}
