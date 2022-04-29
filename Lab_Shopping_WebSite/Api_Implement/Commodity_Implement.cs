using Lab_Shopping_WebSite.Apis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class CommodityApi
    {
        [Authorize]
        async Task<IResult> Add_Shopping_Cart(
                        HttpContext http,
                        int Commodity_SizeID
            )
        {
            var Sid = Convert.ToInt16(http.User.FindFirst("Sid"));

            return Results.Ok();
        }
    }
}
