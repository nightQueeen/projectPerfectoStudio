<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="appointments.aspx.cs" Inherits="ProjectPS.appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="/public/css/bootstrap-rtl.min.css">
    <!-- <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" /> -->
    <link rel="stylesheet" href="https://maxcdn.icons8.com/fonts/line-awesome/1.1/css/line-awesome-font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/air-datepicker/2.2.3/css/datepicker.css" />
    <link rel="stylesheet" href="/public/CSSCal.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top:80px">
        
    <div class="p-5">
        <h2 class="mt-4">קביעת תורים</h2>
        <div class="card">
            <div class="card-body p-0">
                <div id="calendar"></div>
            </div>
        </div>
    </div>

    <!-- calendar modal -->
    <div id="modal-view-event" class="modal modal-top fade calendar-modal">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-body">
                    <h4 class="modal-title"><span class="event-icon"></span><span class="event-title"></span></h4>
                    <div class="event-body"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-view-event-add" class="modal modal-top fade calendar-modal">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div id="add-event">
                    <div class="modal-body">
                        <h4>בחר/י פרטי תור</h4>
                        <div class="form-group">
                            <label>סוג תור</label>
                            <asp:DropDownList class="form-control" name="ename" AutoPostBack="true" ID="ename" runat="server" OnSelectedIndexChanged="OnIndexChange_Category">
                            </asp:DropDownList>
<%--                            <input type="text" class="form-control" name="ename">--%>
                        </div>
                         <div class="form-group">
                            <label>סוג טיפול</label>
                            <asp:DropDownList class="form-control" Visible="true" name="ename" ID="enameTreatment" runat="server">
                            </asp:DropDownList>
<%--                            <input type="text" class="form-control" name="ename">--%>
                        </div>
                        <div class="form-group">
                            <label>תאריך</label>
                            <asp:TextBox type='date' class="form-control" name="edate" ID="edate" runat="server"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>שעות פנויות</label>
                            <asp:DropDownList type='text' class="form-control" name="edate" ID="etime" runat="server"></asp:DropDownList>
                        </div>
                        <%--<div class="form-group">
                        <label>סוג תור/צבע</label>
                            <asp:DropDownList class="form-control" name="ecolor" ID="ecolor" runat="server">
                                <asp:listitem text="default" value="fc-bg-default"></asp:listitem>
                                <asp:listitem text="blue" value="fc-bg-blue"></asp:listitem>
                                <asp:listitem text="lightgreen" value="fc-bg-lightgreen"></asp:listitem>
                                <asp:listitem text="pink/red" value="fc-bg-pinkred"></asp:listitem>
                                <asp:listitem text="deep sky blue" value="fc-bg-deepskyblue"></asp:listitem>
                            </asp:DropDownList>
                        </div>--%>
                     <%--   <div class="form-group">
                            <label>סוג תור/לוגו</label>
                            <asp:DropDownList class="form-control" name="eicon" ID="eicon" runat="server">
                                <asp:listitem text="cog" value="cog"></asp:listitem>
                                <asp:listitem text="group" value="group"></asp:listitem>
                                <asp:listitem text="suitcase" value="suitcase"></asp:listitem>
                                <asp:listitem text="calendar" value="calendar"></asp:listitem>
                            </asp:DropDownList>
                        </div>--%>
                        <div class="form-group">
                            <label>הערות</label>
                            <asp:TextBox class="form-control" name="edesc" ID="edesc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button type="submit" class="btn btn-primary" OnClick="ButtonSave_Click" ID="ButtonSave" runat="server" Text="שמירה" />
                        <asp:Button type="button" class="btn btn-primary" data-dismiss="modal" ID="ButtonClose" runat="server" Text="סגירה" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.22.2/moment.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.9.0/fullcalendar.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/air-datepicker/2.2.3/js/datepicker.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/air-datepicker/2.2.3/js/i18n/datepicker.en.js"></script>

    <script src="/public/JSCal.js"></script>
    <script src="/public/js/bootstrap.bundle.min.js"></script>
</asp:Content>
