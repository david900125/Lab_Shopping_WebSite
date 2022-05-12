using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.DBContext;

namespace Lab_Shopping_WebSite.Extension
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtAuthToken>();
        }
    }

    public class JwtAuthToken
    {
        private readonly RequestDelegate _next;

        public JwtAuthToken(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, AuthDto _auth , DataContext _db)
        {
            var req = context.User.FindFirst("Sid");
            if (req != null)
            {
                Members item = _db.Members.Single(m => m.MemberID == (Convert.ToInt16(req.Value)));
                if (item != null)
                {
                    _auth.UserID = item;
                    _auth.ErrorMsg = "";
                    _auth.IsAuth = true;
                }
                else
                {
                    _auth.UserID = new Members();
                    _auth.ErrorMsg = "Member is not Found";
                    _auth.IsAuth = false;
                }
            }
            else
            {
                _auth.UserID = new Members();
                _auth.ErrorMsg = "Token is not Found";
                _auth.IsAuth = false;
            }

            await _next(context);
        }
    }
}

