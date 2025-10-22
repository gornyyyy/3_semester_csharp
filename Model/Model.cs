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

    public class Student: IDomainObject
    {
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Group { get; set; }
        public int StudentNumber { get; set; }
        public int ID { get; set; }
        public Student() { }
        public Student(string name, string speciality, string group, int studentnumber)
        {
            Name = name;
            Speciality = speciality;
            Group = group;
            StudentNumber = studentnumber;   
        }

    }
}
