using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class DDAALL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //  static string DatabaseConnectionString = @"Server=sql8020.site4now.net; Database=db_aa8601_ex; User Id=db_aa8601_ex_admin; Password=Akastarlord1._; ";
        //  static string DatabaseConnectionStringLAW = @"Server=sql5112.site4now.net; Database=db_aa8601_lawdb; User Id=db_aa8601_lawdb_admin; Password=Akastarlord1._; ";


        //   static string DatabaseConnectionString = @"Server=sql5113.site4now.net; Database=db_aa8601_testdb; User Id=db_aa8601_testdb_admin; Password=Akastarlord1._; ";
        //   static string DatabaseConnectionStringLAW = @"Server=sql5112.site4now.net; Database=db_aa8601_lawdb; User Id=db_aa8601_lawdb_admin; Password=Akastarlord1._; ";


        // static string DatabaseConnectionString = @"Server=192.168.0.117\HEADSERVER;Database=ExpensesDB; User Id=exp; Password=123;  ";
        //static string DatabaseConnectionStringLAW = @"Server=192.168.0.117\HEADSERVER;Database=LawDB; User Id=exp; Password=123;  ";




        static string DatabaseConnectionString = @"Server=DELTA\SQLEXPRESS;  Database=SAAS; Trusted_Connection  = True;";
       
        
        static string DatabaseConnectionStringLAW = @"Server=DELTA\SQLEXPRESS;  Database=LawDB;      Trusted_Connection  = True;";

        //            static string DatabaseConnectionString = @"Server=DESKTOP-DE1EPPS;  Database=ExpensesDB;  User Id=exp; Password=123;";
        //              static string DatabaseConnectionStringLAW = @"Server=DESKTOP-DE1EPPS;  Database=LawDB;       User Id=exp; Password=123;";



        // static string DatabaseConnectionString = @"Server=192.168.0.107\HEADSERVER;Database=ExpensesDB; User Id=exp; Password=123;  ";
        //static string DatabaseConnectionStringLAW = @"Server=192.168.0.107\HEADSERVER;Database=LawDB; User Id=exp; Password=123;  ";




        // static string DatabaseConnectionString = @"Server=DESKTOP-MMJ38GC\HEADSERVER;Database=ExpensesDB; User Id=exp; Password=123;  ";
        // static string DatabaseConnectionStringLAW = @"Server=DESKTOP-MMJ38GC\HEADSERVER;Database=LawDB; User Id=exp; Password=123;  ";






       // static string DatabaseConnectionString__OUT = @"Server=sql8020.site4now.net; Database=db_aa8601_ex; User Id=db_aa8601_ex_admin; Password=Akastarlord1._; ";


        /// <summary>
        /// ////////////////////////////static string DatabaseConnectionString = @"Server=192.168.0.100;Database=ExpensesDB; User Id=exp; Password=123;  ";
        /// </summary>
        /// 

        /// ////////////////////////////static string DatabaseConnectionString = @"Server=192.168.0.100;Database=ExpensesDB; User Id=exp; Password=123;  ";

        //static string DatabaseConnectionString = @"Server=GAMMA;Database=ExpensesDB;Trusted_Connection = True; ";



        // static string DatabaseConnectionString = @"Server=SQL8010.site4now.net;Database=db_aa8601_furnituremasterdb; User Id=db_aa8601_furnituremasterdb_admin; Password=Akastarlord1._; ";



        public static DataTable ExecuteSelectCommand(SqlCommand command)
        {
            command.Connection.Open();
            DataTable table;
            SqlDataAdapter ad = new SqlDataAdapter(command);
            table = new DataTable();
            ad.Fill(table);
            command.Connection.Close();
            return table;
        }
        public static SqlDataAdapter ExecuteSelectCommandAD(SqlCommand command)
        {
            command.Connection.Open();
            DataTable table;
            SqlDataAdapter ad = new SqlDataAdapter(command);
            table = new DataTable();
            ad.Fill(table);
            command.Connection.Close();
            return ad;
        }

        public static IDataReader ExecuteReader(SqlCommand command)
        {
            command.Connection.Open();
            DbDataReader reader = command.ExecuteReader();
            return reader;
        }
        public static bool ExecuteCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
                return true;
            }
            catch
            {
                return false;


            }


        }
        public static int ExecuteScalar(SqlCommand command)
        {

            command.Connection.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return count;

        }
/*

        public static SqlCommand CreateCommand___OUT()
        {
            try
            {

                SqlConnection conn = new SqlConnection(DatabaseConnectionString__OUT);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                conn.Close();
                return comm;
            }
            catch
            {
                return null;


            }
        }*/
        public static SqlCommand CreateCommandLAW()
        {
            try
            {

                SqlConnection conn = new SqlConnection(DatabaseConnectionStringLAW);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                conn.Close();
                return comm;
            }
            catch
            {
                return null;


            }
        }
        public static SqlCommand CreateCommand()
        {
            try
            {

                SqlConnection conn = new SqlConnection(DatabaseConnectionString);
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.StoredProcedure;
                conn.Close();
                return comm;
            }
            catch
            {
                return null;


            }
        }









        public static SqlConnection CreatConn()
        {



            SqlConnection ConStr = null;
            try
            {
                ConStr = new SqlConnection(DatabaseConnectionString);

                ConStr.Open();


            }
            catch
            {
                ErrorMsg();
                ConStr = null;
            }

            return ConStr;
        }
        public static void ErrorMsg()
        {
            // MessageBox.Show("Hello, world!", "My App");


        }

    }
}