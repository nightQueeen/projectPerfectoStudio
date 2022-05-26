using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;

namespace ProjectPS
{

    public class ImproperCalendarEvent
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool allDay { get; set; }
        public string className { get; set; }
        public string icon { get; set; }

    }

    public partial class JsonEvents : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
      

            // appointCode	dateOf	clientCode	workerCode	lengthOf


            //Response.ContentType = "text/plain";
            List<ImproperCalendarEvent> tasksList = new List<ImproperCalendarEvent>();
            var appointments = appointmentMethods.GetAppointmentsForClient(1);
            foreach (DataRow row in appointments.Rows)
            {

                DateTime start = row.Field<DateTime>("dateOf");
                int length = treatmentTypeMethods.GetLengthByTreatmentID(row.Field<int>("treatmentTypeCode"));
                DateTime end = start.AddMinutes(length);
                string startString = String.Format("{0:s}", start);
                string endString = String.Format("{0:s}", end);


                tasksList.Add(new ImproperCalendarEvent
                {
                    id = row.Field<int>("appointCode"),
                    title = "treatment",

                    start = startString, //"2021-12-23T11:30:00", String.Format("{0:s}", start),
                    end = endString, //"2021-12-23T12:30:00", String.Format("{0:s}", end),

                    description = "description",
                    allDay = false,
                    className= "fc-bg-default",
                    icon="circle"
                }) ;
            }

            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(tasksList);

            
            sJSON = @"
            [
				{
					title: 'Barber',
					description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
					start: '2020-05-05',
					end: '2020-05-05',
					className: 'fc-bg-default',
					icon: 'circle'
				},
				{
					title: 'Baby Shower',
					description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
					start: '2020-08-13',
					end: '2020-08-14',
					className: 'fc-bg-default',
					icon: 'child'
				},
				{
					title: 'Dentist',
					description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras eu pellentesque nibh. In nisl nulla, convallis ac nulla eget, pellentesque pellentesque magna.',
					start: '2020-12-29T11:30:00',
					end: '2020-12-29T012:30:00',
					className: 'fc-bg-blue',
					icon: 'medkit',
					allDay: false
				}
			]";
            //Write JSON to response object
            Response.Write(sJSON);
    
            Response.End();
        }
    }
}