using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IDepAmount
    {
        int DepAmtAction { get; set; }
        string PayMode { get; set; }
        string OLNType { get; set; }
        string OFFType { get; set; }
        string TXNO { get; set; }
        string BankRefNo { get; set; }
        string BankID { get; set; }
        string Product { get; set; }
        string TXNDate { get; set; }
        string AuthCode { get; set; }
        string StatusMsg { get; set; }
        string ErrorMsg { get; set; }
        string HashValue { get; set; }
        string PG_Type { get; set; }

    }
}
