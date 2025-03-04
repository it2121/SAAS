<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Main.Master" AutoEventWireup="true" CodeBehind="FinanceEditor.aspx.cs" Inherits="SAAS.Pages.FinanceEditor" %>
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
        <p class="panel-heading ">المعلومات</p>

             
            <div class="row m-2">
                     <div class="col-1">


           
                         <div class="form__group field">
     <asp:TextBox runat="server"   dir="rtl" ID="Ord"  class="form__field" type="input" placeholder="التسلسل" />

    <label for="name" class="form__label">التسلسل</label>
</div>
</div>    
                <div class="col-5">


           
                         <div class="form__group field">
     <asp:TextBox runat="server" dir="rtl" ID="PaidTo"  class="form__field" type="input" placeholder="جهة الصرف" />

    <label for="name" class="form__label">جهة الصرف</label>
</div>
</div>      
                
                <div class="col-3">


           
                         <div class="form__group field">
     <asp:TextBox runat="server" ID="Amount"   dir="rtl" class="form__field" type="input" placeholder="المبلغ" />

    <label for="name" class="form__label">المبلغ</label>
</div>
</div>              
                <div class="col-3">


           
                         <div class="form__group field">
     <asp:TextBox runat="server" ID="PaidDate"  dir="rtl"  class="form__field" type="input" placeholder="تاريخ الصرف" />

    <label for="name" class="form__label">تاريخ الصرف</label>
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


</asp:Content>
