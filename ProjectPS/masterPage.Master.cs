using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectPS
{
    public partial class masterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isManager"] != null) //check if client is manager
            {
                if (Session["isManager"].ToString() == "true")
                {
                    managerPage.Visible = true;
                }
                else
                {
                    managerPage.Visible = false;
                }
            }
            if (Session["isLoggedIn"] != null) //check if client is logged in
            {
                if (Session["isLoggedIn"].ToString() == "true")
                {
                    dropdownLogin.Visible = false;
                    dropdownRegister.Visible = false;
                    appointPage.Visible = true;
                    //dropdownMenuButton.Text = Session["UserName"].ToString();
                }
                else
                {
                    dropdownLogin.Visible = true;
                    dropdownRegister.Visible = true;
                    appointPage.Visible = false;
                    dropdownMenuButton.Text = "משתמש";
                }
            }
        }
    }
}