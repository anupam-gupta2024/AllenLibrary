using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IMDetails
    {
        int MAction { get; set; }
        string MTitle { get; set; }
        string MName { get; set; }
        string MAge { get; set; }
        string MDOB { get; set; }
        string MBGroup { get; set; }
        string MHeight { get; set; }
        string MWeight { get; set; }
        string MMobile1 { get; set; }
        string MMobile2 { get; set; }
        string MMobile3 { get; set; }
        string MStd { get; set; }
        string MPhone1 { get; set; }
        string MPhone2 { get; set; }
        string MEmail { get; set; }
        string MAltEmail { get; set; }
        string MOCCU { get; set; }

    }
}
