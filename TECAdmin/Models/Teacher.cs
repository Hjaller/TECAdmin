using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECAdmin.Interfaces;

namespace TECAdmin.Models
{
    public class Teacher : Person, ITeacher
    {
        public Teacher(int id, string firstName, string lastName) : base(id, firstName, lastName) { }
    }
}
