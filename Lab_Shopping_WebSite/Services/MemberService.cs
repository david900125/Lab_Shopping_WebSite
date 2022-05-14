using Microsoft.EntityFrameworkCore;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.DTO;
using AutoMapper;

namespace Lab_Shopping_WebSite.Services
{
    public class MemberService : IService<MemberService>
    {
        public MemberService(DataContext db , IMapper mapper , AuthDto auth) : base(db , auth , mapper)
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
            var result = await _db.Members.Where(n => n.MemberID == MemberID).FirstOrDefaultAsync();

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
            Members member = _mapper.Map<Members>(dto);
            member.RoleID = 2; // user
            member.Creator = 1;
            member.Modifier = 1;

            return await Creater(member);
        }
        public async Task<Tuple<bool, string>> UpdateMember(UpdMemberDto dto, Members member)
        {
            member.Name =  (dto.Name ??= member.Name);
            member.Address = (dto.Address ??= member.Address);
            member.Gender = Convert.ToBoolean(dto.Gender);
            member.BirthDay = DateOnly.Parse(dto.Birthday);
            member.Phone_Number = (dto.PhoneNumber ??= member.Phone_Number);
            member.Email_Address = (dto.Email_Address ??= member.Email_Address);
            member.Modifier = _auth.UserID.MemberID;
            member.ModifyTime = DateTime.Now;

            var result = await Updater<Members>(member);
            return result;
        }
        public async Task<Tuple<bool, string>> UpdatePassword(Members member, string newPsd)
        {
            member.Password = newPsd.ToMD5();
            member.Modifier = _auth.UserID.MemberID;

            return await Updater<Members>(member);
        }
        public async Task<Tuple<bool , string>> UpdateSinginTime(Members member)
        {
            member.LastSignin = DateTime.Now;
            member.Modifier = member.MemberID;

            return await Updater<Members>(member);
        }
    }
}