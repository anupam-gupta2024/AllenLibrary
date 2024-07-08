using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IDatabase
    {
        DataSet ds1 { get; set; }
        DataSet ds2 { get; set; }
        DataSet ds3 { get; set; }
        DataSet ds4 { get; set; }
        DataSet ds5 { get; set; }

        DataTable dt1 { get; set; }
        DataTable dt2 { get; set; }
        DataTable dt3 { get; set; }
        DataTable dt4 { get; set; }
        DataTable dt5 { get; set; }
        DataTable dt6 { get; set; }
        DataTable dt7 { get; set; }
        DataTable dt8 { get; set; }
        DataTable dt9 { get; set; }
        DataTable dt10 { get; set; }
    }
}
