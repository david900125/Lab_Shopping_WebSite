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
                Issued_Date = Convert.ToDateTime(dto.Issued_Date),
                End_Date = Convert.ToDateTime(dto.End_Date),
                isIssued = dto.isIssued,
                Received_Amount = 0,
                Modifier = MemberID,
                Creator = MemberID,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            };
            return await Creater(coupon);
        }

        public async Task<List<CouponDto>> GetCoupons()
        {
            var quey= (from coupon in _db.Coupons
                        join ways in _db.Coupon_Ways
                            on coupon.Coupon_WayID equals ways.Coupon_WayID
                        select ( 
                        new CouponDto
                        {
                            CouponID = coupon.CouponID,
                            Coupon_Title = coupon.Coupon_Title,
                            Coupon_Content = coupon.Coupon_Content,
                            Coupon_Key = coupon.Coupon_Key,
                            isIssued = coupon.isIssued,
                            Issued_Date = coupon.Issued_Date.ToString("yyyy-MM-dd HH:mm:ss"),
                            End_Date = coupon.End_Date.ToString("yyyy-MM-dd HH:mm:ss"),
                            Coupon_Way = ways.Coupon_Way,
                            DisCount = coupon.Discount
                        })).ToList();

            return quey;
        }
    }
}
