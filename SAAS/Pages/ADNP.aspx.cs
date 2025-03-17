using iTextSharp.text.pdf.parser;
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
        string BackUpFilePath;
        string DevBackUpFilePath;
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
                BackUpFilePath = Server.MapPath("..\\Data\\BackUps.txt");
                DevBackUpFilePath = Server.MapPath("..\\Data\\DevBackUp.txt");
                setInnerEditIndex();
                setView(View);


                SAAS.Pages.Error.FromADNP = true;

            }
            else
            {
                FilePath = Server.MapPath("..\\Data\\Data.txt");
                BackUpFilePath = Server.MapPath("..\\Data\\BackUps.txt");
                DevBackUpFilePath = Server.MapPath("..\\Data\\DevBackUp.txt");
                //  Gdt = GetList();
                /*   DataGridUsers.DataSource = Gdt;
                   DataGridUsers.DataBind();*/
                /*        if(View==3)
                        reBindData();*/
                //   setInnerEditIndex();
                SAAS.Pages.Error.FromADNP = true;
            }
        }

        void setInnerEditIndex()
        {


            foreach (GridViewRow row in DataGridUsers.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow && Session["ID"].ToString().Equals((row.FindControl("lbl_ID") as Label).Text))


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
/*
                if (AddedNew)
                {
                    int theLineNumber = Gdt.Rows.Count - 1;

                    string[] Lines = File.ReadAllLines(FilePath);
                    int counter = 0;
                    foreach (DataRow row in Gdt.Rows)
                    {

                        if (Lines[Lines.Length - 1].Substring(0, Lines[Lines.Length - 1].ToString().LastIndexOf("-")).Equals(row["FileName"].ToString()))
                        {

                            theLineNumber = counter;
                            break;
                        }
                        counter++;
                    }



                    DataGridUsers.EditIndex = theLineNumber;
                    OutterEditIndex = theLineNumber;
                    AddedNew = false;
                    //GridView1.SetEditRow(e.NewEditIndex);
                    reBindData();
                }*/

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

                                PageProjectNameLblV.Text = Session["ID"].ToString();*/

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

                    if (row.RowType == DataControlRowType.DataRow && Session["ID"].ToString().Equals((row.FindControl("lbl_ID") as Label).Text))


                    {
                        if (InnerEditIndex != -1) { (row.FindControl("DataGridV") as GridView).EditIndex = InnerEditIndex; }

                        (row.FindControl("DataGridV") as GridView).DataSource = GetVirsionsList();
                        (row.FindControl("DataGridV") as GridView).DataBind();
                        //   



                    }




                }


                PageProjectNameLblV.Text = Session["ID"].ToString();
            }

            View = view;
        }



        public void ShowDockVersions(string name)
        {


            Session["ID"] = name;



            VGP.Visible = true;

            Gdt = GetVirsionsList();

            ButtonsPanel.Visible = false;
            GridPanel.Visible = false;
            returnBtn.Visible = true;


            (DataGridUsers.FindControl("DataGridV") as GridView).DataSource = Gdt;
            (DataGridUsers.FindControl("DataGridV") as GridView).DataBind();

            PageProjectNameLblV.Text = Session["ID"].ToString();



            View = 3;

            //  setView(3);



        }
        protected void Return(object sender, EventArgs e)


        {


            setView(1);




        }
        protected void AddNew(object sender, EventArgs e)
        {




            if (Session["DocType"] != null)

            {
                // string FileContent = "FU-" + Session["DocType"].ToString() + "-" + "HSE" + "-" + GetLastDocNumber() + "-" + ArabiaTime.Year.ToString() + "-" + "V" + "1" + "#" + "^" + ArabiaTime.ToString("dd/MM/yyyy") + "\n";

                // File.AppendAllText(FilePath, FileContent);

                BBAALL.InsertIntoADNP("FU", Session["DocType"].ToString(), BBAALL.GetLastDocNumber(Session["DocType"].ToString()), ArabiaTime.Year.ToString(), ArabiaTime.ToString("dd/MM/yyyy"), "HSE");


                // AddedNew = true;


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


                    if (Session["ID"] != null)
                    {

                        string name = (row.FindControl("lbl_ID") as Label).Text;
                        string nameFromSession = Session["ID"].ToString();
                        Session["ID"] = nameFromSession;
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



/*        public void BackUp()
        {

            string[] Lines = File.ReadAllLines(FilePath);
            string[] LinesFromBackUp = File.ReadAllLines(BackUpFilePath);


            File.WriteAllText(BackUpFilePath, String.Empty);
            File.AppendAllText(BackUpFilePath, "{" + "\n");

            foreach (string line in Lines)
            {
                if (line.Length > 0)
                {


                    File.AppendAllText(BackUpFilePath, line + "\n");



                }

            }
            int madeCount = 0;
            File.AppendAllText(BackUpFilePath, "}" + "\n");
            foreach (string line in LinesFromBackUp)
            {
                if (line.Length > 0)
                {


                    File.AppendAllText(BackUpFilePath, line + "\n");
                    if (line.Equals("}"))
                    {

                        if (madeCount > 4)
                        {
                            break;
                        }
                        else { madeCount++; }


                    }


                }

            }



        }
*/
        public void refresh()
        {


            Response.Redirect("ADNP.aspx");
        }

        public void ShowMessage(string str)
        {

            Response.Write("<script>alert('" + str + "');</script>");
        }
        public DataTable GetVirsionsList()
        {



            if (Session["ID"] != null)

            {
                return BBAALL.GetVersionsList(Convert.ToInt32(Session["ID"].ToString()));
            }

            else { return null; }
        }


    

    public DataTable GetList()
    {

        if (Session["DocType"] != null)
        {
            return BBAALL.GetMainListByDocType(Session["DocType"].ToString());





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

  

    public void EditDate(string name, string Date)
    {



        Date = Date.Replace("-", " ");
        Date = Date.Replace("#", " ");
        Date = Date.Replace("^", " ");
        Date = Date.Replace("{", " ");
        Date = Date.Replace("}", " ");
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
        newRemarks = newRemarks.Replace("}", " ");
        newRemarks = newRemarks.Replace("{", " ");
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
    public void DeleteLineInner(string ID)
    {

            if (BBAALL.GetVersionsList(


                      Convert.ToInt32(BBAALL.GetVersionByID(Convert.ToInt32(ID)).Rows[0]["MainRecordID"].ToString())




             ).Rows.Count > 1)
            {


                BBAALL.DeleteFromVersions(

                Convert.ToInt32(ID)





                    );
            }
            else
            {

                ShowMessage("You can't delete the last version, try removing the main record.");

            }


        }
    public void DeleteLine(string ID)
    {


            BBAALL.DeleteFromADNP(Convert.ToInt32(ID));


    }
    public void RemoveLastVirstion(string ID)
    {
            if (BBAALL.GetVersionsList(
                
                
                Convert.ToInt32( ID)
                
                
                
                
                
                ).Rows.Count > 1) {

                DataTable dt = BBAALL.GetVersionsList(Convert.ToInt32(ID));

            BBAALL.DeleteFromVersions(

             Convert.ToInt32(  dt.Rows[dt.Rows.Count - 1]["ID1"].ToString())
                
                
                
                
                
                );
            }
            else
            {

                ShowMessage("You can't delete the last version, try removing the main record.");

            }
        }


    public void CreateNewVirsion(string ID)
    {
            BBAALL.InsertIntoVersions(Convert.ToInt32(ID), ArabiaTime.ToString("dd/MM/yyyy"));



    }    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (InnerEditIndex == -1)
            {
                string name = DataGridUsers.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("DataGridV") as GridView;
                Session["ID"] = name;



                gvOrders.DataSource = GetVirsionsList();
                gvOrders.DataBind();

            }
            else
            {
                if (Session["ID"] != null)
                {
                    string name = DataGridUsers.DataKeys[e.Row.RowIndex].Value.ToString();
                    string nameFromSession = Session["ID"].ToString();
                    if (name.Equals(nameFromSession))

                    {


                        GridView gvOrders = e.Row.FindControl("DataGridV") as GridView;
                        Session["ID"] = name;




                        gvOrders.DataSource = GetVirsionsList();
                        gvOrders.DataBind();


                        (e.Row.FindControl("pnlOrders") as Panel).Style.Clear();
                        (e.Row.FindControl("pnlOrders") as Panel).Style.Add("display", "block");


                    }
                   

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


      

        if (x.Equals("Editt"))
        {
            int counter = 0;
            int OutterCounter = 0;
            foreach (GridViewRow row in DataGridUsers.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow && BBAALL.GetVersionByID(Convert.ToInt32(e.CommandArgument)).Rows[0]["MainRecordID"].ToString().Equals((row.FindControl("lbl_ID") as Label).Text))

                //  if (row.RowType == DataControlRowType.DataRow && e.NewEditIndex == row.RowIndex)
                {




                    //   
                    foreach (GridViewRow innerRow in (row.FindControl("DataGridV") as GridView).Rows)
                    {
                        if (innerRow.RowType == DataControlRowType.DataRow && (innerRow.FindControl("lbl_IDInner") as Label).Text.Equals(e.CommandArgument.ToString()))
                        {

                            Session["ID"] = BBAALL.GetVersionByID(Convert.ToInt32(((innerRow.FindControl("lbl_IDInner") as Label).Text))).Rows[0]["MainRecordID"].ToString()
    ;

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

    
            View = 3;

            refresh();
        
        }

  

    }
 
    protected void GridView1_RowUpdatingV(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {








        //Finding the controls from Gridview for the row which is going to update
        Label index = (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).Rows[InnerEditIndex].FindControl("lbl_IDInner") as Label;
        TextBox city = (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).Rows[InnerEditIndex].FindControl("txt_CityInner") as TextBox;
        TextBox Date = (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).Rows[InnerEditIndex].FindControl("txt_DateInner") as TextBox;


            BBAALL.UpdateRemarksAndDate(Convert.ToInt32(index.Text) , city.Text, Date.Text);


   

  


        (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).EditIndex = -1;

        InnerEditIndex = -1;
        OutterEditIndex = -1;
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












        (DataGridUsers.Rows[OutterEditIndex].FindControl("DataGridV") as GridView).EditIndex = -1;



        InnerEditIndex = -1;
        OutterEditIndex = -1;
        View = 2;
        refresh();
      
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
        Label v = DataGridUsers.Rows[e.RowIndex].FindControl("lbl_Quansgt12") as Label;
        TextBox city = DataGridUsers.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
        TextBox DateTb = DataGridUsers.Rows[e.RowIndex].FindControl("txt_Date") as TextBox;




            DataTable dt = BBAALL.GetVersionsList(Convert.ToInt32(index.Text));


            BBAALL.UpdateRemarksAndDate(
                
                
                Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["ID1"].ToString())



                , city.Text,DateTb.Text);



          
        DataGridUsers.EditIndex = -1;
       reBindData();



    }
    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {

        DataGridUsers.EditIndex = -1;
        reBindData();
    }




    protected void DownloadItem(object sender, EventArgs e)
    {


        byte[] bytes;
        string fileName;

        DataTable DT = BBAALL.GetADNPByID(Convert.ToInt32(((Button)sender).ToolTip));


        if (DT.Rows[0]["UploadedFile"].ToString().Length > 0)
        {

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "application/pdf";

            string name = DT.Rows[0]["Prefex"] + "-" + DT.Rows[0]["DocType"] + "-" + DT.Rows[0]["Number"] + "-" + DT.Rows[0]["Year"] + "-" + DT.Rows[0]["Version"];
            HttpContext.Current.Response.BufferOutput = true;
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + " - PDF File.pdf");

            HttpContext.Current.Response.BinaryWrite((byte[])DT.Rows[0]["UploadedFile"]);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();



        }
        else
        {

            ClientScript.RegisterStartupScript(this.GetType(), "Alert ! ", "alert('PDF is not Uploaded yet.');", true);
        }
    }
    public static byte[] Data = null;
    public bool FileSelected = false;
    public static string filename;
    public static int ID;
   

}
}