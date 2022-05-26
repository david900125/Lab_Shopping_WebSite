using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Services;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Extension;


namespace Lab_Shopping_WebSite.Apis
{
    public partial class MemberApi
    {
        [AllowAnonymous]
        async Task<IResult> InsertMember(
            [FromServices] DataContext _db,
            [FromServices] IService<MemberService> service,
            [FromBody] RegisteDto register)
        {
            Tuple<bool, string> result;
            MemberService ms = (MemberService)service;

            if (register.Password == register.second_verify)
            {
                Tuple<bool, Members> query = await ms.GetMembers(register.Email_Address);
                if (!query.Item1)
                {
                    result = await ms.CreateMember(register);
                    if (result.Item1)
                    {
                        return Results.Ok();
                    }
                    else
                        return Results.BadRequest("Insert Error.");
                }
                else
                    return Results.BadRequest("Email Used.");
            }
            else
                return Results.BadRequest("Second verification Error.");

        }

        [AllowAnonymous]
        async Task<IResult> Signin(
            [FromServices] DataContext _db,
            [FromServices] IService<MemberService> service,
            [FromServices] Jwt jwt,
            [FromBody] SigninDto signin)
        {
            MemberService ms = (MemberService)service;
            Tuple<bool, Members> query = await ms.GetMembers(signin.Email_Address);
            if (query.Item1)
            {
                if (query.Item2.Password == signin.Password.ToMD5())
                {
                    // update sigin time
                    ms.UpdateSinginTime(query.Item2);
                    // make token
                    StringBuilder sbuild = new StringBuilder("Bearer ");
                    var token = jwt.GenerateToken(query.Item2.Name, query.Item2.RoleID, query.Item2.MemberID);
                    string result = sbuild.Append(token).ToString();
                    string Role = query.Item2.RoleID == 1 ? "Admin" : "User";
                    return Results.Ok(new { result, Role });
                }
                else
                    return Results.BadRequest("Password inCorrect");
            }
            else
                return Results.BadRequest("Go Registe!");

        }

        [Authorize]
        async Task<IResult> GetMember(
            [FromServices] DataContext _db,
            [FromServices] IService<MemberService> service,
            HttpContext http)
        {
            int MemberID = Convert.ToInt16(http.User.FindFirst("Sid").Value);
            var result = _db.Members.Where(u => u.MemberID == MemberID).ToList();
            return Results.Ok(result);
        }

        [Authorize]
        async Task<IResult> UpdMember(
            [FromServices] DataContext _db,
            [FromServices] IService<MemberService> service,
            [FromServices] AuthDto _auth,
            [FromBody] UpdMemberDto dto)
        {
            MemberService ms = (MemberService)service;
            var query = await ms.GetMembers(_auth.UserID.MemberID);

            if (query.Item1)
            {
                var result = await ms.UpdateMember(dto, query.Item2);
                if (result.Item1)
                    return Results.Ok();
                else
                    return Results.BadRequest("Update Error.");
            }
            else
                return Results.BadRequest("Member not found.");
        }

        [Authorize]
        async Task<IResult> GetTopMember(
               [FromServices] DataContext _db,
               [FromServices] IService<MemberService> service,
               int count)
        {
            List<MemberDto> results = (from members in _db.Members
                                       join roles in _db.Roles
                                       on members.RoleID equals roles.RoleID
                                       //orderby members.CreateTime descending
                                       select new MemberDto()
                                       {
                                           MemberID = members.MemberID,
                                           Email_Address = members.Email_Address,
                                           Name = members.Name,
                                           Address = members.Address,
                                           Phone_Number = members.Phone_Number,
                                           Gender = ((members.Gender == true) ? Gender.Male.ToString() : Gender.Female.ToString()),
                                           Role = roles.RoleName,
                                           BirthDay = members.BirthDay.ToString(),
                                           CreateTime = members.CreateTime.Value.ToString("yyyy/MM/dd HH:mm:ss"),
                                           ModifyTime = members.ModifyTime.Value.ToString("yyyy/MM/dd HH:mm:ss"),
                                       }).Take(count).ToList();

            return Results.Ok(results);
        }

        [Authorize]
        async Task<IResult> UpPassword(
            [FromServices] DataContext _db,
            [FromServices] IService<MemberService> service,
            [FromBody] UpdPsdDto dto,
            HttpContext http)
        {
            if (dto.NewPassword != dto.second_verify)
                return Results.BadRequest("Second Verify Error.");

            MemberService ms = (MemberService)service;
            int MemberID = Convert.ToInt16(http.User.FindFirst("Sid").Value);
            var query = await ms.GetMembers(MemberID);
            if (query.Item1)
            {
                if (query.Item2.Password == dto.OldPassword.ToMD5())
                {
                    var result = await ms.UpdatePassword(query.Item2, dto.NewPassword);
                    if (result.Item1)
                        return Results.Ok();
                    else
                        return Results.BadRequest("New Password Update Failed.");
                }
                else
                    return Results.BadRequest("Old Password InCorrect.");
            }

            return Results.BadRequest("Member Not Found.");
        }
    }
}
