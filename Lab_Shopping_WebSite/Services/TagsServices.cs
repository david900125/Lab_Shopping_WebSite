using AutoMapper;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using System.Runtime.InteropServices;

namespace Lab_Shopping_WebSite.Services
{
    public class TagsService : IService<TagsService>
    {
        public TagsService(DataContext db, AuthDto auth, IMapper mapper) : base(db, auth, mapper)
        {
        }
        // 商品種類 ( Commodity_Kinds ) 取用 標籤 ( Tags )
        public async Task<List<TagsListDto>> GetTagsDto([Optional] int Commodity_KindID)
        {
            List<TagsListDto> tagsList;
            if (Commodity_KindID != 0)
            {
                tagsList = _db.Commodity_Kinds.Where(s => s.Commodity_KindID == Commodity_KindID)
                            .Select(s =>
                                    new TagsListDto
                                    {
                                        KindsID = s.Commodity_KindID,
                                        Kinds = s.Description,
                                        Tag = s.Tags.Select(t =>
                                                new TagsDto
                                                {
                                                    TagsID = t.TagID,
                                                    Tag = t.Tag
                                                }).ToList()
                                    }).ToList();
            }
            else
            {
                tagsList = _db.Commodity_Kinds.Select(s =>
                                                        new TagsListDto
                                                        {
                                                            KindsID = s.Commodity_KindID,
                                                            Kinds = s.Description,
                                                            Tag = s.Tags.Select(t =>
                                                                    new TagsDto
                                                                    {
                                                                        TagsID = t.TagID,
                                                                        Tag = t.Tag
                                                                    }).ToList()
                                                        }).ToList();
            }
            return tagsList;
        }
        // Tags 新增 
        public async Task<Tuple<bool, string>> InsertTags(NewTagDto dto)
        {
            Tuple<bool, string> Tag;
            Tuple<bool, Tags> tags;
            Tuple<bool, Commodity_Kinds> kinds;

            foreach (int kindID in dto.KindsID)
            {
                kinds = await FindCommodityKinds(kindID);
                if (kinds.Item1)
                {
                    tags = await FindTags(id:kindID, TagName: dto.TagName);
                    if (!tags.Item1)
                    {
                        Tag = await Creater<Tags>(
                        new Tags
                        {
                            Commodity_KindsID = kindID,
                            Tag = dto.TagName
                        });

                        if (!Tag.Item1)
                        {
                            return Tuple.Create(false, "Tags Commodity_KindID" + kindID.ToString() + "Insert Error");
                        }
                    }
                }
                else
                {
                    return Tuple.Create(false, "Commmodity_KindsID" + kindID.ToString() + "Not Found.");
                }
            }

            return Tuple.Create(true, "");
        }
        // Tags 更新
        public async Task<Tuple<bool, string>> UpdateTags(UpdateTagDto dto , Tags model)
        {
            model.Tag = dto.TagName;
            return await Updater<Tags>(model);  
        }
        
        // Commodity_Kinds 取用
        public async Task<Tuple<bool, Commodity_Kinds>> FindCommodityKinds([Optional] int id)
        {
            Commodity_Kinds result = _db.Commodity_Kinds.Where(s => s.Commodity_KindID == id).FirstOrDefault();
            if (result != null)
            {
                return Tuple.Create(true, result);
            }
            return Tuple.Create(false, result);
        }
        // Tags 取用
        public async Task<Tuple<bool, Tags>> FindTags(int id, [Optional] int TagID, [Optional] string TagName)
        {
            Tags result;
            if (TagID != 0)
            {
                result = _db.Tags.Where(s => s.Commodity_KindsID == id).Where(s => s.TagID == TagID).FirstOrDefault();
            }
            else
            {
                result = _db.Tags.Where(s => s.Commodity_KindsID == id).Where(s => s.Tag == TagName).FirstOrDefault();
            }
           
            if (result != null)
            {
                return Tuple.Create(true, result);
            }
            return Tuple.Create(false, result);
        }
    }
}