﻿using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;


namespace Lab_Shopping_WebSite.Services
{
    public class CommodityService:IService<CommodityService>
    {
        public CommodityService(DataContext db) : base(db) { }

        public async Task<Tuple<bool,Commodity_Sizes>> Get_Commodity_Size(CartDto dto)
        {
             var result = _db.Commodity_Sizes.Where(n => n.ColorID == dto.ColorID)
                                            .Where(n => n.SizeID == dto.SizeID)
                                            .Where(n=>n.CommodityID == dto.CommodityID)
                                            .FirstOrDefault();

            if (result == null)
                return Tuple.Create(false, new Commodity_Sizes());
            else
                return Tuple.Create(true, result);
        }
        public async Task<List<Commodity_Simple_Dto>> Get_Commodities_Simple()
        {
            var s_prices = (from prices in _db.Commodity_Prices
                            where prices.Commodity_PriceID == 1
                            select (new { prices.CommodityID, prices.Price }));

            var c_price = (from prices in _db.Commodity_Prices
                          where prices.Commodity_PriceID == 2
                          select (new { prices.CommodityID, prices.Price }));

            var query = (from Commodities in _db.Commodities
                         join sprice in s_prices
                             on Commodities.CommodityID equals sprice.CommodityID into sprices
                         from spr in sprices.DefaultIfEmpty()
                         join cprice in c_price
                             on Commodities.CommodityID equals cprice.CommodityID into cprices
                         from cpr in cprices.DefaultIfEmpty()
                         join image in (from imgs in _db.Commodity_Images where imgs.Order == 1 select imgs)
                             on Commodities.CommodityID equals image.CommodityID into images
                         from img in images.DefaultIfEmpty()
                         select new Commodity_Simple_Dto
                         {
                             CommodityID = Commodities.CommodityID,
                             CommodityName = Commodities.CommodityName,
                             CommodityPrice = cpr.Price,
                             SpecialPrice = spr.Price,
                             CommodityUrl = img.Url ?? string.Empty
                         }).ToList();


            return query;
        }
        public async Task<CommodityDto> GetFullCommodity(int CommodityID)
        {
            CommodityDto result = new CommodityDto();
            Commodities item = _db.Commodities.Where(n=> n.CommodityID == CommodityID).FirstOrDefault();
            if (item != null)
            {
                result.CommodityId = item.CommodityID;
                result.CommodityName = item.CommodityName;
                result.Description = item.Description;
                result.Material = item.Material;
                result.Price = _db.Commodity_Prices.Where(n => n.CommodityID == CommodityID).Where(n => n.PriceID == 2).FirstOrDefault().Price;
                result.S_Price = _db.Commodity_Prices.Where(n => n.CommodityID == CommodityID).Where(n => n.PriceID == 1).FirstOrDefault().Price;
                result.CommodityTags = (from tmp in _db.Commodity_Tags
                                       join tags in _db.Tags
                                         on tmp.TagID equals tags.TagID
                                       select tags.Tag).First();
                 result.CommodityKinds = (from tmp in _db.Commodity_Tags
                                          join tags in _db.Tags
                                            on tmp.TagID equals tags.TagID
                                          join kinds in _db.Commodity_Kinds
                                            on tags.Commodity_KindsID equals kinds.Commodity_KindID
                                          where tmp.CommodityID == CommodityID
                                          select kinds.Description).First();
                result.CommodityImages = _db.Commodity_Images.Where(n => n.CommodityID == CommodityID).Select(n => n.Url).ToList();
                result.CommoditySizes = (from tmp in _db.Commodity_Sizes
                                         join sizes in _db.Sizes
                                            on tmp.SizeID equals sizes.SizeID
                                         where tmp.CommodityID == CommodityID
                                         select sizes.Size).ToList();
                var color_collections = (from tmp in _db.Commodity_Sizes
                                          join colors in _db.Colors
                                             on tmp.ColorID equals colors.ColorID
                                          where tmp.CommodityID == CommodityID
                                          select new {colors.Url,colors.Color}).ToList();

                result.CommodityColors = new List<string>();
                foreach (var color in color_collections)
                {
                    result.CommodityColors.Add(color.Color);
                    result.CommodityColors.Add(color.Url);
                }

                var amount_col = (from tmp in _db.Commodity_Sizes
                                where tmp.CommodityID == CommodityID
                                select new
                                {
                                    Amount = _db.Inventories.OrderByDescending(n=>n.InventoryID)
                                            .Where(n=>n.Commodity_SizeID == tmp.Commodity_SizesID)
                                            .Select(n => n.Amount).Take(1).FirstOrDefault()
                                }).ToList();

                result.Amount = new List<decimal>();
                foreach (var amount in amount_col)
                {
                    result.Amount.Add(amount.Amount);
                }
            } 
            return result;
        }
        public async Task<Tuple<bool , string>> Insert_Shopping_Cart(int MemberID , Commodity_Sizes sizes , int Amount)
        {
            return await
            Creater<Shopping_Carts>(new Shopping_Carts
            {
                MemberID = MemberID,
                Commodity_SizeID = sizes.SizeID,
                Amount = Convert.ToDecimal(Amount),
                Creator = MemberID,
                CreateTime = DateTime.Now,
                Modifier = MemberID,
                ModifyTime = DateTime.Now
            });
        }
        public async Task<Tuple<bool, string,Commodities>> Insert_Commodities(NewCommodityDto dto , int Sid)
        {
            var mast = new Commodities
            {
                CommodityName = dto.CommodityName,
                Description = dto.Description,
                Material = dto.Material,
                Creator = Sid,
                CreateTime = DateTime.Now,
                Modifier = Sid,
                ModifyTime = DateTime.Now
            };

            var result = await Creater(mast);

            return Tuple.Create(result.Item1, result.Item2, mast);
        }
        public async Task<Tuple<bool, string>> Insert_Prices(Commodities commodity,decimal Price , int Sid)
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

            return await Creater(mast);
        }
        public async Task<Tuple<bool, string>> Insert_Images(Commodities commodity, List<string> images , int Sid)
        {
            int Counter = 1;
            Tuple<bool,string> mast = null;
            foreach(var img in images)
            {
                mast = await Creater(new Commodity_Images
                {
                    CommodityID = commodity.CommodityID,
                    Url = img,
                    Order = Counter,
                    Creator = Sid,
                    CreateTime = DateTime.Now,
                    Modifier= Sid,
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
        public async Task<Tuple<bool, string>> Insert_Tags(Commodities commodity, int tag, int Sid)
        {
            return await Creater(new Commodity_Tags
            {
                CommodityID = commodity.CommodityID,
                TagID = tag,
                Creator = Sid,
                CreateTime = DateTime.Now,
                Modifier= Sid,
                ModifyTime  = DateTime.Now
            });
        }
        public async Task<Tuple<bool, string>> Insert_Sizes(Commodities commodity, List<int> sizes , List<int> colors, int Sid)
        {
            Tuple<bool, string> mast = null;
            foreach (var size in sizes)
            {
                foreach(var color in colors)
                {
                    mast = await Creater(new Commodity_Sizes
                    {
                        CommodityID = commodity.CommodityID,
                        SizeID = size,
                        ColorID = color,
                        Creator = Sid,
                        CreateTime = DateTime.Now,
                        Modifier = Sid,
                        ModifyTime = DateTime.Now
                    });

                    if (!mast.Item1)
                    {
                        return mast;
                    }
                }
            }

            return mast;
        }
    }
}
