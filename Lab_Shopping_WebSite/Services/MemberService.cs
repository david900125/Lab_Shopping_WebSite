using Microsoft.EntityFrameworkCore;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.DTO;

namespace Lab_Shopping_WebSite.Services
{
    public class MemberService : IService<MemberService>
    {

        public MemberService(DataContext db) : base(db)
        {
        }

        public async Task<Tuple<bool, Members>> GetMembers(string EmailAddress)
        {
            var result = await _db.Members.Where
                    (n => n.Email_Address == EmailAddress)
                    .FirstOrDefaultAsync();

            if (result == null)
            {
                return Tuple.Create(
                        false,
                        new Members());
            }
            else
            {
                return Tuple.Create(
                        true,
                        result);
            }
        }
        public async Task<Tuple<bool, Members>> GetMembers(int MemberID)
        {
            var result = await _db.Members.Where
                    (n => n.MemberID == MemberID)
                    .FirstOrDefaultAsync();

            if (result == null)
            {
                return Tuple.Create(
                        false,
                        new Members());
            }
            else
            {
                return Tuple.Create(
                        true,
                        result);
            }
        }

        public async Task<Tuple<bool, string>> CreateMember(RegisteDto dto)
        {
            return (
                await Creater<Members>(
                    new Members
                    {
                        Email_Address = dto.Email_Address,
                        Password = dto.Password.ToMD5(),
                        Name = dto.Name,
                        RoleID = 1,
                        Creator = 1,
                        CreateTime = DateTime.Now,
                        Modifier = 1,
                        ModifyTime = DateTime.Now
                    }
                 )
              );
        }
        public async Task<Tuple<bool, string>> UpdateMember(UpdMemberDto dto, Members member)
        {
            member.Name = dto.Name;
            member.Address = dto.Address;
            member.Gender = Convert.ToBoolean(dto.Gender);
            member.BirthDay = DateOnly.Parse(dto.Birthday);
            member.Phone_Number = dto.PhoneNumber;
            member.Email_Address = dto.Email_Address;

            var result = await Updater<Members>(member);
            return result;
        }
        public async Task<Tuple<bool, string>> UpdatePassword(Members member, string newPsd)
        {
            member.Password = newPsd.ToMD5();
            return await Updater<Members>(member);
        }
    }
}