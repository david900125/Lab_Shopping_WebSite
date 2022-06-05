using Microsoft.EntityFrameworkCore;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.DTO;
using AutoMapper;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab_Shopping_WebSite.Services
{
    public class SalesService : IService<SalesService>
    {
        private readonly CouponServices cs;
        public SalesService(DataContext db, AuthDto auth, IMapper mapper, IService<CouponServices> service) : base(db, auth, mapper)
        {
            cs = (CouponServices)service;
        }

        public async Task<List<Shopping_Carts>> Shopping_Cart_List(int MemberID)
        {
            return await _db.Shopping_Carts.Where(c => c.MemberID == MemberID).ToListAsync();
        }
        public async Task<Tuple<bool, string>> CreateSales(List<Shopping_Carts> carts, CheckOutDto dto, int MemberID)
        {
            Sales sales = new Sales();
            sales.SaleID = DateTime.Now.ToString("yyyyMMddHH") + _db.Sales.Count().ToString("00");
            // --- 需修改 ---
            sales.Discount_Total = 0;
            // --- 需修改 --- 
            sales.Delivery_optionID = 1; //本島 
            sales.Delivery_Cost = _db.Delivery_Options.Where(n => n.Delivery_OptionsID == sales.Delivery_optionID).Select(n => n.Delivery_Cost).FirstOrDefault();
            sales.Established = DateTime.Now;
            sales.isChecked = false;
            sales.InVoice = DateTime.Today.ToString("yyyyMMdd") + "1";
            sales.Address = dto.Address;
            sales.MemberID = MemberID;
            sales.PaymentID = dto.PaymentID;
            sales.Total_Price = await CheckOut_TotalPrice(carts);
            sales.isChecked = false;
            sales.Creator = MemberID;
            sales.Modifier = MemberID;
            sales.CreateTime = DateTime.Now;
            sales.ModifyTime = DateTime.Now;

            var result = await InsertSales(sales);

            if (result.Item1)
            {
                foreach (var cart in carts)
                {
                    Sales_items item = new Sales_items()
                    {
                        SaleID = result.Item3.SaleID,
                        Commodity_SizeID = cart.Commodity_SizeID,
                        Amount = cart.Amount,
                        Unit_Price = await Price(cart.Commodity_SizeID),
                        StatusID = 3,  // 準備中
                        Creator = 1,
                        Modifier = 1,
                        CreateTime = DateTime.Now,
                        ModifyTime = DateTime.Now
                    };
                    item.Total_Price = item.Amount * item.Unit_Price;

                    var iresult = await InsertSalesItem(item);
                    if (!iresult.Item1)
                    {
                        return iresult;
                    }
                    await Delete_Shopping_Cart(cart);
                }

                return Tuple.Create(true, "");
            }

            return Tuple.Create(false, result.Item2);
        }
        public async Task<Tuple<bool, string>> CreateSales(SalesOrder dto)
        {
            Sales sales = new Sales();
            sales.SaleID = DateTime.Now.ToString("yyyyMMddHH") + _db.Sales.Count().ToString("00");
            sales.Delivery_optionID = dto.DeliveryOptionsID;
           
            sales.Established = DateTime.Now;
            sales.isChecked = false;
            sales.InVoice = "AB" + _db.Sales.Count().ToString("00000000");
            sales.Address = dto.Address;
            sales.MemberID = _auth.UserID.MemberID;
            sales.PaymentID = dto.PaymentID;
            sales.Phone_Number = dto.Phone_Number;
            sales.isChecked = false; // 未寄出
            sales.Total_Price = await CheckOut_TotalPrice(dto.Carts);
            var coupon_use = await CheckOut_TotalPrice(sales.SaleID, dto.Coupons, sales.Total_Price);
            sales.Discount_Total = coupon_use.Item1;
            if (coupon_use.Item2)
            {
                sales.Delivery_Cost = 0;
            }
            else
            {
                sales.Delivery_Cost = _db.Delivery_Options.Where(n => n.Delivery_OptionsID == sales.Delivery_optionID).Select(n => n.Delivery_Cost).FirstOrDefault();
            }
            var result = await InsertSales(sales);

            if (result.Item1)
            {
                foreach (var cart in dto.Carts)
                {
                    Commodity_Sizes cs = await FindCommodity_Size(cart);
                    Sales_items item = new Sales_items()
                    {
                        SaleID = result.Item3.SaleID,
                        Commodity_SizeID = cs.Commodity_SizesID,
                        Amount = cart.Amount,
                        Unit_Price = await Price(cs.Commodity_SizesID),
                        StatusID = 3  // 準備中
                    };
                    item.Total_Price = item.Amount * item.Unit_Price;

                    var iresult = await InsertSalesItem(item);
                    if (!iresult.Item1)
                    {
                        return iresult;
                    }
                }
                return Tuple.Create(true, "");
            }
            return Tuple.Create(false, result.Item2);
        }


        public async Task<Tuple<bool, string, Sales>> InsertSales(Sales sales)
        {
            var result = await Creater(sales);
            return Tuple.Create(result.Item1, result.Item2, sales);
        }
        public async Task<Tuple<bool, string>> InsertSalesItem(Sales_items item)
        {
            var result = await Creater(item);
            return Tuple.Create(result.Item1, result.Item2);
        }
        public async Task<Tuple<bool, string>> InsertCoupon_Use(Coupon_Uses item)
        {
            var result = await Creater(item);
            return Tuple.Create(result.Item1, result.Item2);
        }
        public async Task<Tuple<bool, string>> Delete_Shopping_Cart(Shopping_Carts cart)
        {
            return await Deleter(cart);
        }
        public async Task<Tuple<bool, string>> UpdateSales(SaleUpdDto updDto, int MemberID)
        {
            var query = _db.Sales.Where(n => n.SaleID == updDto.SaleID).FirstOrDefault();
            query.isChecked = true;
            query.SendDate = DateTime.Now;
            query.Modifier = MemberID;
            query.ModifyTime = DateTime.Now;

            var sales = await Updater(query);
            if (sales.Item1)
            {
                var itemquery = _db.Sales_Items.Where(n => n.SaleID == query.SaleID).ToList();
                foreach (var item in itemquery)
                {
                    item.StatusID = 1; //已寄送
                    item.Modifier = MemberID;
                    item.ModifyTime = DateTime.Now;
                    var result = await Updater(item);
                    if (!result.Item1)
                    {
                        return result;
                    }
                }
                return Tuple.Create(true, "");
            }

            return sales;
        }
        public async Task<Tuple<bool, string>> UpdateCoupon_Use(Coupon_Uses item)
        {
            return await Updater<Coupon_Uses>(item);
        }
        public async Task<decimal> CheckOut_TotalPrice(List<Shopping_Carts> carts)
        {
            decimal total = 0;
            foreach (var cart in carts)
            {
                decimal unit = await Price(cart.Commodity_SizeID);
                total += unit * cart.Amount;
            }
            return total;
        }
        public async Task<decimal> CheckOut_TotalPrice(List<CartDto> carts)
        {
            decimal total = 0;
            foreach (var cart in carts)
            {

                decimal unit = await Price(cart);
                total += unit * cart.Amount;
            }
            return total;
        }
        // decimal 總價 bool 是否免運
        public async Task<Tuple<decimal, bool>> CheckOut_TotalPrice(string SaleID, List<string> coupons, decimal Total_Price)
        {
            bool Free_Ship = false;
            decimal discount = 0 , per_discount = 0;
            foreach (var coupon in coupons)
            {
                per_discount = 0;
                Tuple<bool, string> result;
                Coupons c = await cs.Find_Coupon(coupon);
                Coupon_Condition cond = await cs.Create_Condition(c);
                if (cond.Free_Shipping)
                {
                    Free_Ship = true;
                }
                else if (cond.DisCount > 0)
                {
                    decimal tmp = Total_Price * cond.DisCount;
                    if (Decimal.Ceiling(tmp) == tmp)
                    {
                        per_discount  = (Total_Price - tmp);
                        Total_Price = tmp;
                    }
                    else
                    {
                        per_discount = (Total_Price - Decimal.Ceiling(tmp));
                        Total_Price = Decimal.Ceiling(tmp);
                    }

                }
                else if (cond.Rebate > 0)
                {
                    per_discount = cond.Rebate;
                    Total_Price -= cond.Rebate;
                }
                else
                {
                    // do nothing
                }

                
                var query = await FindCoupon_Use(SaleID, c.CouponID);
                if (query == default)
                {
                    Coupon_Uses rec = new Coupon_Uses()
                    {
                        SaleID = SaleID,
                        CouponID = c.CouponID,
                        Amount = 1,
                        Discount = per_discount,
                        Use_Date = DateTime.Now
                    };
                    result = await InsertCoupon_Use(rec);
                }
                else
                {
                    query.Amount++;
                    result = await UpdateCoupon_Use(query);
                }

                discount += per_discount;

                if (!result.Item1)
                    break;
            }

            return Tuple.Create(discount, Free_Ship);
        }
        public async Task<decimal> Price(int Commodity_SizeID)
        {
            Commodity_Sizes cs = await _db.Commodity_Sizes.Where(s => s.Commodity_SizesID == Commodity_SizeID).FirstOrDefaultAsync();
            Commodity_Prices cp = cs.Commodity.Commodity_Prices.Where(s => s.PriceID == 2).FirstOrDefault() ??
                      cs.Commodity.Commodity_Prices.Where(s => s.PriceID == 1).FirstOrDefault();
            return cp.Price;
        }
        public async Task<decimal> Price(CartDto cart)
        {
            decimal cost = 0;
            Commodity_Sizes cs = await FindCommodity_Size(cart);
            Commodity_Prices cp = cs.Commodity.Commodity_Prices.Where(s => s.PriceID == 2).FirstOrDefault() ??
                                  cs.Commodity.Commodity_Prices.Where(s => s.PriceID == 1).FirstOrDefault();
            return cp.Price;
        }
        public async Task<Commodity_Sizes> FindCommodity_Size(CartDto cart)
        {
            Commodity_Sizes? item = await _db.Commodity_Sizes.Where(s => s.CommodityID == cart.CommodityID)
                                                             .Where(s => s.Size.Size == cart.Size)
                                                             .Where(s => s.Color.Color == cart.Color).FirstOrDefaultAsync();
            return item;
        }
        public async Task<Coupon_Uses> FindCoupon_Use(string SaleID, int CouponID)
        {
            return _db.Coupon_Uses.Where(s => s.SaleID == SaleID).Where(s => s.CouponID == CouponID).FirstOrDefault();
        }

        public async Task<List<SaleDto>> GetAllSales()
        {
            var result = _mapper.ProjectTo<SaleDto>(_db.Sales).ToList();
            foreach (var item in result)
            {
                item.Items = _mapper.ProjectTo<Sale_Item>(_db.Sales_Items.Where(s => s.SaleID == item.SaleID)).ToList();
            }
            return result;
        }
        public async Task<List<SaleDto>> GetSalesForm()
        {
            var result = _mapper.ProjectTo<SaleDto>(_db.Sales.Where(s => s.MemberID == _auth.UserID.MemberID)).ToList();
            foreach (var item in result)
            {
                item.Items = _mapper.ProjectTo<Sale_Item>(_db.Sales_Items.Where(s => s.SaleID == item.SaleID)).ToList();
            }
            return result;
        }
        public async Task<Tuple<bool, string>> Check_Inventor_Over(List<CartDto> carts)
        {
            Inventories inv;
            Commodity_Sizes cs;
            foreach (var cart in carts)
            {
                cs = await FindCommodity_Size(cart);
                inv = cs.inventories.OrderByDescending(s => s.InventoryID).Take(1).FirstOrDefault();
                if (inv == default)
                {
                    return Tuple.Create(false, "Inventory shortage");
                }
                if (inv.Total_Amount < cart.Amount)
                {
                    return Tuple.Create(false, cs.Commodity.CommodityName + " Inventory shortage."); ;
                }
            }
            return Tuple.Create(true, "");
        }
        public async Task<Tuple<bool, string>> Check_Coupon_Use(SalesOrder order)
        {
            decimal Total_Pirce = await CheckOut_TotalPrice(order.Carts);

            foreach (var coupon in order.Coupons)
            {
                Coupons c = await cs.Find_Coupon(coupon);
                if (c != default)
                {
                    Coupon_Condition cond = await cs.Create_Condition(c);
                    if (Total_Pirce < cond.Amount_Achieved)
                    {
                        return Tuple.Create(false, "Total Price Doesn't Achieved");
                    }
                }
                else
                {
                    return Tuple.Create(false, "Coupon Not Found!");
                }
            }

            return Tuple.Create(true, "");
        }
    }
}
