

using AutoMapper;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.DTO;

namespace Lab_Shopping_WebSite.Map
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<UpdMemberDto, Members>();
        }
    }
}
