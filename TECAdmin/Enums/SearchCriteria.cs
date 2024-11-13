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
        [Description("Search by Teacher")]
        Teacher,
        [Description("Search by Student")]
        Student,
        [Description("Search by Subject")]
        Subject
    }
}
