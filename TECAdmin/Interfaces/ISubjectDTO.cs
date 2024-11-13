using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECAdmin.Models;

namespace TECAdmin.Interfaces
{
    public interface ISubjectDTO
    {
        string Name { get; set; }
        Teacher Teacher { get; set; }
        List<Student> Students { get; set; }
    }
}
