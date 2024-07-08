using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AllenLibrary.Classes
{
    public class EmployeeMain
    {
        private int _Action;
        private string _EMPID, _Name, _Center, _Mobile, _PWD;
        private string _Salary, _Hourse_loan, _Other_Income, _Gross_Income;
        private string _Name_of_Insurance_co1, _Name_of_Insurance_co2, _Name_of_Insurance_co3, _Name_of_Insurance_co4, _Name_of_Insurance_co5, _Name_of_Insurance_co6;
        private string _Insurance_policyNo1, _Insurance_policyNo2, _Insurance_policyNo3, _Insurance_policyNo4, _Insurance_policyNo5, _Insurance_policyNo6;
        private string _Insurance_amount1, _Insurance_amount2, _Insurance_amount3, _Insurance_amount4, _Insurance_amount5, _Insurance_amount6;
        private string _PPF, _NSC_Purchased, _Housing_Loan_Principal_Repayment, _Tuition_fee_Paid, _Mutual_Fund_ELSS, _Five_year_Fixed_Deposited, _Others_Specify, _Others_Specify_remraks;
        private string _Mediclaim_Policy_No, _Mediclaim_Relation, _Mediclaim_Senior_Citizen_Y_N, _Mediclaim_Amount;
        private string _HRA_Rend_Paid, _HRA_Residential_Accomadation_RentPaid;
        private string _Other_Specify_2, _Other_Specify_2_Remarks;
        private string _Assessee_Name, _Assessee_Name_PanNo, _Assessee_Address, _Period_of_month, _Period_of_monthFrom, _Period_of_monthTo, _Assessee_Paid, _Assessee_PaidMode, _LandLoadsal, _LandLoadName, _LandLoad_Address, _LandLoad_PAN, _Other_Residential_Accommodation;


        private string _Assessee_Name1, _Assessee_Name_PanNo1, _Assessee_Address1, _Period_of_month1, _Period_of_monthFrom1, _Period_of_monthTo1, _Assessee_Paid1, _Assessee_PaidMode1, _LandLoadsal1, _LandLoadName1, _LandLoad_Address1, _LandLoad_PAN1, _Other_Residential_Accommodation1;

        private string _JanAcmAmount, _FebAcmAmount, _MarAcmAmount, _AprAcmAmount, _MayAcmAmount, _JuneAcmAmount, _JulAcmAmount, _AugAcmAmount, _SepAcmAmount, _OCTAcmAmount, _NovAcmAmount, _DecAcmAmount;
        // private string _JanAcmCity, _FebAcmCity, _MarAcmAmount, _AprAcmAmount, _MayAcmAmount, _JuneAcmAmount, _JulAcmAmount, _AugAcmAmount, _SepAcmAmount, _OCTAcmAmount, _NovAcmAmount, _DecAcmAmount;


        private string _Month, _RentPaidAmount, _RentCity;

        private string _Insurance_policyCounting, _Name_of_Insurance_co, _Insurance_policyNo, _Insurance_amount;

        private string _Premium_Date, _Pay_Mode, _Policy_Holder;

        private string _pageno24b, _pageno80clic, _pagenohomeloanrepayment, _pagenonsc,
            _pagenoeless, _pagenofd, _pagenoppf, _pagenosukanya, _pagenotuitionfee, _pagenostampduty,
            _pagenoother, _pageno80d, _pageno80e, _pageno80ccdnps, _pageno80ccdaps, _pageno80u, _pageno1013a, _pagenootherspecify,
            _pagenototal;
        private string _FyYear;



        private string _lta_travellfrom, _lta_travellto, _lta_amount, _lta_travelleddate, _lta_travellmode, _lta_docrequire, _jrnyno, _lta_blockyear, _lta_availed, _ltadependent;

        private string _key1, _key2, _filenamevalue;
        private string _Apptype;


        private string _ltaname, _ltarelation, _ltadependant, _ltadobp, _ltapersonarno;

        public DataTable dt { get; set; }


        #region Property

        public string Apptype
        {
            get { return _Apptype; }
            set { _Apptype = value; }
        }


        public int Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        public string EMPID
        {
            get { return _EMPID; }
            set { _EMPID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Center
        {
            get { return _Center; }
            set { _Center = value; }
        }

        public string PWD
        {
            get { return _PWD; }
            set { _PWD = value; }
        }

        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }

        public string Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        public string Hourse_loan
        {
            get { return _Hourse_loan; }
            set { _Hourse_loan = value; }
        }

        public string Other_Income
        {
            get { return _Other_Income; }
            set { _Other_Income = value; }

        }

        public string Gross_Income
        {
            get { return _Gross_Income; }
            set { _Gross_Income = value; }

        }



        public string Name_of_Insurance_co1
        {
            get { return _Name_of_Insurance_co1; }
            set { _Name_of_Insurance_co1 = value; }

        }
        public string Name_of_Insurance_co2
        {
            get { return _Name_of_Insurance_co2; }
            set { _Name_of_Insurance_co2 = value; }

        }
        public string Name_of_Insurance_co3
        {
            get { return _Name_of_Insurance_co3; }
            set { _Name_of_Insurance_co3 = value; }

        }
        public string Name_of_Insurance_co4
        {
            get { return _Name_of_Insurance_co4; }
            set { _Name_of_Insurance_co4 = value; }

        }
        public string Name_of_Insurance_co5
        {
            get { return _Name_of_Insurance_co5; }
            set { _Name_of_Insurance_co5 = value; }

        }
        public string Name_of_Insurance_co6
        {
            get { return _Name_of_Insurance_co6; }
            set { _Name_of_Insurance_co6 = value; }

        }




        public string Insurance_policyNo1
        {
            get { return _Insurance_policyNo1; }
            set { _Insurance_policyNo1 = value; }

        }

        public string Insurance_policyNo2
        {
            get { return _Insurance_policyNo2; }
            set { _Insurance_policyNo2 = value; }

        }
        public string Insurance_policyNo3
        {
            get { return _Insurance_policyNo3; }
            set { _Insurance_policyNo3 = value; }

        }
        public string Insurance_policyNo4
        {
            get { return _Insurance_policyNo4; }
            set { _Insurance_policyNo4 = value; }

        }
        public string Insurance_policyNo5
        {
            get { return _Insurance_policyNo5; }
            set { _Insurance_policyNo5 = value; }

        }
        public string Insurance_policyNo6
        {
            get { return _Insurance_policyNo6; }
            set { _Insurance_policyNo6 = value; }

        }

        public string Insurance_amount1
        {
            get { return _Insurance_amount1; }
            set { _Insurance_amount1 = value; }

        }
        public string Insurance_amount2
        {
            get { return _Insurance_amount2; }
            set { _Insurance_amount2 = value; }

        }

        public string Insurance_amount3
        {
            get { return _Insurance_amount3; }
            set { _Insurance_amount3 = value; }

        }
        public string Insurance_amount4
        {
            get { return _Insurance_amount4; }
            set { _Insurance_amount4 = value; }

        }
        public string Insurance_amount5
        {
            get { return _Insurance_amount5; }
            set { _Insurance_amount5 = value; }

        }
        public string Insurance_amount6
        {
            get { return _Insurance_amount6; }
            set { _Insurance_amount6 = value; }

        }


        public string PPF
        {
            get { return _PPF; }
            set { _PPF = value; }

        }
        public string NSC_Purchased
        {
            get { return _NSC_Purchased; }
            set { _NSC_Purchased = value; }

        }
        public string Housing_Loan_Principal_Repayment
        {
            get { return _Housing_Loan_Principal_Repayment; }
            set { _Housing_Loan_Principal_Repayment = value; }

        }
        public string Tuition_fee_Paid
        {
            get { return _Tuition_fee_Paid; }
            set { _Tuition_fee_Paid = value; }

        }
        public string Mutual_Fund_ELSS
        {
            get { return _Mutual_Fund_ELSS; }
            set { _Mutual_Fund_ELSS = value; }

        }

        public string Five_year_Fixed_Deposited
        {
            get { return _Five_year_Fixed_Deposited; }
            set { _Five_year_Fixed_Deposited = value; }

        }
        public string Others_Specify
        {
            get { return _Others_Specify; }
            set { _Others_Specify = value; }

        }



        public string Mediclaim_Policy_No
        {
            get { return _Mediclaim_Policy_No; }
            set { _Mediclaim_Policy_No = value; }

        }

        public string Mediclaim_Relation
        {
            get { return _Mediclaim_Relation; }
            set { _Mediclaim_Relation = value; }

        }

        public string Mediclaim_Senior_Citizen_Y_N
        {
            get { return _Mediclaim_Senior_Citizen_Y_N; }
            set { _Mediclaim_Senior_Citizen_Y_N = value; }

        }


        public string Mediclaim_Amount
        {
            get { return _Mediclaim_Amount; }
            set { _Mediclaim_Amount = value; }

        }

        public string HRA_Rend_Paid
        {
            get { return _HRA_Rend_Paid; }
            set { _HRA_Rend_Paid = value; }

        }

        public string HRA_Residential_Accomadation_RentPaid
        {
            get { return _HRA_Residential_Accomadation_RentPaid; }
            set { _HRA_Residential_Accomadation_RentPaid = value; }

        }


        public string Other_Specify_2
        {
            get { return _Other_Specify_2; }
            set { _Other_Specify_2 = value; }

        }
        public string Assessee_Name
        {
            get { return _Assessee_Name; }
            set { _Assessee_Name = value; }

        }


        public string Assessee_Name_PanNo
        {
            get { return _Assessee_Name_PanNo; }
            set { _Assessee_Name_PanNo = value; }

        }




        public string Assessee_Address
        {
            get { return _Assessee_Address; }
            set { _Assessee_Address = value; }

        }
        public string Period_of_month
        {
            get { return _Period_of_month; }
            set { _Period_of_month = value; }

        }

        public string Period_of_monthFrom
        {
            get { return _Period_of_monthFrom; }
            set { _Period_of_monthFrom = value; }

        }

        public string Period_of_monthTo
        {
            get { return _Period_of_monthTo; }
            set { _Period_of_monthTo = value; }

        }
        public string Assessee_Paid
        {
            get { return _Assessee_Paid; }
            set { _Assessee_Paid = value; }

        }

        public string Assessee_PaidMode
        {
            get { return _Assessee_PaidMode; }
            set { _Assessee_PaidMode = value; }

        }


        public string LandLoadsal
        {
            get { return _LandLoadsal; }
            set { _LandLoadsal = value; }

        }


        public string LandLoadName
        {
            get { return _LandLoadName; }
            set { _LandLoadName = value; }

        }
        public string LandLoad_Address
        {
            get { return _LandLoad_Address; }
            set { _LandLoad_Address = value; }

        }

        public string LandLoad_PAN
        {
            get { return _LandLoad_PAN; }
            set { _LandLoad_PAN = value; }

        }

        public string Other_Residential_Accommodation
        {
            get { return _Other_Residential_Accommodation; }
            set { _Other_Residential_Accommodation = value; }

        }



        #region 10 b form 1
        public string Assessee_Name1
        {
            get { return _Assessee_Name1; }
            set { _Assessee_Name1 = value; }

        }


        public string Assessee_Name_PanNo1
        {
            get { return _Assessee_Name_PanNo1; }
            set { _Assessee_Name_PanNo1 = value; }

        }




        public string Assessee_Address1
        {
            get { return _Assessee_Address1; }
            set { _Assessee_Address1 = value; }

        }
        public string Period_of_month1
        {
            get { return _Period_of_month1; }
            set { _Period_of_month1 = value; }

        }

        public string Period_of_monthFrom1
        {
            get { return _Period_of_monthFrom1; }
            set { _Period_of_monthFrom1 = value; }

        }

        public string Period_of_monthTo1
        {
            get { return _Period_of_monthTo1; }
            set { _Period_of_monthTo1 = value; }

        }
        public string Assessee_Paid1
        {
            get { return _Assessee_Paid1; }
            set { _Assessee_Paid1 = value; }

        }

        public string Assessee_PaidMode1
        {
            get { return _Assessee_PaidMode1; }
            set { _Assessee_PaidMode1 = value; }

        }


        public string LandLoadsal1
        {
            get { return _LandLoadsal1; }
            set { _LandLoadsal1 = value; }

        }


        public string LandLoadName1
        {
            get { return _LandLoadName1; }
            set { _LandLoadName1 = value; }

        }
        public string LandLoad_Address1
        {
            get { return _LandLoad_Address1; }
            set { _LandLoad_Address1 = value; }

        }

        public string LandLoad_PAN1
        {
            get { return _LandLoad_PAN1; }
            set { _LandLoad_PAN1 = value; }

        }

        public string Other_Residential_Accommodation1
        {
            get { return _Other_Residential_Accommodation1; }
            set { _Other_Residential_Accommodation1 = value; }

        }

        #endregion
        // private  string _Month,_RentPaidAmount,_RentCity;

        //private string _Insurance_policyCounting, _Name_of_Insurance_co, _Insurance_policyNo, _Insurance_amount;


        public string Month
        {
            get { return _Month; }
            set { _Month = value; }

        }

        public string RentPaidAmount
        {
            get { return _RentPaidAmount; }
            set { _RentPaidAmount = value; }

        }
        public string RentCity
        {
            get { return _RentCity; }
            set { _RentCity = value; }

        }


        public string Insurance_policyCounting
        {
            get { return _Insurance_policyCounting; }
            set { _Insurance_policyCounting = value; }

        }


        public string Name_of_Insurance_co
        {
            get { return _Name_of_Insurance_co; }
            set { _Name_of_Insurance_co = value; }

        }


        public string Insurance_policyNo
        {
            get { return _Insurance_policyNo; }
            set { _Insurance_policyNo = value; }

        }


        public string Insurance_amount
        {
            get { return _Insurance_amount; }
            set { _Insurance_amount = value; }

        }

        public string Others_Specify_remraks
        {
            get { return _Others_Specify_remraks; }
            set { _Others_Specify_remraks = value; }

        }

        public string Other_Specify_2_Remarks
        {
            get { return _Other_Specify_2_Remarks; }
            set { _Other_Specify_2_Remarks = value; }

        }

        public string Premium_Date
        {
            get { return _Premium_Date; }
            set { _Premium_Date = value; }

        }


        public string Pay_Mode
        {
            get { return _Pay_Mode; }
            set { _Pay_Mode = value; }

        }



        public string Policy_Holder
        {
            get { return _Policy_Holder; }
            set { _Policy_Holder = value; }

        }


        



        public string pageno24b
        {
            get { return _pageno24b; }
            set { _pageno24b = value; }

        }
        public string pageno80clic
        {
            get { return _pageno80clic; }
            set { _pageno80clic = value; }

        }
        public string pagenohomeloanrepayment
        {
            get { return _pagenohomeloanrepayment; }
            set { _pagenohomeloanrepayment = value; }

        }

        public string pagenonsc
        {
            get { return _pagenonsc; }
            set { _pagenonsc = value; }

        }


        public string pagenoeless
        {
            get { return _pagenoeless; }
            set { _pagenoeless = value; }

        }
        public string pagenofd
        {
            get { return _pagenofd; }
            set { _pagenofd = value; }

        }
        public string pagenoppf
        {
            get { return _pagenoppf; }
            set { _pagenoppf = value; }

        }
        public string pagenosukanya
        {
            get { return _pagenosukanya; }
            set { _pagenosukanya = value; }

        }



        public string pagenotuitionfee
        {
            get { return _pagenotuitionfee; }
            set { _pagenotuitionfee = value; }

        }

        public string pagenostampduty
        {
            get { return _pagenostampduty; }
            set { _pagenostampduty = value; }

        }






        public string pageno80cother
        {
            get { return _pagenoother; }
            set { _pagenoother = value; }

        }

        public string pageno80d
        {
            get { return _pageno80d; }
            set { _pageno80d = value; }

        }

        public string pageno80e
        {
            get { return _pageno80e; }
            set { _pageno80e = value; }

        }
        public string pageno80ccdnps
        {
            get { return _pageno80ccdnps; }
            set { _pageno80ccdnps = value; }

        }

        public string pageno80ccdaps
        {
            get { return _pageno80ccdaps; }
            set { _pageno80ccdaps = value; }

        }

        public string pageno80u
        {
            get { return _pageno80u; }
            set { _pageno80u = value; }

        }

        public string pageno1013a
        {
            get { return _pageno1013a; }
            set { _pageno1013a = value; }

        }

        public string pagenootherspecify
        {
            get { return _pagenootherspecify; }
            set { _pagenootherspecify = value; }

        }



        public string pagenototal
        {
            get { return _pagenototal; }
            set { _pagenototal = value; }

        }



        public string FyYear
        {
            get { return _FyYear; }
            set { _FyYear = value; }

        }




        public string lta_travellfrom
        {
            get { return _lta_travellfrom; }
            set { _lta_travellfrom = value; }

        }
        public string lta_travellto
        {
            get { return _lta_travellto; }
            set { _lta_travellto = value; }

        }
        public string lta_amount
        {
            get { return _lta_amount; }
            set { _lta_amount = value; }

        }
        public string lta_travelleddate
        {
            get { return _lta_travelleddate; }
            set { _lta_travelleddate = value; }

        }
        public string lta_travellmode
        {
            get { return _lta_travellmode; }
            set { _lta_travellmode = value; }

        }

        public string lta_docrequire
        {
            get { return _lta_docrequire; }
            set { _lta_docrequire = value; }

        }

        public string lta_blockyear
        {
            get { return _lta_blockyear; }
            set { _lta_blockyear = value; }

        }

        public string lta_availed
        {
            get { return _lta_availed; }
            set { _lta_availed = value; }

        }




        public string jrnyno
        {
            get { return _jrnyno; }
            set { _jrnyno = value; }

        }


        public string key1
        {
            get { return _key1; }
            set { _key1 = value; }

        }
        public string key2
        {
            get { return _key2; }
            set { _key2 = value; }

        }
        public string filenamevalue
        {
            get { return _filenamevalue; }
            set { _filenamevalue = value; }

        }




        public string ltaname
        {
            get { return _ltaname; }
            set { _ltaname = value; }

        }


        public string ltarelation
        {
            get { return _ltarelation; }
            set { _ltarelation = value; }

        }

        public string ltadependent
        {
            get { return _ltadependent; }
            set { _ltadependent = value; }

        }

        public string ltadobp
        {
            get { return _ltadobp; }
            set { _ltadobp = value; }

        }


        public string ltapersonarno
        {
            get { return _ltapersonarno; }
            set { _ltapersonarno = value; }

        }






        #endregion


     
        private string _Email, _DOJ, _DOW, _DOB, _Bgroup, _MaritalStatus, _SpouseName;
        private string _HighQual, _HighUni, _HighPassYear;
        private string _CurAdd1, _CurAdd2, _CurAdd3, _CurCity, _CurDist, _CurState, _CurPIN;
        private string _PermAdd1, _PermAdd2, _PermAdd3, _PermCity, _PermDist, _PermState, _PermPIN;
        private string _FDSal, _FDName, _FDGender, _FDDOB, _FDAge, _FDMobile, _FDOccupation, _FDRalation, _FDDepend, _IP;

        private string _R1, _R2, _R3, _R4, _R5, _R6, _R7, _R8, _R9, _R10;

        private string _groupheadempid, _point, _qid, _apprslid, _username, _sysname, _adminid, _entrymode;
       

        

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string DOJ
        {
            get { return _DOJ; }
            set { _DOJ = value; }
        }

        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        public string DOW
        {
            get { return _DOW; }
            set { _DOW = value; }
        }




        public string Bgroup
        {
            get { return _Bgroup; }
            set { _Bgroup = value; }
        }

        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }
        public string SpouseName
        {
            get { return _SpouseName; }
            set { _SpouseName = value; }
        }
        public string HighQual
        {
            get { return _HighQual; }
            set { _HighQual = value; }
        }
        public string HighUni
        {
            get { return _HighUni; }
            set { _HighUni = value; }
        }
        public string HighPassYear
        {
            get { return _HighPassYear; }
            set { _HighPassYear = value; }
        }




        public string CurAdd1
        {
            get { return _CurAdd1; }
            set { _CurAdd1 = value; }
        }
        public string CurAdd2
        {
            get { return _CurAdd2; }
            set { _CurAdd2 = value; }
        }
        public string CurAdd3
        {
            get { return _CurAdd3; }
            set { _CurAdd3 = value; }
        }
        public string CurCity
        {
            get { return _CurCity; }
            set { _CurCity = value; }
        }
        public string CurDist
        {
            get { return _CurDist; }
            set { _CurDist = value; }
        }
        public string CurState
        {
            get { return _CurState; }
            set { _CurState = value; }
        }
        public string CurPIN
        {
            get { return _CurPIN; }
            set { _CurPIN = value; }
        }



        public string PermAdd1
        {
            get { return _PermAdd1; }
            set { _PermAdd1 = value; }
        }
        public string PermAdd2
        {
            get { return _PermAdd2; }
            set { _PermAdd2 = value; }
        }
        public string PermAdd3
        {
            get { return _PermAdd3; }
            set { _PermAdd3 = value; }
        }
        public string PermCity
        {
            get { return _PermCity; }
            set { _PermCity = value; }
        }
        public string PermDist
        {
            get { return _PermDist; }
            set { _PermDist = value; }
        }
        public string PermState
        {
            get { return _PermState; }
            set { _PermState = value; }
        }
        public string PermPIN
        {
            get { return _PermPIN; }
            set { _PermPIN = value; }
        }



        public string FDSal
        {
            get { return _FDSal; }
            set { _FDSal = value; }
        }

        public string FDName
        {
            get { return _FDName; }
            set { _FDName = value; }
        }

        public string FDGender
        {
            get { return _FDGender; }
            set { _FDGender = value; }
        }


        public string FDDOB
        {
            get { return _FDDOB; }
            set { _FDDOB = value; }
        }
        public string FDAge
        {
            get { return _FDAge; }
            set { _FDAge = value; }
        }

        public string FDMobile
        {
            get { return _FDMobile; }
            set { _FDMobile = value; }
        }




        public string FDOccupation
        {
            get { return _FDOccupation; }
            set { _FDOccupation = value; }
        }

        public string FDRalation
        {
            get { return _FDRalation; }
            set { _FDRalation = value; }
        }
        public string FDDepend
        {
            get { return _FDDepend; }
            set { _FDDepend = value; }
        }

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public string R1
        {
            get { return _R1; }
            set { _R1 = value; }
        }

        public string R2
        {
            get { return _R2; }
            set { _R2 = value; }
        }

        public string R3
        {
            get { return _R3; }
            set { _R3 = value; }
        }

        public string R4
        {
            get { return _R4; }
            set { _R4 = value; }
        }

        public string R5
        {
            get { return _R5; }
            set { _R5 = value; }
        }

        public string R6
        {
            get { return _R6; }
            set { _R6 = value; }
        }

        public string R7
        {
            get { return _R7; }
            set { _R7 = value; }
        }

        public string R8
        {
            get { return _R8; }
            set { _R8 = value; }
        }

        public string R9
        {
            get { return _R9; }
            set { _R9 = value; }
        }

        public string R10
        {
            get { return _R10; }
            set { _R10 = value; }
        }


        public string groupheadempid
        {
            get { return _groupheadempid; }
            set { _groupheadempid = value; }
        }

        public string point
        {
            get { return _point; }
            set { _point = value; }
        }


        public string qid
        {
            get { return _qid; }
            set { _qid = value; }
        }

        public string apprslid
        {
            get { return _apprslid; }
            set { _apprslid = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string sysname
        {
            get { return _sysname; }
            set { _sysname = value; }
        }

        public string adminid
        {
            get { return _adminid; }
            set { _adminid = value; }
        }

        public string entrymode
        {
            get { return _entrymode; }
            set { _entrymode = value; }
        }

    }
}
