<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectPS.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="row justify-content-md-center">
            <div class="col-lg-5">
                <h1>כניסה</h1>
                <div class="form-group">
                    <label for="<%= TextBoxEmail.ClientID %>">כתובת אימייל</label>
                    <asp:TextBox type="email" class="form-control" ID="TextBoxEmail" aria-describedby="emailHelp" placeholder="הכנסת אימייל" runat="server"></asp:TextBox>

                </div>
                <div class="form-group">
                    <label for="exampleInputPassword1">סיסמה</label>
                    <asp:TextBox type="password" class="form-control" ID="TextBoxPasswordLogin" placeholder="סיסמה" runat="server"></asp:TextBox>
                </div>
                <br />
                <asp:Button class="btn btn-primary" ID="Submit" runat="server" OnClick="SubmitLogin_Click" Text="כניסה" />
            </div>
        </div>
    </div>
</asp:Content>
