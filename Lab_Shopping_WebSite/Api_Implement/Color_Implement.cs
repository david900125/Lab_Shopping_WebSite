﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lab_Shopping_WebSite.DTO;
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

        [Authorize(Policy ="OnlyAdminRole")]
        async Task<IResult> UpdateTag(
            [FromServices] IService<TagsService> service,
            [FromServices] AuthDto auth,
            NewTagDto dto)
        {

            return Results.Ok();
        }
    }
}
