using AutoMapper;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Lab_Shopping_WebSite.Services
{
    public class CouponServices : IService<CouponServices>
    {
        public CouponServices(DataContext db, AuthDto auth, IMapper mapper) : base(db, auth, mapper)
        {
        }

        public async Task<Tuple<bool, string>> CreateCoupon(CraeteCouponDto dto, int MemberID)
        {
            Coupons coupon = new Coupons()
            {
                Coupon_Title = dto.Coupon_Title,
                Coupon_Key = dto.Coupon_Key,
                Coupon_Content = dto.Coupon_Content,
                Coupon_WayID = dto.Coupon_WayID,
                Amount_Achieved = dto.Amount_Achieved,
                Discount = dto.DisCount,
                Issued_Amount = dto.Issued_Amount,
                Issued_Date = Convert.ToDateTime(dto.Issued_Date),
                End_Date = Convert.ToDateTime(dto.End_Date),
                isIssued = dto.isIssued,
                Received_Amount = 0
            };
            return await Creater(coupon);
        }
        public async Task<Tuple<bool,string>> UpdateCoupon(UpdateCouponDto dto)
        {
            Coupons mast =  _db.Coupons.Where(s => s.CouponID == dto.CouponID).FirstOrDefault();
            if (mast != null)
            {
                mast.Coupon_Title = dto.Coupon_Title == mast.Coupon_Title ? mast.Coupon_Title : dto.Coupon_Title;
                mast.Coupon_Key = dto.Coupon_Key == mast.Coupon_Key ? mast.Coupon_Key : dto.Coupon_Key;
                mast.Coupon_Content = dto.Coupon_Content == mast.Coupon_Content ? mast.Coupon_Content : dto.Coupon_Content;
                mast.Issued_Amount = dto.Issued_Amount == mast.Issued_Amount ? mast.Issued_Amount : dto.Issued_Amount;
                mast.Amount_Achieved = dto.Amount_Achieved == mast.Amount_Achieved ? mast.Amount_Achieved : dto.Amount_Achieved;
                mast.Issued_Date = Convert.ToDateTime(dto.Issued_Date) == mast.Issued_Date ? mast.Issued_Date : Convert.ToDateTime(dto.Issued_Date);
                mast.End_Date = Convert.ToDateTime(dto.End_Date) == mast.End_Date ? mast.End_Date : Convert.ToDateTime(dto.End_Date);
                mast.Coupon_WayID = dto.Coupon_WayID == mast.Coupon_WayID ? mast.Coupon_WayID : dto.Coupon_WayID;
                mast.Discount = dto.DisCount == mast.Discount ? mast.Discount : dto.DisCount;
                mast.isIssued = dto.isIssued == mast.isIssued ? mast.isIssued : dto.isIssued;

                return await Updater<Coupons>(mast);
            }

            return Tuple.Create(false, "Coupon Not Found !");
        }
        public async Task<Tuple<bool,string>> DeleteCoupon(int CouponID)
        {
            Coupons item = _db.Coupons.Where(c => c.CouponID == CouponID).FirstOrDefault();
            if (item != null)
                return await Deleter<Coupons>(item);

            return Tuple.Create(false, "");
        }
        public async Task<List<CouponDto>> GetCoupons([Optional] int CouponID)
        {
            if(CouponID == 0)
                return _mapper.ProjectTo<CouponDto>(_db.Coupons).ToList();

            return _mapper.ProjectTo<CouponDto>(_db.Coupons).Where(s => s.CouponID == CouponID).ToList();
        }
        public async Task<List<Coupon_WaysDto>> GetCoupon_Ways([Optional] int Coupon_WayID)
        {
            if(Coupon_WayID > 0)
            {
                return await _mapper.ProjectTo<Coupon_WaysDto>(_db.Coupon_Ways).Where(s => s.Coupon_WayID == Coupon_WayID).ToListAsync();
            }
            
            return await _mapper.ProjectTo<Coupon_WaysDto>(_db.Coupon_Ways).ToListAsync();
        }
    }
}
