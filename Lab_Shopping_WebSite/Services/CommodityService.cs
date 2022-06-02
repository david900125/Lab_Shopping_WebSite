using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;
using AutoMapper;
using System.Runtime.InteropServices;

namespace Lab_Shopping_WebSite.Services
{
    public class CommodityService : IService<CommodityService>
    {
        public CommodityService(DataContext db, AuthDto auth, IMapper mapper) : base(db, auth, mapper) { }

        public async Task<Tuple<bool, Commodity_Sizes>> Get_Commodity_Size(CartDto dto)
        {
            var result = _db.Commodity_Sizes.Where(n => n.Color.Color == dto.Color)
                                            .Where(n => n.Size.Size == dto.Size)
                                            .Where(n => n.CommodityID == dto.CommodityID)
                                            .FirstOrDefault();

            if (result == null)
                return Tuple.Create(false, new Commodity_Sizes());
            else
                return Tuple.Create(true, result);
        }
        public async Task<List<CommodityDto>> Get_Commodities_Simple()
        {
            List<CommodityDto> result = new List<CommodityDto>();
            foreach (var item in _db.Commodities.ToList())
            {
                result.Add(await Inject(item));
            }
            return result;
        }
        public async Task<CommodityDto> GetFullCommodity(int CommodityID)
        {
            CommodityDto result = new CommodityDto();
            Commodities item = _db.Commodities.Where(n => n.CommodityID == CommodityID).FirstOrDefault();
            if (item != null)
            {
                result = await Inject(item);
            }
            return result;
        }
        public async Task<CommodityDto> Inject(Commodities item)
        {
            CommodityDto result = new CommodityDto();
            int CommodityID = item.CommodityID;
            result.CommodityId = item.CommodityID;
            result.CommodityName = item.CommodityName;
            result.Description = item.Description;
            result.Material = item.Material;
            result.isReleased = item.isReleased;
            result.Price = item.Commodity_Prices?.FirstOrDefault(s => s.PriceID == 2)?.Price ?? decimal.Zero;
            result.S_Price = item.Commodity_Prices?.FirstOrDefault(s => s.PriceID == 1)?.Price ?? decimal.Zero;
            result.CommodityTags = item.Commodity_Tags.Join(_db.Tags, ct => ct.TagID, t => t.TagID, (ct, t) => t.Tag).Distinct().ToList();
            result.CommodityKinds = (from tmp in _db.Commodity_Tags
                                     join tags in _db.Tags
                                       on tmp.TagID equals tags.TagID
                                     join kinds in _db.Commodity_Kinds
                                       on tags.Commodity_KindsID equals kinds.Commodity_KindID
                                     where tmp.CommodityID == CommodityID
                                     select kinds.Description).Distinct().ToList();
            result.CommodityImages = item.Images.Where(n => n.CommodityID == CommodityID).Select(n => n.Url).ToList() ?? new List<string>();
            result.CommoditySizes = item.Commodity_Sizes.Join(_db.Sizes, c => c.SizeID, s => s.SizeID, (c, s) => s.Size).Distinct().ToList();
            result.CommodityColors = new List<string>();
            var color_collections = item.Commodity_Sizes?.Join(_db.Colors, s => s.ColorID, c => c.ColorID, (s, c) => new { c.Url, c.Color }).Distinct().ToList();
            foreach (var color in color_collections)
            {
                result.CommodityColors.Add(color.Color);
                result.CommodityColors.Add(color.Url);
            }

            var amount_col = (from tmp in item.Commodity_Sizes
                              select new
                              {
                                  Amount = _db.Inventories.OrderByDescending(n => n.InventoryID)
                                          .Where(n => n.Commodity_SizeID == tmp.Commodity_SizesID)
                                          .Select(n => n.Amount).Take(1).FirstOrDefault()
                              }).ToList();

            result.Amount = new List<decimal>();
            foreach (var amount in amount_col)
            {
                result.Amount.Add(amount.Amount);
            }

            return result;
        }

