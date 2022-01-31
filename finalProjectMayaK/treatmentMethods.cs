using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DAL
{
    public class treatmentMethods
    {
        //---------GET---------
        public static DataTable GetTreatmentCategoryName()
        {
            string com = $"SELECT categoryName FROM TreatmentCategory";
            return oledbhelper.GetTable(com);
        }

        //---------ADD---------
        //public static void addAppointent(int appointCode, DateTime dateOf, int clientCode, int workerCode)
        //{
        //    string com = "INSERT INTO Appointment(appointCode, dateOf, clientCode, workerCode) VALUES ('" + appointCode + "','" + dateOf + "','" + clientCode + "','" + workerCode + "')";
        //    oledbhelper.Execute(com);
        //}
        //---------SET---------
        //public static void deleteAppointment(DateTime dateOf, int clientCode)//delete appointment
        //{
        //    string com = $"DELETE FROM Appointment WHERE dateOf = {dateOf} AND clientCode = {clientCode}";
        //    oledbhelper.Execute(com);
        //}
    }
}
