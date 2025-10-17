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
            if (!string.IsNullOrWhiteSpace(name) && !(students.Any(x => x.StudentNumber == studentNumber)))
            {
                repository.Create(student);
                repository.Save();
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
                repository.Save();
                RefreshStudents();
                return true;
                //students.RemoveAll(x => x.ID == id);
            }
            return false;
        }
        public List<string> GetAllStudents()
        {
            return repository.ReadAll().Select(s => $"{s.ID} | {s.Name} | {s.Speciality} | {s.Group} | {s.StudentNumber}").ToList();
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
                Console.WriteLine($"{item.Key} | {arrows}");
            }
        }
        public void RefreshStudents()
        {
            students = repository.ReadAll().ToList();
        }
    }
}
