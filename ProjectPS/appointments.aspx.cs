using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using DAL;
namespace ProjectPS
{
    public partial class appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //add items to dropdownlist (appointment type)
            DataTable data = appointmentMethods.GetAppointmentsTypes();
            foreach (DataRow dataR in data.Rows)
            {
                ename.Items.Add(dataR[0].ToString());
            }
            //ename.DataBind();
        }
    }
}