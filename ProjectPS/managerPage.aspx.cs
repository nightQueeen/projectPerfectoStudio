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
    public partial class managerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            dataGridAppoint.Visible = true;
            if (textBoxDOB.Text != "")
            {
                LabelGridNull.Visible = false;
                DateTime d = DateTime.Parse(textBoxDOB.Text);
                //TimeSpan ts = new TimeSpan(00, 00, 00);
                //d = d.Date + ts;
                //DateTime dt = new DateTime(2022, 11, 06, 00, 00, 00);
                dataGridAppoint.DataSource = null;
                //dataGridAppoint.DataSource = DAL.appointmentMethods.GetAllAppointments();
                dataGridAppoint.DataSource = DAL.appointmentMethods.GetAppointmentsByDate(d);
                dataGridAppoint.DataBind();
                if (dataGridAppoint.Rows.Count == 0)
                {
                    LabelGridNull.Visible = true;
                    dataGridAppoint.Visible = true;

                }
            }
            else
            {
                LabelGridNull.Visible = true;
            }
            //Label1.Text = d.ToString();
            //dataGridAppoint.DataSource = DAL.treatmentTypeMethods.GetTreatmentInfoByID(1);

        }

        protected void dataGridAppoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ButtonDelete.Visible = true;

        }

        protected void ButtonSend2_Click(object sender, EventArgs e)
        {
            GridViewDelete.Visible = true;
            if (textBoxDOB2.Text != "")
            {
                LabelGridDeleteNull.Visible = false;
                DateTime d = DateTime.Parse(textBoxDOB2.Text);
                GridViewDelete.DataSource = null;
                GridViewDelete.DataSource = DAL.appointmentMethods.GetAppointmentsByDate(d);
                GridViewDelete.DataBind();
                if (GridViewDelete.Rows.Count == 0)
                {
                    LabelGridDeleteNull.Visible = true;
                    GridViewDelete.Visible = false;

                }
            }

        }
    }
}