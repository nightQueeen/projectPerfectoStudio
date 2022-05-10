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
            textBoxEmail.BorderColor = System.Drawing.Color.Gray; //return border color to original color
            textBoxFirstName.BorderColor = System.Drawing.Color.Gray;
            textBoxLastName.BorderColor = System.Drawing.Color.Gray;
            textBoxPhoneNum.BorderColor = System.Drawing.Color.Gray;
        }
        bool flagIsEmpty = false;
        public void ErrorIsEmpty(TextBox txt) //check if textBox is null
        {
            if (txt.Text == "")
            {
                txt.BorderColor = System.Drawing.Color.Red;
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
            if (DAL.clientMethods.IsExistsEmail(textBoxEmail.Text) && (textBoxEmail.Text != "")) //check textBox before register
            {
                textBoxEmail.BorderColor = System.Drawing.Color.Red;
                //this email was used
            }
            if (DAL.clientMethods.IsExistsPhoneNum(textBoxPhoneNum.Text) && (textBoxPhoneNum.Text != ""))
            {
                textBoxPhoneNum.BorderColor = System.Drawing.Color.Red;
                //this phoneNum was used
            }
            else if ((DAL.clientMethods.IsExistsEmail(textBoxEmail.Text) == false) && (DAL.clientMethods.IsExistsPhoneNum(textBoxPhoneNum.Text) == false) && (flagIsEmpty == false))
            {
                textBoxEmail.BorderColor = System.Drawing.Color.LawnGreen; //all correct
                textBoxFirstName.BorderColor = System.Drawing.Color.LawnGreen;
                textBoxLastName.BorderColor = System.Drawing.Color.LawnGreen;
                textBoxPhoneNum.BorderColor = System.Drawing.Color.LawnGreen;
                DAL.clientMethods.AddClient(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNum.Text, textBoxEmail.Text, TextBoxPass.Text, textBoxDOB.Text);
                Response.Redirect("homePage.aspx");
                //send grid
            }
            flagIsEmpty = false;
        }
    }
}