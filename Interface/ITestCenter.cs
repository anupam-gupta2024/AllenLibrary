using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface ITestCenter
    {
        string TestCenter1 { get; set; }
        string TestCenter2 { get; set; }
        string TestCenter3 { get; set; }

        string TestCity1 { get; set; }
        string TestCity2 { get; set; }
        string TestCity3 { get; set; }

        string TestCenterAdd1 { get; set; }
        string TestCenterAdd2 { get; set; }
        string TestCenterAdd3 { get; set; }
    }
}
