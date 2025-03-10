<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADNP.aspx.cs" Inherits="SAAS.Pages.ADNP"  UnobtrusiveValidationMode="None"  %>


<!DOCTYPE html>


<html>
<head runat="server">
    <title>ADNP</title>

    
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
            <link rel="icon" type="image/png" href="../Images/logoNew.ico" sizes="32x32">



   <style>
        .HeaderDiv {
            box-shadow: 4px 4px 20px Black;
            border-radius: 10px;
        }
    </style>

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




      </style>
    </head>
<body>
    <form id="form1" runat="server">

           
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
                                        <asp:Label  ID="MainLbl" runat="server"  class="menu-text  text-center text is-size-4">ADNP</asp:Label>
                                        <span class="badge badge-pill badge-primary"></span>
            </div>

                           </div>
                    
                           </div>
                       </div>

                             
                            
                     

                    




                                         
   
              <asp:Panel runat="server" ID="ButtonsBar">
        <div class="row " style="margin-bottom: 1em">


            <div class="col-auto">
                <div class="field buttons align-items-end">
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
                <%--     <div class="field buttons align-items-end">


                              <div class="col-auto">
                <div class="field buttons align-items-end">

     <asp:LinkButton  runat="server"  style="background-color: white; color: #33B3FF; font: bold; border-color:#33B3FF" text="الرجوع"
      
         data-target="modal-js-example"
                                 onclick="Return"

                        class="js-modal-trigger button is-fullwidth  align align-content-center  button is-ou">الرجوع
                       
                        <i class="fas fa-home " style="margin-left: 1em">

                        </i></asp:LinkButton>
                </div>
            </div>
                </div>--%>
            </div>

        </div>

    </asp:Panel>





    <div class="row">
            <div class="col-4 col-sm-12 col-lg-4">


        <article class="panel is-info" style="background-color: white; padding-bottom: 2em;">

            <p class="panel-heading text-center " style="background-color: #3399ff;">Create New Document<i class="fa-solid fa-file-invoice-dollar"></i></p>




            <br />



            <div class="row   m-4" style="padding-left: 0em; padding-right: 0em;">
                <div class="col-12  text-center ">
                    <div class="row   m-4" style="padding-left:0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button1" ToolTip="POL" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Policy"></asp:Button>
                        </div>



                    </div>

                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="SalaryManBtn" ToolTip="PRO" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Procedure"></asp:Button>
                        </div>



                    </div>

                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button2" ToolTip="WI" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Work Instruction"></asp:Button>
                        </div>



                    </div>


                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button3" ToolTip="FRM" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Form"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button4" ToolTip="MAN" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Manual"></asp:Button>
                        </div>



                    </div>
                    
                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button5" ToolTip="RA" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Risk Assessment"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button6" ToolTip="PLN" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Plan"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button7" ToolTip="RPT" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Report"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button8" ToolTip="REC" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Record"></asp:Button>
                        </div>



                    </div>
                    <div class="row  m-4" style="padding-left: 0em; padding-right: 0em;">





                        <div class="col   text-center ">
                            <asp:Button runat="server" ID="Button9" ToolTip="SCH" Style="font: bolder; font-size: 1.5em; width: 100%;" class="btn" OnClick="SetDocTypeAndMoveOn" role="button" Text="Schedule"></asp:Button>
                        </div>


                </div>


          
                </div>
            </div>
             </article>
    </div>

        <div class="col-8 col-sm-12 col-lg-8">

              <article class="panel is-info" style="background-color: white;padding-bottom:2em;">
        <p class="panel-heading text-center" style="background-color:#3399ff;">                <asp:Label  runat ="server" ID ="PageProjectNameLbl" Text="Files List" ></asp:Label>
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
                          

                            >
            <Columns>
        

                
                
                
                 

               
                
              

                  <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="Index">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_ID" runat="server" Text='<%#Eval("Index") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   

              



                <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="FileName">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_Quansgt" runat="server" Text='<%#Eval("FileName") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   


                 <asp:TemplateField   ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label  ID="lbl_ORusys" runat="server" Text='<%#Eval("Remarks") %>' Font-Bold="true" Font-Size="Medium"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
              
           
                 
   
                
               
                
               
               

                 <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:Label ID="lbl_City" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_City"  runat="server" Text='<%#Eval("Remarks") %>'></asp:TextBox>
                           
                            </EditItemTemplate>
                        </asp:TemplateField>
    
            
                
                     <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-warning"
                                    style="Width:70%; Height:25px ; font-size:1 em"  

                            CommandArgument='<%#Eval("Index") %>' CommandName="CreateNewVirsion"


                            ID="btnNewV_Edit1" runat="server" Text="Create New Version"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>

           
                  <asp:TemplateField  >
                            <ItemTemplate>
                                <asp:Button
                                    class="js-modal-trigger button is-info is-outlined"
                                    Style="width: 25px; height: 20px"
                                    ID="btn_Edit" runat="server" Text="Edit"  CommandName="Edit" />
                            </ItemTemplate>
                              </asp:TemplateField>
                    

             <asp:TemplateField  ItemStyle-HorizontalAlign="Center" >
                    <ItemTemplate>
                        <asp:Button Font-Bold="true"
                                                                class="js-modal-trigger button  is-bold is-danger is-outlined"
                                    style="Width:40%; Height:25px"  

                            CommandArgument='<%#Eval("Index") %>' CommandName="DeleteLine"

                             OnClientClick="return confirmation();"
                            ID="btnNewVd_Edit1" runat="server" Text="Delete"  />

                    </ItemTemplate>

                         
                </asp:TemplateField>

                     
                     <asp:TemplateField  >
                            <EditItemTemplate > 
                                <asp:Button ID="btn_Update" class="js-modal-trigger button is-warning"
                                    Style="width: 35px; height: 20px; margin-right:5px" runat="server" Text="Update" CommandName="Update" />
                                <asp:Button ID="btn_Cancel" class="js-modal-trigger button is-primary "
                                    Style="width: 35px; height: 20px" runat="server" Text="Cancel" CommandName="Cancel" />
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
        </div>
   

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


           
             


                
    
      
    </form>
</body>
</html>
