using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SAAS.Pages
{
    public partial class ADNP : System.Web.UI.Page
    {
        string FilePath;
        DataTable Gdt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FilePath = Server.MapPath("..\\Data\\Data.txt");
                Gdt = GetList();
                DataGridUsers.DataSource = Gdt;
                DataGridUsers.DataBind();

            }
            else
            {
                FilePath = Server.MapPath("..\\Data\\Data.txt");
                Gdt = GetList();
                /*   DataGridUsers.DataSource = Gdt;
                   DataGridUsers.DataBind();*/

            }
        }

        protected void SetDocTypeAndMoveOn(object sender, EventArgs e)
        {
            Session["DocType"] = ((Button)sender).ToolTip;


            //   Response.Write("<script>alert('"+((Button)sender).ToolTip+"');</script>");

            //Dep.DocType = ((Button)sender).ToolTip;






            /*     foreach (string line in File.ReadAllLines(FilePath))
          {

            //  Response.Write("<script>alert('" + line + "');</script>");

          }*/




            string FileContent = Session["DocType"].ToString() + "-" + "HSE" + "-" + GetLastDocNumber() + "-" + DateTime.Now.Year.ToString() + "-" + "V" + "1" + "#" + "\n";

            File.AppendAllText(FilePath, FileContent);





            // 












            //  Response.Redirect("Dep.aspx");


            refresh();


        }
        public void reBindData()
        {

            DataGridUsers.DataSource = GetList();
            DataGridUsers.DataBind();
            //  Response.Redirect("Home.aspx");
        }
        public void refresh()
        {

            /*  DataGridUsers.DataSource = GetList();
              DataGridUsers.DataBind();*/
            Response.Redirect("ADNP.aspx");
        }

        public void ShowMessage(string str)
        {

            Response.Write("<script>alert('" + str + "');</script>");
        }
        public DataTable GetList()
        {
            DataTable dt = new DataTable();
            string[] Lines = File.ReadAllLines(FilePath);
            dt.Columns.Add("Index", typeof(System.String));
            dt.Columns.Add("FileName", typeof(System.String));
            dt.Columns.Add("Remarks", typeof(System.String));
            int counter = 1;

            foreach (string line in Lines)
            {
                if (line.Length > 0)
                {
                    DataRow row = dt.NewRow();


                    row["Index"] = counter + "";
                    row["FileName"] = line.Substring(0, line.IndexOf("#")); ;
                    row["Remarks"] = line.Substring(line.IndexOf("#") + 1);

                    dt.Rows.Add(row);

                    counter++;
                }

            }







            return dt;
        }

        public void GetDep()
        {




        }

        public string RemarksByIndex(int index)


        {

            int counter = 0;

            string[] Lines = File.ReadAllLines(FilePath);

            foreach (string line in Lines)
            {
                if (counter == index)
                {

                    return line.Substring(line.IndexOf("#"));


                }

                counter++;
            }







            return "No Remarks yet";


        }

        public int GetLastDocNumber()
        {
            int MaxNum = 0;
            string[] Lines = File.ReadAllLines(FilePath);
            string str = "";
            foreach (string line in Lines)
            {
                if (line.Length > 0)
                {
                    str = line;

                    str = str.Substring(str.IndexOf("-") + 1);
                    str = str.Substring(str.IndexOf("-") + 1);
                    str = str.Substring(0, str.LastIndexOf("-"));
                    str = str.Substring(0, str.LastIndexOf("-"));

                    // Response.Write("<script>alert('" + str + "');</script>");

                    if (MaxNum <= Convert.ToInt32(str))
                        MaxNum = Convert.ToInt32(str);
                }
            }


            return MaxNum + 1;

        }


        //public string GetDocVersion(string NewName)
        //{
        //    int virsion = 1;

        //    string[] Lines = File.ReadAllLines(FilePath);
        //    string str = "";
        //    foreach (string line in Lines)
        //    {


        //        str = line;

        //        str = str.Substring(str.IndexOf("-") + 1);
        //        str = str.Substring(str.IndexOf("-") + 1);
        //        str = str.Substring(0, str.LastIndexOf("-"));
        //        str = str.Substring(0, str.LastIndexOf("-"));




        //    }




        //    return virsion + "";








        //}

        public void EditRemarks(int index, string newRemarks)
        {



            string[] Lines = File.ReadAllLines(FilePath);
            string[] temoLines = Lines;

            int counter = 0;

            foreach (string line in temoLines)
            {
                if (line.Length > 0)
                {

                    if (counter == index - 1)
                    {

                        Lines[counter] = line.Substring(0, line.IndexOf("#")) + "#" + newRemarks;

                        //  row["FileName"] = line.Substring(0, line.IndexOf("#")); ;
                        //   row["Remarks"] = line.Substring(line.IndexOf("#") + 1);



                    }
                }
                counter++;
            }

            File.WriteAllText(FilePath, String.Empty);

            foreach (string line in Lines)
            {
                if (line.Length > 0)
                {


                    File.AppendAllText(FilePath, line + "\n");



                }

            }




        }
        public void DeleteLine(int index)
        {



            string[] Lines = File.ReadAllLines(FilePath);
            string[] temoLines = Lines;

            int counter = 0;


            File.WriteAllText(FilePath, String.Empty);

            foreach (string line in Lines)
            {

                if (counter != index - 1)
                {
                    if (line.Length > 0)
                    {


                        File.AppendAllText(FilePath, line + "\n");



                    }
                }
                counter++;
            }




        }
        public void CreateNewVirsion(int index)
        {

            string[] Lines = File.ReadAllLines(FilePath);
            string currentVersion = "";
            string str = "1";
            int counter = 0;

            foreach (string line in Lines)
            {
                if (line.Length > 0)
                {

                    if (counter == index - 1)
                    {

                        // theLine = line.Substring(0, line.IndexOf("")) + "#";

                        //  row["FileName"] = line.Substring(0, line.IndexOf("#")); ;
                        //   row["Remarks"] = line.Substring(line.IndexOf("#") + 1);

                        currentVersion = line;
                        currentVersion = currentVersion.Substring(currentVersion.IndexOf("V") + 1);
                        currentVersion = currentVersion.Substring(0, currentVersion.LastIndexOf("#"));

                        currentVersion = (Convert.ToInt32(currentVersion) + 1) + "";


                        str = line.Substring(0, line.LastIndexOf("V")) + "V" + currentVersion + "#";

                        File.AppendAllText(FilePath, str + "\n");
                    }
                }
                counter++;
            }



        }
        protected void MyGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {//GoToPay
            string x = e.CommandName;//returns "Select" for both asp:CommandField columns

            if (x.Equals("CreateNewVirsion"))
            {

                CreateNewVirsion(Convert.ToInt32(e.CommandArgument.ToString()));


                //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");



                refresh();

            }



            if (x.Equals("DeleteLine"))
            {

                DeleteLine(Convert.ToInt32(e.CommandArgument.ToString()));


                //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");




                refresh();
            }









        }
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {


            DataGridUsers.EditIndex = e.NewEditIndex;

            //GridView1.SetEditRow(e.NewEditIndex);
            reBindData();

        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update
            Label index = DataGridUsers.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox city = DataGridUsers.Rows[e.RowIndex].FindControl("txt_City") as TextBox;



            EditRemarks(Convert.ToInt32(index.Text), city.Text);


            // ShowMessage(city.Text + " - " + index.Text);




            DataGridUsers.EditIndex = -1;
            //Call ShowData method for displaying updated data
            reBindData();



        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {

            DataGridUsers.EditIndex = -1;
            reBindData();
        }


    }
}