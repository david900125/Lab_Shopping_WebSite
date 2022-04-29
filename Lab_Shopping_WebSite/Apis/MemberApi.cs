using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Apis
{
    public partial class MemberApi:IApi
    {
        public MemberApi()
        {
        }

        public void Register(WebApplication app)
        {
            app.MapPost("/api/Member/register" , InsertMember).AllowAnonymous();
            app.MapPost("/api/Member/signin", Signin).AllowAnonymous();

            
            app.MapPost("/api/Member/update", UpdMember);
            app.MapGet("/api/Member/getMember/{MemberID:int}", GetMember);
            app.MapGet("/api/Member/GetTopMember/{count:int}", GetTopMember);
        }
    }
}
