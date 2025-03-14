using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAAS.Pages
{
    public partial class EMainPage : System.Web.UI.Page
    {
        public static int ProjectID = 0;
        public static bool print = false;
        public static int printID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
          //  Main.openPage = "Expences";

            if (!IsPostBack)
            {

                DataTable dt = BBAALL.GetList();


                DataGridUsers.DataSource = dt;
                DataGridUsers.DataBind();







            }

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label Finished = (e.Row.FindControl("lbl_Quansgt") as Label);
                    Label ColorLbl = (e.Row.FindControl("lbl_Color") as Label);

                    bool FinishedBool = Finished.Text.Equals("1");


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
        {//GoToPay
            string x = e.CommandName;//returns "Select" for both asp:CommandField columns

            if (x.Equals("GoToUpdate"))
            {

                Updates.MainRecordID = Convert.ToInt32(e.CommandArgument.ToString());





                Response.Redirect("Updates.aspx");

            }
         

        

        }
        protected void PaidCheck(object sender, EventArgs e)
        {
            // NewProv.ProvID = Convert.ToInt32(((Button)sender).ToolTip);
            //  NewProv.AllMasters = BBAALL.GetAllMasters();
            //  Req.FRID = Convert.ToInt32(((Button)sender).ToolTip);

            //  Req.fromEdit = true;
            // Req.flag = flag;
            int IIDD = Convert.ToInt32(((Button)sender).ToolTip);



            BBAALL.SetFinished(IIDD);

            Response.Redirect("EMainPage.aspx");

        }
        protected void GetExtendedReport(object sender, EventArgs e)
        {

           

        }
         protected void GetSummationReport(object sender, EventArgs e)
        {

            exportSum();

        }
        
        protected void GoToNewItem(object sender, EventArgs e)
        {

            //  MatBuyEditor.ProjectID = ProjectID;
            EMainPageEditor.ID = 0;

            Response.Redirect("EMainPageEditor.aspx");

        }





        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.
            // DataGridUsers.EditIndex = e.NewEditIndex;
            //  showstuff();

            Label id = DataGridUsers.Rows[e.NewEditIndex].FindControl("lbl_ID") as Label;


            EMainPageEditor.ID = Convert.ToInt32(id.Text);


            Response.Redirect("EMainPageEditor.aspx");


        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update
            //  Label id = DataGridUsers.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            //  TextBox city = DataGridUsers.Rows[e.RowIndex].FindControl("txt_City") as TextBox;

            //updating the record
            //  BBAALL.EditAmountOfItemsProvided(Convert.ToInt32(id.Text), Convert.ToInt32(city.Text));


            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            //  DataGridUsers.EditIndex = -1;
            //Call ShowData method for displaying updated data
            //  showstuff();
        }//
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview
            //  DataGridUsers.EditIndex = -1;
            // showstuff();
        }


        public void printRecord(int RecID)
        {



            // string filename = HttpRuntime.AppDomainAppPath + "/Images/pdffile.pdf";
            //  string headerpath = HttpRuntime.AppDomainAppPath + "/Images/pdfheader.png";
        //    export(RecID);


        }
        private static PdfPCell PhraseCellClear(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.BLACK;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 4f;
            cell.PaddingTop = 2f;

            return cell;
        }
        private static PdfPCell PhraseCellHeader(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }

        public void exportSum()
        {


            DataTable SummationList = BBAALL.GetList_Finished();



            if (SummationList.Rows.Count>0)
            {
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
               /* Document doc = new Document(PageSize.A4.Rotate(), 88f, 88f, 110f, 25f  );*/
                Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 100, 100, 25, 25);



                BaseFont basefontArabic = BaseFont.CreateFont(System.Web.HttpContext.Current.Server.MapPath("/fonts/times.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font f = new iTextSharp.text.Font(basefontArabic, 18);
                iTextSharp.text.Font fsmall = new iTextSharp.text.Font(basefontArabic, 18);
                iTextSharp.text.Font fcontent = new iTextSharp.text.Font(basefontArabic, 20);
                iTextSharp.text.Font fLarg = new iTextSharp.text.Font(basefontArabic, 16);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    //doc = new Document(PageSize.A4, 88f, 88f, 90f, 25f);
                    PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);


                    writer.PageEvent = new PDFFooter();
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    BaseColor color = null;


                    doc.Open();


                    DateTime localDate = DateTime.Now;


                    PdfPTable tabhead = new PdfPTable(1);
                    PdfPCell celllogo;
                    string path = "../Images/pdfheader.png";
                    celllogo = ImageCell(path, 56f, PdfPCell.ALIGN_CENTER);
                    tabhead.AddCell(celllogo);

                    doc.Add(tabhead);


                    //table for header (Ref SOP NO, FORM NO and Certificate of Analaysis)






                    table = new PdfPTable(1);
                    table.WidthPercentage = 90;

                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 700f });
                    table.SpacingBefore = 10f;



                    cell = PhraseCellClear(new Phrase("جدول اعمال شركة الصومعة التلخيصي", fLarg), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.WHITE;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    table.AddCell(cell);


                   // doc.Add(new Paragraph("\n"));



                    doc.Add(table);




                    var text = writer.PageNumber.ToString();
                    table = new PdfPTable(6);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 500f, 200f, 300f, 200f, 200f, 75f });
                    table.SpacingBefore = 20f;
                   





                    cell = PhraseCell(new Phrase("الملاحظات", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    table.AddCell(cell);





                    cell = PhraseCell(new Phrase("تاريخ اخر المستجدات", fsmall), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);





                    cell = PhraseCell(new Phrase("تفاصيل اخر المستجدات", fsmall), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);

                    cell = PhraseCell(new Phrase("القسم", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);

                    cell = PhraseCell(new Phrase("المشروع", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);


                    cell = PhraseCell(new Phrase("ت", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);

                    int counter = 0;
                    foreach (DataRow row in SummationList.Rows)
                    {


                        counter++;


                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(row["Notes"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;



                        //  cell.BackgroundColor = new iText.BaseColor(System.Drawing.ColorTranslator.FromHtml("#C2D69B"));
                        Color cc = ColorTranslator.FromHtml(row["Color"].ToString());
                        cell.BackgroundColor = new BaseColor(Convert.ToInt16(cc.R), Convert.ToInt16(cc.G), Convert.ToInt16(cc.B));

                        table.AddCell(cell);




                        phrase = new Phrase();
                        cell = PhraseCell(new Phrase(row["UpdateDate"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                         cc = ColorTranslator.FromHtml(row["Color"].ToString());
                        cell.BackgroundColor = new BaseColor(Convert.ToInt16(cc.R), Convert.ToInt16(cc.G), Convert.ToInt16(cc.B));

                        table.AddCell(cell);


                        phrase = new Phrase();
                        cell = PhraseCell(new Phrase(row["TheUpdate"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                         cc = ColorTranslator.FromHtml(row["Color"].ToString());
                        cell.BackgroundColor = new BaseColor(Convert.ToInt16(cc.R), Convert.ToInt16(cc.G), Convert.ToInt16(cc.B));

                        table.AddCell(cell);


                        phrase = new Phrase();
                        cell = PhraseCell(new Phrase(row["Dep"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                         cc = ColorTranslator.FromHtml(row["Color"].ToString());
                        cell.BackgroundColor = new BaseColor(Convert.ToInt16(cc.R), Convert.ToInt16(cc.G), Convert.ToInt16(cc.B));

                        table.AddCell(cell);


                        phrase = new Phrase();
                        cell = PhraseCell(new Phrase(row["ProjectName"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                         cc = ColorTranslator.FromHtml(row["Color"].ToString());
                        cell.BackgroundColor = new BaseColor(Convert.ToInt16(cc.R), Convert.ToInt16(cc.G), Convert.ToInt16(cc.B));

                        table.AddCell(cell);


                        phrase = new Phrase();
                        cell = PhraseCell(new Phrase(counter+"", fcontent), PdfPCell.ALIGN_CENTER);
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        cc = ColorTranslator.FromHtml(row["Color"].ToString());
                        cell.BackgroundColor = new BaseColor(Convert.ToInt16(cc.R), Convert.ToInt16(cc.G), Convert.ToInt16(cc.B));

                        table.AddCell(cell);







                    }



                    doc.Add(new Paragraph("\n"));



                    doc.Add(table);








/*
                    if (dt.Rows.Count > 0)
                    {


                        //single table to holde Quality Control
                        table = new PdfPTable(1);
                        table.WidthPercentage = 130;
                        table.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.SetWidths(new float[] { 300f });
                        table.SpacingBefore = 20f;




                        cell = PhraseCellHeader(new Phrase("الدفعات", f), PdfPCell.ALIGN_CENTER);
                        cell.BackgroundColor = GrayColor.WHITE;
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;



                        table.AddCell(cell);
                        doc.Add(table);


                        table = new PdfPTable(3);
                        table.WidthPercentage = 130;
                        table.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.SetWidths(new float[] { 100f, 450f, 300f });
                        table.SpacingBefore = 10f;


                        cell = PhraseCell(new Phrase("رقم الدفعة", fcontent), PdfPCell.ALIGN_CENTER);
                        cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table.AddCell(cell);


                        cell = PhraseCell(new Phrase("مبلغ الدفعة", fcontent), PdfPCell.ALIGN_CENTER);
                        cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table.AddCell(cell);



                        cell = PhraseCell(new Phrase("التاريخ", fcontent), PdfPCell.ALIGN_CENTER);
                        cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        table.AddCell(cell);




                        int counter = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            counter++;
                            phrase = new Phrase();
                            cell = PhraseCell(new Phrase(counter + "", fcontent), PdfPCell.ALIGN_CENTER);
                            cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                            table.AddCell(cell);




                            phrase = new Phrase();
                            cell = PhraseCell(new Phrase(MyStringManager.GetNumberWithComas(row["PaidAmount"].ToString()) + "  دينار عراقي  ", fcontent), PdfPCell.ALIGN_CENTER);
                            cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                            table.AddCell(cell);



                            phrase = new Phrase();
                            cell = PhraseCell(new Phrase(MyStringManager.GetDateAfterCheckingFormating(row["Date"].ToString()), fcontent), PdfPCell.ALIGN_CENTER);

                            cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                            table.AddCell(cell);





                        }





                        doc.Add(table);

                    }


*/

                    table = new PdfPTable(1);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 300f });
                    table.SpacingBefore = 20f;

                    doc.Add(new Paragraph("\n"));




                    string datetime = localDate.ToString("dd/MM/yyyy HH:mm");

                    cell = PhraseCellHeader(new Phrase(datetime, fcontent), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.WHITE;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    table.AddCell(cell);

                    doc.Add(table);


                    doc.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();

                    Response.ContentType = "application/pdf";
                    string fnm2 = datetime + "جدول اعمال شركة الصومعة التلخيصي " + ".pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + fnm2);
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();


                }

            }
          
        }
        PdfPCell ImageCell(string path, float scale, int align)
        {


            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }



    }
    public class PDFFooter : PdfPageEventHelper
    {
        public static PdfPCell PhraseCellHeader(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }

        public static PdfPCell ImageCell(string path, float scale, int align)
        {


            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            BaseFont basefontArabic = BaseFont.CreateFont(System.Web.HttpContext.Current.Server.MapPath("/fonts/times.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font f = new iTextSharp.text.Font(basefontArabic, 10);
            iTextSharp.text.Font fheader = new iTextSharp.text.Font(basefontArabic, 20);
            //header
            BaseColor color = null;
            Phrase phrase = null;





            PdfPTable tabhead = new PdfPTable(1);
            PdfPCell celllogo;
            tabhead.SpacingAfter = 30F;
            tabhead.WidthPercentage = 100; //table width to 100per

            tabhead.TotalWidth = 500f;
            tabhead.LockedWidth = true;
            tabhead.SetWidths(new float[] { 1f });
            float h = tabhead.TotalHeight;


            //Company Logo
            string path = "../Images/pdfheader.png";
            celllogo = ImageCell(path, 20, PdfPCell.ALIGN_CENTER);
            tabhead.AddCell(celllogo);


            tabhead.WriteSelectedRows(0, -1, 30f, 840f, writer.DirectContent);



        }
    }
}