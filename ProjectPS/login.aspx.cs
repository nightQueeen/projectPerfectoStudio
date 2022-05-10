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
            TextBoxEmail.BorderColor = System.Drawing.Color.Gray;
            TextBoxPasswordLogin.BorderColor = System.Drawing.Color.Gray;
        }
        //trxfdgjh
        bool isLoggedIn = false;
        bool flagIsEmpty = false;

        string managerEmail = "mayakatz03@gmail.com";
        public void ErrorIsEmpty(TextBox txt)
        {
            if (txt.Text == "")
            {
                //Response.Write("this is empty ");
                txt.BorderColor = System.Drawing.Color.Red;
                flagIsEmpty = true;
            }
            else
            {
                Response.Write("ok ");
                flagIsEmpty = false;
            }
        }
        protected void SubmitLogin_Click(object sender, EventArgs e)
        {
            ErrorIsEmpty(TextBoxEmail);
            ErrorIsEmpty(TextBoxPasswordLogin);

            if (flagIsEmpty == false) //check if the textBox arent empty
            {
                if (DAL.clientMethods.IsExistsEmail(TextBoxEmail.Text) == true)//check if email is registered
                {
                    TextBoxEmail.BorderColor = System.Drawing.Color.Green;

                    if (DAL.clientMethods.UserLoginEmailPass(TextBoxEmail.Text, TextBoxPasswordLogin.Text) == true)//check if password match email
                    {
                        TextBoxPasswordLogin.BorderColor = System.Drawing.Color.Green;
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
                        isLoggedIn = true;
                        Session["UserName"] = DAL.clientMethods.GetNameByEmail(TextBoxEmail.Text);
                        Session["UserEmail"] = TextBoxEmail.Text;
                        Response.Redirect("homePage.aspx");
                    }
                    else
                    {
                        //password incorrect
                        TextBoxEmail.BorderColor = System.Drawing.Color.LawnGreen;
                        TextBoxPasswordLogin.BorderColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    //email incorrect/doesnt exist
                    TextBoxEmail.BorderColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //email or password empty
            }



            //=========================>>
            //if (DAL.clientMethods.IsExistsEmail(TextBoxEmail.Text) == true)
            //{

            //    if ((DAL.clientMethods.UserLoginEmailPass(TextBoxEmail.Text, TextBoxPasswordLogin.Text) == true) && (flagIsEmpty == false))
            //    {

            //        Response.Write("Ok");
            //        if (TextBoxEmail.Text == managerEmail)
            //        {
            //            Session["isManager"] = "true";
            //        }
            //        else
            //        {
            //            Session["isManager"] = "false";
            //        }
            //        Session["isLoggedIn"] = "true";
            //        isLoggedIn = true;
            //        Session["UserName"] = DAL.clientMethods.GetNameByEmail(TextBoxEmail.Text);
            //        Session["UserEmail"] = TextBoxEmail.Text;
            //        Response.Redirect("homePage.aspx");

            //    }
            //}
            //else if (DAL.clientMethods.IsExistsEmail(TextBoxEmail.Text) == false)
            //{
            //    Response.Write("אימייל לא קיים");
            //    Session["isLoggedIn"] = "false";
            //}
            //else
            //{
            //    Response.Write("סיסמה או אימייל לא נכונים");
            //    Session["isLoggedIn"] = "false";
            //}
        }
    }
}