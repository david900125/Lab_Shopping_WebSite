using AutoMapper;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.DTO
{
    public class RegisteDto:IMapFrom<Members>
    {
        public string Email_Address { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string second_verify { get; set; }

        public void Mapping(Profile profile)
        {
            var c = profile.CreateMap<RegisteDto, Members>()
                           .ForMember(d => d.MemberID , opt => opt.Ignore())
                           .ForMember(d => d.Email_Address, opt => opt.MapFrom(s => s.Email_Address))
                           .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                           .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Password.ToMD5()))
                           .ForMember(d => d.RoleID, opt => opt.Ignore())
                           .ForMember(d => d.CreateTime, opt => opt.MapFrom(src => DateTime.Now))
                           .ForMember(d => d.ModifyTime, opt => opt.MapFrom(src => DateTime.Now));
        }
    }

    public class SigninDto
    {
        public string Email_Address { get; set; }
        public string Password { get; set; }
    }

    public class UpdMemberDto
    {
        public string Name { get; set; }
        public string Email_Address { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public string Birthday { get; set; }
    }

    public class MemberDto
    {
        public int MemberID { get; set; }
        public string? Email_Address { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone_Number { get; set; }
        public string? Gender { get; set; }
        public string? BirthDay { get; set; }
        public string Role { get; set; }
        public string? LastSignin { get; set; }
        public string? CreateTime { get; set; }
        public string? ModifyTime { get; set; }
    }

    public class UpdPsdDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string second_verify { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}