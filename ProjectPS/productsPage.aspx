<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="productsPage.aspx.cs" Inherits="ProjectPS.productsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            position: relative;
            width: 50%;
        }

        .image {
            display: block;
            width: 100%;
            height: auto;
        }

        .overlay {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            height: 100%;
            width: 100%;
            opacity: 0;
            transition: .5s ease;
            background-color: #b3d9ff;
        }

        .container:hover .overlay {
            opacity: 0.8;
        }

        .text {
            color: white;
            font-size: 20px;
            position: absolute;
            top: 50%;
            left: 50%;
            -webkit-transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            transform: translate(-50%, -50%);
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="margin-top: 110px">
        <h1>מוצרים</h1> 
        <h4> מוצרים עם הסבר מורחב וטווח מחירים</h4>
        <div class="row">
            
            <div class="col-md-4">
                        
                <div class="container">
                        <img src="images/products/oneTemp.jpg" alt="name" style="width: 80%">
                        <div class="caption">
                            <p>מפקס אותנו ומעניק אנחת רווחה ושקט נפשי.</p>
                        </div>
                        <div class="overlay">שמן אתרי עשב לימון <br> ₪35 </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="container">
                        <img src="images/products/twoTemp.jpg" alt="name" style="width: 80%">
                        <div class="caption">
                            <p>שמן מרומם, מרגיע, משחרר ממתחים, מעורר יצירתיות.</p>
                        </div>
                        <div class="overlay">שמן אתר תפוז <br> ₪35 </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="container">
                        <img src="images/products/threeTemp.jpg" alt="name" style="width: 80%">
                        <div class="caption">
                            <p>בעל ריח הדרים ייחודי ועמוק המרגיע את הנפש מאוד מאוד.</p>
                        </div>
                        <div class="overlay">שמן אתרי ברגמוט <br> ₪35 </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="container">
                        <img src="images/products/fourTemp.jpg" alt="name" style="width: 80%">
                        <div class="caption">
                            <p>נהדר בתקופות מעבר והסתגלות כמו גיל ההתבגרות או גיל המעבר.</p>
                        </div>
                        <div class="overlay">שמן אתרי קלמנטינה <br> ₪35 </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="container">
                        <img src="images/products/fiveTemp.jpg" alt="name" style="width: 80%">
                        <div class="caption">
                            <p>משרה תחושת ניקיון ורעננות, טוב לכל מצב דלקתי הזקוק לטיהור.</p>
                        </div>
                        <div class="overlay">שמן אתרי לימון <br> ₪35 </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="container">
                        <img src="images/products/sixTemp.jpg" alt="name" style="width: 80%">
                        <div class="caption">
                            <p>.גבישי מלח מים המלח בתערובת שמן אתרי לבנדר צרפתי לאווירה רגועה ונעימה באמבט חם יעניקו לעור חיוניות, ברק וגמישות</p>
                        </div>
                        <div class="overlay">מלח ארומתרפי <br> ₪40 </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
