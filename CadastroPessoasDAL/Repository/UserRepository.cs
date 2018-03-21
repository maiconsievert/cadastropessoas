using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroPessoasDAL;
using CadastroPessoasDAL.Models;
using CadastroPessoasDAL.Contexto;
using CadastroPessoasDAL.Helper;
using System.Data.Entity;

namespace CadastroPessoasDAL.Repository
{

    public interface IRepository<T> : IDisposable
        where T : class
    {
        ICollection<T> Get();
        T Get(int id);
        void SaveOrUpdate(T entity);
        void Delete(int id);
    }

    public interface IUserRepository : IRepository<Usuarios>
    {
        Usuarios Authenticate(string username, string password);
    }

    public class UserRepository : IUserRepository
    {
        private CadastrosContext _db;

        public object Helper { get; private set; }

        public UserRepository(CadastrosContext context)
        {
            _db = context;
        }

        public ICollection<Usuarios> Get()
        {
            return _db.Usuarios.ToList();
        }

        public Usuarios Get(int id)
        {
            return _db.Usuarios.Find(id);
        }

        public Usuarios Authenticate(string username, string password)
        {
            var senhaHashed = MD5Helper.GetMd5HashData(password);
            return _db.Usuarios.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == senhaHashed).FirstOrDefault();
        }

        public void SaveOrUpdate(Usuarios entity)
        {
            if (entity.Id == 0)
                _db.Usuarios.Add(entity);
            else
                _db.Entry<Usuarios>(entity).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Usuarios.Remove(_db.Usuarios.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
