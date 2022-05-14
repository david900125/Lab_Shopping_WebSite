using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Lab_Shopping_WebSite.DBContext;
using Lab_Shopping_WebSite.DTO;
using System.Reflection;

namespace Lab_Shopping_WebSite.Interfaces

{
    public interface IApi
    {
        abstract public void Register(WebApplication app);
    }

    public class IService<T>
    {
        public readonly DataContext _db;
        public readonly AuthDto _auth;
        public readonly IMapper _mapper;
        public IService(DataContext db , AuthDto auth , IMapper mapper)
        {
            if (db == null)
                throw new ArgumentNullException("db");
            this._db = db;

            if (auth == null)
                throw new ArgumentException("authdto");
            this._auth = auth;

            if (mapper == null)
                throw new ArgumentException("mapper");
            this._mapper = mapper;
        }

        public async Task<Tuple<bool, string>> Updater<M>(M model)
            where M : class, new()
        {
            string ErrorMsg = "";

            Type type = typeof(M);

            // set update time and updater
            PropertyInfo propInfo = model.GetType().GetProperty("ModifyTime");
            if (propInfo != null)
            {
                propInfo.SetValue(model, DateTime.Now, null);
            }
            propInfo = model.GetType().GetProperty("Modifier");
            if (propInfo != null)
            {
                propInfo.SetValue(model, _auth.UserID.MemberID, null);
            }
            

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
            where M : class, new()
        {
            string ErrorMsg = "";
            Type type = typeof(M);

            // set creater
            PropertyInfo propInfo = model.GetType().GetProperty("Creator");
            if (propInfo != null && propInfo.GetValue(model) != null)
            {
                propInfo.SetValue(model, _auth.UserID.MemberID, null);
            }

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

        public async Task<Tuple<bool, string>> Deleter<M>(M model)
            where M : class, new()
        {
            string ErrorMsg = "";
            Type type = typeof(M);
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                _db.Remove(model);
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
