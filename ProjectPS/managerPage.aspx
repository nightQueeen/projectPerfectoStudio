<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="managerPage.aspx.cs" Inherits="ProjectPS.managerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container-fluid" style="margin-top: 110px">
        <div class="row justify-content-md-center">
            <div class="col-lg-5">
                <h1>דף עריכה</h1>
                <h3>(למנהלת בלבד)</h3>
                <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
                <div class="container p-3 my-3 border">
                                    <div class="form-group">
                    <label for="textBoxDOB">תאריך תור</label>
                    <asp:TextBox type="date" class="form-control" ID="textBoxDOB" runat="server"></asp:TextBox>
                </div>
                <%--                <div>
                    <asp:DropDownList ID="DropDownDate" runat="server"></asp:DropDownList>
                </div>--%>
                <asp:Button ID="ButtonSend" runat="server" OnClick="ButtonSend_Click" Text="אישור" />
                <asp:Label ID="LabelGridNull" Visible="false" runat="server" Text="אין תורים בתאריך זה"></asp:Label>

                </div>

                <br />
                <div>
                    <asp:GridView ID="dataGridAppoint" OnSelectedIndexChanged="dataGridAppoint_SelectedIndexChanged" runat="server"></asp:GridView>
                </div>
                <br />

                <div class="container p-3 my-3 border">
                    <div class="form-group">
                        <label for="textBoxDOB2">תאריך תור</label>
                        <asp:TextBox type="date" class="form-control" ID="textBoxDOB2" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="ButtonSend2" runat="server" OnClick="ButtonSend2_Click" Text="אישור" />
                    <asp:Label ID="LabelGridDeleteNull" Visible="false" runat="server" Text="אין תורים בתאריך זה"></asp:Label>

                    <br />
<%--                    <div class="form-group">
                        <label for="DropDownClients">שם לקוח</label>
                        <asp:DropDownList ID="DropDownClients" runat="server"></asp:DropDownList>
                    </div>--%>
                    <asp:Button type="button" class="btn btn-danger" ID="ButtonDelete" runat="server" Text="ביטול תור" />
                    <asp:Button type="button" class="btn btn-success" ID="ButtonAdd" runat="server" Text="הוספת תור" />

                </div>
                <br />
                <div>
                    <asp:GridView ID="GridViewDelete" runat="server"></asp:GridView>
                </div>

            </div>
        </div>
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
