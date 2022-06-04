using AutoMapper;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.DTO
{
    public class CheckOutDto
    {
        public string Address { get; set; }
        public int PaymentID { get; set; }
    }
    public class SaleUpdDto
    {
        public string SaleID { get; set; }
        public string SendDate { get; set; }
        public bool isChecked { get; set; }
        public bool isPayed { get; set; }
    }
    public class SaleDto : IMapFrom<Sales>
    {
        public string SaleID { get; set; }
        public string Address { get; set; }
        public string Phone_Number { get; set; }
        public string Delivery { get; set; }
        public string? SendDate { get; set; }
        public string Established { get; set; }
        public decimal Total_Price { get; set; }
        public bool isChecked { get; set; }
        public bool isPayed { get; set; }
        public List<Sale_Item> Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sales, SaleDto>()
                           .ForMember(d => d.SaleID, opt => opt.MapFrom(s => s.SaleID))
                           .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                           .ForMember(d => d.Phone_Number, opt => opt.MapFrom(s => s.Phone_Number))
                           .ForMember(d => d.Delivery, opt => opt.MapFrom(s => s.Delivery_Option.Delivery_Option))
                           .ForMember(d => d.SendDate, opt => opt.MapFrom(s => s.SendDate.HasValue ? s.SendDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null))
                           .ForMember(d => d.Established, opt => opt.MapFrom(s => s.CreateTime.Value.ToString("yyyy/MM/dd HH:mm:ss")))
                           .ForMember(d => d.Total_Price, opt => opt.MapFrom(s => s.Total_Price))
                           .ForMember(d => d.isPayed, opt => opt.MapFrom(s => s.isPayed))
                           .ForMember(d => d.isChecked, opt => opt.MapFrom(s => s.isChecked))
                           .ForMember(d => d.Items, opt => opt.Ignore());
        }
    }
    public class Sale_Item:IMapFrom<Sales_items>
    {
        public string CommodityName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Amount { get; set; }
        public decimal Unit_Price { get; set; }
        public decimal Total_Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sales_items, Sale_Item>()
                    .ForMember(d => d.CommodityName, opt => opt.MapFrom(s => s.Commodity_Size.Commodity.CommodityName))
                    .ForMember(d => d.Color, opt => opt.MapFrom(s => s.Commodity_Size.Color.Color))
                    .ForMember(d => d.Size, opt => opt.MapFrom(s => s.Commodity_Size.Size.Size))
                    .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                    .ForMember(d => d.Unit_Price, opt => opt.MapFrom(s => s.Unit_Price))
                    .ForMember(d => d.Total_Price, opt => opt.MapFrom(s => s.Total_Price));
        }
    }
}
