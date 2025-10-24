using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;


namespace BusinessLogic
{
    public class Logic
    {
        IRepository<Student> repository = new EntityFrameworkRepository<Student>();

        public List<Student> students { set; get; } = new List<Student>();
        public Logic()
        {
            RefreshStudents();
        }

        public bool AddStudent(string name, string speciality, string group, string studentNumber)
        {

            var student = new Student(name, speciality, group, studentNumber);
            if (!string.IsNullOrWhiteSpace(studentNumber) && !(students.Any(x => x.StudentNumber == studentNumber)))
            {
                repository.Create(student);
                RefreshStudents();
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int id)
        {
            var student = repository.ReadById(id);
            if (student != null)
            {
                repository.Delete(student);
                RefreshStudents();
                return true;
            }
            return false;
        }
        public List<string> GetAllStudents()
        {
            return repository.ReadAll().Select(s =>
            $"{s.ID.ToString().PadLeft(3)} | {s.Name.PadRight(15)} | {s.Speciality.PadRight(20)} | {s.Group.PadRight(8)} | {s.StudentNumber.ToString().PadLeft(6)}").ToList();
        }
        public Dictionary<string, int> GetSpecialtyDistribution()
        {
            return students
                .GroupBy(s => s.Speciality)
                .ToDictionary(g => g.Key, g => g.Count());
        }
        public void PrintSpecialityHistogram()
        {
            var histogram = GetSpecialtyDistribution();

            foreach (var item in histogram)
            {
                string arrows = new string('>', item.Value);
                string specialty = item.Key;
                Console.WriteLine($"{(specialty).PadRight(10, ' ')} | {arrows}");
            }
        }
        public void RefreshStudents()
        {
            students = repository.ReadAll().ToList();
        }
    }
}
