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
            dropdownLoad();
            FormLoad();
            
        }
        public bool isDropdownLoad = false;
        public bool flagIsEmpty = false;
        public void FormLoad()
        {
            ename.BorderColor = System.Drawing.Color.Gray;
            enameTreatment.BorderColor = System.Drawing.Color.Gray;
            etime.BorderColor = System.Drawing.Color.Gray;

        }
        public void ErrorIsEmpty(DropDownList list) //check if string is empty
        {
            if (list.SelectedValue.ToString() == "")
            {
                Response.Write("this is empty ");
                list.BorderColor = System.Drawing.Color.Red;
                flagIsEmpty = true;
                //mark empty on form (not edesc)
            }
            else
            {
                list.BorderColor = System.Drawing.Color.Green;
                Response.Write("ok ");
            }
        }
        public static DateTime[] EndTimeArr(DateTime dt)
        {
            DateTime d = new DateTime(2022, 11, 06);
            DateTime timeOf;
            DataTable tbl = appointmentMethods.OrderHourByDate(dt.Date);
            DateTime[] arrEnd = new DateTime[tbl.Rows.Count];
            int minutesByType;
            int i = -1;
            foreach (DataRow dataR in tbl.Rows)
            {
                i++;
                int typeID = int.Parse(dataR["treatmentTypeCode"].ToString());
                //Console.WriteLine(treatmentTypeMethods.GetLengthByTreatmentID(typeID));
                minutesByType = treatmentTypeMethods.GetLengthByTreatmentID(typeID); //120 => 90

                timeOf = DateTime.Parse(dataR["timeOf"].ToString()); //14:00 => 17:00
                //Console.WriteLine(timeOf);
                arrEnd[i] = timeOf.AddMinutes(minutesByType);
            }
            return arrEnd;
        }
        public static DateTime[] StartTimeArr(DateTime dt)
        {
            DataTable tbl = appointmentMethods.OrderHourByDate(dt);
            DateTime[] arrStart = new DateTime[tbl.Rows.Count];
            int i = -1;
            foreach (DataRow dataR in tbl.Rows)
            {
                i++;
                arrStart[i] = DateTime.Parse(dataR["timeOf"].ToString());
            }
            return arrStart;
        }
        public static DateTime[] AvaliableHours(DateTime dt, int length) //check avaliable hours in existed appointment time range
        {
            DateTime[] arrStart = StartTimeArr(dt); //14:00, 17:00
            DateTime[] arrEnd = EndTimeArr(dt); //16:00, 18:30

            DateTime start;
            DateTime end;
            int breakTime = 10;
            int AppointTimeOG = length + breakTime;
            int kAdd = 0;
            int j = 0;
            DateTime openingTime = new DateTime();
            openingTime = openingTime.AddHours(10).AddMinutes(00).AddSeconds(00);
            DateTime closing = new DateTime();
            closing = closing.AddHours(21).AddMinutes(00).AddSeconds(00);
            DateTime[] arrAvaliable = new DateTime[20];
            if (arrStart.Length > 0)
            {
                int appointTime = AppointTimeOG;
                if (arrStart[0].Hour != 10) // ADD avaliable hours from opening hour
                {
                    while (openingTime.AddMinutes(appointTime).Hour < arrStart[0].Hour)
                    {
                        arrAvaliable[kAdd] = openingTime.AddMinutes(breakTime + (AppointTimeOG * kAdd));
                        appointTime += AppointTimeOG;
                        kAdd++;
                    }
                }
                for (int i = 1; i < arrStart.Length; i++) // ADD avaliable hours in free time range between appointments
                {
                    j = 0 + kAdd; // arrAvaliable count times of avaliable hour
                    int k = 0 - kAdd; // count amount of avaliable houres at a time range

                    appointTime = AppointTimeOG;
                    start = arrStart[i]; // start time of appointment by date
                    end = arrEnd[i - 1]; // end time of appointment by date

                    // count avaliable hour if the time range between existed appointments is enough
                    while ((end.AddMinutes(appointTime).Hour <= start.Hour) && (end.AddMinutes(appointTime).Hour < closing.Hour))
                    {
                        if (start.AddMinutes(appointTime).Hour == end.Hour)
                        {
                            if (start.AddMinutes(appointTime).Minute < end.Minute) // check 
                            {
                                k++;
                                appointTime += AppointTimeOG;
                            }
                        }
                        else
                        {
                            k++;
                            appointTime += AppointTimeOG;
                        }
                    }

                    while (1 < k)
                    {
                        arrAvaliable[j] = end.AddMinutes(breakTime + (AppointTimeOG * j));
                        k--;
                        j++;
                    }
                }
                int l = 0;
                int jAdd = j;
                appointTime = AppointTimeOG;

                while (arrAvaliable[j - 1].AddMinutes(appointTime).Hour <= closing.Hour) // ADD avaliable hours from last appointment to closing time
                {
                    if (arrAvaliable[j - 1].AddMinutes(appointTime).Hour == closing.Hour)
                    {
                        if (arrAvaliable[j - 1].AddMinutes(appointTime).Minute == 0)
                        {
                            arrAvaliable[jAdd] = arrAvaliable[j - 1].AddMinutes(breakTime + (AppointTimeOG * l));
                        }
                    }
                    else
                    {
                        arrAvaliable[jAdd] = arrAvaliable[j - 1].AddMinutes(breakTime + (AppointTimeOG * l));
                    }
                    appointTime += AppointTimeOG;
                    jAdd++;
                    l++;
                }
            }
            else // avaliable hours during the whole day
            {
                int n = 0; // arrAvaliable count times of avaliable hour
                int appointTime = AppointTimeOG;
                while (openingTime.AddMinutes(appointTime) < closing)
                {
                    arrAvaliable[n] = openingTime.AddMinutes(breakTime + (AppointTimeOG * n));
                    appointTime += AppointTimeOG;
                    n++;
                }
            }
            return arrAvaliable;
        }

        public void DropDownHours(string enameValue)
        {
            //DateTime selectedDate = DateTime.Parse(edate.Text);
            etime.Items.Clear();
            DateTime selectedDate = DateTime.Parse(edate.Text);
            int Length = treatmentTypeMethods.GetLengthByTreatmentName(enameValue.ToString());
            DateTime[] hours = AvaliableHours(selectedDate, Length);
            for (int i = 0; i < hours.Length; i++)
            {
                if(hours[i].Hour != 0)
                {
                    etime.Items.Add(hours[i].ToString("HH:mm"));
                }
            }
        }

        public void dropdownLoad() // add items to dropdownlists (treatment category && hours) 
        {
            if (!IsPostBack)
            {
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
            enameTreatment.Items.Clear();
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
            ErrorIsEmpty(ename);
            ErrorIsEmpty(enameTreatment);
            //ErrorIsEmpty(edate);
            ErrorIsEmpty(etime);

            int userCode = clientMethods.GetClientIdByEmailInt(Session["UserEmail"].ToString());
            string userName = clientMethods.GetNameByEmailString(Session["UserEmail"].ToString());
            int typeCode = treatmentTypeMethods.GetCodeByName(enameTreatment.SelectedValue);
            if (flagIsEmpty == false && edate.Text != "")
            {
                appointmentMethods.addAppointent(DateTime.Parse(edate.Text), userCode, 1, typeCode, DateTime.Parse(etime.SelectedValue.ToString()), edesc.Text);
                enameTreatment.Items.Clear();
                etime.Items.Clear();
                string message = " נקבע תור חדש! בתאריך " + DateTime.Parse(edate.Text).ToString("yyyy-MM-dd") + " (פרטים נוספים ניתן לראות באזור האישי באתר) ";
                sendGrid.Execute(Session["UserEmail"].ToString(), userName, message);
            }
            else
            {
                 
            }

        }

        protected void edate_TextChanged(object sender, EventArgs e)
        {
            string treatmentValue = enameTreatment.SelectedValue.ToString();
            if (enameTreatment.SelectedValue.ToString() == "")
            {
                enameTreatment.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                DropDownHours(treatmentValue);
            }
        }
    }
}