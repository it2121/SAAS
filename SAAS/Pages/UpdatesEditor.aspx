<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="UpdatesEditor.aspx.cs" Inherits="SAAS.Pages.UpdatesEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>

        .form__group {
  position: relative;
  padding: 20px 0 0;
  width: 100%;
}

.form__field {
  font-family: inherit;
  width: 100%;
  border: none;
  border-bottom: 2px solid #9b9b9b;
  outline: 0;
  font-size: 17px;
  color: #000;
  padding: 7px 0;
  background: transparent;
  transition: border-color 0.2s;
}

.form__field::placeholder {
  color: transparent;
}

.form__field:placeholder-shown ~ .form__label {
  font-size: 17px;
  cursor: text;
  top: 20px;
}

.form__label {
  position: absolute;
  top: 0;
  display: block;
  transition: 0.2s;
  font-size: 17px;
  color: #9b9b9b;
  pointer-events: none;
}

.form__field:focus {
  padding-bottom: 6px;
  font-weight: 700;
  border-width: 3px;
  border-image: linear-gradient(to right, #116399, #38caef);
  border-image-slice: 1;
}

.form__field:focus ~ .form__label {
  position: absolute;
  top: 0;
  display: block;
  transition: 0.2s;
  font-size: 17px;
  color: #38caef;
  font-weight: 700;
}

/* reset input */
.form__field:required, .form__field:invalid {
  box-shadow: none;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <asp:ScriptManager ID="ScriptManager11" runat="server"></asp:ScriptManager>
      <asp:Panel runat="server" ID="ButtonsBar" >
            <div class="row " style="margin-bottom:1em">
    
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

                      


                       
        
                    
                </div>
            </div>

        </div>
            </asp:Panel>


        <article class="panel is-info" style="background-color: white;">
        <p class="panel-heading ">معلومات قيد الشراء</p>

             
            <div class="row m-2">

                <div class="col-1">


           
                         <div class="form__group field">
     <asp:TextBox runat="server" ID="Ord"  dir="rtl"  class="form__field" type="input" placeholder="التسلسل" />

    <label for="name" class="form__label">التسلسل</label>
</div>
</div>     

                <div class="col-5">


           
                         <div class="form__group field">
     <asp:TextBox runat="server" ID="TheUpdate"  dir="rtl"  class="form__field" type="input" placeholder="التحديث" />

    <label for="name" class="form__label">التحديث</label>
</div>
</div>      
                
                <div class="col-6">


           
                         <div class="form__group field">
     <asp:TextBox runat="server" ID="UpdateDate"  dir="rtl"  class="form__field" type="input" placeholder="التاريخ" />

    <label for="name" class="form__label">التاريخ</label>
</div>
</div>              
                <div class="col-12">


           
                         <div class="form__group field">
     <asp:TextBox runat="server" ID="Notes"  dir="rtl"  class="form__field" type="input" placeholder="الملاحظات" />

    <label for="name" class="form__label">الملاحظات</label>
</div>
</div>
    <div class="col-12">


           
                         <div class="form__group field">
<asp:DropDownList  class="form__field mt-2 is-large" Font-Size="XX-Large" ID="DropDownList1" runat="server" onchange="SetDropDownListColor(this);">
    <asp:ListItem style="background-color: #ffffff !important;"  Value="#ffffff">#ffffff</asp:ListItem>
    <asp:ListItem style="background-color: #ffd257 !important;" Value="#ffd257">#ffd257</asp:ListItem>
    <asp:ListItem style="background-color: #ff7a7a !important;" Value="#ff7a7a">#ff7a7a</asp:ListItem>
    <asp:ListItem style="background-color: #a8b4ff !important;" Value="#a8b4ff">#a8b4ff</asp:ListItem>
    <asp:ListItem style="background-color: #a8fff3 !important;" Value="#a8fff3">#a8fff3</asp:ListItem>
    <asp:ListItem style="background-color: #ed47ff !important;" Value="#ed47ff">#ed47ff</asp:ListItem>
    <asp:ListItem style="background-color: #4eff47 !important;" Value="#4eff47">#4eff47</asp:ListItem>
</asp:DropDownList>
</div>
</div>


   



</div>
          
<hr />


     

      <div class="row m-2">
           
                   <div class="col-md-12 text-center ">

              <asp:Button runat="server" ID="CreateBtn" style="width:20em" OnClick="CreateItem" class="button is-primary text-center " Text="اضافة"></asp:Button>
          </div>

      </div>


    
<hr />    
      

        <div class="row m-2">
           <div class="col-md-12 text-center ">
              <asp:Button runat="server" Visible="false" 
                   UseSubmitBehavior="true" 
    OnClientClick="return confirmation();"  ID="DelBtn" style="width:20em" OnClick="DelProv" class="button is-danger text-center" Text="حذف نهائياً"></asp:Button>
          </div>
          </div>
        <br />
    </article>

    <script>function confirmation() {
            return confirm("هل انت متاكد, سوف تحذف البيانات نهائياً?");
        }</script>



    <script>

        function SetDropDownListColor(ddl) {
            for (var i = 0; i < ddl.options.length; i++) {
                if (ddl.options[i].selected) {
                    switch (i) {
                        case 0:
                            ddl.style.backgroundColor = '#ffffff';
                            return;

                        case 1:
                            ddl.style.backgroundColor = '#ffd257';
                            return;

                        case 2:
                            ddl.style.backgroundColor = '#ff7a7a';
                            return;

                        case 3:
                            ddl.style.backgroundColor = '#a8b4ff';
                            return;

                        case 4:
                            ddl.style.backgroundColor = '#a8fff3';
                            return;
                        case 5:
                            ddl.style.backgroundColor = '#ed47ff';
                            return;
                        case 6:
                            ddl.style.backgroundColor = '#4eff47';
                            return;
                    }
                }
            }
        }

    </script>



</asp:Content>
