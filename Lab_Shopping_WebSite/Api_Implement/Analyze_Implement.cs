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
    }
}
