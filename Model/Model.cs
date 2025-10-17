using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IDomainObject
    {
        int ID { get; set; }
    }
    public class Student : IDomainObject
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Group { get; set; }
        public int ID { get; set; }
        public string StudentNumber { get; set; }
        public Student() { }
        public Student(string name, string speciality, string group, string studentNumber)
        {
            Name = name;
            Speciality = speciality;
            Group = group;
            StudentNumber = studentNumber;
        }

    }
}
