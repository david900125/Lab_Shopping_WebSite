using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.DTO
{
    public class AuthDto
    {
        public AuthDto()
        {
        }

        public Members UserID { get; set; }

        public string ErrorMsg { get; set; }

        public bool IsAuth { get; set; }
    }

    public class ErrorDto
    {
        public string Code { get; set; }
        public string ErrorMsg { get; set; }
        public string Type { get; set; }
    }
}
