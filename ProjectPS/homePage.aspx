<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="ProjectPS.homePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--    <link rel="stylesheet" href="/public/css/bootstrap-rtl.min.css">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top:110px">
        <h1 style="text-align: center">דף בית</h1>
        <br />
        <div id="carouselExampleInterval" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
                <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
            </ol>
            <div id="carouselExampleFade" class="carousel slide carousel-fade" data-ride="carousel">
                <!-- Wrapper for slides -->

                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="images/nailsWideTemp.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>תמונה ראשונה</h5>
                            <p>טקסט טקסט טקסט</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="images/nailsWide2Temp.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>תמונה שנייה</h5>
                            <p>טקסט טקסט טקסט</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="images/nailsWide3Temp.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>תמונה שלישית</h5>
                            <p>טקסט טקסט טקסט</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="carousel-control-prev" href="#carouselExampleInterval" role="button" data-slide="next">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleInterval" role="button" data-slide="prev">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
</asp:Content>
