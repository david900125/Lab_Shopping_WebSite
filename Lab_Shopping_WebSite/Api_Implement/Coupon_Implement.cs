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
        public async Task<IResult> Create_Coupon(
            [FromServices] IService<CouponServices> service,
            [FromBody] CraeteCouponDto dto,
            HttpContext http)
        {
            CouponServices ss = (CouponServices)service;
            var req = http.User.FindFirst("Sid");
            if (req == null)
                return Results.Unauthorized();

            int MemberID = Convert.ToInt16(req.Value);
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
    }
}
