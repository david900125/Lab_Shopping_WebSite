

using AutoMapper;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.DTO;

namespace Lab_Shopping_WebSite.Map
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<BlogDto, Blogs>(MemberList.None)
                .ForMember(
                    dest => dest.BlogID,
                    opt => opt.MapFrom(src => $"{src.BlogID}")
                )
                .ForMember(
                    dest => dest.Blog_Title,
                    opt => opt.MapFrom(src => $"{src.Blog_Title}")
                ).ReverseMap();

            CreateMap<Blogs, BlogDto>(MemberList.None)
                .ForMember(
                    dest => dest.BlogID,
                    opt => opt.MapFrom(src => $"{src.BlogID}")
                )
                .ForMember(
                    dest => dest.Blog_Title,
                    opt => opt.MapFrom(src => $"{src.Blog_Title}")
                )
                .ForMember(
                    dest => dest.Hrefs,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Images,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Contents,
                    opt => opt.Ignore()
                );
        }
    }
}
