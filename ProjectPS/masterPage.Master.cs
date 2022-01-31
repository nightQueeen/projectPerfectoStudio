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
            if (Session["isManager"] != null)
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
            if (Session["isLoggedIn"] != null)
            {
                if (Session["isLoggedIn"].ToString() == "true")
                {
                    dropdownLogin.Visible = false;
                    dropdownRegister.Visible = false;
                }
                else
                {
                    dropdownLogin.Visible = true;
                    dropdownRegister.Visible = true;
                }
            }
        }
    }
}