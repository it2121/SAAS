<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADNP.aspx.cs" Inherits="SAAS.Pages.ADNP"  UnobtrusiveValidationMode="None"  %>


<!DOCTYPE html>


<html>
<head runat="server">
    <title>Document Control</title>

    
     <link href="../Libs/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="../Libs/bootstrap.min.js"></script>
        <script src="../Libs/jquery.min.js"></script>
        <script src="../Libs/popper.min.js"></script>
        <script src="../Libs/jquery.mCustomScrollbar.concat.min.js"></script>
        <script src="../Libs/main.js"></script>
        <script src="../Libs/jquery-3.3.1.slim.min.js"></script>
        <script src="../Libs/jquery.dataTables.min.js"></script>
        <link href="../Libs/bootstrap.min.css" rel="stylesheet" />
        <link href="../Libs/jquery.mCustomScrollbar.min.css" rel="stylesheet" />
        <link href="../Libs/all.css" rel="stylesheet" />
        <link href="../Libs/main.css" rel="stylesheet" />
        <link href="../Libs/sidebar-themes.css" rel="stylesheet" />
        <script src="../Libs/dataTables.bulma.min.js"></script>
        <link href="../Libs/bulma.min.css" rel="stylesheet" />
            <link href="../Libs/dataTables.bulma.min.css" rel="stylesheet" />
                <link href="../Libs/font-awesome.css"" rel="stylesheet" />
        <script src="../Libs/334e818a85.js" crossorigin="anonymous"></script>


      <script src="path/to/chartjs/dist/chart.umd.js"></script>
            <link rel="icon" type="image/png" href="../Images/DC.ico" sizes="32x32">


