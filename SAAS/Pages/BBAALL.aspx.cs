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

        public static DataTable GetList()
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetList";



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }      public static DataTable GetAllMainRecord()
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
        }  public static DataTable GetSubRecordByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetSubRecordByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }  public static DataTable DeleteSubRecordByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "DeleteSubRecordByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }  public static DataTable GetMainRecordByID(int ID)
        {


            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            cm.CommandText = "GetMainRecordByID";

            cm.Parameters.AddWithValue("@ID", ID);


            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteSelectCommand(cm);
        }
       
        public static bool UpdateMainRecord(string ProjectName,
           string Dep,int ID)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateMainRecord";


            cm.Parameters.AddWithValue("@ProjectName", ProjectName);
            cm.Parameters.AddWithValue("@Dep", Dep);
            cm.Parameters.AddWithValue("@ID", ID);
    



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }  
        
        
        
        public static bool UpdateSubRecord(int MainRecordID, string TheUpdate, string Notes,int ID )

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "UpdateSubRecord";
            cm.Parameters.AddWithValue("@MainRecordID", MainRecordID);
            cm.Parameters.AddWithValue("@TheUpdate", TheUpdate);
            cm.Parameters.AddWithValue("@Notes", Notes);
            cm.Parameters.AddWithValue("@ID", ID);
            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);


        }  
           
                 
        public static bool InsertIntoSubRecord(int MainRecordID, string TheUpdate, string Notes)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertIntoSubRecord";
            cm.Parameters.AddWithValue("@MainRecordID", MainRecordID);
            cm.Parameters.AddWithValue("@TheUpdate", TheUpdate);
            cm.Parameters.AddWithValue("@Notes", Notes);
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
        
        
        
        
        
        public static bool InsertIntoMainRecord(string ProjectName,
           string Dep)

        {
            SqlCommand cm;
            cm = DDAALL.CreateCommand();
            if (cm == null) { return false; }
            cm.CommandText = "InsertIntoMainRecord";


            cm.Parameters.AddWithValue("@ProjectName", ProjectName);
            cm.Parameters.AddWithValue("@Dep", Dep);
    



            SqlConnection.ClearAllPools();
            return DDAALL.ExecuteCommand(cm);



        }  
    }
}