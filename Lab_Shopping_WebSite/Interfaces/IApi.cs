using Lab_Shopping_WebSite.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Lab_Shopping_WebSite.Interfaces

{
    public interface IApi
    {
        abstract public void Register(WebApplication app);

    }

    public class IService<T>
    {
        public readonly DataContext _db;

        public IService(DataContext db)
        {
            if (db == null)
                throw new ArgumentNullException("db");
            this._db = db;
        }

        public async Task<Tuple<bool, string>> Updater<M>(M model)
            where M : class, new()
        {
            string ErrorMsg = "";

            Type type = typeof(M);

            using var transaction = _db.Database.BeginTransaction();
            try
            {
                _db.Update(model);
                await _db.SaveChangesAsync();
                transaction.Commit();
                return new Tuple<bool, string>(true, ErrorMsg);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                transaction.Rollback();
                ex.Entries.Single().Reload();
                ErrorMsg = ex.Message.ToString();
                return new Tuple<bool, string>(false, ErrorMsg);
            }
        }

        public async Task<Tuple<bool, string>> Creater<M>(M model)
            where M: class, new()
        {
            string ErrorMsg = "";
            Type type = typeof(M);
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                await _db.AddAsync(model);
                await _db.SaveChangesAsync();
                transaction.Commit();
                return new Tuple<bool, string>(true, ErrorMsg);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                transaction.Rollback();
                ex.Entries.Single().Reload();
                ErrorMsg = ex.Message.ToString();
                return new Tuple<bool, string>(false, ErrorMsg);
            }
        }
    }
}
