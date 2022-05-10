<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="ProjectPS.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="container-fluid" style="margin-top:110px">
        <div class="row justify-content-md-center">
            <div class="col-lg-5">
                <h1>הרשמה
                </h1>
                <div class="form-row">
                    <div class="col">
                        <label class="col-form-label" for="textBoxFirstName">שם פרטי</label>
                        <asp:TextBox type="text" class="form-control" ID="textBoxFirstName" placeholder="הכנס/י שם פרטי" runat="server"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label class="col-form-label" for="textBoxLastName">שם משפחה</label>
                        <asp:TextBox type="text" class="form-control" ID="textBoxLastName" placeholder="הכנס/י שם משפחה" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="textBoxEmail">כתובת אימייל</label>
                    <asp:TextBox type="email" class="form-control" ID="textBoxEmail" aria-describedby="emailHelp" placeholder="הכנסת אימייל" runat="server"></asp:TextBox>
                    <small id="emailHelp" class="form-text text-muted">לא נשתף את כתובת האימייל שלך במקום אחר.</small>
                </div>
                <div class="form-group">
                    <label for="textBoxPhoneNum" runat="server">מספר טלפון</label>
                    <asp:TextBox class="form-control" ID="textBoxPhoneNum" placeholder="הכנס/י מספר טלפון" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="TextBoxPass">סיסמה</label>
                    <asp:TextBox type="password" class="form-control" ID="TextBoxPass" placeholder="הכנס/י סיסמה" runat="server"></asp:TextBox>
                </div>
 
                <div class="form-group">
                    <label for="textBoxDOB">תאריך לידה</label>
                    <asp:TextBox type="date" class="form-control" ID="textBoxDOB" placeholder="הכנס/י תאריך לידה" runat="server"></asp:TextBox>
                </div>
                <div class="form-check">
                    <asp:CheckBox type="checkbox" class="form-check-input" ID="CheckBoxRegister" runat="server" />
                    <label class="form-check-label" for="CheckBoxRegister">סמנ/י בשביל לקבל התראות באימייל</label>
                </div>

                <br />
                <asp:Button class="btn btn-primary" ID="Submit" runat="server" OnClick="Button1_Click" Text="הרשמה" />
            </div>
        </div>
    </div>
</asp:Content>
