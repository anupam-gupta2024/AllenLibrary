using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IConDetails
    {
        Int64 ConAction { get; set; }
        string CaseStatus { get; set; }
        string Conc { get; set; }
        string Scode { get; set; }
        string SPer { get; set; }
        string Amount { get; set; }
        string EAllen { get; set; }
        string ConcLess { get; set; }
        string BalAmt { get; set; }
        string Cases { get; set; }
        string SchRemarks { get; set; }
        string SchReason { get; set; }
        int ConID { get; set; }
        int SchID { get; set; }


    }
}
