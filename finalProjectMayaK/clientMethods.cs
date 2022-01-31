using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DAL
{
    public class clientMethods
    {
        //---------GET---------
        public static DataTable GetAllClients()//All info
        {
            string com = "select * from Client";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetClientNames()//All names
        {
            string com = "select clientName from Client";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetClientByName(string x)//Info by name
        {
            string com = $"select * from Client where clientName='{x.Replace("'", "''")}'";
            return oledbhelper.GetTable(com);
        }
        public static bool IsExistsEmail(string x)
        {
            string com = $"select * from Client where clientEmail= '{x.Replace("'", "''")}'";
            DataTable tbl = oledbhelper.GetTable(com);
            if (tbl.Rows.Count == 0)
                return false;
            return true;
        }
        public static bool IsExistsPhoneNum(string x)
        {
            string com = $"select * from Client where clientPhoneNum= '{x.Replace("'", "''")}'";
            DataTable tbl = oledbhelper.GetTable(com);
            if (tbl.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        //ADD

        public static void AddClient(string clientFirstName, string clientLastName, string clientPhoneNum, string clientEmail, string clientPassword, string clientDOB)//Add new user
        {
            string com = "insert into Client (clientFirstName, clientLastName, clientPhoneNum, clientEmail, clientPassword, datee)" +
                " VALUES ('" + clientFirstName + "','" + clientLastName + "','" + clientPhoneNum + "','" + clientEmail + "','" + clientPassword + "','" + clientDOB + "')";
            oledbhelper.Execute(com);
        }
        public static void UpdateClient(string clientName, string clientPhoneNum, string clientEmail, string clientPassword, DateTime clientDOB)//Add new user
        {
            string com = $"update Client set clientName = {clientName}, clientPhoneNum = {clientPhoneNum}, clientEmail = {clientEmail}, clientPassword = {clientPassword}" +
                $" where clientDOB = {clientDOB}";
            oledbhelper.Execute(com);
        }


        //--------check--------
        public static bool UserLoginEmailPass(string clientEmail, string clientPassword) //login
        {
            string com = $"SELECT * FROM Client WHERE clientEmail = '{clientEmail.Replace("'", "''")}' AND clientPassword = '{clientPassword.Replace("'", "''")}'";
            DataTable tbl = oledbhelper.GetTable(com);
            if (tbl.Rows.Count == 0)
            {
                Console.WriteLine("test fls");
                return false;
            }
            Console.WriteLine("test true");
            return true;
        }
        //-------delete--------
        public static void deleteUser(string clientEmail, string clientPassword)
        {
            string com = $"DELETE FROM Client WHERE clientEmail = {clientEmail.Replace("'", "''")} AND clientPassword = {clientPassword.Replace("'", "''")}";
            oledbhelper.Execute(com);
        }
    }
}
