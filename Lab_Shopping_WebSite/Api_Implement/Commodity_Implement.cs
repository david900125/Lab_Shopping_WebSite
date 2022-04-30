using Lab_Shopping_WebSite.Apis;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;


namespace Lab_Shopping_WebSite.Apis
{
    public partial class CommodityApi
    {
        [Authorize]
        async Task<IResult> Add_Shopping_Cart(
                [FromServices] IService<CommodityService> service,
                HttpContext http,
                CartDto dto)
        {
            CommodityService cs = (CommodityService)service;

            var Sid = Convert.ToInt16(http.User.FindFirst("Sid"));
            Tuple<bool, Commodity_Sizes> query = await cs.Get_Commodity_Size(dto);
            if (query.Item1)
            {
                var result = await cs.Insert_Shopping_Cart(Sid, query.Item2, dto.Amount);
                if (result.Item1)
                    return Results.Ok();
                else
                {
                    return Results.BadRequest("Insert Error.");
                }
            }
            else
                return Results.BadRequest("Commodity Detail Error.");
        }

        async Task<IResult> GetCommodities(
            [FromServices] IService<CommodityService> service,
            int count
            )
        {
            CommodityService cs = (CommodityService)service;
            List<Commodity_Simple_Dto> results = await cs.Get_Commodities_Simple(count);
            return Results.Ok(results);
        }


        async Task<IResult> SelectionCommodity(
            [FromServices] IService<CommodityService> service,
            Commodity_Selection_Dto dto
        )
        {
            CommodityService cs = (CommodityService)service;
            return Results.Ok();
        }
    }
}
