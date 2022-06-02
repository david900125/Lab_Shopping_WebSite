using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;
using AutoMapper;

namespace Lab_Shopping_WebSite.DTO
{
    public class CraeteCouponDto
    {
        public string Coupon_Key { get; set; }
        public string Coupon_Title { get; set; }
        public string Coupon_Content { get; set; }
        public int Coupon_WayID { get; set; }
        public decimal Amount_Achieved { get; set; }    // 達成條件
        public int Issued_Amount { get; set; }
        public decimal DisCount { get; set; }   // 折價 
        public string Issued_Date { get; set; }
        public string End_Date { get; set; }
        public bool isIssued { get; set; }
    }
    public class UpdateCouponDto
    {
        public int CouponID { get; set; }
        public string Coupon_Key { get; set; }
        public string Coupon_Title { get; set; }
        public string Coupon_Content { get; set; }
        public int Coupon_WayID { get; set; }
        public decimal Amount_Achieved { get; set; }    // 達成條件
        public int Issued_Amount { get; set; }
        public decimal DisCount { get; set; }   // 折價 
        public string Issued_Date { get; set; }
        public string End_Date { get; set; }
        public bool isIssued { get; set; }
    }
    public class CouponDto : IMapFrom<Coupons>
    {
        public int CouponID { get; set; }
        public string Coupon_Key { get; set; }
        public string Coupon_Title { get; set; }
        public string Coupon_Content { get; set; }
        public int Coupon_WayID { get; set; }
        public string Coupon_Way { get; set; }
        public int Issued_Amount { get; set; }
        public decimal Amount_Achieved { get; set; }
        public string Issued_Date { get; set; }
        public string End_Date { get; set; }
        public decimal DisCount { get; set; }
        public bool isIssued { get; set; }

        public void Mapping(Profile profile)
        { 
            profile.CreateMap<Coupons, CouponDto>()
                           .ForMember(d => d.CouponID, opt => opt.MapFrom(s => s.CouponID))
                           .ForMember(d => d.Coupon_Key, opt => opt.MapFrom(s => s.Coupon_Key))
                           .ForMember(d => d.Coupon_Title, opt => opt.MapFrom(s => s.Coupon_Title))
                           .ForMember(d => d.Coupon_Content, opt => opt.MapFrom(s => s.Coupon_Content))
                           .ForMember(d => d.Coupon_WayID, opt => opt.MapFrom(s => s.Coupon_WayID))
                           .ForMember(d => d.Coupon_Way, opt => opt.MapFrom(s => s.Coupon_Ways.Coupon_Way))
                           .ForMember(d => d.Issued_Amount, opt => opt.MapFrom(s => s.Issued_Amount))
                           .ForMember(d => d.Amount_Achieved, opt => opt.MapFrom(s => s.Amount_Achieved))
                           .ForMember(d => d.Issued_Date, opt => opt.MapFrom(s => s.Issued_Date.ToString("yyyy/MM/dd HH:mm:ss")))
                           .ForMember(d => d.End_Date, opt => opt.MapFrom(s => s.End_Date.ToString("yyyy/MM/dd HH:mm:ss")))
                           .ForMember(d => d.DisCount, opt => opt.MapFrom(s => s.Discount))
                           .ForMember(d => d.isIssued, opt => opt.MapFrom(s => s.isIssued));
        }
    }
    public class Coupon_WaysDto : IMapFrom<Coupon_Ways>
    {
        public int Coupon_WayID { get; set; }
        public string? Coupon_Way { get; set; }
        public void Mapping(Profile profile)
        {
            var x = profile.CreateMap<Coupon_Ways, Coupon_WaysDto>()
                           .ForMember(d => d.Coupon_WayID, opt => opt.MapFrom(s => s.Coupon_WayID))
                           .ForMember(d => d.Coupon_Way, opt => opt.MapFrom(s => s.Coupon_Way));
        }
    }
}
