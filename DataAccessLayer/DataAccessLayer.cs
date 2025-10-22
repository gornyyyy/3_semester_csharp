using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Model;

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

    public class Context: DbContext
    {
        public Context() : base("DbConnection") { }

        public DbSet<Student> Students { get; set; }
    }

    public class DapperRepository<T> : IRepository<T> where T :
        class, IDomainObject, new()
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=StudentDatabase;" +
                            "Integrated Security=True;Connect Timeout=30";

        IDbConnection db = new SqlConnection(connectionString);

        public void Create(T t)
        {
            var sqlQuery = "INSERT INTO Students (Name, Group, Speciality) " +
                "VALUES(@Name, @Group, @Speciality); SELECT CAST(SCOPE_IDENTITY() as int)";
            int studentId = db.Query<int>(sqlQuery, t).FirstOrDefault();
            t.ID = studentId;

        }

        public void Delete(T t)
        {
            var sqlQuery = "DELETE FROM Students WHERE ID = @ID";
            db.Execute(sqlQuery, new { ID = t.ID });
        }

        public void Save()
        {

        }
        public T ReadById(int id)
        {
            return db.Query<T>("Select * From Students Where ID = " + id).FirstOrDefault();
        }
        public IEnumerable<T> ReadAll()
        {
            return db.Query<T>("SELECT * FROM Students").ToList();
        }
        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
