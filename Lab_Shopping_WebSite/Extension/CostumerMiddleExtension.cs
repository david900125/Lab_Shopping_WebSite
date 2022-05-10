using Lab_Shopping_WebSite.DTO;

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

        public JwtAuthToken(RequestDelegate next )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context ,AuthDto _auth)
        {
            var req = context.User.FindFirst("Sid");
            if (req != null)
            {
                _auth.UserID = Convert.ToInt16(req.Value);
            }
            await _next(context);
        }
    }
}

