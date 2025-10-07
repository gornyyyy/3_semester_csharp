using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BusinessLogic
{
    public class Logic
    {
        public List<Student> students { set; get; } = new List<Student>();

        public bool AddStudent(string name, string speciality, string group, int id)
        {

            var student = new Student(name, speciality, group, id);
            if (!string.IsNullOrWhiteSpace(name) && !(students.Any(x => x.ID == id)))
            {
                students.Add(student); 
                return true;
            }
            return false;
        }
        public void DeleteStudent(int id)
        {
            students.RemoveAll(x => x.ID == id);
        }
        public List<string> GetAllStudents()
        {
            return students.Select(s => $"{s.ID} | {s.Name} | {s.Speciality} | {s.Group}").ToList();
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
    }
}
