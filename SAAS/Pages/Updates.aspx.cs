﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class Updates : System.Web.UI.Page
    {
        public static int MainRecordID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                AddnewBtn.Visible = false;

                DataTable dt = BBAALL.GetAllSubRecordsOfMainRecord(MainRecordID);

                DataGridUsers.DataSource = dt;
                DataGridUsers.DataBind();


                if (BBAALL.GetMainRecordByID(MainRecordID).Rows[0]["Finished"].ToString().Equals("0"))
                    AddnewBtn.Visible = true;






            }

        }
        protected void Return(object sender, EventArgs e)
        {

            Response.Redirect("EMainPage.aspx");



        }

        protected void GoToNewItem(object sender, EventArgs e)
        {

            //  MatBuyEditor.ProjectID = ProjectID;
            UpdatesEditor.MainRecordID = MainRecordID;
            UpdatesEditor.ID = 0;

            Response.Redirect("UpdatesEditor.aspx");

        }
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.
            // DataGridUsers.EditIndex = e.NewEditIndex;
            //  showstuff();

            Label id = DataGridUsers.Rows[e.NewEditIndex].FindControl("lbl_ID") as Label;


            UpdatesEditor.ID = Convert.ToInt32(id.Text);
            UpdatesEditor.MainRecordID = MainRecordID;


            Response.Redirect("UpdatesEditor.aspx");


        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    //Label Finished = (e.Row.FindControl("lbl_Quansgt") as Label);
                    Label ColorLbl = (e.Row.FindControl("lbl_Color") as Label);

                  //  bool FinishedBool = Finished.Text.Equals("1");


                    e.Row.BackColor = Color.FromName(ColorLbl.Text);


                    /*    if (FinishedBool)
                        {
                            e.Row.BackColor = Color.FromName("#e6ffe3");


                        }
                        else
                        {
                            e.Row.BackColor = Color.FromName("#ffe3e3");





                        }
    */

                }
            }
            catch (Exception ex)
            {
            }




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
     

    }
}