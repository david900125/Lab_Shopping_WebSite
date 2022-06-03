using AutoMapper;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.Services
{
    public class AnalyzeService : IService<AnalyzeService>
    {
        public AnalyzeService(DataContext db, AuthDto auth, IMapper mapper) : base(db, auth, mapper)
        {
        }


        public async Task<int> Get_Week_View()
        {
            return _db.Recently_Viewed.Where(s => s.Viewed_Date >= DateTime.Now.AddDays(-7)).Count();
        }
        public async Task<int> Get_Sales_Count()
        {
            return _db.Sales.Count();
        }
        public async Task<int> Get_Sales_Unship_Count()
        {
            return _db.Sales.Where(s => s.SendDate == default).Count();
        }
        public async Task<int> Get_Sales_UnPay_Count()
        {
            return _db.Sales.Where(s => s.isPayed == false).Count();
        }
        public async Task<List<Top_Commodity_Analyze>> Get_Top_Commodity(int Count)
        {
            List<Top_Commodity_Analyze> results = new List<Top_Commodity_Analyze>();
            var querys = _db.Recently_Viewed.GroupBy(v => v.CommodityID)
                                                    .Select(group => new
                                                    {
                                                        CommodityID = group.Key,
                                                        count = group.Count()
                                                    }).OrderByDescending(g => g.count).Take(Count).ToList();

            foreach (var item in querys)
            {
                var q = _db.Commodities.Where(s => s.CommodityID == item.CommodityID)
                                .Select(s => new Top_Commodity_Analyze
                                {
                                    CommodityName = s.CommodityName,
                                    Viewed = s.Recently_Viewed.Count(),
                                    Liked = s.Like_Commodities.Count(),
                                    Add_to_Carts = _db.Shopping_Carts.Where(c => c.Commodity_Sizes.CommodityID == item.CommodityID).Count()
                                }).ToList();
                results.AddRange(q);
            }

            return results;
        }
        public async Task<PicturDto> Get_All_Inventor()
        {
            PicturDto pic = new PicturDto();
            pic.Label = new List<string>();
            pic.Data = new List<decimal>();

            var q = _db.Commodities.
                Select(c => new
                {
                    CommodityName = c.CommodityName,
                    CommoditySizes = c.Commodity_Sizes.Select(s => s.Commodity_SizesID).ToList()
                }).ToList();

            foreach (var item in q)
            {

                var total = _db.Inventories.Where(s => item.CommoditySizes.Contains(s.Commodity_SizeID))
                                .GroupBy(s => s.Commodity_SizeID,
                                (x, y) => new
                                {
                                    Index = x,
                                    Last = y.OrderBy(y => y.InventoryID).LastOrDefault().Total_Amount
                                }).Select(g => g.Last).Sum();
                                

                pic.Label.Add(item.CommodityName);
                pic.Data.Add(total);
            }
            return pic;

        }
        public async Task<PicturDto> Get_All_Sales()
        {
            PicturDto pic = new PicturDto();
            pic.Label = new List<string>();
            pic.Data = new List<decimal>();

            var q = _db.Commodities.
                Select(c => new
                {
                    CommodityName = c.CommodityName,
                    CommoditySizes = c.Commodity_Sizes.Select(s => s.Commodity_SizesID).ToList()
                }).ToList();

            foreach (var item in q)
            {

                var total = _db.Sales_Items.Where(s => item.CommoditySizes.Contains(s.Commodity_SizeID))
                                .GroupBy(s => s.Commodity_SizeID,
                                (x, y) => new
                                {
                                    Index = x,
                                    Last = y.Select(s => s.Amount).Sum()
                                }).Select(g => g.Last).Sum();


                pic.Label.Add(item.CommodityName);
                pic.Data.Add(total);
            }
            return pic;
        }
    }
}
