using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllenLibrary.Interface
{
    public interface IStudent
    {
        int StuAction { get; set; }
        string UName { get; set; }
        string UPassword { get; set; }
        string Fno { get; set; }
        string Title { get; set; }
        string Name { get; set; }
        string DOB { get; set; }
        string Age { get; set; }
        string Gender { get; set; }
        string Medium { get; set; }
        string BGroup { get; set; }
        string Height { get; set; }
        string Weight { get; set; }
        string Mobile1 { get; set; }
        string Mobile2 { get; set; }
        string Mobile3 { get; set; }
        string Std { get; set; }
        string Phone1 { get; set; }
        string Phone2 { get; set; }
        string Email { get; set; }
        string AltEmail { get; set; }
        string Course { get; set; }

        string StudyCCode { get; set; }
        string TCCode { get; set; }
        string IsFee { get; set; }
        string FDate { get; set; }
        string AttNo { get; set; }
        string InfoSource { get; set; }
        string MCode { get; set; }

        string Stream { get; set; }
        string CourseType { get; set; }
        string SubType { get; set; }

        string TestDate { get; set; }
        string Cat { get; set; }
        string Part { get; set; }
        string Board { get; set; }

        string CName { get; set; }
        Int64 BSID { get; set; }

        string UNewPassword { get; set; }
    }
}
