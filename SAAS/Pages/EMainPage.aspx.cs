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

                    bool FinishedBool = Finished.Text.Equals("1");


                    if (FinishedBool)
                    {
                        e.Row.BackColor = Color.FromName("#e6ffe3");


                    }
                    else
                    {
                        e.Row.BackColor = Color.FromName("#ffe3e3");





                    }


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

       /* public void export(int RecID)
        {


            DataTable MatBuyTbl = BBAALL.getMatBuyRecByID(RecID);



            foreach (DataRow rrooww in MatBuyTbl.Rows)
            {
                Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
                Document doc = new Document(PageSize.A4, 88f, 88f, 90f, 25f);

                BaseFont basefontArabic = BaseFont.CreateFont(System.Web.HttpContext.Current.Server.MapPath("/fonts/times.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font f = new iTextSharp.text.Font(basefontArabic, 14);
                iTextSharp.text.Font fcontent = new iTextSharp.text.Font(basefontArabic, 12);
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


                    string pin = "تجهيز مواد - " + localDate.ToString("yyyy") + "- ";


                    //table for header (Ref SOP NO, FORM NO and Certificate of Analaysis)



                    table = new PdfPTable(1);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 700f });
                    table.SpacingBefore = 20f;



                    cell = PhraseCellClear(new Phrase(BBAALL.getProjectNameByID(Convert.ToInt32(Session["ProjectID"].ToString())).Rows[0][0].ToString(), fLarg), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.GREEN;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    table.AddCell(cell);


                    doc.Add(new Paragraph("\n"));



                    doc.Add(table);




                    var text = writer.PageNumber.ToString();
                    table = new PdfPTable(3);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 300f, 300f, 300f });
                    table.SpacingBefore = 20f;






                    cell = PhraseCell(new Phrase("تاريخ القيد", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    table.AddCell(cell);





                    cell = PhraseCell(new Phrase("رقم القيد", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);





                    cell = PhraseCell(new Phrase("نوع القيد", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);




                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(MyStringManager.GetDateAfterCheckingFormating(rrooww["ContractDate"].ToString()), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);


                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["ContractNumber"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);










                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase("تجهيز مواد", fcontent), PdfPCell.ALIGN_CENTER);

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);



                    doc.Add(new Paragraph("\n"));



                    doc.Add(table);








                    //single table to holde Quality Control
                    table = new PdfPTable(1);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 300f });
                    table.SpacingBefore = 20f;




                    cell = PhraseCellHeader(new Phrase("المعلومات", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.WHITE;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;



                    table.AddCell(cell);
                    doc.Add(table);




                    table = new PdfPTable(4);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 400f, 300f, 300f, 400f });
                    table.SpacingBefore = 8f;






                    cell = PhraseCell(new Phrase("اسم المجهز", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;


                    table.AddCell(cell);





                    cell = PhraseCell(new Phrase("نوع التجهيز", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);





                    cell = PhraseCell(new Phrase("رقم الهاتف", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);




                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase("المشتري", fcontent), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);







                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["NameOfSupplyer"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);




                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["MatType"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);



                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["NumberOfSupplyer"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);



                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["Buyer"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);







                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase("اسم المادة", fcontent), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);





                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase("الكمية", fcontent), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);


                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase("العدد", fcontent), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);

                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase("الوحدة", fcontent), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;

                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    table.AddCell(cell);




                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["MatName"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);




                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["Quant"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);



                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["Count"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);



                    phrase = new Phrase();
                    cell = PhraseCell(new Phrase(rrooww["MatUnit"].ToString(), fcontent), PdfPCell.ALIGN_CENTER);
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                    table.AddCell(cell);








                    doc.Add(new Paragraph("\n"));



                    doc.Add(table);




                    DataTable dt = BBAALL.getAllPayByRecID(RecID);



                    table = new PdfPTable(2);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 500f, 500f });
                    table.SpacingBefore = 20f;




                    cell = PhraseCell(new Phrase("المبلغ الكلي : " + MyStringManager.GetNumberWithComas(rrooww["TotalCost"].ToString()) + "  دينار عراقي  ", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.BackgroundColor = GrayColor.WHITE;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.FixedHeight = 25f;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);



                    cell = PhraseCell(new Phrase("المبلغ الواصل : " + MyStringManager.GetNumberWithComas(rrooww["RecAmount"].ToString()) + "  دينار عراقي  ", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.BackgroundColor = GrayColor.WHITE;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.FixedHeight = 25f;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);

                    cell = PhraseCell(new Phrase("المبلغ المتبقي : " + MyStringManager.GetNumberWithComas((Convert.ToInt32(rrooww["TotalCost"].ToString()) - Convert.ToInt32(rrooww["RecAmount"].ToString())) + "") + "  دينار عراقي  ", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.BackgroundColor = GrayColor.WHITE;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.FixedHeight = 25f;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);



                    cell = PhraseCell(new Phrase("عدد الدفعات المستلمة : " + dt.Rows.Count + "", f), PdfPCell.ALIGN_CENTER);
                    cell.BackgroundColor = GrayColor.LIGHT_GRAY;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.BackgroundColor = GrayColor.WHITE;
                    cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    cell.FixedHeight = 25f;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);







                    doc.Add(table);


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




                    table = new PdfPTable(1);
                    table.WidthPercentage = 130;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SetWidths(new float[] { 300f });
                    table.SpacingBefore = 20f;

                    doc.Add(new Paragraph("\n"));




                    string datetime = localDate.ToString("MM/dd/yyyy HH:mm");

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
                    string fnm2 = datetime + "تقرير مواد" + ".pdf";
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
    
    */
    
    
    }
    public class PDFFooter : PdfPageEventHelper
    {
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

        private static PdfPCell ImageCell(string path, float scale, int align)
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
            tabhead.TotalWidth = 500f;
            tabhead.LockedWidth = true;
            tabhead.SetWidths(new float[] { 1f });
            float h = tabhead.TotalHeight;


            //Company Logo
            string path = "~/Images/pdfheader.png";
            celllogo = ImageCell(path, 54f, PdfPCell.ALIGN_CENTER);
            tabhead.AddCell(celllogo);


            tabhead.WriteSelectedRows(0, -1, 30f, 840f, writer.DirectContent);



        }
    }
}