using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace ProjectPS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool isLoggedIn = false;
        bool flagIsEmpty = false;

        string managerEmail = "mayakatz03@gmail.com";
        public void ErrorIsEmpty(TextBox txt)
        {
            if (txt.Text == "")
            {
                Response.Write("this is empty ");
                flagIsEmpty = true;
            }
            else
            {
                Response.Write("ok ");
            }
        }
        protected void SubmitLogin_Click(object sender, EventArgs e)
        {
            ErrorIsEmpty(TextBoxEmail);
            ErrorIsEmpty(TextBoxPasswordLogin);
            if (DAL.clientMethods.UserLoginEmailPass(TextBoxEmail.Text, TextBoxPasswordLogin.Text) == true)
            {
                Response.Write("Ok");
                if (TextBoxEmail.Text == managerEmail)
                {
                    Session["isManager"] = "true";
                }
                else
                {
                    Session["isManager"] = "false";
                }
                Session["isLoggedIn"] = "true";
                Response.Redirect("homePage.aspx");
                isLoggedIn = true;
            }
            else if (DAL.clientMethods.IsExistsEmail(TextBoxEmail.Text) == false)
            {
                Response.Write("אימייל לא קיים");
                Session["isLoggedIn"] = "false";

            }
            else
            {
                Response.Write("סיסמה או אימייל לא נכונים");
                Session["isLoggedIn"] = "false";
            }
        }
    }
}