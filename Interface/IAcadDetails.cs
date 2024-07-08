using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IAcadDetails
    {

        int AcadAction { get; set; }
        string IXPer { get; set; }
        string IXYear { get; set; }
        string XPer { get; set; }
        string XYear { get; set; }
        string XIIPer { get; set; }
        string XIIYear { get; set; }

        string DiplomaStream { get; set; }
        string DiplomaPer { get; set; }
        string DiplomaYear { get; set; }

        string GraStream { get; set; }
        string GraPer { get; set; }
        string GraYear { get; set; }

        string PGraStream { get; set; }
        string PGraPer { get; set; }
        string PGraYear { get; set; }

        string CertifyStream { get; set; }
        string CertifyPer { get; set; }
        string CertifyYear { get; set; }

        string AadharNo { get; set; }
        string RollXIotXII { get; set; }
        string RollTTex { get; set; }
        string RollExAllen { get; set; }






    }
}
