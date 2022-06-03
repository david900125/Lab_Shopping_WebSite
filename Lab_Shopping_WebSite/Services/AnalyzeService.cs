using AutoMapper;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;

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
            return _db.Sales.Where(s => s.isChecked == false).Count();
        }
        public async Task<int> Get_Sales_UnPay_Count()
        {
            return _db.Sales.Where(s => s.isPayed == false).Count();
        }

    }
}
