using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IADDDetails
    {
        int ADDAction { get; set; }
        string LAdd1 { get; set; }
        string LAdd2 { get; set; }
        string LAdd3 { get; set; }
        string LCity { get; set; }
        string LDistrict { get; set; }
        string LState { get; set; }
        string LPin { get; set; }
        string PAdd1 { get; set; }
        string PAdd2 { get; set; }
        string PAdd3 { get; set; }
        string PCity { get; set; }
        string PDistrict { get; set; }
        string PState { get; set; }
        string PPin { get; set; }
    }
}
