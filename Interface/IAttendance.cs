using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IAttendance
    {
        string OperationType { get; set; }
        string days { get; set; }
        string week { get; set; }
        string daycount { get; set; }
        string batchshift { get; set; }
        string building { get; set; }
    }
}