<script type="text/javascript">
    $(document).on("click", "[src*=plus]", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
        $(this).attr("src", "../Images/minus.png");
    });
    $(document).on("click", "[src*=minus]", function () {
        $(this).attr("src", "../Images/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>

      <script type="text/javascript">

          $(document).ready(function () {

              $(document).ready(function () {
                  $('#DataGridUsers').DataTable();

              });
              $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({

                  "order": [[1, 'desc']],
                  "pageLength": 100,

              });
              $('.table1').DataTable();
          });

      </script>

        <script>


            document.addEventListener('DOMContentLoaded', () => {
                // Functions to open and close a modal
                function openModal($el) {
                    $el.classList.add('is-active');
                }

                function closeModal($el) {
                    $el.classList.remove('is-active');
                }

                function closeAllModals() {
                    (document.querySelectorAll('.modal') || []).forEach(($modal) => {
                        closeModal($modal);
                    });
                }

                // Add a click event on buttons to open a specific modal
                (document.querySelectorAll('.js-modal-trigger') || []).forEach(($trigger) => {
                    const modal = $trigger.dataset.target;
                    const $target = document.getElementById(modal);

                    $trigger.addEventListener('click', () => {
                        openModal($target);
                    });
                });

                // Add a click event on various child elements to close the parent modal
                (document.querySelectorAll('.modal-background, .modal-close, .modal-card-head .delete, .modal-card-foot .button') || []).forEach(($close) => {
                    const $target = $close.closest('.modal');

                    $close.addEventListener('click', () => {
                        closeModal($target);
                    });
                });

                // Add a keyboard event to close all modals
                document.addEventListener('keydown', (event) => {
                    if (event.code === 'Escape') {
                        closeAllModals();
                    }
                });
            });

        </script>






   <style>
        .HeaderDiv {
            box-shadow: 4px 4px 20px Black;
            border-radius: 10px;
        }
    </style>

  
       
      <style>
          @font-face {
              font-family: CustomFont;
              src: url('../Libs/Beiruti-VariableFont_wght.ttf');
          }

          * :not(i) {
              font-family: CustomFont, sans-serif !important;
              font-optical-sizing: auto !important;
              font-weight: 700 !important;
              font-style: normal !important;
          }

          body {
              background-image: url("../Images/bgbg.jpg");
              background-repeat: repeat;
              background-size: 300px;
          }

          .button-89 {
              --b: 3px; /* border thickness */
              --s: .45em; /* size of the corner */
              --color: #3399ff;
              padding: calc(.5em + var(--s)) calc(.9em + var(--s));
              color: var(--color);
              --_p: var(--s);
              background: conic-gradient(from 90deg at var(--b) var(--b),White 90deg,var(--color) 0) var(--_p) var(--_p)/calc(100% - var(--b) - 2*var(--_p)) calc(100% - var(--b) - 2*var(--_p));
              transition: .3s linear, color 0s, background-color 0s;
              outline: var(--b) solid #0000;
              outline-offset: .6em;
              font-size: 19px;
              font-weight: bold;
              border: 0;
              user-select: none;
              -webkit-user-select: none;
              touch-action: manipulation;
          }

              .button-89:hover,
              .button-89:focus-visible {
                  --_p: 0px;
                  outline-color: var(--color);
                  outline-offset: .05em;
              }

              .button-89:active {
                  background: var(--color);
                  color: #fff;
              }

          html, body {
              margin: 0;
              height: 100%;
          }

          .btn {
              background-color: #44a2ff;
              padding: 14px 40px;
              color: #fff;
              text-transform: uppercase;


/*                font-size:  calc(2em + 2vw);
*/               font-size: 6vmin;



                    cursor: pointer;
              border-radius: 10px;
              border: 2px dashed #44a2ff;
              box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px, rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
              transition: .4s;
          }

              .btn span:last-child {
                  display: none;
              }

              .btn:hover {
                  transition: .4s;
                  border: 2px dashed #3b9dff;
                  background-color: #fff;
                  color: #44a2ff;
              }

              .btn:active {
                  background-color: #9bcdff;
              }

          }


             body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .Grid td
        {
            background-color: #A1DCF2;
            color: black;
            font-size: 10pt;
            line-height:200%
        }
        .Grid th
        {
            background-color: #3AC0F2;
            color: White;
            font-size: 10pt;
            line-height:200%
        }
        .ChildGrid td
        {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height:50%
        }
        .ChildGrid th
        {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height:50%
        }

      </style>


    
    
 

    </head>
<body>
  
    <form id="form1" runat="server">
               <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>
           
                <!-- page-content  -->
                <main class="page-content pt-2">
                    <div id="overlay" class="overlay"> </div>
                    <div class="container-fluid p-5">

                
                         
                                <h2></h2>
                                                                              <div class="container">
         
                       <div class="row mb-4">

                          
                           <div class="col-12">
                                                   <div class="box align-content-center text-center" style="background-color:#343a40; color:white;">

                                <i class="fa-solid fa-2x fa-file-signature" ></i>
                                        <asp:Label  ID="MainLbl" runat="server"  class="menu-text  text-center text is-size-4">Document Control</asp:Label>
                                        <span class="badge badge-pill badge-primary"></span>
            </div>

                           </div>
                    
                           </div>
                       </div>

                             
                            
                     

                    




                                         
   
              <asp:Panel runat="server" ID="ButtonsBar">
        <div class="row " style="margin-bottom: 1em">


            <div class="col-auto">
                        <div class="field buttons align-items-end">


     <asp:LinkButton  runat="server"  style="background-color: white; color: #33B3FF; font: bold; border-color:#33B3FF" text="Add New"
        
         
                                 onclick="AddNew"
         ID="AddNewBtn"
         
                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">Add New 
                       
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

     <asp:LinkButton  runat="server"  style="background-color: white; color: #33B3FF; font: bold; border-color:#33B3FF" text="Return"
      
                                 onclick="Return"
         ID="returnBtn"
         Visible="false"
                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">Return
                       
                        <i class="fas fa-home " style="margin-left: 1em">

                        </i></asp:LinkButton>
                </div>
            </div>
                </div>
            </div>

        </div>

    </asp:Panel>



    <div class="row">
        <div class="col-12">
                        <asp:Panel ID = "GridPanel" runat="server" Visible="false" > 

              <article class="panel is-info" style="background-color: white;padding-bottom:2em;">
        <p class="panel-heading text-center" style="background-color:#3399ff;">                <asp:Label  runat ="server" ID ="PageProjectNameLbl" Text="Files List" ></asp:Label>
<i class="fa-solid fa-file-invoice-dollar"></i></p>
        
        


 
     <div class="row ">
        
          
                <div class="container-fluid d-flex flex-column">
        <div class="row m-2" >

            <div class="col-12">
              
      <div class="content-1">
           


                        <asp:GridView ShowHeaderWhenEmpty="true" ID="DataGridUsers" runat="server" 
                            AutoGenerateColumns="False" 
                            class="table table-striped  table-hover border-0 "
                            CellPadding="6"
                            OnRowCancelingEdit="GridView1_RowCancelingEdit"
                             OnRowDataBound="OnRowDataBound"
                                     DataKeyNames="ID"
OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                            HeaderStyle-HorizontalAlign="Center"
                          OnRowCommand="MyGridView_OnRowCommand"
                          
                            
                            >
            <Columns>
        

                
                
                       <asp:TemplateField>
                <ItemTemplate>
                <img alt = "" style="cursor: pointer " src="../Images/plus.png"  width="30"  />

                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none" Width="100%">

                                <asp:GridView ShowHeaderWhenEmpty="true" ID="DataGridV" runat="server" AutoGenerateColumns="False"  class="" CellPadding="1" 
                            OnRowCancelingEdit="GridView1_RowCancelingEditV"
                                CssClass = "ChildGrid"   

                                    
                                    
                                    OnRowUpdating="GridView1_RowUpdatingV"
                            HeaderStyle-HorizontalAlign="Center"
                          OnRowCommand="MyGridView_OnRowCommand"
                          Width="100%"
                                    
                            
                            >
            <Columns>
        

                
                
                
                 

               
                
              

                  <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="Index">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_IDInner" runat="server" Text='<%#Eval("ID1") %>' Font-Bold="false" Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                

                   <asp:TemplateField HeaderText="Date Created"   ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label  style="word-wrap:break-word;max-width:25em; " Width="100%" ID="lbl_DateInner" runat="server" Text='<%#Eval("TheDate") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox    style="word-wrap:break-word;max-width:100%;" ID="txt_DateInner"  Width="100%" runat="server" Text='<%#Eval("TheDate") %>'></asp:TextBox>
                           
                            </EditItemTemplate>
                        </asp:TemplateField>


                <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Date Created">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_QuansgtInnerDate" runat="server" Text='<%#Eval("TheDate") %>' Font-Bold="true" Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 



                <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="FileName">
                    <ItemTemplate>

                              <asp:Label  ID="lbl_QuansgtInner" runat="server" Text='<%#Eval("Prefex") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12anotherInner1" runat="server" Text='<%# "-"+Eval("DocType") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another2Inner" runat="server" Text='<%# "-"+Eval("Dep") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another3Inner" runat="server" Text='<%# "-"+Eval("Number") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another4Inner" runat="server" Text='<%# "-"+Eval("Year") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another5Inner" runat="server" Text='<%# "-"+Eval("Version") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>   
             <%--   <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="FileName">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_Quansgt12" runat="server" Text='<%#Eval("VReached") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>  --%> 


                 <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label style="word-wrap:break-word; max-width:100%;" ID="lbl_ORusys"    runat="server" Text='<%#Eval("Remarks") %>' Font-Bold="true" Font-Size="Small"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
              
           
                 
   
                
               
                
               
               

                 <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:Label style="word-wrap:break-word;max-width:25em; " Width="100%" ID="lbl_CityInner" runat="server" Height="10px"  Font-Size="Small" Text='<%#Eval("Remarks") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox   TextMode="MultiLine"  style="word-wrap:break-word;max-width:100%;" ID="txt_CityInner"  Font-Size="Small" Height="40px"   Width="100%" runat="server" Text='<%#Eval("Remarks") %>'></asp:TextBox>
                           
                            </EditItemTemplate>
                        </asp:TemplateField>
    
            
                
            <%--         <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate >
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-info"
                                    style="Width:35%; Height:25px"  

                            CommandArgument='<%#Eval("FileName") %>' CommandName="Manage"

                                                         Visible ='<%# Eval("VReached").ToString() == "V1" ? false :true %>'

                            ID="btnNewV_Edit1" runat="server" Text="Manage Version"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>--%>


<%--                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate >
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-warning"
                                    style="Width:20%; Height:25px"  

                            CommandArgument='<%#Eval("FileName") %>' CommandName="CreateNewVirsion"


                            ID="btnNewV_Edit1" runat="server" Text="V+"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>--%>



<%--                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-danger"
                                    style="Width:20%; Height:25px"  

                            CommandArgument='<%#Eval("FileName") %>' CommandName="RemoveLastVirstion"
                             Visible ='<%# Eval("VReached").ToString() == "V1" ? false :true %>'

                            ID="btnNewV_Editeee1" runat="server" Text="V-"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>--%>
           
                  <asp:TemplateField  >
                            <ItemTemplate>
                                <asp:Button
                                    class="js-modal-trigger button is-info is-outlined"
                                    style="Width:30%; Height:25px; padding-left:0.5em; padding-top:0.1em; padding-bottom:0.5em; margin-right:0.3em;"  
                                                                 Font-Size="Small"
                                    Height="10px" 
                                    ID="btn_EditVInner" runat="server" Text="✎"  CommandName="Editt" ToolTip='<%#Eval("ID1") %>' CommandArgument='<%#Eval("ID1") %>'/>
                            </ItemTemplate>
                              </asp:TemplateField>
                    

             <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >

          

                    <ItemTemplate>
                        <asp:Button Font-Bold="true" 
                                                                class="js-modal-trigger button  is-bold is-danger is-outlined"
                                    style="Width:30%; Height:25px; padding-left:0.5em; padding-top:0.1em; padding-bottom:0.5em; margin-right:0.3em;"  
                             Font-Size="Small"
                            CommandArgument='<%#Eval("ID1") %>' CommandName="DeleteLineV"

                             OnClientClick="return confirmation();"
                            ID="btnNewVd_Edit1Inner" runat="server" Text="✗"   />
                    

                    </ItemTemplate>

                         
                </asp:TemplateField>

                        
                   <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-info is-outlined"
                                    Style="width: 50%; height: 25px"
                            Font-Size="Small"
                            CommandArgument='<%#Eval("ID1") %>' CommandName="UploadFileV"
         data-target="modal-js-example"

                            ID="btnNewVd_Edit1U" runat="server" Text="🔼"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>
                                 <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-warning is-outlined"
                                    Style="width: 50%; height: 25px"
                            Font-Size="Small"
                            CommandArgument='<%#Eval("ID1") %>' CommandName="DownloadFileV"
                                                         Visible ='<%# Eval("FileName").ToString().Length> 0 ?  true:false %>'

                            ID="btnNewVd_Edit1D" runat="server" Text="🔽"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>




                



                     <asp:TemplateField  >
                            <EditItemTemplate > 
                                <asp:Button ID="btn_UpdateInner" class="js-modal-trigger button is-warning"
                                                                                                                     Font-Size="Small"
              style="Width:30%; Height:25px; padding-left:0.5em; padding-top:0.1em; padding-bottom:0.7em; margin-right:0.3em;"  
 runat="server" Text="✓" CommandName="Update" />
                                <asp:Button ID="btn_CancelInner" class="js-modal-trigger button is-primary "
                                                                                                                                    Font-Size="Small"
    style="Width:30%; Height:25px; padding-left:0.5em; padding-top:0.1em; padding-bottom:0.7em; margin-right:0.3em;"  
 runat="server" Text="✗" CommandName="Cancel" />
                            </EditItemTemplate>

                        </asp:TemplateField>
            </Columns>
                                <EmptyDataTemplate>No Rows yet</EmptyDataTemplate>  

        </asp:GridView>
                  


                    </asp:Panel>
                    <script></script>

                </ItemTemplate>
            </asp:TemplateField>
          
       
                 
               
                
              

                  <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="Index">       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Label  ID="lbl_ID" runat="server" Text='<%#Eval("ID") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   



                   <asp:TemplateField HeaderText="Date Created"   ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label  style="word-wrap:break-word;max-width:25em; " Width="100%" ID="lbl_Date" runat="server" Text='<%#Eval("TheDate") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox    style="word-wrap:break-word;max-width:100%;" ID="txt_Date"  Width="100%" runat="server" Text='<%#Eval("TheDate") %>'></asp:TextBox>
                           
                            </EditItemTemplate>
                        </asp:TemplateField>
    


                  <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Date Created"> <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Label  ID="lbl_QuansgtDate" runat="server" Text='<%#Eval("TheDate") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 


                <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="FileName">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_Quansgt" runat="server" Text='<%#Eval("Prefex") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another1" runat="server" Text='<%# "-"+Eval("DocType") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another2" runat="server" Text='<%# "-"+Eval("Dep") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another3" runat="server" Text='<%# "-"+Eval("Number") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another4" runat="server" Text='<%# "-"+Eval("Year") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                        <asp:Label  ID="lbl_Quansgt12another5" runat="server" Text='<%# "-"+Eval("Version") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   
                <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Latest Version   ">       <HeaderStyle Width="1" />
<ItemStyle Width="1" />
                    <ItemTemplate>
                        <asp:Label   ID="lbl_Quansgt12" runat="server" Text='<%#Eval("Version") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   


                 <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lbl_ORusys" runat="server" Text='<%#Eval("Remarks") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
              
           
                 
   
                
               
                
               
               

                 <asp:TemplateField HeaderText="Remarks"   ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label  style="word-wrap:break-word;max-width:25em; " Width="100%" ID="lbl_City" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox  TextMode="MultiLine"  style="word-wrap:break-word;max-width:100%;" ID="txt_City"  Width="100%" runat="server" Text='<%#Eval("Remarks") %>'></asp:TextBox>
                           
                            </EditItemTemplate>
                        </asp:TemplateField>
    
            


                
                







               


                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate >
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-warning"
                                    Style="width: 50%; height: 25px"

                            CommandArgument='<%#Eval("ID") %>' CommandName="CreateNewVirsion"


                            ID="btnNewV_Edit1" runat="server" Text="V+"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>
                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-danger"
                                    Style="width: 50%; height: 25px"

                            CommandArgument='<%#Eval("ID") %>' CommandName="RemoveLastVirstion"
                             Visible ='<%# Eval("Version").ToString() == "V1" ? false :true %>'

                            ID="btnNewV_Editeee1" runat="server" Text="V-"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>
           
                  <asp:TemplateField  >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                            <ItemTemplate>
                                <asp:Button
                                    class="js-modal-trigger button is-info is-outlined"
                                    Style="width: 50%; height: 25px"
                                    Font-Size="Small"
                                    ID="btn_Edit" runat="server" Text="✎"  CommandName="Edit" />
                            </ItemTemplate>
                              </asp:TemplateField>
                    

             <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-danger is-outlined"
                                    Style="width: 50%; height: 25px"
                            Font-Size="Small"
                            CommandArgument='<%#Eval("ID") %>' CommandName="DeleteLine"

                             OnClientClick="return confirmation();"
                            ID="btnNewVd_Edit1" runat="server" Text="✗"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>


                        <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-info is-outlined"
                                    Style="width: 50%; height: 25px"
                            Font-Size="Small"
                            CommandArgument='<%#Eval("ID") %>' CommandName="UploadFile"
         data-target="modal-js-example"

                            OnClientClick= '<%# String.Format("return showUploadFile(\"{0}\")",Eval("ID"))%>'
                          
                            ID="btnNewVd_Edit1U1" runat="server" Text="🔼"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>
                                 <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-warning is-outlined"
                                    Style="width: 50%; height: 25px"
                            Font-Size="Small"
                            CommandArgument='<%#Eval("ID") %>' CommandName="DownloadFile"
                                                         Visible ='<%# Eval("FileName").ToString().Length> 0 ?  true:false %>'

                            ID="btnNewVd_Edit1D1" runat="server" Text="🔽"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>
                     
                     <asp:TemplateField  >       <HeaderStyle Width="10" />
<ItemStyle Width="10" />
                            <EditItemTemplate > 
                                <asp:Button ID="btn_Update" class="js-modal-trigger button is-warning"
                                      Font-Size="Small"
                                    Style="width: 50%; height: 25px; margin-right:5px" runat="server" Text="✓" CommandName="Update" />
                                <asp:Button ID="btn_Cancel" class="js-modal-trigger button is-primary "
                                    Font-Size="Small"
                                    Style="width: 50%; height: 25px; margin-right:5px" runat="server" Text="✗" CommandName="Cancel" />
                            </EditItemTemplate>

                        </asp:TemplateField>
            </Columns>
                                <EmptyDataTemplate>No Rows yet</EmptyDataTemplate>  

        </asp:GridView>
                </div>




          
            </div>
            </div>
            </div>
            </div>



    

    </article>
    }


</script>
                             </asp:Panel>
        </div>




























        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
   
              <div class="col-12">
                        <asp:Panel ID = "VGP" runat="server" Visible="false" > 

              <article class="panel is-info" style="background-color: white;padding-bottom:2em;">
        <p class="panel-heading text-center" style="background-color:#3399ff;">                <asp:Label  runat ="server" ID ="PageProjectNameLblV" Text="Files List" ></asp:Label>
<i class="fa-solid fa-file-invoice-dollar"></i></p>
        
        


 
     <div class="row ">
        
          
                <div class="container-fluid d-flex flex-column">
        <div class="row m-2" >

            <div class="col-12">
              
      <div class="content-1">
           


                
                </div>




          
            </div>
            </div>
            </div>
            </div>



    

    </article>

                             </asp:Panel>
        </div>




























        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <%--/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
   
        
        
        
        <div class="col-12">
            <asp:Panel ID = "ButtonsPanel" runat="server" Visible="true" > 

        <article class="panel is-info" style="background-color: white; padding-bottom: 2em;">

            <p class="panel-heading text-center " style="background-color: #3399ff;">Create New Document<i class="fa-solid fa-file-invoice-dollar"></i></p>




            <br />



            <div class="row   m-4" style="padding-left: 1em; padding-right: 1em;">
                <div class="col-6  text-center ">
                    <div class="row   m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button1" ToolTip="POL" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Policy"></asp:Button>
                        </div>



                    </div>

                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="SalaryManBtn" ToolTip="PRO" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Procedure"></asp:Button>
                        </div>



                    </div>

                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button2" ToolTip="WI" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Work Instruction"></asp:Button>
                        </div>



                    </div>


                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button3" ToolTip="FRM" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Form"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button4" ToolTip="MAN" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Manual"></asp:Button>
                        </div>



                    </div>
                    
               

          
                </div>        
                
                <div class="col-6  text-center ">
                

                 

                  


                 
                    
                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button5" ToolTip="RA" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Risk Assessment"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button6" ToolTip="PLN" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Plan"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button7" ToolTip="RPT" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Report"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button8" ToolTip="REC" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Record"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 1em; padding-right: 1em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button9" ToolTip="SCH" Style="font: bolder; font-size: 2em; width: 85%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Schedule"></asp:Button>
                        </div>


                </div>


          
                </div>
            </div>
    </div>
    </article>
        </asp:Panel>
        </div>

      
        <div class="row ">
        </div>




       <script>function confirmation() {
               return confirm("Are you sure you want to delete?");
           }</script>











  <footer class="main-footer bg-white footer1" style="width:100%; background-color:#343b46;" >
					<div class="float-right d-none d-sm-inline-block">


		</div>

			<div class="float-right d-none d-sm-inline-block">
				
			</div>
		</footer>
         
          </div>
       
             </main>
                <!-- page-content" -->

           <div id="modal-js-example" class="modal" >
        <div class="modal-background  "></div>

        <div class="modal-content">
            <div class="box bg-light">
           
                    <panel id="UploadPanel" style="display:none;">

                <p>Upload File</p>


                <br />


                <div class="row">
                    <div class="col-12">
                         <center>
                       <button  class="button is-danger is-outlined" style="width:100%; color:#f39658;">

<%--                        <asp:TextBox runat="server" ReadOnly="true" ID="FileAdrs" class="input is-warning " BackColor="LightGray" placeholder="File Address"></asp:TextBox>--%>
                                                    <asp:FileUpload ID="FileUploadControl" Visible="true" runat="server" Width="100%"/>
                         </button>
                                </center>
                    </div>
                    <div class="col-3">
<%--                            <asp:FileUpload id="FileUploadControl" Visible="false" runat="server"/>--%> 
                        
<%--                        <asp:Button   runat="server" Font-Bold="true"  BackColor="DarkGray" Text="Browse" class=" button is-fullwidth  align align-content-center text-white "> </asp:Button>--%>
                     

                    </div>
                </div>
                <br />
                <br />
              
                <div class="row">
                   
                    <div class="col-12">
   <center>
                   <asp:LinkButton ID="UpBtn"  onclick="Upload" runat="server" Font-Bold="true" Width="75%" BackColor="#f39658" Text="Upload" class=" button is-fullwidth  align align-content-center text-white ">Upload <i class="fas fa-upload " style="margin-left: 2em"></i></asp:LinkButton>

         </center>
                    </div>
                </div>
                   
                <br />

                </panel>

                  <asp:Panel runat="server" id="UploadPanelV" style="display:none;" >

                <p>Upload File</p>


                <br />


                <div class="row">
                    <div class="col-12">
                         <center>
                       <button  class="button is-danger is-outlined" style="width:100%; color:#f39658;">

<%--                        <asp:TextBox runat="server" ReadOnly="true" ID="FileAdrs" class="input is-warning " BackColor="LightGray" placeholder="File Address"></asp:TextBox>--%>
                                                    <asp:FileUpload ID="FileUpload1V" Visible="true" runat="server" Width="100%"/>
                         </button>
                                </center>
                    </div>
                    <div class="col-3">
<%--                            <asp:FileUpload id="FileUploadControl" Visible="false" runat="server"/>--%> 
                        
<%--                        <asp:Button   runat="server" Font-Bold="true"  BackColor="DarkGray" Text="Browse" class=" button is-fullwidth  align align-content-center text-white "> </asp:Button>--%>
                     

                    </div>
                </div>
                <br />
                <br />
              
                <div class="row">
                   
                    <div class="col-12">
   <center>
                   <asp:LinkButton ID="LinkButton1V"  onclick="UploadV" runat="server" Font-Bold="true" Width="75%" BackColor="#f39658" Text="Upload" class=" button is-fullwidth  align align-content-center text-white ">Upload <i class="fas fa-upload " style="margin-left: 2em"></i></asp:LinkButton>

         </center>
                    </div>
                </div>
                   
                <br />

                </asp:Panel>

                 </div> </div> </div> </div>
           
    

      
    </form>

</body>
         <script  type="text/javascript"> function showUploadFile(FFID) {
                 document.getElementById('UploadPanel').style.display = "block";
                 PageMethods.SetFFID(FFID);
                 return false;
             }

             function showUploadFileV() {
                 document.getElementById('UploadPanelV').style.display = "block";
               
             }
         




         </script>

    
</html>
