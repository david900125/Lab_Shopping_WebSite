using Microsoft.EntityFrameworkCore;

using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.Services
{
    public class MemberService : IService<MemberService>
    {
        private readonly DataContext _db;

        public MemberService(DataContext db)
        {
            if (db == null)
                throw new ArgumentNullException("db");
            this._db = db;
        }
    }
}