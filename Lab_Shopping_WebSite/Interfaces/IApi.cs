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
        public DataContext _db { get; set; }

        public async Task<Tuple<bool, string>> Updater<T>(T model)
            where T : class, new()
        {
            string ErrorMsg = "";

            Type type = typeof(T);

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
    }
}
