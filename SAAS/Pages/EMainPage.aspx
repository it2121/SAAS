﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="EMainPage.aspx.cs" Inherits="SAAS.Pages.EMainPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script type="text/javascript">

               $(document).ready(function () {

                   $(document).ready(function () {
                       $('#DataGridUsers').DataTable();
                   });
                   $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                       "pageLength": 100
});
                   $('.table1').DataTable();
               });

       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel runat="server" ID="Panel1">
        <div class="row " style="margin-bottom: 1em">
                 
                
              <div class="col-auto">
                <div class="field buttons align-items-end">





     <asp:LinkButton  runat="server"  ID="AddnewBtn" style="background-color: white; color: #33B3FF; font: bold; border-color:#33B3FF" text="اضافة فقرة اعمال جديدة "
        
         
         data-target="modal-js-example"
                                 onclick="GoToNewItem"

                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">اضافة فقرة اعمال جديدة 
                       
                        <i class="fas fa-add " style="margin-left: 1em">

                        </i></asp:LinkButton>

                </div>
            </div>


            <div class="col-auto">
                <div class="field buttons align-items-end">
                </div>
            </div>
            <div class="col-lg">
            </div>
            <div class="col-auto">
            </div>
            <div class="col-auto  ">
            </div>
            <div class="col-auto">
                <div class="field buttons align-items-end">


                              <div class="col-auto">
                <div class="field buttons align-items-end">

                       <asp:LinkButton  runat="server"  ID="LinkButton1" style="background-color: #f4ffbc; color: #33B3FF; font: bold; border-color:#33B3FF" text="اضافة فقرة اعمال جديدة "
        
         
         data-target="modal-js-example"
                                 onclick="GetExtendedReport"

                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">سحب تقرير مفصل 
                        <i class="fas fa-file-export " style="margin-left: 1em">

                        </i></asp:LinkButton>



                </div>
            </div>
                    
                              <div class="col-auto">
                <div class="field buttons align-items-end">

                       <asp:LinkButton  runat="server"  ID="LinkButton2" style="background-color: #e1ffc5; color: #33B3FF; font: bold; border-color:#33B3FF" text="اضافة فقرة اعمال جديدة "
        
         
         data-target="modal-js-example"
                                 onclick="GetSummationReport"

                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">سحب تقرير تلخيصي
                       
                        <i class="fas fa-file-export " style="margin-left: 1em">

                        </i></asp:LinkButton>



                </div>
            </div>
                </div>
            </div>

        </div>

    </asp:Panel>
  
    
  
    <article class="panel is-info" style="background-color: white;padding-bottom:2em;">
        <p class="panel-heading text-center" style="background-color:#3399ff;">                <asp:Label  runat ="server" ID ="PageProjectNameLbl" Text="جدول اعمال شركة الصومعة" ></asp:Label>
<i class="fa-solid fa-file-invoice-dollar"></i></p>
        
        
          
 
     <div class="row ">
        
          
                <div class="container-fluid d-flex flex-column">
        <div class="row m-2" >

            <div class="col-12">
              
      <div class="content-1">
           


                        <asp:GridView ShowHeaderWhenEmpty="true" ID="DataGridUsers" runat="server" AutoGenerateColumns="False"  class="table table-striped  table-hover border-0 " CellPadding="6" OnRowCancelingEdit="GridView1_RowCancelingEdit"

OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                            HeaderStyle-HorizontalAlign="Center"
                          OnRowCommand="MyGridView_OnRowCommand"
                             OnRowDataBound="GridView1_RowDataBound"

                            >
            <Columns>
        

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Color" runat="server" Text='<%#Eval("Color") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  
                
                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                     <asp:Button
                                    style="Width:6.5rem; Height:2rem;padding-bottom:1em;padding-top:0.3em;  font-size:1rem;"  
                                    
                                  
                                    class='<%# Eval("Finished").ToString() == "0" ? "js-modal-trigger button is-danger " :"js-modal-trigger button is-primary "  %>' 
                                    ID="checkedBtn" runat="server" 
                                    onclick="PaidCheck"

                                    ToolTip=' <%# ((Eval("ID"))) %> ' Text='<%# Eval("Finished").ToString() == "0" ? "تحويل الى مكتملة" :"تحويل الى غير مكتملة"  %>'> </asp:Button>
                    </ItemTemplate>
            
                </asp:TemplateField>

                
                  <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-primary "
                                    style="Width:60%; Height:25px"  

                            CommandArgument='<%#Eval("ID") %>' CommandName="GoToUpdate"


                            ID="btn_Edit1" runat="server" Text="التحديثات"  />
                    </ItemTemplate>
            
                </asp:TemplateField>
                
                      <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:Button 
                                      Font-Bold="true"                          class="js-modal-trigger button  is-bold is-info "
                                    style="Width:50%; Height:25px"  

                            ID="btn_Edit" runat="server" Text="تعديل" CommandName="Edit" />
                    </ItemTemplate>
            
                </asp:TemplateField>

                  <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="الملاحظات">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_Quant" runat="server" Text='<%#Eval("Notes") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   

              



                <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="مكتمل">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_Quansgt" runat="server" Text='<%#Eval("Finished") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   


                 <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="تاريخ اخر تحديث">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_ORusys" runat="server" Text='<%#Eval("UpdateDate") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="اخر تحديث">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_OR" runat="server" Text='<%#Eval("TheUpdate") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                    
                  <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="القسم">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_OR3" runat="server" Text='<%#Eval("Dep") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   

                
                <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="اسم المشروع">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_OR4" runat="server" Text='<%#Eval("ProjectName") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   




                   <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="ت">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_OR4Ord" runat="server" Text='<%#Eval("Ord") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   
                 
   
                
               
                
               
               
              
               
             
    
           





      

                  
            </Columns>
                                <EmptyDataTemplate>لا توجد معلومات بعد</EmptyDataTemplate>  

        </asp:GridView>
                </div>




          
            </div>
            </div>
            </div>
            </div>
            </div>



    

    </article>


    
                 <script>

                     var table = $('#DataGridUsers').DataTable();

                     new DataTable.Responsive(table);

                 </script>






</asp:Content>
