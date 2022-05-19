using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ColorApi
    {
        [AllowAnonymous]
        async Task<IResult> GetAll(
            [FromServices] IService<ColorServices> service)
        {
            ColorServices cs = (ColorServices)service;
            return Results.Ok(await cs.GetColorDtos());
        }

        [AllowAnonymous]
        async Task<IResult> GetOneColor(
            [FromServices] IService<ColorServices> service,
            int id)
        {
            ColorServices cs = (ColorServices)service;
            return Results.Ok(await cs.GetColorDtos(id));
        }

        [Authorize(Policy = "AdminRole")]
        async Task<IResult> InsertColor(
            [FromServices] IService<ColorServices> service,
            [FromServices] AuthDto auth,
            ColorDto color)
        {
            ColorServices cs = (ColorServices)service;

            if (!auth.IsAuth)
            {
                return Results.Unauthorized();
            }

            Tuple<bool, string> result = await cs.InsertColor(color);
            if (result.Item1 == true)
            {
                return Results.Ok(color);
            }
            else
            {
                return Results.BadRequest(new ErrorDto()
                {
                    Code = "400",
                    ErrorMsg = "Insert Error",
                    Type = "Bad Request"
                });
            }

        }

        [Authorize(Policy = "AdminRole")]
        async Task<IResult> UpdateColor(
            [FromServices] IService<ColorServices> service,
            [FromServices] AuthDto auth,
            ColorDto color)
        {
            ColorServices cs = (ColorServices)service;
            if (!auth.IsAuth)
            {
                return Results.Unauthorized();
            }

            Tuple<bool, string> result = await cs.UpdateColor(color);
            if (result.Item1 == true)
            {
                return Results.Ok(color);
            }
            else
            {
                return Results.BadRequest(new ErrorDto()
                {
                    Code = "400",
                    ErrorMsg = "Insert Error",
                    Type = "Bad Request"
                });
            }
        }

        [Authorize(Policy = "AdminRole")]
        async Task<IResult> DeleteColor(
            [FromServices] IService<ColorServices> service,
            [FromServices] AuthDto auth,
            ColorDto color)
        {
            ColorServices cs = (ColorServices)service;
            if (!auth.IsAuth)
            {
                return Results.Unauthorized();
            }

            Tuple<bool, string> result = await cs.DeleteColor(color);
            if (result.Item1 == true)
            {
                return Results.Ok(color);
            }
            else
            {
                return Results.BadRequest(
                    new ErrorDto()
                    {
                        Code = "400",
                        ErrorMsg = "Delete Error",
                        Type = "Bad Request"
                    });
            }
        }

        [AllowAnonymous]
        async Task<IResult> GetAllTags(
            [FromServices] IService<TagsService> service)
        {
            TagsService ts = (TagsService)service;
            return Results.Ok(await ts.GetTagsDto());
        }

        [AllowAnonymous]
        async Task<IResult> GetOneTag(
            [FromServices] IService<TagsService> service,
            int CommodityKindID)
        {
            TagsService ts = (TagsService)service;
            return Results.Ok(await ts.GetTagsDto(CommodityKindID));
        }

        [Authorize(Policy = "OnlyAdminRole")]
        async Task<IResult> InsertTag(
            [FromServices] IService<TagsService> service,
            [FromServices] AuthDto auth,
            NewTagDto dto)
        {
            TagsService ts = (TagsService)service;
            Tuple<bool, string> result = await ts.InsertTags(dto);

            if (!auth.IsAuth)
            {
                return Results.Unauthorized();
            }

            if (result.Item1)
            {
                return Results.Ok();
            }

            return Results.BadRequest(new ErrorDto
            {
                Code = "400",
                ErrorMsg = result.Item2,
                Type = "Bad Request"
            });
        }

        [Authorize(Policy = "OnlyAdminRole")]
        async Task<IResult> UpdateTag(
            [FromServices] IService<TagsService> service,
            [FromServices] AuthDto auth,
            List<UpdateTagDto> dtos)
        {
            TagsService ts = (TagsService)service;
            Tuple<bool, Tags> find;
            Tuple<bool, string> result;
            foreach (UpdateTagDto dto in dtos)
            {
                find = await ts.FindTags(id: dto.KindID, TagID: dto.TagID);
                if (find.Item1)
                {
                    result = await ts.UpdateTags(dto , find.Item2);
                    if (!result.Item1)
                    {
                        return Results.BadRequest("Update Failed. KindsID:" + dto.KindID + "TagsID :" + dto.TagID);
                    }
                }
            }
            return Results.Ok();
        }
    }
}
