using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AllenLibrary.Interface;
using System.Data;

namespace AllenLibrary.Classes
{
    #region Student Main Class Definition
    public class StudentMain : IStudent,
                            IFDetails,
                            IMDetails,
                            IADDDetails,
                            IAcadDetails,
                            IFeeDetails,
                            IConDetails,
                            IDepAmount,
                            IUniqueNumber,
                            ISchoolDetails,
                            IAuthSpecDetails, 
                            IICardDetail,
                            ITestCenter,
                            IDatabase,
                            IAttendance
    {

        public int Action { get; set; }
        public int TrackID { get; set; }
        public int UType { get; set; }
        public int AdminID { get; set; }
        public string isdeleted { get; set; }
        public int sort { get; set; }
        public string SCCity { get; set; }
        public string SCName { get; set; }
        public string Session { get; set; }
        public string CashAmt { get; set; }
        public string DDAmt { get; set; }
        public string ChkAmt { get; set; }
        public string IssueMode { get; set; }
        public string OrderID { get; set; }
        public string PrintCount { get; set; }        

        public string Msg { get; set; }
        public string MsgTitle { get; set; }
        public string ClassTitle { get; set; }
        public string ClassValue { get; set; }
        public string Status { get; set; }
        public string Msg1 { get; set; }
        public string MsgTitle1 { get; set; }
        public string CourseOld { get; set; }
        public string CourseNew { get; set; }

        public string AppName { get; set; }
        public string AppType { get; set; }
        public string AppNo { get; set; }
        public string AuthBy { get; set; }

        public string StudyCCodeOld { get; set; }

        public string UserType { get; set; }

        public string EmpCode { get; set; }
        public string PermittedLinks { get; set; }

        public int TCCodeNew { get; set; }

        public string LinkTitle { get; set; }
        public string LinkURL { get; set; }
        public string LinkRootDir { get; set; }
        public string LinkDetail { get; set; }

        public Int64 LinkOrder { get; set; }
        public Int64 LinkVerOrder { get; set; }

        public string XCGPA { get; set; }
        public string HNO { get; set; }
        public string Area { get; set; }
        public string StudyCCode1 { get; set; }

        public string Remarks { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }       
        
        public string ID { get; set; }
        public string Sno { get; set; }


        #region Student Properties
        public int StuAction { get; set; }
        public string UName { get; set; }
        public string UPassword { get; set; }
        public string UNewPassword { get; set; }
        public string Fno { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Medium { get; set; }
        public string BGroup { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Mobile3 { get; set; }
        public string Mobile1Old { get; set; }
        public string Mobile2Old { get; set; }
        public string Mobile3Old { get; set; }
        public string CountryCode1 { get; set; }
        public string CountryCode2 { get; set; }
        public string CountryCode3 { get; set; }
        public string Std { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string StdOld { get; set; }
        public string Phone1Old { get; set; }
        public string Phone2Old { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public string CourseName { get; set; }
        public string Course { get; set; }
        public string StudyCCode { get; set; }
        public string TCCode { get; set; }
        public string IsFee { get; set; }
        public string FDate { get; set; }
        public string AttNo { get; set; }
        public string InfoSource { get; set; }
        public string MCode { get; set; }
        public string Stream { get; set; }
        public string CourseType { get; set; }
        public string SubType { get; set; }

        public string TestDate { get; set; }


        public string Cat { get; set; }
        public string Part { get; set; }
        public string Board { get; set; }

        public string CName { get; set; }
        public Int64 BSID { get; set; }


        public string Phy { get; set; }
        public string Che { get; set; }
        public string Mat { get; set; }
        public string Bio { get; set; }
        public string Ma { get; set; }
        public string Total { get; set; }
        public string TotalMarks { get; set; }
        public string Per { get; set; }

        public string MMPhy { get; set; }
        public string MMChe { get; set; }
        public string MMMat { get; set; }
        public string MMBio { get; set; }
        public string MMMa { get; set; }

        public string TestID { get; set; }

        public string UserID { get; set; }
        public string CourseTitle { get; set; }


        #endregion

        #region Father Properties
        public int FAction { get; set; }
        public string FTitle { get; set; }
        public string FName { get; set; }
        public string FAge { get; set; }
        public string FDOB { get; set; }
        public string FBGroup { get; set; }
        public string FHeight { get; set; }
        public string FWeight { get; set; }
        public string FMobile1 { get; set; }
        public string FMobile2 { get; set; }
        public string FMobile3 { get; set; }
        public string FStd { get; set; }
        public string FPhone1 { get; set; }
        public string FPhone2 { get; set; }
        public string FEmail { get; set; }
        public string FAltEmail { get; set; }
        public string FOCCU { get; set; }


        #endregion

        #region Mother Properties
        public int MAction { get; set; }
        public string MTitle { get; set; }
        public string MName { get; set; }
        public string MAge { get; set; }
        public string MDOB { get; set; }
        public string MBGroup { get; set; }
        public string MHeight { get; set; }
        public string MWeight { get; set; }
        public string MMobile1 { get; set; }
        public string MMobile2 { get; set; }
        public string MMobile3 { get; set; }
        public string MStd { get; set; }
        public string MPhone1 { get; set; }
        public string MPhone2 { get; set; }
        public string MEmail { get; set; }
        public string MAltEmail { get; set; }
        public string MOCCU { get; set; }
        #endregion

        #region Address Properties

        public int ADDAction { get; set; }
        public string LAdd1 { get; set; }
        public string LAdd2 { get; set; }
        public string LAdd3 { get; set; }
        public string LCity { get; set; }
        public string LDistrict { get; set; }
        public string LState { get; set; }
        public string LCountry { get; set; }
        public string LPin { get; set; }
        public string PAdd1 { get; set; }
        public string PAdd2 { get; set; }
        public string PAdd3 { get; set; }
        public string PCity { get; set; }
        public string PDistrict { get; set; }
        public string PState { get; set; }
        public string PCountry { get; set; }
        public string PPin { get; set; }
        #endregion

        #region Academic Properties
        public int AcadAction { get; set; }
        public string IXPer { get; set; }
        public string IXYear { get; set; }
        public string XPer { get; set; }
        public string XYear { get; set; }
        public string XIIPer { get; set; }
        public string XIIYear { get; set; }

        public string DiplomaStream { get; set; }
        public string DiplomaPer { get; set; }
        public string DiplomaYear { get; set; }

        public string EducationQualification { get; set; }

        public string GraStream { get; set; }
        public string GraPer { get; set; }
        public string GraYear { get; set; }

        public string PGraStream { get; set; }
        public string PGraPer { get; set; }
        public string PGraYear { get; set; }

        public string CertifyStream { get; set; }
        public string CertifyPer { get; set; }
        public string CertifyYear { get; set; }

        public string AadharNo { get; set; }
        public string RollXIotXII { get; set; }
        public string RollTTex { get; set; }
        public string RollExAllen { get; set; }
        #endregion

        #region Fee Properties
        public int FeeAction { get; set; }
        public string Inst { get; set; }
        public string Fee { get; set; }
        public string CFee { get; set; }
        public string ST { get; set; }
        public string STPer { get; set; }
        public string Cess { get; set; }
        public string CessPer { get; set; }
        public string CaseType { get; set; }
        public string StartDate { get; set; }
        public string LastDate { get; set; }
        public string EndDate { get; set; }
        public string DepDate { get; set; }
        public string TotalSt { get; set; }
        public string Sid { get; set; }

        #endregion

        #region Concession Prorerties
        public Int64 ConAction { get; set; }
        public string CaseStatus { get; set; }
        public string Conc { get; set; }
        public string Scode { get; set; }
        public string SPer { get; set; }
        public string Amount { get; set; }
        public string EAllen { get; set; }
        public string ConcLess { get; set; }
        public string BalAmt { get; set; }
        public string Cases { get; set; }
        public string SchRemarks { get; set; }
        public string SchReason { get; set; }
        public int ConID { get; set; }
        public int SchID { get; set; }
        #endregion

        #region Deposite Amount Properties
        public int DepAmtAction { get; set; }
        public string PayMode { get; set; }
        public string OLNType { get; set; }
        public string OFFType { get; set; }
        public string TXNO { get; set; }
        public string BankRefNo { get; set; }
        public string BankID { get; set; }
        public string Product { get; set; }
        public string TXNDate { get; set; }
        public string AuthCode { get; set; }
        public string StatusMsg { get; set; }


        public string ErrorMsg { get; set; }
        public string HashValue { get; set; }
        public string PG_Type { get; set; }


        #endregion

        #region Unique Identification Number Properrties
        public int UniNumAction { get; set; }
        public string PanNO { get; set; }
        public string DLNO { get; set; }
        public string ANO { get; set; }
        public string VNO { get; set; }
        public string PNO { get; set; }
        #endregion

        #region School Properties
        public int SchoolAction { get; set; }
        public string SID { get; set; }
        public string SCHName { get; set; }
        public string SCHAdd1 { get; set; }
        public string SCHAdd2 { get; set; }
        public string SCHAdd3 { get; set; }
        public string SCHCity { get; set; }
        public string SCHDistrict { get; set; }
        public string SCHState { get; set; }
        public string SCHCountry { get; set; }
        public string SCHPin { get; set; }
        #endregion

        #region Auth. Sepcification Properties
        public Int64 AuthAction { get; set; }
        public string EntryDate { get; set; }
        public string UserName { get; set; }
        public string LIP { get; set; }
        public string RIP { get; set; }
        public string BroType { get; set; }
        public string EntryVia { get; set; }
        public string APPID { get; set; }
        public string ComputerName { get; set; }
        public string SystemName { get; set; }
        #endregion

        #region ICard Properties
        public int ICardAction { get; set; }
        public string Batch { get; set; }
        public string OldBatch { get; set; }
        public string Regno { get; set; }
        public string IColor { get; set; }
        public string OldRegno { get; set; }
        public string Photo { get; set; }
        public string PhotoDate { get; set; }
        #endregion

        #region DLP
        public string Ucode { get; set; }
        public string SMPrec { get; set; }
        public string CourierName { get; set; }
        public string CourierCode { get; set; }
        public string Quantity { get; set; }
        public string DispatchFrom { get; set; }
        public string DispatchTo { get; set; }
        public string DispatchDate { get; set; }
        public string DispatchBy { get; set; }
        public string ReturnDate { get; set; }
        public string SMPLogID { get; set; }
        public string Setno { get; set; }
        #endregion

        #region Bank
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BranchAddress { get; set; }
        public string IFSC { get; set; }
        #endregion


        #region Test Center
        public string TestCenter1 { get; set; }
        public string TestCenter2 { get; set; }
        public string TestCenter3 { get; set; }

        public string TestCity1 { get; set; }
        public string TestCity2 { get; set; }
        public string TestCity3 { get; set; }

        public string TestCenterAdd1 { get; set; }
        public string TestCenterAdd2 { get; set; }
        public string TestCenterAdd3 { get; set; }
        #endregion

        #region Database
        public DataSet ds1 { get; set; }
        public DataSet ds2 { get; set; }
        public DataSet ds3 { get; set; }
        public DataSet ds4 { get; set; }
        public DataSet ds5 { get; set; }

        public DataTable dt1 { get; set; }
        public DataTable dt2 { get; set; }
        public DataTable dt3 { get; set; }
        public DataTable dt4 { get; set; }
        public DataTable dt5 { get; set; }
        public DataTable dt6 { get; set; }
        public DataTable dt7 { get; set; }
        public DataTable dt8 { get; set; }
        public DataTable dt9 { get; set; }
        public DataTable dt10 { get; set; }
        #endregion

        #region Reserve Variable
        public string R1 { get; set; }
        public string R2 { get; set; }
        public string R3 { get; set; }
        public string R4 { get; set; }
        public string R5 { get; set; }
        public string R6 { get; set; }
        public string R7 { get; set; }
        public string R8 { get; set; }
        public string R9 { get; set; }
        public string R10 { get; set; }
        public string R11 { get; set; }
        public string R12 { get; set; }
        public string R13 { get; set; }
        public string R14 { get; set; }
        public string R15 { get; set; }
        public string R16 { get; set; }
        public string R17 { get; set; }
        public string R18 { get; set; }
        public string R19 { get; set; }
        public string R20 { get; set; }

        public string E1 { get; set; }
        public string E2 { get; set; }
        public string E3 { get; set; }
        public string E4 { get; set; }
        public string E5 { get; set; }
        public string E6 { get; set; }
        public string E7 { get; set; }
        public string E8 { get; set; }
        public string E9 { get; set; }
        public string E10 { get; set; }
        public string E11 { get; set; }
        public string E12 { get; set; }
        public string E13 { get; set; }
        public string E14 { get; set; }
        public string E15 { get; set; }        
        #endregion

        #region Alltendance
        public string OperationType { get; set; }
        public string days { get; set; }
        public string week { get; set; }
        public string daycount { get; set; }
        public string batchshift { get; set; }
        public string building { get; set; }
        #endregion

        #region Subject
        public string SubjectID { get; set; }
        public string SubjectName { get; set; }

        public string TopicID { get; set; }
        public string TopicName { get; set; }
        public string TopicFlag { get; set; }

        public string DoubtID { get; set; }
        public string DoubtName { get; set; }
        public string DoubtCategory { get; set; }

        public string ChapterID { get; set; }
        public string ChapterName { get; set; }

        public string FromTime { get; set; }
        public string ToTime { get; set; }

        public string GUID { get; set; }

        public string QuestionID { get; set; }
        public string Question { get; set; }

        public string DocID { get; set; }
        public string DocName { get; set; }

        public string EmpName { get; set; }
        public string EmpMobile { get; set; }
        public string EmpEmail { get; set; }
        public string EmpMedium { get; set; }

        public string Grade { get; set; }
        #endregion

        #region ExtraEdge
        public Dictionary<string, string> lead = new Dictionary<string, string>();
        public string leadjosn { get; set; }
        public string leadresponse { get; set; }
        public string leaderror { get; set; }

        public string AuthToken { get; set; }
        public string Source { get; set; }
        public string LeadName { get; set; }
        public string LeadSource { get; set; }
        public string FirstName { get; set; }
        public string Center { get; set; }
        public string Location { get; set; }
        public string Entity4 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
        public string LeadType { get; set; }
        public string BestTimeToCall { get; set; }
        public string ReasonCode { get; set; }
        public string LeadStatus { get; set; }
        public string SourceTo { get; set; }
        public string BatchApplied { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }


        #endregion

        #region Lead Source (LMS)
        public string Utm_Source { get; set; }
        public string Utm_Medium { get; set; }
        public string Utm_Campaign { get; set; }
        public string Utm_AdGroup { get; set; }
        public string Utm_Term { get; set; }
        public string PageID { get; set; }
        public string Frmtype { get; set; }
        public string Email_VCode { get; set; }
        public string Dt_MastKeyValue { get; set; }
        public string OperationFlag { get; set; }
        public string UID { get; set; }

        #endregion
    }
    #endregion
}
