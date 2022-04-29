namespace Lab_Shopping_WebSite.DTO
{
    public class RegisteDto
    {
        public RegisteDto()
        {
        }

        public string Email_Address { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string second_verify { get; set; }
    }

    public class SigninDto
    {
        public SigninDto()
        {
        }

        public string Email_Address { get; set; }
        public string Password { get; set; }
    }

    public class UpdMemberDto
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get;set; }
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