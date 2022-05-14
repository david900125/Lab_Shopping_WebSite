using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using AutoMapper;

namespace Lab_Shopping_WebSite.Services
{
    public class FileServices : IService<FileServices>
    {
        public FileServices(DataContext db, AuthDto auth , IWebHostEnvironment _environment , IMapper mapper) : base(db , auth ,mapper)
        {
           this.Environment = _environment;
        }
        private IWebHostEnvironment Environment;

        public async Task<Tuple<bool,string>> Store_File(IFormFile file)
        {
            string fname = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var path = Path.Combine(this.Environment.ContentRootPath, "Upload" , fname);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Tuple.Create(true , path);
        }
        public async Task<Tuple<bool,string,Lab_Shopping_WebSite.Models.Files>> Insert_File(IFormFile file , string path)
        {
            var ob = new Lab_Shopping_WebSite.Models.Files
            {
                FileName = Path.GetFileName(path),
                FilePath = path,
                FileSize = file.Length,
                FileType = file.ContentType,
                Modifier = 1,
                Creator = 1,
                ModifyTime = DateTime.Now,
                CreateTime = DateTime.Now
            };
            var result = await Creater<Lab_Shopping_WebSite.Models.Files>(ob);

            return Tuple.Create(result.Item1 , result.Item2, ob);
        }
    }
}
