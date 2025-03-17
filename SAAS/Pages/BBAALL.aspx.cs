using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class BBAALL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static DataTable GetList_Finished()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetList_Finished";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }     
        
        public static DataTable GetList()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetList";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }     
        
        
        
        public static DataTable GetAllFinance()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetAllFinance";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }    
        public static DataTable GetAllMainRecord()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetAllMainRecord";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }
         public static DataTable GetAllSubRecordsOfMainRecord(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetAllSubRecordsOfMainRecord";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }  
        public static DataTable GetFinanceByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetFinanceByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        } public static DataTable GetSubRecordByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetSubRecordByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }

        public static DataTable UploadFile(int ID, byte[] UploadedFile,string FileType,string FileName)
        {




            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "UploadFIle";



            cm.Parameters.AddWithValue("@UploadedFile", UploadedFile);
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@FileType", FileType);
            cm.Parameters.AddWithValue("@FileName", FileName);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }





        public static DataTable GetMainListByDocType(string DocType)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetMainListByDocType";

            cm.Parameters.AddWithValue("@DocType", DocType);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }
        

        public static DataTable GetMainList()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetMainList";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }


          public static DataTable GetAllADNP()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetAllADNP";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }
        
        
        
        public static DataTable GetVersionsListWithFile(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetVersionsListWithFile";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }    
          public static DataTable GetVersionsList(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetVersionsList";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }    
        
        
        
        
        public static DataTable GetVersionByID(int ID)
        {



            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetVersionByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }     
        
        public static DataTable GetADNPByID(int ID)
        {



            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetADNPByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }  



            public static DataTable DeleteFromVersions(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "DeleteFromVersions";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }  
            public static DataTable DeleteSubRecordByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "DeleteSubRecordByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }  




        public static DataTable GetAllNumbers()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetAllNumbers";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }
        public static string GetLastDocNumber( string docType)
        {

            int max = 0;
            foreach (DataRow row in GetAllNumbers().Rows)
            {
                if (row["DocType"].ToString().Equals(docType)) { 
                if (max < Convert.ToInt32(row["Number"].ToString()))
                {

                    max = Convert.ToInt32(row["Number"].ToString());

                }
                }

            }


            max++;
            if (max < 10)
            {
                return "00" + max;
            }
            else if (max < 100)
            {
                return "0" + max;


            }
            else
            {
                return max + "";


            }

        }
       
        public static DataTable GetMainRecordByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetMainRecordByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }
       
     
        public static bool DeleteFromFinance(int ID)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DeleteFromFinance";


            cm.Parameters.AddWithValue("@ID", ID);
    



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }   public static bool SetFinanceAproved(int ID)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "SetFinanceAproved";


            cm.Parameters.AddWithValue("@ID", ID);
    



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }

        public static bool UpdateMainRecord(string ProjectName,
         string Dep, int ID, string Ord)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateMainRecord";


            cm.Parameters.AddWithValue("@ProjectName", ProjectName);
            cm.Parameters.AddWithValue("@Dep", Dep);
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@Ord", Ord);




            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }

        public static bool UpdateFinance(string PaidTo,
           float Amount, string PaidDate, string Ord , int ID)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateFinance";


            cm.Parameters.AddWithValue("@PaidTo", PaidTo);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@PaidDate", PaidDate);
            cm.Parameters.AddWithValue("@Ord", Ord);
            cm.Parameters.AddWithValue("@ID", ID);
    



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }    public static bool InsertIntoFinance(string PaidTo,
           float Amount, string PaidDate,string Ord)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertIntoFinance";


            cm.Parameters.AddWithValue("@PaidTo", PaidTo);
            cm.Parameters.AddWithValue("@Amount", Amount);
            cm.Parameters.AddWithValue("@PaidDate", PaidDate);
            cm.Parameters.AddWithValue("@Approved", "0");
            cm.Parameters.AddWithValue("@Ord", Ord);
    
    



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }  
        
        
        
        public static bool UpdateSubRecord(int MainRecordID, string TheUpdate, string Notes,int ID ,string UpdateDate ,string Ord,string Color)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateSubRecord";
            cm.Parameters.AddWithValue("@MainRecordID", MainRecordID);
            cm.Parameters.AddWithValue("@TheUpdate", TheUpdate);
            cm.Parameters.AddWithValue("@Notes", Notes);
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@UpdateDate", UpdateDate);
            cm.Parameters.AddWithValue("@Ord", Ord);
            cm.Parameters.AddWithValue("@Color", Color);
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
                 
        public static bool InsertIntoADNP(string Prefex, string DocType, string Number, string Year,string TheDate,string Dep)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertIntoADNP";
            cm.Parameters.AddWithValue("@Prefex", Prefex);
            cm.Parameters.AddWithValue("@DocType", DocType);
            cm.Parameters.AddWithValue("@Number", Number);
            cm.Parameters.AddWithValue("@Year", Year);
            cm.Parameters.AddWithValue("@TheDate", TheDate);
            cm.Parameters.AddWithValue("@Dep", Dep);
        
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
                public static bool UpdateVersions(int ID, string Remarks, string TheDate)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateVersions";
          
            cm.Parameters.AddWithValue("@ID", ID);
            cm.Parameters.AddWithValue("@YeaRemarksr", Remarks);
            cm.Parameters.AddWithValue("@TheDate", TheDate);
        
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
           
                public static bool InsertIntoVersions(int MainRecordID,string TheDate)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertIntoVersions";
          
            cm.Parameters.AddWithValue("@MainRecordID", MainRecordID);
            cm.Parameters.AddWithValue("@TheDate", TheDate);
        
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
          
                      
        public static bool UpdateRemarksAndDate(int  ID, string Remarks, string TheDate)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateRemarksAndDate";
            cm.Parameters.AddWithValue("@ID", ID);

            cm.Parameters.AddWithValue("@Remarks", Remarks);
            cm.Parameters.AddWithValue("@TheDate", TheDate);
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
                  public static bool DeleteFromADNP(int  ID)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DeleteFromADNP";
            cm.Parameters.AddWithValue("@ID", ID);

   
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
          
        
             
                 
        public static bool InsertIntoSubRecord(int MainRecordID, string TheUpdate, string Notes,string UpdateDate,string Ord,string Color)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertIntoSubRecord";
            cm.Parameters.AddWithValue("@MainRecordID", MainRecordID);
            cm.Parameters.AddWithValue("@TheUpdate", TheUpdate);
            cm.Parameters.AddWithValue("@Notes", Notes);
            cm.Parameters.AddWithValue("@UpdateDate", UpdateDate);
            cm.Parameters.AddWithValue("@Ord", Ord);
            cm.Parameters.AddWithValue("@Color", Color);
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
          
        
     
        
        public static bool SetFinished(int ID)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "SetFinished";
            cm.Parameters.AddWithValue("@ID", ID);
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
        
        
        
           
        public static bool DeleteMainRecord(int ID)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "DeleteMainRecord";
            cm.Parameters.AddWithValue("@ID", ID);
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
        
        
        
        
        
        public static bool InsertIntoMainRecord(
            string ProjectName,
           string Dep,string Ord)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertIntoMainRecord";


            cm.Parameters.AddWithValue("@ProjectName", ProjectName);
            cm.Parameters.AddWithValue("@Dep", Dep);
            cm.Parameters.AddWithValue("@Ord", Ord);
    



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }  
    }
}