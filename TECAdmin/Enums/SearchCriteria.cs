using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECAdmin.enums
{
    public enum SearchCriteria
    {
        [Description("Søg på fag")]
        Subject = 1,
        [Description("Søg på lærer ")]
        Teacher = 2,
        [Description("Søg på elev")]
        Student = 3,

    }
}
