using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;
using AutoMapper;

namespace Lab_Shopping_WebSite.DTO
{
    public class CartDto : IMapFrom<Shopping_Carts>
    {
        public int CommodityID { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Amount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Shopping_Carts, CartDto>()
                          .ForMember(d => d.CommodityID, opt => opt.MapFrom(s => s.Commodity_Sizes.CommodityID))
                          .ForMember(d => d.Size, opt => opt.MapFrom(s => s.Commodity_Sizes.Size.Size))
                          .ForMember(d => d.Color, opt => opt.MapFrom(s => s.Commodity_Sizes.Color.Color))
                          .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount));
        }
    }

    public class Commodity_Simple_Dto
    {
        public int CommodityID { get; set; }
        public string CommodityName { get; set; }
        public decimal? CommodityPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public string CommodityUrl { get; set; }
        public List<string> CommodityTags { get; set; }
        public List<string> CommodityKinds { get; set; }
    }

    public class Commodity_Selection_Dto
    {
        public string Selection { get; set; }
    }

    public class NewCommodityDto
    {
        public string CommodityName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public bool isReleased { get; set; }
        public decimal Price { get; set; }
        public decimal S_Price { get; set; }
        public int CommodityKinds { get; set; }
        public List<int> CommodityTags { get; set; }
        public List<int> CommoditySizes { get; set; }
        public List<int> CommodityColors { get; set; }
        public List<string> CommodityImages { get; set; }
    }

    public class UpdateCommodityDto
    {
        public int CommodityID { get; set; }
        public string CommodityName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public bool isReleased { get; set; }
        public decimal Price { get; set; }
        public decimal S_Price { get; set; }
        public int CommodityKinds { get; set; }
        public List<int> CommodityTags { get; set; }
        public List<int> CommoditySizes { get; set; }
        public List<int> CommodityColors { get; set; }
        public List<string> CommodityImages { get; set; }
    }

    public class CommodityDto
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public bool isReleased { get; set; }
        public decimal Price { get; set; }
        public decimal S_Price { get; set; }
        public List<decimal> Amount { get; set; }
        public List<string> CommodityKinds { get; set; }
        public List<string> CommodityTags { get; set; }
        public List<string> CommoditySizes { get; set; }
        public List<string> CommodityColors { get; set; }
        public List<string> CommodityImages { get; set; }
    }

    public class SalesOrder
    {
        public int DeliveryOptionsID { get; set; } // 運送方式
        public int PaymentID { get; set; } // 付款方式
        public string? Address { get; set; } // 地址
        public string? Phone_Number { get; set; } // 電話號碼
        public List<string> Coupons { get; set; } // 優惠券使用
        public List<CartDto> Carts { get; set; } // 訂單內容
    }

}
