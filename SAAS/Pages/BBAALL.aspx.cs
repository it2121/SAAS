﻿using System;
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
        
        
        public static DataTable DeleteSubRecordByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "DeleteSubRecordByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
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