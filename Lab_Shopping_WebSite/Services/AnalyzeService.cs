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

            var q = _db.Commodities
                .OrderBy(s => s.CommodityID)
                .Select(c => new
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

            var q = _db.Commodities
                .OrderBy(s => s.CommodityID)
                .Select(c => new
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
        public async Task<List<TempViewModel>> Get_All_Kind()
        {
            List<Commodities> Commodities = _db.Commodities.ToList();
            List<TempViewModel> result = new List<TempViewModel>();
            foreach (var item in Commodities)
            {
                string Lable = item.Commodity_Tags.Select(s => s.Tag.Commodity_Kind.Description).FirstOrDefault();
                List<int> CommoditySizes = item.Commodity_Sizes.Select(s => s.Commodity_SizesID).ToList();

                if (Lable != default)
                {
                    TempViewModel q = result.Where(s => s.Label == Lable).FirstOrDefault();
                    if (q == default)
                    {
                        TempViewModel tm = new TempViewModel();
                        tm.Label = Lable;
                        tm.Sales = await Get_Sales_Month(CommoditySizes);
                        tm.Inventor = await Get_Inventor_Month(CommoditySizes);
                        result.Add(tm);
                    }
                    else
                    {
                        List<decimal> s = await Get_Sales_Month(CommoditySizes);
                        List<decimal> l = await Get_Inventor_Month(CommoditySizes);

                        for(int i = 0; i < 12; i++)
                        {
                            q.Sales[i] += s[i];
                            q.Inventor[i] += l[i];
                        }
                    }
                }
            }
            return result;
        }
        public async Task<List<Pictur2Dto>> Temp2Pic2(List<TempViewModel> tmp)
        {
            List<Pictur2Dto> result = new List<Pictur2Dto>();
            foreach(var item in tmp)
            {
                List<decimal> Inv = item.Inventor;
                for(int i = 0; i < Inv.Count; i++)
                {
                    // 處理存貨 跨月
                    if(i > 0 && Inv[i] == 0 && Inv[i-1] != 0 && DateTime.Now.Month > i)
                    {
                        Inv[i] = Inv[i-1];
                    }
                }

                Pictur2Dto r1 = new Pictur2Dto();
                r1.Label = item.Label + " 存貨";
                r1.Data = Inv;

                Pictur2Dto r2 = new Pictur2Dto();
                r2.Label = item.Label + " 銷貨";
                r2.Data = item.Sales;

                result.Add(r1);
                result.Add(r2);
            }

            return result;
        }
        public async Task<List<decimal>> Get_Sales_Month(List<int> Commodity_SizeIDs)
        {
            var query = _db.Sales_Items.Where(s => Commodity_SizeIDs.Contains(s.Commodity_SizeID))
                            .GroupBy(s => s.CreateTime.Value.Month,
                                            (x, y) => new
                                            {
                                                Month = x,
                                                Amount = y.Select(s => s.Amount).Sum()
                                            })
                            .OrderBy(s => s.Month).ToList();

            List<decimal> result = new List<decimal>(new decimal[12]);
            foreach (var item in query)
            {
                result[item.Month - 1] = item.Amount;
            }
            return result;
        }
        public async Task<List<decimal>> Get_Inventor_Month(List<int> Commodity_SizeIDs)
        {
            var query = (from inv in (_db.Inventories.Where(s => Commodity_SizeIDs.Contains(s.Commodity_SizeID)))
                         group inv by new
                         {
                             inv.CreateTime.Value.Month,
                             inv.Commodity_SizeID
                         } into g
                         select new
                         {
                             Month = g.Key.Month,
                             Commodity_SizeID = g.Key.Commodity_SizeID,
                             Total_Amount = g.OrderBy(s => s.CreateTime).Last()
                         }).ToList();


            List<decimal> result = new List<decimal>(new decimal[12]);
            foreach (var item in query)
            {
                result[item.Month - 1] += item.Total_Amount.Total_Amount;
            }
            return result;
        }
    }
}
