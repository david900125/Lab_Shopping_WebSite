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
    public partial class SalesApi
    {
        async Task<IResult> CheckOut(
            [FromServices] IService<SalesService> service,
            [FromBody] CheckOutDto dto,
            HttpContext http)
        {

            SalesService ss = (SalesService)service;
            var req = http.User.FindFirst("Sid");
            if (req == null)
                return Results.Unauthorized();

            int MemberID = Convert.ToInt16(req.Value);
            List<Shopping_Carts> lists = await ss.Shopping_Cart_List(MemberID);
            if(lists.Count > 0)
            {
               var result = await ss.CreateSales(lists , dto , MemberID);
                if (result.Item1)
                {
                    return Results.Ok();
                }
                else
                {
                    return Results.BadRequest("Sales Create Error.");
                }
            }
            else
            {
                return Results.Ok("No Shopping List.");
            }

            
        }


        async Task<IResult> UpdSales(
            [FromServices] IService<SalesService> service,
            [FromBody] SaleUpdDto dto,
            HttpContext http)
        {
            SalesService ss = (SalesService)service;
            var req = http.User.FindFirst("Sid");
            if (req == null)
                return Results.Unauthorized();

            int MemberID = Convert.ToInt16(req.Value);
            var result = await ss.UpdateSales(dto , MemberID);
            if (result.Item1)
            {
                return Results.Ok();
            }
            return Results.BadRequest();
        }


    }
}
