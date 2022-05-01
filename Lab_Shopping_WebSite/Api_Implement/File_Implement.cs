using Microsoft.AspNetCore.Mvc;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DTO;
using Microsoft.AspNetCore.Http;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class FileApi
    {
        async Task<IResult> UploadFile(
            [FromServices] DataContext _db,
            [FromServices] IService<FileServices> service,
            HttpRequest request)
        {
            FileServices fs = (FileServices)service;

            if (!request.HasFormContentType)
                return Results.BadRequest();

            var form = await request.ReadFormAsync();
            var formFile = form.Files["file"];

            if (formFile!= null)
            {
               var store =  await fs.Store_File(formFile);
                if (store.Item1)
                {
                    var result = await fs.Insert_File(formFile, store.Item2);
                    if (result.Item1)
                    {
                        return Results.Ok(result.Item3);
                    }
                }
            }

            return Results.BadRequest();
        }

    }
}
