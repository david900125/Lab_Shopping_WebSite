using AutoMapper;
using AutoMapper.QueryableExtensions;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Services
{
    public class ColorServices: IService<ColorServices>
    {
        private IMapper _mapper;
        public ColorServices(DataContext db , IMapper mapper) : base(db)
        {
            _mapper = mapper;
        }

        public async Task<List<ColorDto>> GetAllColors()
        {
            //List<ColorDto> colors = _db.Colors.Select(s => _mapper.Map()).ToList();
            return  new List<ColorDto>();
        }
    }
}
