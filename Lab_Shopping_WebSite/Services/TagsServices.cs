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
        public async Task<List<TagsDto>> GetTagsDto([Optional] int id)
        {
            List<TagsDto> result = new List<TagsDto>();
            if (id != 0)
            {
                _mapper.ProjectTo<TagsDto>(_db.Commodity_Kinds.Where(s => s.Commodity_KindID == id)).ToList();
            }
            else
            {
                _mapper.ProjectTo<TagsDto>(_db.Commodity_Kinds).ToList();
            }

            result.ForEach(t =>
            {
                t.TagName = _db.Tags.Where(s => s.Commodity_KindsID == t.KindsID).OrderBy(s => s.TagID).Select(s => s.Tag).ToList();
                t.TagsID = _db.Tags.Where(s => s.Commodity_KindsID == t.KindsID).OrderBy(s => s.TagID).Select(s => s.TagID).ToList();
            });


            return result;
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
                    tags = await FindTags(kindID , dto.TagName);
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
        // Commodity_Kinds 取用
        public async Task<Tuple<bool, Tags>> FindTags([Optional] int id , [Optional] string TagName)
        {
            Tags result = _db.Tags.Where(s => s.Commodity_KindsID == id).Where(s => s.Tag == TagName).FirstOrDefault();
            if (result != null)
            {
                return Tuple.Create(true, result);
            }
            return Tuple.Create(false, result);
        }
    }
}