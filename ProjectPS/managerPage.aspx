<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="managerPage.aspx.cs" Inherits="ProjectPS.managerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row justify-content-md-center">
            <div class="col-lg-5">
                <h1>דף עריכה</h1>
                <h3>(למנהלת בלבד)</h3>
                <div class="form-group">
                    <label for="textBoxDOB">תאריך תור</label>
                    <asp:TextBox type="date" class="form-control" ID="textBoxDOB" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Table ID="TableAppointments" runat="server"></asp:Table>
                </div>
                <asp:Button ID="ButtonDelete" runat="server" Text="מחיקה" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
