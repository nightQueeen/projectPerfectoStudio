using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    class Program
    {
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
        static void Main(string[] args)
        {

            ////DateTime dt = new DateTime(2022, 01, 12);

            ////DateTime[] arrStart = StartTimeArr(dt); //14:00, 17:00
            ////DateTime[] arrEnd = EndTimeArr(dt); //16:00, 18:30

            ////int length = 90;

            ////DateTime start;
            ////DateTime end;
            ////int breakTime = 10;
            ////int AppointTimeOG = length + breakTime;
            ////int kAdd = 0;
            ////int j = 0;
            ////DateTime openingTime = new DateTime();
            ////openingTime = openingTime.AddHours(10).AddMinutes(00).AddSeconds(00);
            ////DateTime closing = new DateTime();
            ////closing = closing.AddHours(21).AddMinutes(00).AddSeconds(00);
            ////DateTime[] arrAvaliable = new DateTime[20];
            ////if (arrStart.Length > 0)
            ////{
            ////    int appointTime = AppointTimeOG;
            ////    if (arrStart[0].Hour != 10) //add avaliable hours from opening hour
            ////    {
            ////        while (openingTime.AddMinutes(appointTime).Hour < arrStart[0].Hour)
            ////        {
            ////            //Console.WriteLine("arrStart: " + arrStart[0].ToString("HH:mm"));
            ////            //Console.WriteLine("openingTime.AddMinutes: " + openingTime.AddMinutes(appointTime).ToString("HH:mm"));
            ////            //Console.WriteLine(openingTime.AddMinutes(breakTime + (AppointTimeOG * kAdd)).ToString("HH:mm"));
            ////            arrAvaliable[kAdd] = openingTime.AddMinutes(breakTime + (AppointTimeOG * kAdd));
            ////            appointTime += AppointTimeOG;
            ////            kAdd++;
            ////        }
            ////        //Console.WriteLine("=============>");

            ////    }
            ////    for (int i = 1; i < arrStart.Length; i++) //לולאה שחוזרת על עצמה מספיק פעמים בשביל לבדוק טווח פנוי בין שעות קיימות
            ////    {
            ////        j = 0 + kAdd; // arrAvaliable count times of avaliable hour
            ////        int k = 0 - kAdd; // count amount of avaliable houres at a time range

            ////        appointTime = AppointTimeOG;
            ////        start = arrStart[i]; //start time of appointment by date (10:00, 17:00, ...)
            ////        end = arrEnd[i - 1]; //end time of appointment by date (11:00, 17:30, ...)

            ////        //count avaliable hour if the time range between existed appointments is enough
            ////        while ((end.AddMinutes(appointTime).Hour <= start.Hour) && (end.AddMinutes(appointTime).Hour < closing.Hour))
            ////        {
            ////            if (start.AddMinutes(appointTime).Hour == end.Hour)
            ////            {
            ////                if (start.AddMinutes(appointTime).Minute < end.Minute) //check 
            ////                {
            ////                    k++;
            ////                    appointTime += AppointTimeOG;
            ////                }
            ////            }
            ////            else
            ////            {
            ////                k++;
            ////                appointTime += AppointTimeOG;
            ////            }
            ////        }

            ////        //Console.WriteLine(start.AddMinutes(breakTime + length));
            ////        while (1 < k)
            ////        {
            ////            arrAvaliable[j] = end.AddMinutes(breakTime + (AppointTimeOG * j));
            ////            k--;
            ////            j++;
            ////        }
            ////        //for (int m = 0; m < arrAvaliable.Length; m++)
            ////        //{
            ////        //    if (arrAvaliable[m].Hour != 0)
            ////        //    {
            ////        //        Console.WriteLine(arrAvaliable[m].ToString("HH:mm"));
            ////        //    }
            ////        //}
            ////    }
            ////    int l = 0;
            ////    int jAdd = j;
            ////    appointTime = AppointTimeOG;
            ////    //Console.WriteLine("=============>");

            ////    while (arrAvaliable[j - 1].AddMinutes(appointTime).Hour <= closing.Hour) //avaliable hours from last appointment to closing time
            ////    {
            ////        if (arrAvaliable[j - 1].AddMinutes(appointTime).Hour == closing.Hour)
            ////        {
            ////            if (arrAvaliable[j - 1].AddMinutes(appointTime).Minute == 0)
            ////            {
            ////                //Console.WriteLine(arrAvaliable[j - 1].AddMinutes(breakTime + (AppointTimeOG * l)).ToString("HH:mm"));
            ////                arrAvaliable[jAdd] = arrAvaliable[j - 1].AddMinutes(breakTime + (AppointTimeOG * l));
            ////            }
            ////        }
            ////        else
            ////        {
            ////            //Console.WriteLine(arrAvaliable[j-1].ToString("HH:mm"));
            ////            //Console.WriteLine(arrAvaliable[j - 1].AddMinutes(breakTime + (AppointTimeOG * l)).ToString("HH:mm"));
            ////            arrAvaliable[jAdd] = arrAvaliable[j - 1].AddMinutes(breakTime + (AppointTimeOG * l));
            ////        }
            ////        appointTime += AppointTimeOG;
            ////        jAdd++;
            ////        l++;

            ////    }
            ////}
            ////else //avaliable hours during the whole day
            ////{
            ////    Console.WriteLine("else");
            ////    int n = 0; // arrAvaliable count times of avaliable hour
            ////    int appointTime = AppointTimeOG;
            ////    while (openingTime.AddMinutes(appointTime) < closing)
            ////    {
            ////        //Console.WriteLine(openingTime.AddMinutes(breakTime + (AppointTimeOG * n)).ToString("HH:mm"));
            ////        arrAvaliable[n] = openingTime.AddMinutes(breakTime + (AppointTimeOG * n));
            ////        appointTime += AppointTimeOG;
            ////        n++;
            ////    }
            ////}
            ////for (int m = 0; m < arrAvaliable.Length; m++)
            ////{
            ////    if (arrAvaliable[m].Hour != 0)
            ////    {
            ////        Console.WriteLine(arrAvaliable[m].ToString("HH:mm"));
            ////    }
            ////}
            //DateTime dt = new DateTime(2022, 01, 01);

            //DateTime selectedDate = DateTime.Parse(dt.ToString("HH:mm"));
            //DataTable tbl = appointmentMethods.GetAppointmentsByDate(dt.Date);

            //foreach (DataRow dataR in tbl.Rows)
            //{
            //    Console.WriteLine(dataR["clientCode"].ToString());
            //}


            //DateTime dt = new DateTime(2022, 12, 12);
            //DateTime time = new DateTime();
            //time.AddHours(11).AddMinutes(00).AddSeconds(00);
            //appointmentMethods.addAppointent(dt, 1, 1, 3, time, "note");
            //int x = treatmentTypeMethods.GetCodeByName("גבות");
            //Console.WriteLine(x);
            //Console.WriteLine(clientMethods.GetClientIdByEmailInt("mayokatz03@gmail.com"));
        }
    }
}
