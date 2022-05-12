using AutoMapper;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.DTO
{
    public class ColorDto:IMapFrom<Colors>
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorUrl { get; set; }

        public void Mapping(Profile profile)
        {
            var x = profile.CreateMap<Colors, ColorDto>()
                           .ForMember(d => d.ColorId, opt => opt.MapFrom(s => s.ColorID))
                           .ForMember(d => d.ColorName, opt => opt.MapFrom(s => s.Color))
                           .ForMember(d => d.ColorUrl, opt => opt.MapFrom(s => s.Url));

            var z = profile.CreateMap<ColorDto, Colors>()
                           .ForMember(d => d.ColorID, opt => opt.Ignore())
                           .ForMember(d => d.Color, opt => opt.MapFrom(s => s.ColorName))
                           .ForMember(d => d.Url, opt => opt.MapFrom(s => s.ColorUrl));
        }
    }
}
