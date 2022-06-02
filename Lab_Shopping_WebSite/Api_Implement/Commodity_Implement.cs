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
    public partial class CommodityApi
    {
        [Authorize]
        async Task<IResult> Add_Shopping_Cart(
                [FromServices] IService<CommodityService> service,
                [FromServices] AuthDto auth,
                List<CartDto> dtos)
        {
            CommodityService cs = (CommodityService)service;
            if (!auth.IsAuth)
                return Results.Unauthorized();

            foreach(var dto in dtos)
            {
                Tuple<bool, Commodity_Sizes> query = await cs.Get_Commodity_Size(dto);
                if (query.Item1)
                {
                    var result = await cs.Insert_Shopping_Cart(auth.UserID.MemberID, query.Item2, dto.Amount);
                    if (result.Item1)
                        continue;
                    else
                        return Results.BadRequest("Insert Error.");
                }
                else
                    return Results.BadRequest("Commodity Detail Error.");
            }
            return Results.Ok();
        }

        async Task<IResult> GetCommodities(
            [FromServices] IService<CommodityService> service)
        {
            CommodityService cs = (CommodityService)service;
            List<CommodityDto> results = await cs.Get_Commodities_Simple();
            return Results.Ok(results);
        }

        async Task<IResult> SelectCommodity(
            [FromServices] IService<CommodityService> service,
            Commodity_Selection_Dto dto)
        {
            CommodityService cs = (CommodityService)service;
            var result = await cs.SelectByName(dto);
            return Results.Ok(result);
        }

        async Task<IResult> AddNewCommodity(
            [FromServices] IService<CommodityService> service,
            [FromServices] AuthDto auth,
            [FromBody] NewCommodityDto dto)
        {
            CommodityService cs = (CommodityService)service;
            if (!auth.IsAuth)
                return Results.Unauthorized();

            if (dto.Price < dto.S_Price)
                return Results.BadRequest("Preferential Price is over Bid Price!");

            var Sid = auth.UserID.MemberID;
            var insert1 = await cs.Insert_Commodities(dto, Sid);
            if (insert1.Item1)
            {
                var insert2 = await cs.Insert_Prices(insert1.Item3, dto.Price, dto.S_Price, Sid);
                if (insert2.Item1)
                {
                    var insert3 = await cs.Insert_Images(insert1.Item3, dto.CommodityImages, Sid);
                    if (insert3.Item1)
                    {
                        var insert4 = await cs.Insert_Tags(insert1.Item3, dto.CommodityTags, Sid);
                        if (insert4.Item1)
                        {
                            var insert5 = await cs.Insert_Sizes(insert1.Item3, dto.CommoditySizes, dto.CommodityColors, Sid);
                            if (insert5.Item1)
                                return Results.Ok();
                        }
                    }
                }
            }

            return Results.BadRequest("Commodity Insert Error.");
        }

        [Authorize]
        async Task<IResult> UpdateCommodity(
            [FromServices] IService<CommodityService> service,
            [FromServices] AuthDto auth,
            [FromBody] UpdateCommodityDto dto)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false,"Not Found!");
            CommodityService cs = (CommodityService)service;
            if (!auth.IsAuth)
                return Results.Unauthorized();

            if (dto.Price < dto.S_Price)
                return Results.BadRequest("Preferential Price is over Bid Price!");

            Commodities mast = await cs.FindCommodity(dto.CommodityID);
            if(mast != null)
            {
               result =  await cs.Update_Commodity(mast,dto);
                if (result.Item1)
                    result = await cs.Update_Images(mast , dto);
                    if (result.Item1)
                        result = await cs.Update_Prices(mast , dto);
                        if(result.Item1)
                            result = await cs.Update_Sizes(mast,dto);
                            if (result.Item1)
                                result = await cs.Update_Tags(mast, dto);
                                if (result.Item1)
                                    return Results.Ok();
            }

            return Results.BadRequest("Update Failed!");
        }

        async Task<IResult> Get_full_Commodity_info(
            [FromServices] IService<CommodityService> service,
            [FromServices] AuthDto auth,
            int CommodityID)
        {
            CommodityService cs = (CommodityService)service;
            var result = await cs.GetFullCommodity(CommodityID);
            if (result != null)
            {
                if (auth.IsAuth)
                    await cs.Insert_Viewed(CommodityID);
                else
                    await cs.Insert_Viewed(CommodityID);
            }
            return Results.Ok(result);
        }

        async Task<IResult> Get_Commodity_By_Kinds(
            [FromServices] IService<CommodityService> service,
            int KindID
            )
        {
            CommodityService cs = (CommodityService)service;
            return Results.Ok(await cs.SalectByKinds(KindID));
        }

        async Task<IResult> Get_Random_Commodity(
            [FromServices] IService<CommodityService> service,
            int Count)
        {
            CommodityService cs = (CommodityService)service;
            return Results.Ok(await cs.GetRandom(Count));
        }

        [Authorize(Policy = "OnlyAdminRole")]
        async Task<IResult> Delete_Commodity(
            [FromServices] IService<CommodityService> service,
            int CommodityID)
        {
            CommodityService cs = (CommodityService)service;
            var result = await cs.DeleteCommodity(CommodityID);
            if (result.Item1)
            {
                return Results.Ok();
            }
            return Results.BadRequest(result.Item2);
        }

        [Authorize]
        async Task<IResult> GetShoppingCart(
            [FromServices] IService<CommodityService> service,
            [FromServices] AuthDto auth)
        {
            CommodityService cs = (CommodityService)service;
            if (!auth.IsAuth)
                return Results.Unauthorized();

            var query = await cs.GetShoppingCart();

            return Results.Ok();

        }
    
        async Task<IResult> View_Recoder(
            [FromServices] IService<CommodityService> service,
            int CommodityID)
        {
            CommodityService cs = (CommodityService)service;
            await cs.Insert_Viewed(CommodityID);
            return Results.Ok();
        }
    }
}
