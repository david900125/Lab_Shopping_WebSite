using Microsoft.EntityFrameworkCore;

using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.Interfaces;
using Lab_Shopping_WebSite.Models;

namespace Lab_Shopping_WebSite.Services
{
    public class BlogService : IService
    {
        private readonly DataContext _db;

        public BlogService(DataContext db)
        {
            if (db == null)
                throw new ArgumentNullException("db");
            this._db = db;
        }

        public async Task<bool> UpdateBlogs(Blogs blog)
        {
            using var transaction = _db.Database.BeginTransaction();

            try
            {
                _db.Update(blog);
                await _db.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                transaction.Rollback();

                Blogs? Item = await _db.Blogs?.FirstOrDefaultAsync(b => b.BlogID == blog.BlogID);

                if (Item == null)
                {
                    return false;
                }
                else
                {
                    ex.Entries.Single().Reload();
                    throw;
                }
            }

        }

    }
}