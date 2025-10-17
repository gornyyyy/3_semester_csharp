using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DataAccessLayer
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Create(T item);
        void Delete(T item);
        void Save();

    }
}
    public class Context : DbContext
    {
        public Context() : base("name=StudentDbConnection") { }
        public DbSet<Student> Students { get; set; } //доступ к данным таблицы
    }


public class EntityFrameworkRepository<T> : IRepository<T>
    where T : class, IDomainObject, new()
    {
        public Context _context;
        public DbSet<T> _dbSet;

        public EntityFrameworkRepository()
        {
            _context = new Context();
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> ReadAll()
        {
            return _dbSet.ToList();
        }

        public T ReadById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(T obj)
        {
            _dbSet.Add(obj);
            Save();
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
    


