using Lab_Shopping_WebSite.DBContext;
using AutoMapper;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Lab_Shopping_WebSite.Services
{
    public class SizeServices:IService<SizeServices>
    {
        public SizeServices(DataContext db, AuthDto auth, IMapper mapper) : base(db, auth, mapper)
        {
        }
        // Get Size
        public async Task<List<SizeDto>> GetSizes([Optional] int id)
        {
            if(id == 0)
            {
                return await _mapper.ProjectTo<SizeDto>(_db.Sizes).ToListAsync();
            }
            else
            {
                return await _mapper.ProjectTo<SizeDto>(_db.Sizes.Where(s => s.Commodity_KindsID == id)).ToListAsync();
            }
        } 
        
    }
}
