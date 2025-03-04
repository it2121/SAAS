using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class FinanceEditor : System.Web.UI.Page
    {
        public static int ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ID != 0)
                {

                    DataTable MatBuyTbl = BBAALL.GetFinanceByID(ID);


                    DelBtn.Visible = true;



                    foreach (DataRow dt in MatBuyTbl.Rows)
                    {




                        PaidTo.Text = dt["PaidTo"].ToString();
                        Amount.Text = dt["Amount"].ToString();
                        PaidDate.Text = dt["PaidDate"].ToString();
                        Ord.Text = dt["Ord"].ToString();


                       



                    }
                    DelBtn.Visible = true;
                    CreateBtn.Text = "حفظ التعديلات";





                }
                else
                {
                    PaidTo.Text = "";
                    Amount.Text = "0";
                    PaidDate.Text = "";
                    PaidDate.Text = DateTime.Now.ToString("MM/dd/yyyy");


                    DataTable dt = BBAALL.GetAllFinance();
                    int max = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (max < Convert.ToInt32(row["Ord"].ToString()))
                            max = Convert.ToInt32(row["Ord"].ToString());

                    }


                    Ord.Text = (max + 1) + "";

                }

            }
        }
        protected void Return(object sender, EventArgs e)
        {


            Response.Redirect("Finance.aspx");



        }

        protected void CreateItem(object sender, EventArgs e)
        {
            if (ID == 0)
            {


                // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ORNumber.Text + Date.Text + Value.Text + checkedd + Note.Text + "');", true);



                BBAALL.InsertIntoFinance(PaidTo.Text,Convert.ToInt32(Amount.Text),PaidDate.Text,Ord.Text);




                Response.Redirect("Finance.aspx");

            }
            else
            {


                BBAALL.UpdateFinance(PaidTo.Text, Convert.ToInt32(Amount.Text), PaidDate.Text, Ord.Text,ID);




                Response.Redirect("Finance.aspx");
            }


        }

        protected void DelProv(object sender, EventArgs e)
        {

            BBAALL.DeleteFromFinance(ID);
            ID = 0;
            DelBtn.Visible = false;

            CreateBtn.Text = "اضافة قيد شراء جديد";




            Response.Redirect("Finance.aspx");



        }
    }
}