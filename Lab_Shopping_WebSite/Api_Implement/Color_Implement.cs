using AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ColorApi
    {
        async Task<IResult> GetAll(
            [FromServices] IService<ColorServices> service,
            [FromServices] AuthDto auth,
            int id)
        {
            

            return Results.Ok(id);
        }
    }
}
