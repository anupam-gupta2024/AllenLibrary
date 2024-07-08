using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IFDetails
    {
        int FAction { get; set; }
        string FTitle { get; set; }
        string FName { get; set; }
        string FAge { get; set; }
        string FDOB { get; set; }
        string FBGroup { get; set; }
        string FHeight { get; set; }
        string FWeight { get; set; }
        string FMobile1 { get; set; }
        string FMobile2 { get; set; }
        string FMobile3 { get; set; }
        string FStd { get; set; }
        string FPhone1 { get; set; }
        string FPhone2 { get; set; }
        string FEmail { get; set; }
        string FAltEmail { get; set; }
        string FOCCU { get; set; }

    }
}
