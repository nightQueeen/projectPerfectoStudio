<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="clientPage.aspx.cs" Inherits="ProjectPS.clientPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top:110px">
        <h1>אזור אישי</h1>
        <div class="row">
            <div class="container p-3 my-3 border">
                <h3>שלום</h3>
                <asp:Label ID="clientNameLable" runat="server" Text="name"></asp:Label>

                <div class="container p-3 my-3 bg-primary">
                    <p style="color:white">תורים:</p>
                    <div class="container">
                        <asp:GridView ID="GridClientAppiont" BackColor="White" runat="server"></asp:GridView>
                    </div>
                </div>
                <asp:Button type="button" class="btn btn-danger" ID="Button1" runat="server" Text="התנתקות" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
