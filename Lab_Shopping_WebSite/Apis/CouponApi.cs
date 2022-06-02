using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class CouponApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/api/Coupon/GetAll", GetAllCoupon).WithTags("Coupon");
            app.MapGet("/api/Coupon/GetAllCouponWays", Get_All_Coupon_Ways).WithTags("Coupon");
            app.MapGet("/api/Coupon/Delete/{CouponID:int}", Delete_Coupon).WithTags("Coupon");
            app.MapPost("/api/Coupon/Create", Create_Coupon).WithTags("Coupon");
            app.MapPost("/api/Coupon/Update", Update_Coupon).WithTags("Coupon");
        }
    }
}
