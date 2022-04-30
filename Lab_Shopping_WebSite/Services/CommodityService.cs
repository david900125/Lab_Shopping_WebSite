using Lab_Shopping_WebSite.DBContext;
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

        public async Task<List<Commodity_Simple_Dto>> Get_Commodities_Simple(int count)
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
                         }).Take(count).ToList();


            return query;
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
    }
}
