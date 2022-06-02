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
            app.MapGet("/api/Member/getMember", GetMember).WithTags("Member");
            app.MapGet("/api/Member/GetTopMember/{count:int}", GetTopMember).WithTags("Member");
            app.MapPost("/api/Member/register", InsertMember).AllowAnonymous().WithTags("Member");
            app.MapPost("/api/Member/signin", Signin).AllowAnonymous().WithTags("Member");
            app.MapPost("/api/Member/update", UpdMember).WithTags("Member");
            app.MapPost("/api/Member/UpdatePassword", UpPassword).WithTags("Member");
        }
    }
}
