using Lab_Shopping_WebSite.Apis;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Lab_Shopping_WebSite.DBContext;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class CouponApi
    {
        async Task<IResult> Create_Coupon(
            [FromServices] IService<CouponServices> service,
            [FromServices] AuthDto _auth,
            [FromBody] CraeteCouponDto dto)
        {
            CouponServices ss = (CouponServices)service;
            if (!_auth.IsAuth)
                return Results.Unauthorized();

            int MemberID = _auth.UserID.MemberID;
            var result = await ss.CreateCoupon(dto, MemberID);
            if (result.Item1)
            {
                return Results.Ok();
            }
            else
            {
                return Results.BadRequest("Create Failed.");
            }
        }

        async Task<IResult> Update_Coupon(
            [FromServices] IService<CouponServices> service,
            [FromServices] AuthDto _auth,
            [FromBody] UpdateCouponDto dto)
        {
            CouponServices ss = (CouponServices)service;
            if (!_auth.IsAuth)
                return Results.Unauthorized();

            var result = await ss.UpdateCoupon(dto);
            if (result.Item1)
            {
                return Results.Ok();
            }
            else
            {
                return Results.BadRequest("Update Failed.");
            }
        }

        async Task<IResult> GetAllCoupon(
            [FromServices] IService<CouponServices> service)
        {
            CouponServices cs = (CouponServices)service;
            return Results.Ok(await cs.GetCoupons());
        }

        async Task<IResult> Get_All_Coupon_Ways(
            [FromServices] IService<CouponServices> service)
        {
            CouponServices cs = (CouponServices)service;
            return Results.Ok(await cs.GetCoupon_Ways());
        }

        [Authorize(Policy = "OnlyAdminRole")]
        async Task<IResult> Delete_Coupon(
            [FromServices] IService<CouponServices> service,
            [FromServices] AuthDto _auth,
            int CouponID)
        {
            CouponServices cs = (CouponServices)service;
            if (!_auth.IsAuth)
                return Results.Unauthorized();

            var query = await cs.DeleteCoupon(CouponID);

            if (!query.Item1)
                return Results.BadRequest();

            return Results.Ok();
        }


        async Task<IResult> Cond_Coupon(
            [FromServices] IService<CouponServices> service,
            [FromServices] AuthDto _auth,
            string Coupon_Key)
        {
            CouponServices cs = (CouponServices)service;
            if (!_auth.IsAuth)
                return Results.Unauthorized();

            var query = await cs.Find_Coupon(Coupon_Key);


            if (query != default)
                return Results.Ok(await cs.Create_Condition(query));

            return Results.BadRequest();
        }
    }
}
