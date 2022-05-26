<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="imagesPage.aspx.cs" Inherits="ProjectPS.imagesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:110px">
        <h2 style="text-align:center">גלריית תמונות</h2>
        <p style="text-align:center">☴</p>
        <p>לחצ/י על תמונה כדי להגדיל</p>
        <div class="row">
            <div class="col-md-4">
                <div class="thumbnail">
                    <a href="images/gallery/galleryNails.jpg" target="_blank">
                        <img src="images/gallery/galleryNails.jpg" alt="name" style="width: 90%">
                        <div class="caption">
                            <p>✧✧✧</p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail">
                    <a href="images/gallery/galleryNails2.jpg" target="_blank">
                        <img src="images/gallery/galleryNails2.jpg" alt="name" style="width: 90%">
                        <div class="caption">
                            <p>✧✧✧</p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail">
                    <a href="images/gallery/galleryNails3.jpeg" target="_blank">
                        <img src="images/gallery/galleryNails3.jpeg" alt="name" style="width: 90%">
                        <div class="caption">
                            <p>✧✧✧</p>
                        </div>
                    </a>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="thumbnail">
                    <a href="images/gallery/galleryNails4.jpg" target="_blank">
                        <img src="images/gallery/galleryNails4.jpg" alt="name" style="width: 90%">
                        <div class="caption">
                            <p>✧✧✧</p>
                        </div>
                    </a>
                </div>
            </div>
                        <div class="col-md-4">
                <div class="thumbnail">
                    <a href="images/gallery/galleryNails5.jpg" target="_blank">
                        <img src="images/gallery/galleryNails5.jpg" alt="name" style="width: 90%">
                        <div class="caption">
                            <p>✧✧✧</p>
                        </div>
                    </a>
                </div>
            </div>
                        <div class="col-md-4">
                <div class="thumbnail">
                    <a href="images/gallery/galleryNails6.jpg" target="_blank">
                        <img src="images/gallery/galleryNails6.jpg" alt="name" style="width: 90%">
                        <div class="caption">
                            <p>✧✧✧</p>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
