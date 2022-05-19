using AutoMapper;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.DTO
{
    // Tags 展示
    public class TagsListDto:IMapFrom<Commodity_Kinds>
    {
        public int KindsID { get; set; }
        public string Kinds { get; set; }
        public List<TagsDto> Tag { get; set; }

    }

    public class TagsDto
    {
        public int TagsID { get; set; }
        public string Tag { get; set; }
    }
    // Tags 新增
    public class NewTagDto
    {
        public List<int> KindsID { get; set; }
        public string TagName { get; set; }
    }
    // Tags 更新
    public class UpdateTagDto
    {
        public int KindID { get; set; }
        public int TagID { get; set; }
        public string TagName { get; set; }
    }

}
