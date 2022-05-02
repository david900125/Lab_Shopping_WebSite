using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.Services
{
    public class CouponServices:IService<CouponServices>
    {
        public CouponServices(DataContext db) : base(db)
        {
        }

        public async Task<Tuple<bool,string>> CreateCoupon(CraeteCouponDto dto , int MemberID)
        {
            Coupons coupon = new Coupons() 
            { 
                Coupon_Title = dto.Coupon_Title,
                Coupon_Key = dto.Coupon_Key,
                Coupon_Content = dto.Coupon_Content,
                Coupon_WayID = dto.Coupon_WayID, 
                Amount_Achieved = 0, // 達成量
                Discount = dto.DisCount,
                Issued_Amount = dto.Issued_Amount,
                Issued_Date = DateTime.Now,
                isIssued = dto.isIssued,
                Received_Amount = 0,
                Modifier = MemberID,
                Creator = MemberID,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            };
            return await Creater(coupon);
        }

        public async Task<List<Coupons>> GetCoupons()
        {
            return _db.Coupons.ToList();
        }
    }
}
