using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class UpdatesEditor : System.Web.UI.Page
    {
        public static int ID = 0;
        public static int MainRecordID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ID != 0)
                {

                    DataTable MatBuyTbl = BBAALL.GetSubRecordByID(ID);


                    DelBtn.Visible = true;



                    foreach (DataRow dt in MatBuyTbl.Rows)
                    {




                        TheUpdate.Text = dt["TheUpdate"].ToString();
                        Notes.Text = dt["Notes"].ToString();


                        UpdateDate.Text = dt["UpdateDate"].ToString(); 





                    }
                    DelBtn.Visible = true;
                    CreateBtn.Text = "حفظ التعديلات";





                }
                else
                {
                    TheUpdate.Text = "";
                    Notes.Text = "";


                    UpdateDate.Text = "";


                }

            }
        }
        protected void Return(object sender, EventArgs e)
        {

            Updates.MainRecordID = MainRecordID;
            Response.Redirect("Updates.aspx");



        }

        protected void CreateItem(object sender, EventArgs e)
        {
            if (ID == 0)
            {


                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ORNumber.Text + Date.Text + Value.Text + checkedd + Note.Text + "');", true);



                BBAALL.InsertIntoSubRecord(MainRecordID, TheUpdate.Text, Notes.Text, UpdateDate.Text);



                Updates.MainRecordID = MainRecordID;
                Response.Redirect("Updates.aspx");

            }
            else
            {


                BBAALL.UpdateSubRecord(MainRecordID, TheUpdate.Text, Notes.Text, ID, UpdateDate.Text);



                Updates.MainRecordID = MainRecordID;
                Response.Redirect("Updates.aspx");


            }
        }
        protected void DelProv(object sender, EventArgs e)
        {

            BBAALL.DeleteSubRecordByID(ID);
            ID = 0;
            DelBtn.Visible = false;

            CreateBtn.Text = "اضافة قيد شراء جديد";




            Updates.MainRecordID = MainRecordID;
            Response.Redirect("Updates.aspx");



        }

    }
}