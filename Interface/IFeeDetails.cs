using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IFeeDetails
    {
        int FeeAction { get; set; }
        string Sid { get; set; }
        string Inst { get; set; }
        string Fee { get; set; }
        string CFee { get; set; }
        string ST { get; set; }
        string STPer { get; set; }
        string Cess { get; set; }
        string CessPer { get; set; }
        string CaseType { get; set; }
        string StartDate { get; set; }
        string LastDate { get; set; }
        string DepDate { get; set; }
        string TotalSt { get; set; }
    }
}
