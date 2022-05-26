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
            if (textBoxDOB.Text != "") //input appointments info by DAL and recived dateTime
            {
                LabelGridNull.Visible = false;
                DateTime d = DateTime.Parse(textBoxDOB.Text);

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
            if (textBoxDOB2.Text != "" && DropDownEmail.SelectedValue == "")//input appointments info by DAL and recived dateTime
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
            else if (textBoxDOB2.Text != "" && DropDownEmail.SelectedValue != "")
            {
                LabelGridDeleteNull.Visible = false;
                DateTime d = DateTime.Parse(textBoxDOB2.Text);
                DateTime time = DateTime.Parse(DropDownEmail.SelectedValue.ToString());

                //DataTable appointmentsByDateAndName = DAL.appointmentMethods.GetAllByDateAndID(d, int.Parse(DropDownEmail.SelectedValue.ToString()));

                GridViewDelete.DataSource = null;
                GridViewDelete.DataSource = DAL.appointmentMethods.GetAllByDateAndTime(d.Date, DateTime.Parse(time.ToString("HH:mm")));
                GridViewDelete.DataBind();
                if (GridViewDelete.Rows.Count == 0)
                {
                    LabelGridDeleteNull.Visible = true;
                    GridViewDelete.Visible = false;
                }
                
            }

        }

        protected void textBoxDOB2_TextChanged(object sender, EventArgs e)
        {
            DropDownEmail.Items.Clear();
            DateTime selectedDate = DateTime.Parse(textBoxDOB2.Text);
            DataTable tbl = appointmentMethods.GetAppointmentsByDate(selectedDate.Date);

            if (tbl.Rows.Count == 0)
            {
                LabelGridDeleteNull.Visible = true;
                GridViewDelete.Visible = false;
            }
            else
            {
                foreach (DataRow dataR in tbl.Rows)
                {
                    LabelGridDeleteNull.Visible = false;
                    GridViewDelete.Visible = true;
                    DateTime timeOf = DateTime.Parse(dataR["timeOf"].ToString());
                    DropDownEmail.Items.Add(timeOf.ToString("HH:mm"));
                }
            }

        }

        protected void ButtonDelete_Click(object sender, EventArgs e) // delete appointment
        {
            if (textBoxDOB2.Text != "" && DropDownEmail.SelectedValue != "")
            {
                if (GridViewDelete.Rows.Count != 0)
                {                    
                    DateTime date = DateTime.Parse(textBoxDOB2.Text);
                    DateTime timeOf = DateTime.Parse(DropDownEmail.SelectedValue.ToString());
                    appointmentMethods.deleteAppointment(date.Date, DateTime.Parse(timeOf.ToString("HH:mm")));
                    LabelGridDeleteNull.Visible = false;
                    GridViewDelete.Visible = false;

                }
                else
                {
                    LabelGridDeleteNull.Visible = true;
                }
            }
        }
    }
}