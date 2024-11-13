using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECAdmin.Interfaces
{
    public interface IStudent : IPerson
    {
        DateTime BirthDay { get; set; }
    }
}
