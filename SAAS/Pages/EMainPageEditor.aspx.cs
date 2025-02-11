using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class EMainPageEditor : System.Web.UI.Page
    {
        public static int ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Finished.ReadOnly = true;
                if (ID != 0)
                {
                   
                    DataTable MatBuyTbl = BBAALL.GetMainRecordByID(ID);
             

                    DelBtn.Visible = true;



                    foreach (DataRow dt in MatBuyTbl.Rows)
                    {




                        ProjectName.Text = dt["ProjectName"].ToString();
                        Dep.Text = dt["Dep"].ToString();


                        Finished.Text = "غير مكتملة";

                        if (dt["Finished"].ToString().Equals("1")) {

                            Finished.Text = "مكتملة";

                        }
                   
                        

                    }
                    DelBtn.Visible = true;
                    CreateBtn.Text = "حفظ التعديلات";


                  


                }
                else
                {
                    ProjectName.Text ="";
                    Dep.Text = "";


                    Finished.Text = "غير مكتملة";
                }

            }
         

        }



        protected void Return(object sender, EventArgs e)
        {


            Response.Redirect("EMainPage.aspx");



        }

        protected void CreateItem(object sender, EventArgs e)
        {
            if (ID == 0)
            {


                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ORNumber.Text + Date.Text + Value.Text + checkedd + Note.Text + "');", true);



                BBAALL.InsertIntoMainRecord(ProjectName.Text, Dep.Text );




                Response.Redirect("EMainPage.aspx");

            }
            else
            {


                BBAALL.UpdateMainRecord(ProjectName.Text, Dep.Text,ID);




                Response.Redirect("EMainPage.aspx");
            }


        }

        protected void DelProv(object sender, EventArgs e)
        {

            BBAALL.DeleteMainRecord(ID);
            ID = 0;
            DelBtn.Visible = false;

            CreateBtn.Text = "اضافة قيد شراء جديد";


       

            Response.Redirect("EMainPage.aspx");



        }


    }
}