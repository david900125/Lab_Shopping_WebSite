using AutoMapper;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.DTO
{
    // Tags 展示
    public class TagsDto:IMapFrom<Commodity_Kinds>
    {
        public string Kinds { get; set; }
        public int KindsID { get; set; }    
        public List<string> TagName { get; set; }
        public List<int> TagsID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Commodity_Kinds, TagsDto>()
                    .ForMember(d => d.KindsID, opt => opt.MapFrom(s => s.Commodity_KindID))
                    .ForMember(d => d.Kinds, opt => opt.MapFrom(s =>s.Description))
                    .ForMember(d => d.TagName, opt => opt.Ignore())
                    .ForMember(d => d.TagName, opt => opt.Ignore());
        }
    }
    // Tags 新增
    public class NewTagDto : IMapFrom<Commodity_Kinds>
    {
        public List<int> KindsID { get; set; }
        public string TagName { get; set; }
    }
}
