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
        //[Authorize]
        async Task<IResult> Add_Shopping_Cart(
                [FromServices] IService<CommodityService> service,
                HttpContext http,
                CartDto dto)
        {
            CommodityService cs = (CommodityService)service;

            var Sid = Convert.ToInt16(http.User.FindFirst("Sid").Value);
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
            [FromServices] IService<CommodityService> service
            )
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
            [FromBody] NewCommodityDto dto,
            HttpContext http)
        {
            CommodityService cs = (CommodityService)service;
            var Sid = Convert.ToInt16(http.User.FindFirst("Sid").Value);
            var insert1 = await cs.Insert_Commodities(dto, Sid);
            if (insert1.Item1)
            {
                var insert2 = await cs.Insert_Prices(insert1.Item3 , dto.Price, dto.S_Price , Sid);
                if (insert2.Item1)
                {
                    var insert3 = await cs.Insert_Images(insert1.Item3, dto.CommodityImages, Sid);
                    if (insert3.Item1)
                    {
                        var insert4 = await cs.Insert_Tags(insert1.Item3, dto.CommodityTags, Sid);
                        if (insert4.Item1)
                        {
                            var insert5 = await cs.Insert_Sizes(insert1.Item3, dto.CommoditySizes , dto.CommodityColors, Sid);
                            if (insert5.Item1)
                                return Results.Ok();
                        }
                    }
                }
            }

            return Results.BadRequest("Commodity Insert Error.");
        }


        async Task<IResult> Get_full_Commodity_info(
            [FromServices] IService<CommodityService> service,
            int CommodityID , HttpContext http)
        {
            CommodityService cs = (CommodityService)service;
            var req = http.User.FindFirst("Sid");
            if (req == null)
                return Results.Unauthorized();

            int MemberID = Convert.ToInt16(req.Value);
            var result = await cs.GetFullCommodity(CommodityID);
            if(result!= null)
            {
               //await cs.Insert_Viewed(CommodityID , MemberID);
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
            int Count
            )
        {
            CommodityService cs = (CommodityService)service;
            return Results.Ok(await cs.GetRandom(Count));
        }

        async Task<IResult> Delete_Commodity(
            [FromServices] IService<CommodityService> service,
            int CommodityID
            )
        {
            CommodityService cs = (CommodityService)service;
            var result = await cs.DeleteCommodity(CommodityID);
            if (result.Item1)
            {
                return Results.Ok();
            }
            return Results.BadRequest(result.Item2);
        }
    }
}
