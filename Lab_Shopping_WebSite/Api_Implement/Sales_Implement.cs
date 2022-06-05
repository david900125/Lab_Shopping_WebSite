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
            [FromServices] AuthDto auth,
            [FromBody] SalesOrder dto)
        {
            SalesService ss = (SalesService)service;
            if (!auth.IsAuth)
                return Results.Unauthorized();
            // Check Stock
            var check_1 = await ss.Check_Inventor_Over(dto.Carts);
            
            if (check_1.Item1)
            {
                var check_2 = await ss.Check_Coupon_Use(dto);
                if (check_2.Item1)
                {
                    // Create Sales Order
                    var create = await ss.CreateSales(dto);
                    if (create.Item1)
                    {
                        return Results.Ok();
                    }
                    else
                    {
                        return Results.BadRequest(create.Item2);
                    }
                }
            }
            return Results.BadRequest(check_1.Item2);
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
            var result = await ss.UpdateSales(dto, MemberID);
            if (result.Item1)
            {
                return Results.Ok();
            }
            return Results.BadRequest();
        }

        async Task<IResult> GetAllSales(
            [FromServices] IService<SalesService> service)
        {
            SalesService ss = (SalesService)service;
            return Results.Ok(await ss.GetAllSales());
        }

        async Task<IResult> GetSales(
           [FromServices] IService<SalesService> service)
        {
            SalesService ss = (SalesService)service;
            return Results.Ok(await ss.GetSalesForm());
        }

    }
}
