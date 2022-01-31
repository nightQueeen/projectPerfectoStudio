using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;

namespace ProjectPS
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        bool flagIsEmpty = false;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            ErrorIsEmpty(textBoxFirstName);
            ErrorIsEmpty(textBoxLastName);
            ErrorIsEmpty(textBoxEmail);
            ErrorIsEmpty(textBoxPhoneNum);
            ErrorIsEmpty(textBoxDOB);
            if (DAL.clientMethods.IsExistsEmail(textBoxEmail.Text) && (textBoxEmail.Text != ""))//there's kfilut in the validation!!!!!!!!
            {
                Response.Write("this email was used");
            }
            if (DAL.clientMethods.IsExistsPhoneNum(textBoxPhoneNum.Text) && (textBoxPhoneNum.Text != ""))
            {
                Response.Write("this phoneNum was used");
            }
            else if ((DAL.clientMethods.IsExistsEmail(textBoxEmail.Text) == false) && (DAL.clientMethods.IsExistsPhoneNum(textBoxPhoneNum.Text) == false) && (flagIsEmpty == false))
            {
                DAL.clientMethods.AddClient(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNum.Text, textBoxEmail.Text, TextBoxPass.Text, textBoxDOB.Text);
                Response.Redirect("homePage.aspx");
            }
            flagIsEmpty = false;
        }
    }
}