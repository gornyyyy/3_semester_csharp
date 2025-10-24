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
using Dapper;


namespace DataAccessLayer
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Create(T item);
        void Delete(T item);
    }
}
    public class Context : DbContext
    {
        public Context() : base("name=StudentDbConnection") { }
        public DbSet<Student> Students { get; set; }
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
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            _dbSet.Remove(obj);
            _context.SaveChanges();
        }
    }

    public class DapperRepository<T> : IRepository<T> 
        where T : class, IDomainObject, new()
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;";
        IDbConnection db = new SqlConnection(connectionString);

        public void Create(T t)
        {
        var sqlQuery = @"INSERT INTO Students (Name, [Group], Speciality, StudentNumber) 
                   VALUES(@Name, @Group, @Speciality, @StudentNumber); 
                   SELECT CAST(SCOPE_IDENTITY() as int)";
        int studentId = db.Query<int>(sqlQuery, t).FirstOrDefault();
        t.ID = studentId;

        }
        public void Delete(T t)
        {
            var sqlQuery = "DELETE FROM Students WHERE ID = @ID";
            db.Execute(sqlQuery, new { ID = t.ID });
        }
        public T ReadById(int id)
        {
            return db.Query<T>("Select * From Students Where ID = " + id).FirstOrDefault();
        }
        public IEnumerable<T> ReadAll()
        {
            return db.Query<T>("SELECT * FROM Students").ToList();
        }
    }