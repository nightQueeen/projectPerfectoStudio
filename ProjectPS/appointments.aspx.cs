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
            enameTreatment.Items.Clear();
            dropdownLoad();
        }
        public bool isDropdownLoad = false;
        public bool flagIsEmpty = false;
        public void ErrorIsEmpty(string txt) //check is string empty?
        {
            if (txt == "")
            {
                Response.Write("this is empty ");
                flagIsEmpty = true;
                //mark empty on form (not edesc)
            }
            else
            {
                Response.Write("ok ");
            }
        }
        public void dropdownLoad()
        { 
            if(!IsPostBack)
            {
                //add items to dropdownlist (treatment category)
                //edate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataTable data = treatmentCategoryMethods.GetAllCategoryNames();
                foreach (DataRow dataR in data.Rows)
                {
                    ename.Items.Add(dataR[0].ToString());
                }
            }
        }
        protected void OnIndexChange_Category(object sender, EventArgs e)
        {
            //add items to dropdownlist (treatment type)
            string x = ename.SelectedValue.ToString(); //selected value from category dropdownlist
            int categoryID = treatmentCategoryMethods.GetCategoryIDByName2(x);//get selected value's ID

            DataTable dataT = treatmentTypeMethods.GetTreatmentTypeByCategoryID(categoryID);
            //table of treatment types with the selected value's ID
            foreach (DataRow dataR in dataT.Rows)
            {
                enameTreatment.Items.Add(dataR[0].ToString());
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            ErrorIsEmpty(ename.Text);
            ErrorIsEmpty(enameTreatment.Text);
            ErrorIsEmpty(edate.Text);
            ErrorIsEmpty(etime.Text);
            DateTime d = new DateTime(2022, 11, 6, 17, 0, 0);
            //ErrorIsEmpty(edesc.Text);
            if (flagIsEmpty == false)
            {
                DataTable data = appointmentMethods.GetAppointmentsByDate_Time(d);
                if (data.Rows.Count == 0)
                {
                    
                    //appointmentMethods.addAppointent(d, )
                }
            }
            else
            {

            }

        }

        //private class tempo
        //{
        //    private string code;
        //    private string desc;

        //    public tempo(string code, string desc)
        //    {
        //        this.code = code;
        //        this.desc = desc;
        //    }
        //    public override string ToString()
        //    {
        //        return desc;
        //    }
        //    public string Code
        //    {
        //        get
        //        { return code; }

        //    }
        //}
    }
}