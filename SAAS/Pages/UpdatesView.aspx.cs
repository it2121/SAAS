using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class UpdatesView : System.Web.UI.Page
    {
        public static int MainRecordID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                DataTable dt = BBAALL.GetAllSubRecordsOfMainRecord(MainRecordID);

                DataGridUsers.DataSource = dt;
                DataGridUsers.DataBind();


         





            }

        }
        protected void Return(object sender, EventArgs e)
        {

            Response.Redirect("EMainPageView.aspx");



        }

        protected void GoToNewItem(object sender, EventArgs e)
        {

           /* //  MatBuyEditor.ProjectID = ProjectID;
            UpdatesEditor.MainRecordID = MainRecordID;
            UpdatesEditor.ID = 0;

            Response.Redirect("UpdatesEditor.aspx");*/

        }
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.
            // DataGridUsers.EditIndex = e.NewEditIndex;
            //  showstuff();

/*            Label id = DataGridUsers.Rows[e.NewEditIndex].FindControl("lbl_ID") as Label;


            UpdatesEditor.ID = Convert.ToInt32(id.Text);
            UpdatesEditor.MainRecordID = MainRecordID;


            Response.Redirect("UpdatesEditor.aspx");
*/

        }

        protected void MyGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

    }
}