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
        public static int InnerEditIndex = -1;
        public static int OutterEditIndex = -1;
        public static int View = 1;
        public static bool AddedNew = false;
        DateTime ArabiaTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
   DateTime.UtcNow, "Arab Standard Time");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FilePath = Server.MapPath("..\\Data\\Data.txt");
                setInnerEditIndex();
                setView(View);

            }
            else
            {
                FilePath = Server.MapPath("..\\Data\\Data.txt");
                //  Gdt = GetList();
                /*   DataGridUsers.DataSource = Gdt;
                   DataGridUsers.DataBind();*/
                /*        if(View==3)
                        reBindData();*/
                //   setInnerEditIndex();
            }
        }

        void setInnerEditIndex()
        {


            foreach (GridViewRow row in DataGridUsers.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow && Session["NameOfFile"].ToString().Equals((row.FindControl("lbl_Quansgt") as Label).Text))


                {
                    if (InnerEditIndex != -1) { (row.FindControl("DataGridV") as GridView).EditIndex = InnerEditIndex; }

                    (row.FindControl("DataGridV") as GridView).DataSource = GetVirsionsList();
                    (row.FindControl("DataGridV") as GridView).DataBind();
                    //   



                }




            }

        }

        public void setView(int view)
        {

            if (view == 1)
            {
                AddNewBtn.Visible = false;

                ButtonsPanel.Visible = true;
                GridPanel.Visible = false;
                VGP.Visible = false;
                returnBtn.Visible = false;
                InnerEditIndex = -1;
                OutterEditIndex = -1;
            }
            else if (view == 2)
            {
                AddNewBtn.Visible = true;

                ButtonsPanel.Visible = false;
                GridPanel.Visible = true;
                VGP.Visible = false;
                returnBtn.Visible = true;

                Gdt = GetList();
                DataGridUsers.DataSource = Gdt;
                DataGridUsers.DataBind();
                if (Session["DocFullTypeName"] != null)
                {
                    PageProjectNameLbl.Text = Session["DocFullTypeName"].ToString();
                }
                else
                {

                    PageProjectNameLbl.Text = "Document Control";
                }
                InnerEditIndex = -1;
                OutterEditIndex = -1;

                if (AddedNew)
                {


                    DataGridUsers.EditIndex = Gdt.Rows.Count - 1;
                    OutterEditIndex = Gdt.Rows.Count - 1;
                    AddedNew = false;
                    //GridView1.SetEditRow(e.NewEditIndex);
                    reBindData();
                }

            }

            else if (view == 3)
            {
                /*
                                ButtonsPanel.Visible = false;
                                GridPanel.Visible = false;
                                VGP.Visible = true;
                                returnBtn.Visible = true;



                                Gdt = GetVirsionsList();

                                (DataGridUsers.FindControl("DataGridV") as GridView).DataSource = Gdt;
                                (DataGridUsers.FindControl("DataGridV") as GridView).DataBind();

                                PageProjectNameLblV.Text = Session["NameOfFile"].ToString();*/

                AddNewBtn.Visible = true;

                ButtonsPanel.Visible = false;
                GridPanel.Visible = true;
                VGP.Visible = false;
                returnBtn.Visible = true;

                Gdt = GetList();
                DataGridUsers.DataSource = Gdt;
                DataGridUsers.DataBind();

                PageProjectNameLbl.Text = Session["DocFullTypeName"].ToString();


                /*   ButtonsPanel.Visible = false;
                   GridPanel.Visible = false;
                   VGP.Visible = true;
                   returnBtn.Visible = true;*/



                Gdt = GetVirsionsList();



                foreach (GridViewRow row in DataGridUsers.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow && Session["NameOfFile"].ToString().Equals((row.FindControl("lbl_Quansgt") as Label).Text))


                    {
                        if (InnerEditIndex != -1) { (row.FindControl("DataGridV") as GridView).EditIndex = InnerEditIndex; }

                        (row.FindControl("DataGridV") as GridView).DataSource = GetVirsionsList();
                        (row.FindControl("DataGridV") as GridView).DataBind();
                        //   



                    }




                }


                PageProjectNameLblV.Text = Session["NameOfFile"].ToString();
            }

            View = view;
        }



        public void ShowDockVersions(string name)
        {


            Session["NameOfFile"] = name;



            VGP.Visible = true;

            Gdt = GetVirsionsList();

            ButtonsPanel.Visible = false;
            GridPanel.Visible = false;
            returnBtn.Visible = true;


            (DataGridUsers.FindControl("DataGridV") as GridView).DataSource = Gdt;
            (DataGridUsers.FindControl("DataGridV") as GridView).DataBind();

            PageProjectNameLblV.Text = Session["NameOfFile"].ToString();



            View = 3;

            //  setView(3);



        }
        protected void Return(object sender, EventArgs e)


        {


            setView(1);




        }
        protected void AddNew(object sender, EventArgs e)
        {




            if (Session["DocType"] !=null)

            { 
            string FileContent = "FU-" + Session["DocType"].ToString() + "-" + "HSE" + "-" + GetLastDocNumber() + "-" + ArabiaTime.Year.ToString() + "-" + "V" + "1" + "#" + "^" + ArabiaTime.ToString("dd/MM/yyyy") + "\n";

            File.AppendAllText(FilePath, FileContent);

            AddedNew = true;
            }
            refresh();
        }

        protected void SetDocTypeAndMoveOn(object sender, EventArgs e)
        {


        
                Session["DocType"] = ((Button)sender).ToolTip;
            Session["DocFullTypeName"] = ((Button)sender).Text;






            setView(2);




            refresh();


        }
        public void reBindData()
        {
            if (View == 2)
            {
                DataGridUsers.DataSource = GetList();
                DataGridUsers.DataBind();
            }
            else if (View == 3)
            {


                foreach (GridViewRow row in DataGridUsers.Rows)
                {


                    if(Session["NameOfFile"] != null) {

                    string name = (row.FindControl("lbl_Quansgt") as Label).Text;
                    string nameFromSession = Session["NameOfFile"].ToString().Substring(0, Session["NameOfFile"].ToString().LastIndexOf("-"));
                    Session["NameOfFile"] = nameFromSession;
                    if (row.RowType == DataControlRowType.DataRow && nameFromSession.Equals(name))


                    {

                        if (InnerEditIndex != -1) { (row.FindControl("DataGridV") as GridView).EditIndex = InnerEditIndex; }

                        (row.FindControl("DataGridV") as GridView).DataSource = GetVirsionsList();
                        (row.FindControl("DataGridV") as GridView).DataBind();
                        //   



                    }
                    }



                }
            }
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
        public DataTable GetVirsionsList()
        {



            string[] Lines = File.ReadAllLines(FilePath);
            if (Session["NameOfFile"] != null) { 

                string name = Session["NameOfFile"].ToString();

            DataTable dt = new DataTable();
            string[] MidLines = File.ReadAllLines(FilePath);
            dt.Columns.Add("Index", typeof(System.String));
            dt.Columns.Add("FileName", typeof(System.String));
            dt.Columns.Add("Remarks", typeof(System.String));
            dt.Columns.Add("Date", typeof(System.String));
            int counter = 1;




            foreach (string line in Lines)
            {
                if (line.Length > 0)
                {
                    string temp = line.Substring(0, line.LastIndexOf("-"));

                    if (name.Equals(line.Substring(0, line.LastIndexOf("-"))))
                    {








                        DataRow row = dt.NewRow();


                        row["Index"] = counter + "";
                        row["FileName"] = line.Substring(0, line.IndexOf("#")); ;
                        row["Remarks"] = line.Substring(line.IndexOf("#") + 1);

                        row["Remarks"] = row["Remarks"].ToString().Substring(0, row["Remarks"].ToString().LastIndexOf("^"));

                        row["Date"] = line.Substring(line.IndexOf("^") + 1);

                        dt.Rows.Add(row);

                        counter++;






                    }
                }

            }

            return dt;
            }else { return null;}
        }
        public DataTable GetList()
        {

            if (Session["DocType"] != null)
            {
                Session["DocType"].ToString();

                DataTable dt = new DataTable();
                string[] Lines = File.ReadAllLines(FilePath);
                string[] MidLines = File.ReadAllLines(FilePath);
                dt.Columns.Add("Index", typeof(System.String));
                dt.Columns.Add("FileName", typeof(System.String));
                dt.Columns.Add("Remarks", typeof(System.String));
                dt.Columns.Add("VReached", typeof(System.String));
                dt.Columns.Add("Date", typeof(System.String));
                int counter = 1;


                for (int i = 0; i < MidLines.Length; i++)
                {
                    if (MidLines[i].Length > 0)
                    {
                        MidLines[i] = MidLines[i].Substring(0, MidLines[i].IndexOf("V"));
                    }
                }
                string[] DistinctLines = MidLines.Distinct().ToArray();


                for (int i = 0; i < DistinctLines.Length; i++)
                {
                    if (DistinctLines[i].Length > 0)
                    {

                        string FileName = "";
                        string Remarks = "";
                        string VReached = "";
                        string Date = "";


                        string str = DistinctLines[i].Substring(0, DistinctLines[i].LastIndexOf("-"));
                        str = str.Substring(0, str.LastIndexOf("-"));
                        str = str.Substring(0, str.LastIndexOf("-"));
                        str = str.Substring(0, str.LastIndexOf("-"));
                        str = str.Substring(str.IndexOf("-") + 1);
                        //  ShowMessage(str);

                        // str = str.Substring(0, str.IndexOf("-"));
                        if (Session["DocType"].ToString().Equals(str))
                        {
                            foreach (string line in Lines)
                            {


                                if (DistinctLines[i].Equals(line.Substring(0, line.IndexOf("V"))))
                                {

                                    // FileName = line.Substring(0, line.IndexOf("#"));
                                    FileName = line.Substring(0, line.LastIndexOf("-"));
                                    Remarks = line.Substring(line.IndexOf("#") + 1);
                                    Remarks = Remarks.Substring(0, Remarks.LastIndexOf("^"));
                                    Date = line.Substring(line.IndexOf("^") + 1);


                                    VReached = line.Substring(line.IndexOf("V"));
                                    VReached = VReached.Substring(0, VReached.LastIndexOf("#"));

                                }

                            }


                            DataRow row = dt.NewRow();


                            row["Index"] = counter + "";
                            row["FileName"] = FileName; ;
                            row["Remarks"] = Remarks;
                            row["VReached"] = VReached;
                            row["Date"] = Date;

                            dt.Rows.Add(row);

                            counter++;
                        }
                    }
                }



                /*
                            foreach (string line in Lines)
                            {
                                if (line.Length > 0)
                                {

                                    if (Session["DocType"].ToString().Equals(line.Substring(0, line.IndexOf("-"))))
                                    {








                                        DataRow row = dt.NewRow();


                                        row["Index"] = counter + "";
                                        row["FileName"] = line.Substring(0, line.IndexOf("#")); ;
                                        row["Remarks"] = line.Substring(line.IndexOf("#") + 1);

                                        dt.Rows.Add(row);

                                        counter++;






                                    }
                                }

                            }

                */





                return dt;
            }
            else { return null; }
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

        public string GetLastDocNumber()
        {



            int MaxNum = 0;
            string[] Lines = File.ReadAllLines(FilePath);
            string str = "";
            foreach (string line in Lines)
            {
                if (line.Length > 0)
                {
                    string ssttrr = line;
                    ssttrr = ssttrr.Substring(ssttrr.IndexOf("-") + 1);
                    ssttrr = ssttrr.Substring(0, ssttrr.LastIndexOf("-"));
                    ssttrr = ssttrr.Substring(0, ssttrr.LastIndexOf("-"));
                    ssttrr = ssttrr.Substring(0, ssttrr.LastIndexOf("-"));
                    ssttrr = ssttrr.Substring(0, ssttrr.LastIndexOf("-"));
                    // ShowMessage(ssttrr);
                    if (ssttrr.Equals(Session["DocType"].ToString()))
                    {
                        str = line;

                        str = str.Substring(str.IndexOf("-") + 1);
                        str = str.Substring(str.IndexOf("-") + 1);
                        str = str.Substring(str.IndexOf("-") + 1);
                        str = str.Substring(0, str.LastIndexOf("-"));
                        str = str.Substring(0, str.LastIndexOf("-"));

                        // Response.Write("<script>alert('" + str + "');</script>");

                        if (MaxNum <= Convert.ToInt32(str))
                            MaxNum = Convert.ToInt32(str);

                    }
                }
            }


            MaxNum++;
            if (MaxNum < 10)
            {
                return "00" + MaxNum;
            }
            else if (MaxNum < 100)
            {
                return "0" + MaxNum;


            }
            else
            {
                return MaxNum + "";


            }


            // return MaxNum + 1;

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

        public void EditDate(string name, string Date)
        {



            Date = Date.Replace("-", " ");
            Date = Date.Replace("#", " ");
            Date = Date.Replace("^", " ");
            Date = Date.Replace(System.Environment.NewLine, " ");
            string[] Lines = File.ReadAllLines(FilePath);
            string[] temoLines = Lines;
            string date = "";
            int counter = 0;

            foreach (string line in temoLines)
            {
                if (line.Length > 0)
                {

                    if (line.Substring(0, line.LastIndexOf("#")).Equals(name))
                    {



                        Lines[counter] = line.Substring(0, line.IndexOf("^")) + "^" + Date;

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
        public void EditRemarks(string name, string newRemarks)
        {


            newRemarks = newRemarks.Replace("-", " ");
            newRemarks = newRemarks.Replace("#", " ");
            newRemarks = newRemarks.Replace("^", " ");
            newRemarks = newRemarks.Replace(System.Environment.NewLine, " ");

            string[] Lines = File.ReadAllLines(FilePath);
            string[] temoLines = Lines;
            string date = "";
            int counter = 0;

            foreach (string line in temoLines)
            {
                if (line.Length > 0)
                {

                    if (line.Substring(0, line.LastIndexOf("#")).Equals(name))
                    {
                        date = line.Substring(line.IndexOf("^"));


                        Lines[counter] = line.Substring(0, line.IndexOf("#")) + "#" + newRemarks + date;

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
        public void DeleteLineInner(string name)
        {



            string[] Lines = File.ReadAllLines(FilePath);
            string[] temoLines = Lines;

            int counter = 0;


            File.WriteAllText(FilePath, String.Empty);


            foreach (string line in Lines)
            {

                if (!line.Substring(0, line.LastIndexOf("#")).Equals(name))
                {
                    if (line.Length > 0)
                    {


                        File.AppendAllText(FilePath, line + "\n");



                    }
                }
                counter++;
            }






        }
        public void DeleteLine(string name)
        {



            string[] Lines = File.ReadAllLines(FilePath);
            string[] temoLines = Lines;

            int counter = 0;


            File.WriteAllText(FilePath, String.Empty);

            foreach (string line in Lines)
            {

                if (!line.Substring(0, line.LastIndexOf("-")).Equals(name))
                {
                    if (line.Length > 0)
                    {


                        File.AppendAllText(FilePath, line + "\n");



                    }
                }
                counter++;
            }





        }
        public void RemoveLastVirstion(string name)
        {

            string[] Lines = File.ReadAllLines(FilePath);
            string currentVersion = "";
            string str = "1";
            int counter = 0;
            string midLine = "";
            string outterLine = "";
            foreach (string line in Lines)
            {
                midLine = line;
                if (line.Length > 0)
                {

                    if (line.Substring(0, line.LastIndexOf("-")).Equals(name.Substring(0, line.LastIndexOf("-"))))
                    {
                        outterLine = line;



                    }
                }
                counter++;
            }




            Lines = File.ReadAllLines(FilePath);
            string[] temoLines = Lines;

            counter = 0;


            File.WriteAllText(FilePath, String.Empty);

            foreach (string line in Lines)
            {

                if (!line.Equals(outterLine))
                {
                    if (line.Length > 0)
                    {


                        File.AppendAllText(FilePath, line + "\n");



                    }
                }
                counter++;
            }




        }


        public void CreateNewVirsion(string name)
        {

            string[] Lines = File.ReadAllLines(FilePath);
            string currentVersion = "";
            string str = "1";
            int counter = 0;
            string midLine = "";
            string outterLine = "";
            string date = "";
            foreach (string line in Lines)
            {
                midLine = line;
                if (line.Length > 0)
                {

                    if (line.Substring(0, line.LastIndexOf("-")).Equals(name))
                    {

                        // theLine = line.Substring(0, line.IndexOf("")) + "#";

                        //  row["FileName"] = line.Substring(0, line.IndexOf("#")); ;
                        //   row["Remarks"] = line.Substring(line.IndexOf("#") + 1);

                        currentVersion = midLine;
                        currentVersion = currentVersion.Substring(currentVersion.IndexOf("V") + 1);
                        currentVersion = currentVersion.Substring(0, currentVersion.LastIndexOf("#"));



                        outterLine = midLine;
                        //date = midLine.Substring(0, date.LastIndexOf("^"));

                    }
                }
                counter++;
            }

            currentVersion = (Convert.ToInt32(currentVersion) + 1) + "";


            str = outterLine.Substring(0, outterLine.LastIndexOf("V")) + "V" + currentVersion + "#" + "^" + ArabiaTime.ToString("dd/MM/yyyy");

            File.AppendAllText(FilePath, str + "\n");

        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (InnerEditIndex == -1)
                {
                    string name = DataGridUsers.DataKeys[e.Row.RowIndex].Value.ToString();
                    GridView gvOrders = e.Row.FindControl("DataGridV") as GridView;
                    Session["NameOfFile"] = name;



                    gvOrders.DataSource = GetVirsionsList();
                    gvOrders.DataBind();

                }
                else
                {
                    if (Session["NameOfFile"] != null) { 
                    string name = DataGridUsers.DataKeys[e.Row.RowIndex].Value.ToString();
                    string nameFromSession = Session["NameOfFile"].ToString().Substring(0, Session["NameOfFile"].ToString().LastIndexOf("-"));
                    if (name.Equals(nameFromSession))

                    {


                        GridView gvOrders = e.Row.FindControl("DataGridV") as GridView;
                        Session["NameOfFile"] = name;




                        gvOrders.DataSource = GetVirsionsList();
                        gvOrders.DataBind();


                        (e.Row.FindControl("pnlOrders") as Panel).Style.Clear();
                        (e.Row.FindControl("pnlOrders") as Panel).Style.Add("display", "block");

                        // ShowMessage(e.Row.RowIndex+"");
                        /*   foreach (GridViewRow row in DataGridUsers.Rows)
                           {
                               if (row.RowType == DataControlRowType.DataRow && nameFromSession.ToString().Equals((row.FindControl("lbl_Quansgt") as Label).Text))
                               {

                                  *//* if ((row.FindControl("btnNewV_Edit1M") as Button).Text.Equals("Show Version"))
                                   {*//*
                                       //(row.FindControl("pnlOrders") as Panel).Visible = true;
                                       (row.FindControl("pnlOrders") as Panel).Style.Add("display", "block");
                                   // (row.FindControl("btnNewV_Edit1M") as Button).Text = "Hide Version";
                                   // }
                                   *//*  else
                                     {
                                         (row.FindControl("pnlOrders") as Panel).Visible = false;
                                         (row.FindControl("btnNewV_Edit1M") as Button).Text = "Show Version";

                                     }*//*
                               }


                           }*/















                        //   ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "show()", true);

                        // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "show()", true);

                    }
                    /*  string name = DataGridUsers.DataKeys[e.Row.RowIndex].Value.ToString();
                                    GridView gvOrders = e.Row.FindControl("DataGridV") as GridView;
                                    Session["NameOfFile"] = name;



                                    gvOrders.DataSource = GetVirsionsList();
                                    gvOrders.DataBind();
                                        foreach (GridViewRow row in DataGridUsers.Rows)
                                        {
                                            string name = (row.FindControl("lbl_Quansgt") as Label).Text;
                                            string nameFromSession = Session["NameOfFile"].ToString().Substring(0, Session["NameOfFile"].ToString().LastIndexOf("-"));
                                            if (row.RowType == DataControlRowType.DataRow && name.Equals(nameFromSession))


                                            {
                                                if (InnerEditIndex != 0) { (row.FindControl("DataGridV") as GridView).EditIndex = InnerEditIndex; }

                                                (row.FindControl("DataGridV") as GridView).DataSource = GetVirsionsList();
                                                (row.FindControl("DataGridV") as GridView).DataBind();
                                                //   



                                            }
                    }



                                        }*/

                }
                }

            }
        }
        public bool Fired = false;
        protected void MyGridView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {//GoToPay
            string x = e.CommandName;//returns "Select" for both asp:CommandField columns
            /*      if (!Fired) { */
            if (x.Equals("CreateNewVirsion"))
            {

                CreateNewVirsion(e.CommandArgument.ToString());


                AddedNew = true;


                View = 2;

                //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");



                refresh();

            }
            if (x.Equals("RemoveLastVirstion"))
            {

                RemoveLastVirstion(e.CommandArgument.ToString());

                View = 2;

                //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");



                refresh();

            }
            if (x.Equals("Manage"))
            {


                foreach (GridViewRow row in DataGridUsers.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow && e.CommandArgument.ToString().Equals((row.FindControl("lbl_Quansgt") as Label).Text))
                    {

                        if ((row.FindControl("btnNewV_Edit1M") as Button).Text.Equals("Show Version"))
                        {
                            (row.FindControl("pnlOrders") as Panel).Visible = true;
                            (row.FindControl("btnNewV_Edit1M") as Button).Text = "Hide Version";
                        }
                        else
                        {
                            (row.FindControl("pnlOrders") as Panel).Visible = false;
                            (row.FindControl("btnNewV_Edit1M") as Button).Text = "Show Version";

                        }
                    }


                }



                //ShowDockVersions(e.CommandArgument.ToString());


                //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");



                //   refresh();

            }



            if (x.Equals("DeleteLine"))
            {

                DeleteLine(e.CommandArgument.ToString());


                //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");




                refresh();
            }



            if (x.Equals("DeleteLineV"))
            {

                DeleteLineInner(e.CommandArgument.ToString());


                //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");




                refresh();
            }


            /*
                            if (x.Equals("CopyFileName"))
                        {

                            CopyFileNameToCLipBoard(e.CommandArgument.ToString());


                            //Response.Write("<script>alert('" + Convert.ToInt32(e.CommandArgument.ToString()) + "');</script>");




                            refresh();
                        }

            */

            if (x.Equals("Editt"))
            {
                int counter = 0;
                int OutterCounter = 0;
                foreach (GridViewRow row in DataGridUsers.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow && e.CommandArgument.ToString().Substring(0, e.CommandArgument.ToString().LastIndexOf("-")).Equals((row.FindControl("lbl_Quansgt") as Label).Text))

                    //  if (row.RowType == DataControlRowType.DataRow && e.NewEditIndex == row.RowIndex)
                    {




                        //   
                        foreach (GridViewRow innerRow in (row.FindControl("DataGridV") as GridView).Rows)
                        {
                            if (innerRow.RowType == DataControlRowType.DataRow && (innerRow.FindControl("lbl_QuansgtInner") as Label).Text.Equals(e.CommandArgument.ToString()))
                            {
                                //   ShowMessage((innerRow.FindControl("lbl_QuansgtInner") as Label).Text + "!!!!" + counter);

                                Session["NameOfFile"] = (innerRow.FindControl("lbl_QuansgtInner") as Label).Text;
                                (row.FindControl("DataGridV") as GridView).EditIndex = counter;
                                //  (row.FindControl("DataGridV") as GridView).EditIndex = counter;

                                InnerEditIndex = counter;
                                OutterEditIndex = OutterCounter;

                            }

                            counter++;
                        }


                    }

                    OutterCounter++;

                }

                // (DataGridUsers.FindControl("DataGridV") as GridView).EditIndex = e.NewEditIndex;
                // DataGridV.EditIndex = e.NewEditIndex;

                //GridView1.SetEditRow(e.NewEditIndex);
                View = 3;

                refresh();
                // reBindData();
                // reBindData();
            }

            /*    Fired = true;

            }*/

        }
        /* protected void GridView1_RowEditingV(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
         {
             foreach (GridViewRow row in DataGridUsers.Rows)
             {

                 if (row.RowType == DataControlRowType.DataRow && (sender as Button).ToolTip.ToString().Equals((row.FindControl("lbl_Quansgt") as Label).Text))

                   //  if (row.RowType == DataControlRowType.DataRow && e.NewEditIndex == row.RowIndex)
                 {
                     (row.FindControl("DataGridV") as GridView).EditIndex = e.NewEditIndex;


                     //   
                     foreach (GridViewRow innerRow in (row.FindControl("DataGridV") as GridView).Rows)
                     {
                         if (innerRow.RowType == DataControlRowType.DataRow)
                         {
                             ShowMessage((innerRow.FindControl("lbl_Quansgt") as Label).Text);

                           //  Session["NameOfFile"] = (innerRow.FindControl("lbl_Quansgt") as Label).Text;

                         }
                     }


                 }


             }

             // (DataGridUsers.FindControl("DataGridV") as GridView).EditIndex = e.NewEditIndex;
             // DataGridV.EditIndex = e.NewEditIndex;

             //GridView1.SetEditRow(e.NewEditIndex);
             View = 3;
           //  reBindData();

         }*/
        protected void GridView1_RowUpdatingV(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {








            //Finding the controls from Gridview for the row which is going to update
            Label index = (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).Rows[InnerEditIndex].FindControl("lbl_QuansgtInner") as Label;
            TextBox city = (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).Rows[InnerEditIndex].FindControl("txt_CityInner") as TextBox;
            TextBox Date = (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).Rows[InnerEditIndex].FindControl("lbl_DateInner") as TextBox;



            EditRemarks(index.Text, city.Text);
            EditDate(index.Text, Date.Text);


            // ShowMessage(city.Text + " - " + index.Text);




            (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).EditIndex = -1;

            InnerEditIndex = -1;
            OutterEditIndex = -1;
            //Call ShowData method for displaying updated data
            View = 2;
            refresh();




            foreach (GridViewRow row in DataGridUsers.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    (DataGridUsers.FindControl("DataGridV") as GridView).EditIndex = -1;

                }
            }










        }
        protected void GridView1_RowCancelingEditV(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {





















            /*   foreach (GridViewRow row in DataGridUsers.Rows)
               {

                   if (row.RowType == DataControlRowType.DataRow)
                   { 
                       (DataGridUsers.FindControl("DataGridV") as GridView).EditIndex = -1;

               }
               } */
            (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).EditIndex = -1;



            InnerEditIndex = -1;
            OutterEditIndex = -1;
            View = 2;
            refresh();
            //  reBindData();
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



            Label index = DataGridUsers.Rows[e.RowIndex].FindControl("lbl_Quansgt") as Label;
            Label v = DataGridUsers.Rows[e.RowIndex].FindControl("lbl_Quansgt12") as Label;
            TextBox city = DataGridUsers.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
            TextBox DateTb = DataGridUsers.Rows[e.RowIndex].FindControl("txt_Date") as TextBox;



            EditRemarks(index.Text + "-" + v.Text, city.Text);
            EditDate(index.Text + "-" + v.Text, DateTb.Text);


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