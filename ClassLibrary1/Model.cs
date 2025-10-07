using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Student
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Group { get; set; }
        public int ID { get; set; }
        public Student(string name, string speciality, string group, int id)
        {
            Name = name;
            Speciality = speciality;
            Group = group;
            ID = id;
        }


    }
}
