using Microsoft.AspNetCore.Mvc;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class TestApi
    {
        // DI Property Injection IConfiguration
        async Task<IResult> GetAll(IConfiguration configuration)
        {
            await Task.Run(() => Console.WriteLine("123"));
            return Results.Ok("Test");
        }
    }
}
