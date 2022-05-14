using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Models;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;


namespace Lab_Shopping_WebSite.Services
{
    public class ColorServices : IService<ColorServices>
    {
        public ColorServices(DataContext db, IMapper mapper , AuthDto auth) : base(db , auth,mapper)
        {
        }
        // Get Colors
        public async Task<Colors> GetColors(int colorid)
        {
            return await _db.Colors.Where(s => s.ColorID == colorid).FirstOrDefaultAsync();
        }
        // Get ColorsDto
        public async Task<List<ColorDto>> GetColorDtos([Optional] int id)
        {
            List<ColorDto> colors;
            if (id == 0)
            {
                colors = await _mapper.ProjectTo<ColorDto>(_db.Colors).ToListAsync();
            }
            else
            {
                colors = await _mapper.ProjectTo<ColorDto>(_db.Colors).Where(s => s.ColorId == id).ToListAsync();
            }

            return colors;
        }
        // Insert Color
        public async Task<Tuple<bool, string>> InsertColor(ColorDto color)
        {
            Colors Mast = _mapper.Map<Colors>(color);
            return await Creater<Colors>(Mast);
        }
        // Update Color
        public async Task<Tuple<bool, string>> UpdateColor(ColorDto color)
        {
            Colors colors =  await GetColors(color.ColorId);
            colors.Color = color.ColorName ?? colors.Color;
            colors.Url = color.ColorUrl ?? colors.Url;
            return await Updater<Colors>(colors);
        }
        // Delete Color
        public async Task<Tuple<bool, string>> DeleteColor(ColorDto color)
        {
            Colors colors = await GetColors(color.ColorId);
            return await Deleter<Colors>(colors);
        }
    }
}
