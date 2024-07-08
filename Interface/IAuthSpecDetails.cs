using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IAuthSpecDetails
    {
        Int64 AuthAction { get; set; }
        string EntryDate { get; set; }
        string UserName { get; set; }
        string LIP { get; set; }
        string RIP { get; set; }
        string BroType { get; set; }
        string EntryVia { get; set; }
        string APPID { get; set; }
    }
}