        public async Task<Tuple<bool, string>> Insert_Shopping_Cart(int MemberID, Commodity_Sizes sizes, int Amount)
        {
            return await
            Creater<Shopping_Carts>(new Shopping_Carts
            {
                MemberID = MemberID,
                Commodity_SizeID = sizes.Commodity_SizesID,
                Amount = Convert.ToDecimal(Amount),
                Creator = MemberID,
                CreateTime = DateTime.Now,
                Modifier = MemberID,
                ModifyTime = DateTime.Now
            });
        }
        public async Task<Tuple<bool, string, Commodities>> Insert_Commodities(NewCommodityDto dto, int Sid)
        {
            var mast = new Commodities
            {
                CommodityName = dto.CommodityName,
                Description = dto.Description,
                Material = dto.Material,
                isReleased = dto.isReleased
            };

            var result = await Creater(mast);

            return Tuple.Create(result.Item1, result.Item2, mast);
        }
        public async Task<Tuple<bool, string>> Insert_Prices(Commodities commodity, decimal Price, decimal S_Price, int Sid)
        {
            var mast = new Commodity_Prices
            {
                CommodityID = commodity.CommodityID,
                PriceID = 2,    // 標價
                Price = Price,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                Creator = Sid,
                CreateTime = DateTime.Now,
                Modifier = Sid,
                ModifyTime = DateTime.Now
            };
            var result = await Creater(mast);
            if (result.Item1)
            {
                var mast2 = new Commodity_Prices
                {
                    CommodityID = commodity.CommodityID,
                    PriceID = 1,    // 優惠價
                    Price = S_Price,
                    StartDate = DateOnly.FromDateTime(DateTime.Now),
                    Creator = Sid,
                    CreateTime = DateTime.Now,
                    Modifier = Sid,
                    ModifyTime = DateTime.Now
                };
                result = await Creater(mast2);
            }

            return result;
        }
        public async Task<Tuple<bool, string>> Insert_Images(Commodities commodity, List<string> images, int Sid)
        {
            int Counter = 1;
            Tuple<bool, string> mast = Tuple.Create(true, "");
            foreach (var img in images)
            {
                mast = await Creater(new Commodity_Images
                {
                    CommodityID = commodity.CommodityID,
                    Url = img,
                    Order = Counter,
                    Creator = Sid,
                    CreateTime = DateTime.Now,
                    Modifier = Sid,
                    ModifyTime = DateTime.Now
                });

                if (!mast.Item1)
                {
                    break;
                }
                Counter++;
            }

            return mast;
        }
        public async Task<Tuple<bool, string>> Insert_Tags(Commodities commodity, List<int> tags, int Sid)
        {
            Tuple<bool, string> tuple;
            foreach (int tag in tags)
            {
                tuple = await Creater(new Commodity_Tags
                {
                    CommodityID = commodity.CommodityID,
                    TagID = tag,
                    Creator = Sid,
                    CreateTime = DateTime.Now,
                    Modifier = Sid,
                    ModifyTime = DateTime.Now
                });
                if (!tuple.Item1)
                    return tuple;
            }
            return Tuple.Create(true, "");
        }
        public async Task<Tuple<bool, string>> Insert_Sizes(Commodities commodity, List<int> sizes, List<int> colors, int Sid)
        {
            Tuple<bool, string> mast = Tuple.Create(true, "");
            foreach (var size in sizes)
            {
                foreach (var color in colors)
                {
                    mast = await Creater(new Commodity_Sizes
                    {
                        CommodityID = commodity.CommodityID,
                        SizeID = size,
                        ColorID = color
                    });

                    if (!mast.Item1)
                    {
                        return mast;
                    }
                }
            }

            return mast;
        }
        public async Task<Tuple<bool, string>> Insert_Viewed(int CommodityID)
        {
            return await Creater
            (new Recently_Viewed
            {
                CommodityID = CommodityID,
                MemberID = _auth.IsAuth ? _auth.UserID.MemberID : null
            });
        }


        public async Task<Tuple<bool, string>> Update_Commodity(Commodities mast, UpdateCommodityDto dto)
        {
            mast.CommodityName = dto.CommodityName == mast.CommodityName ? mast.CommodityName : dto.CommodityName;
            mast.Description = dto.Description == mast.Description ? mast.Description : dto.Description;
            mast.Material = dto.Material == mast.Material ? mast.Material : dto.Material;
            mast.isReleased = dto.isReleased == mast.isReleased ? mast.isReleased : dto.isReleased;
            return await Updater<Commodities>(mast);
        }
        public async Task<Tuple<bool, string>> Update_Images(Commodities mast, UpdateCommodityDto dto)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(true, "");
            List<Commodity_Images> images = mast.Images.ToList();
            for (int i = 0; i < images.Count; i++)
            {
                if (i < dto.CommodityImages.Count)
                {
                    if (images[i].Url != dto.CommodityImages[i])
                    {
                        images[i].Url = dto.CommodityImages[i];
                        result = await Updater<Commodity_Images>(images[i]);
                        if (!result.Item1)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }
        public async Task<Tuple<bool, string>> Update_Prices(Commodities mast, UpdateCommodityDto dto)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false, "");
            List<Commodity_Prices> prices = mast.Commodity_Prices.ToList();
            // 優惠價
            List<Commodity_Prices> S_Price = prices.Where(p => p.PriceID == 1).ToList();
            S_Price[0].Price = S_Price[0].Price == dto.S_Price ? S_Price[0].Price : dto.S_Price;
            result = await Updater<Commodity_Prices>(S_Price[0]);

            if (result.Item1)
            {
                List<Commodity_Prices> Price = prices.Where(p => p.PriceID == 2).ToList();
                Price[0].Price = Price[0].Price == dto.Price ? Price[0].Price : dto.Price;
                result = await Updater<Commodity_Prices>(Price[0]);
            }

            return result;
        }
        public async Task<Tuple<bool, string>> Update_Tags(Commodities mast, UpdateCommodityDto dto)
        {
            Tuple<bool, string> result = await DeleteTag(mast.CommodityID);
            if (result.Item1)
            {
                result = await Insert_Tags(mast, dto.CommodityTags, _auth.UserID.MemberID);
            }

            return result;
        }
        public async Task<Tuple<bool, string>> Update_Sizes(Commodities mast, UpdateCommodityDto dto)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false, "");
            result = await DeleteSize(mast.CommodityID);
            if (result.Item1)
            {
                result = await Insert_Sizes(mast, dto.CommoditySizes, dto.CommodityColors, _auth.UserID.MemberID);
            }

