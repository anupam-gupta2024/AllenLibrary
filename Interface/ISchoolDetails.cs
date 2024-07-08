using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface ISchoolDetails
    {
        int SchoolAction { get; set; }
        string SID { get; set; }
        string SCHName { get; set; }
        string SCHAdd1 { get; set; }
        string SCHAdd2 { get; set; }
        string SCHAdd3 { get; set; }
        string SCHCity { get; set; }
        string SCHDistrict { get; set; }
        string SCHState { get; set; }
        string SCHPin { get; set; }
    }
}
