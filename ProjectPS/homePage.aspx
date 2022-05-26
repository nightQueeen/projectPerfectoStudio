<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="ProjectPS.homePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--    <link rel="stylesheet" href="/public/css/bootstrap-rtl.min.css">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top:110px">
        <h1 style="text-align: center">דף בית</h1>
                <p style="text-align:center">☴</p>
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
                        <img src="images/carussel/wideNails3.jpg" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>לק ג'ל קלאסי</h5>
                            <p>הנחה של 15% בקנייה ראשונה!</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="images/carussel/wideNails2.jpg" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>לק ג'ל</h5>
                            <p>הנחה של 15% בקנייה ראשונה!</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="images/carussel/wideNails1.jpg" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>לק עם בנייה</h5>
                            <p>הנחה של 15% בקנייה ראשונה!</p>
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
