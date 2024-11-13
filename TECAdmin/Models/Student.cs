using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECAdmin.Interfaces;

namespace TECAdmin.Models
{
    public class Student : Person, IStudent, IComparable<Student>
    {
        public DateTime BirthDay { get; set; }
        public Student(int id, string firstName, string lastName, DateTime birthDay) : base(id, firstName, lastName)
        {
            BirthDay = birthDay;
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            return string.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);
        }
    }
}
