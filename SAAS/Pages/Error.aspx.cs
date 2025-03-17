using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class Error : System.Web.UI.Page
    {
        string FilePath;
        string BackUpFilePath;
        string DevBackUpFilePath;
        public static bool FromADNP = false;    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FilePath = Server.MapPath("..\\Data\\Data.txt");
                BackUpFilePath = Server.MapPath("..\\Data\\BackUps.txt");
                DevBackUpFilePath = Server.MapPath("..\\Data\\DevBackUp.txt");

                RBBtn.Visible = FromADNP;
            }
            else
            {
                FilePath = Server.MapPath("..\\Data\\Data.txt");
                BackUpFilePath = Server.MapPath("..\\Data\\BackUps.txt");
                DevBackUpFilePath = Server.MapPath("..\\Data\\DevBackUp.txt");
          
            }
        }
        protected void RollBack(object sender, EventArgs e)
        {


            string[] Lines = File.ReadAllLines(FilePath);
            string[] LinesFromBackUp = File.ReadAllLines(BackUpFilePath);
            List<string> NewLinesFromBackUp = new List<string>();


           






            int counter = 0;


            if (LinesFromBackUp.Length > 1) { 

            File.WriteAllText(FilePath, String.Empty);

            foreach (string line in LinesFromBackUp)
            {
                if (line.Length > 0)
                {

                    counter++;

                    if (line.Equals("}"))
                    {
                       
                       

                        break;
                    }
                    if (!line.Equals("{"))
                    { 
                    File.AppendAllText(FilePath, line + "\n");
                     }


                }

            }




            int secondCounter = 0;
            File.WriteAllText(BackUpFilePath, String.Empty);

            foreach (string line in LinesFromBackUp)
            {
                if (line.Length > 0)
                {

                    if (secondCounter >= counter)
                    File.AppendAllText(BackUpFilePath, line + "\n");

                    secondCounter++;

                }

            }


            Response.Redirect("ADNP.aspx");

            }else
            {


                 Response.Write("<script>alert('Unable to Roll Data Back any further, Please contact support');</script>");

            }


        }
    }
}