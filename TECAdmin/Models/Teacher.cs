using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECAdmin.Interfaces;

namespace TECAdmin.Models
{
    public class Teacher : Person, ITeacher, IComparable<Teacher>
    {
        public Teacher(int id, string firstName, string lastName) : base(id, firstName, lastName) { }

        public int CompareTo(Teacher other)
        {
            if (other == null) return 1;
            return string.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);
        }
    }
}
