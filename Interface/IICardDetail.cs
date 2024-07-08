using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IICardDetail
    {
        int ICardAction { get; set; }
        string Batch { get; set; }
        string OldBatch { get; set; }
        string Regno { get; set; }
        string IColor { get; set; }
        string OldRegno { get; set; }
        string Photo { get; set; }
        string PhotoDate { get; set; }


    }
}
