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
    public partial class clientPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

                //if (Session["isLoggedIn"].ToString() == "true")  Session["UserEmail"].ToString()
                //{
                //int clientID = int.Parse(data.ToString());
                //clientNameLable.Text = Session["UserName"].ToString();
                //GridClientAppiont.DataSource = DAL.appointmentMethods.GetAppointmentsForClient(clientID);
                //}
                //else
                //{
                //    clientNameLable.Text = "name";
                //    GridClientAppiont.DataSource = null;
                //}
                getClientInfo(GridClientAppiont, clientNameLable);
        }
        public void getClientInfo(GridView GridClientAppiont, Label clientNameLable) //use DAL to get client's info and update client's table
        {
            if (Session["UserEmail"] != null)
            {
                DataTable data = DAL.clientMethods.GetClientIdByEmail(Session["UserEmail"].ToString());
                foreach (DataRow datarow in data.Rows)
                {
                    foreach (var item in datarow.ItemArray)
                    {
                        int clientID = int.Parse(item.ToString());
                        GridClientAppiont.DataSource = DAL.appointmentMethods.GetAppointmentsForClient(clientID);
                        GridClientAppiont.DataBind();
                    }
                }
                clientNameLable.Text = Session["UserName"].ToString();
            }

            //clientNameLable.Text = Session["UserName"].ToString();
        }
    }
}