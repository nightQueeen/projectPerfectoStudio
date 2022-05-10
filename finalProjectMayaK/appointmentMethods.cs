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
        public static DataTable GetAllAppointments() //get all of the appointments
        {
            string com = $"SELECT * FROM Appointment";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetAppointmentsForClient(int clientCode) //get by client's name
        {
            string com = $"select * from Appointment where clientCode={clientCode}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetAppointmentsForWorker(int workerCode) //get by worker's name
        {
            string com = $"SELECT * FROM Appointment WHERE workerCode = {workerCode}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetAppointmentsByDate(DateTime dt) // get by date
        {
            string com = $"SELECT * FROM Appointment WHERE dateOf = #{dt.ToString("yyyy-MM-dd")}#";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetAppointmentsByDate_Time(DateTime dt) //get by date and time
        {
            string com = $"SELECT * FROM Appointment WHERE dateOf = {dt.ToString("yyyy-MM-dd-HH-mm-ss")}";
            return oledbhelper.GetTable(com);
        }
        //public static DataTable GetAppointmentsTypes()
        //{
        //    string com = $"SELECT Appointment FROM appointment";
        //    return oledbhelper.GetTable(com);
        //}

        //---------ADD---------
        public static void addAppointent(DateTime dateOf, int clientCode, int workerCode, DateTime timeOf) //add new appointment
        {
            string com = "INSERT INTO Appointment(dateOf, clientCode, workerCode) VALUES ('" + dateOf.ToString("yyyy-MM-dd") + "','" + clientCode + "','" + workerCode + "','" + timeOf.ToString("HH,mm") + "')";
            oledbhelper.Execute(com);
        }
        //---------SET---------
        public static void deleteAppointment(DateTime dateOf, int clientCode, DateTime timeOf)//delete appointment
        {
            string com = $"DELETE FROM Appointment WHERE dateOf = #{dateOf.ToString("yyyy-MM-dd")}# AND clientCode = {clientCode} AND timeOf = #{timeOf.ToString("HH,mm")}#";
            oledbhelper.Execute(com);
        }
        public static void updateAppointment(DateTime dateOf, int clientCode, int workerCode, DateTime timeOf) //update appoinment's information
        {
            string com = $"UPDATE Appointment SET dateOf = #{dateOf.ToString("yyyy-MM-dd")}#, clientCode = {clientCode}, workerCode = {workerCode}, timeOf = #{timeOf.ToString("HH, mm")}# WHERE dateOf = {dateOf.ToString("yyyy-MM-dd")} AND clientCode = {clientCode} AND timeOf = #{timeOf.ToString("HH, mm")}#";
            oledbhelper.Execute(com);
        }
    }
}
