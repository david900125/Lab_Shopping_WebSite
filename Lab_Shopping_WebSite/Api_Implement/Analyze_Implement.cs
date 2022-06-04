using Microsoft.AspNetCore.Mvc;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DTO;
using AutoMapper;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class AnalyzeApi
    {
        // 本周商店瀏覽量
        async Task<IResult> Get_Week_View(
            [FromServices] IService<AnalyzeService> service)
        {
            AnalyzeService ans = (AnalyzeService) service;
            return Results.Ok(await ans.Get_Week_View());
        }

        // 訂單成交數
        async Task<IResult> Sales_Count(
            [FromServices] IService<AnalyzeService> service)
        {
            AnalyzeService ans = (AnalyzeService)service;
            return Results.Ok(await ans.Get_Sales_Count());
        }

        // 訂單未成交數
        async Task<IResult> Sales_Unship_Count(
            [FromServices] IService<AnalyzeService> service)
        {
            AnalyzeService ans = (AnalyzeService)service;
            return Results.Ok(await ans.Get_Sales_Unship_Count());
        }

        // 未付款訂單數
        async Task<IResult> Sales_UnPay_Count(
            [FromServices] IService<AnalyzeService> service)
        {
            AnalyzeService ans = (AnalyzeService)service;
            return Results.Ok(await ans.Get_Sales_UnPay_Count());
        }

        // 前 {} 名次瀏覽商品
        async Task<IResult> Get_Top_Commodity (
            [FromServices] IService<AnalyzeService> service,
            int Count)
        {
            AnalyzeService ans = (AnalyzeService)service;
            return Results.Ok(await ans.Get_Top_Commodity(Count));
        }

        // 圖一  產品存貨
        async Task<IResult> Get_All_Inventor(
            [FromServices] IService<AnalyzeService> service)
        {
            AnalyzeService ans = (AnalyzeService)service;
            return Results.Ok(await ans.Get_All_Inventor());
        }
    
        // 圖二 本周銷貨
        async Task<IResult> Get_All_Sales(
            [FromServices] IService<AnalyzeService> service)
        {
            AnalyzeService ans = (AnalyzeService)service;
            return Results.Ok(await ans.Get_All_Sales());
        }

        // 圖三 各種類存貨與銷貨
        async Task<IResult> Get_All_Kinds(
           [FromServices] IService<AnalyzeService> service)
        {
            AnalyzeService ans = (AnalyzeService)service;
            List<TempViewModel> temp = await ans.Get_All_Kind();
            return Results.Ok(await ans.Temp2Pic2(temp));
        }
    }
}
