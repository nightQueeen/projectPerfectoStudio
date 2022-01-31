using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DAL
{
    public class appointmentMethods
    {
        //---------GET---------
        public static DataTable GetAppointmentsForClient(int clientCode)
        {
            string com = $"select * from appointment where clientCode={clientCode}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetAppointmentsForWorker(int workerCode)
        {
            string com = $"SELECT * FROM appointment WHERE workerCode = {workerCode}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetAppointmentsByDate(DateTime dateTime)
        {
            string com = $"SELECT * FROM appointment WHERE dateOf = {dateTime}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetAppointmentsTypes()
        {
            string com = $"SELECT appointCode FROM appointment";
            return oledbhelper.GetTable(com);
        }

        //---------ADD---------
        public static void addAppointent(DateTime dateOf, int clientCode, int workerCode)
        {
            string com = "INSERT INTO Appointment(dateOf, clientCode, workerCode) VALUES ('" + dateOf + "','" + clientCode + "','" + workerCode + "')";
            oledbhelper.Execute(com);
        }
        //---------SET---------
        public static void deleteAppointment(DateTime dateOf, int clientCode)//delete appointment
        {
            string com = $"DELETE FROM Appointment WHERE dateOf = {dateOf} AND clientCode = {clientCode}";
            oledbhelper.Execute(com);
        }
        public static void updateAppointment(int appointCode, DateTime dateOf, int clientCode, int workerCode)
        {
            string com = $"UPDATE Appointment SET dateOf = {dateOf}, clientCode = {clientCode}, workerCode = {workerCode} WHERE dateOf = {dateOf} AND clientCode = {clientCode}";
            oledbhelper.Execute(com);
        }
    }
}
