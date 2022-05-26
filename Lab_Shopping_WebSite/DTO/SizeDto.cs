using AutoMapper;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.DTO
{
    public class SizeDto:IMapFrom<Sizes>
    {
        public int SizeID { get; set; }
        public int CommodityKindID { get; set; }
        public string? Size { get; set; }
        public void Mapping(Profile profile)
        {
            var x = profile.CreateMap<Sizes , SizeDto>()
                           .ForMember(d => d.SizeID, opt => opt.MapFrom(s => s.SizeID))
                           .ForMember(d => d.CommodityKindID, opt => opt.MapFrom(s => s.Commodity_KindsID))
                           .ForMember(d => d.Size, opt => opt.MapFrom(s => s.Size));
        }
    }
}
