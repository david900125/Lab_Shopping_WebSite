using Microsoft.AspNetCore.Mvc;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class ClientApi
    {
        // DI Property Injection IConfiguration
        async Task<IResult> GetAll(IConfiguration configuration)
        {
            await Task.Run(() => Console.WriteLine("123"));
            return Results.Ok(configuration["ConnectionStrings:DefaultConnection"]);
        }

        async Task<IResult> GetOne([FromRoute] int id)
        {
            await Task.Run(() => Console.WriteLine(id));
            return Results.Ok(id);
        }
    }
}