            return result;
        }

        public async Task<Tuple<bool, string>> DeleteCommodity(int CommodityID)
        {
            var d1 = await Deleter(_db.Commodities.Where(n => n.CommodityID == CommodityID).First());
            if (d1.Item1)
            {
                var d2 = await DeleteImg(CommodityID);
                if (d2.Item1)
                {
                    var d3 = await DeletePrice(CommodityID);
                    if (d3.Item1)
                    {
                        var d4 = await DeletePrice(CommodityID);
                        if (d4.Item1)
                        {
                            var d5 = await DeleteTag(CommodityID);
                            return d5;
                        }
                        return d4;
                    }
                    return d3;
                }
                return d2;
            }
            return d1;
        }
        public async Task<Tuple<bool, string>> DeleteImg(int CommodityID)
        {
            var query = _db.Commodity_Images.Where(n => n.CommodityID == CommodityID).ToList();
            if (query.Count > 0)
            {
                return await Deleter(query);
            }
            return Tuple.Create(true, "NotFound.");
        }
        public async Task<Tuple<bool, string>> DeleteSize(int CommodityID)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(true, "");
            var query = _db.Commodity_Sizes.Where(n => n.CommodityID == CommodityID).ToList();
            if (query.Count > 0)
            {
                foreach (var item in query)
                {
                    result = await Deleter(item);
                    if (!result.Item1)
                        return result;
                }
            }
            return result;
        }
        public async Task<Tuple<bool, string>> DeletePrice(int CommodityID)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(true, "");
            var query = _db.Commodity_Prices.Where(n => n.CommodityID == CommodityID).ToList();
            if (query.Count > 0)
            {
                foreach (var item in query)
                {
                    result = await Deleter(item);
                    if (!result.Item1)
                        return result;
                }
            }
            return result;
        }
        public async Task<Tuple<bool, string>> DeleteTag(int CommodityID)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(true, "");
            var query = _db.Commodity_Tags.Where(n => n.CommodityID == CommodityID).ToList();
            if (query.Count > 0)
            {
                foreach (var item in query)
                {
                    result = await Deleter(item);
                    if (!result.Item1)
                        return result;
                }
            }
            return result;
        }

        public async Task<Commodities> FindCommodity(int CommodityID)
        {
            return _db.Commodities.Where(s => s.CommodityID == CommodityID).FirstOrDefault();
        }
        public async Task<List<CommodityDto>> SelectByName(Commodity_Selection_Dto dto)
        {
            List<Commodities> commodities = _db.Commodities.Where(n => n.CommodityName.Contains(dto.Selection)).ToList();
            List<CommodityDto> result = new List<CommodityDto>();
            foreach (var commodity in commodities)
            {
                result.Add(await Inject(commodity));
            }
            return result;
        }
        public async Task<List<CommodityDto>> SalectByKinds(int KindID)
        {
            List<CommodityDto> result = new List<CommodityDto>();
            var kinds = _db.Commodity_Kinds.Where(n => n.Commodity_KindID == KindID).Select(n => n.Commodity_KindID).ToList();
            var sizes = _db.Sizes.Where(n => kinds.Contains(n.Commodity_KindsID)).Select(n => n.SizeID).ToList();
            var commotdity_size = _db.Commodity_Sizes.Where(n => sizes.Contains(n.Commodity_SizesID)).Select(n => n.CommodityID).ToList();
            List<Commodities> tmps = _db.Commodities.Where(n => commotdity_size.Contains(n.CommodityID)).ToList();
            foreach (var tmp in tmps)
            {
                result.Add(await Inject(tmp));
            }

            return result;
        }
        public async Task<List<CommodityDto>> GetRandom(int Count)
        {
            Random random = new Random();
            List<CommodityDto> results = new List<CommodityDto>();
            List<Commodities> items = _db.Commodities.OrderBy(x => Guid.NewGuid()).Take(Count).ToList();
            foreach (var item in items)
            {
                results.Add(await Inject(item));
            }

            return results;
        }
        public async Task<List<CartDto>> GetShoppingCart()
        {
            var query = _db.Shopping_Carts.Where(s => s.MemberID == _auth.UserID.MemberID).ToList();
            foreach(var item in query)
            {

            }
            return new List<CartDto>();
        }
    }
}
