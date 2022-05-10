using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class oledbhelper
    {
        public static string CONECTIONSTRING
        {
            get
            {
                return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\final project_YB\DataBaseFinalProject.accdb";
            }
        }

        //שאילתות עדכון מבנה ה –Database ושאילתות עדכון ,מחיקה והוספת רשומות.

        public static void Execute(string com)
        {
            //Connection  יצירת אובייקט מסוג 
            OleDbConnection cn = new OleDbConnection(CONECTIONSTRING);
            cn.Open();
            // command יצירת אובייקט מסוג 
            OleDbCommand command = new OleDbCommand();
            command.Connection = cn;
            command.CommandText = com;

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static DataTable GetTable(string com)
        {
            //Connection  יצירת אובייקט מסוג 
            OleDbConnection cn = new OleDbConnection(CONECTIONSTRING);
            // command יצירת אובייקט מסוג 
            OleDbCommand command = new OleDbCommand();
            command.Connection = cn;
            command.CommandText = com;
            //יצירת אובייקט מסוג דטהסט - אוסף טבלאות בזיכרון המחשב

            DataTable dt = new DataTable();
            dt.TableName = "tbl";
            //יצירת אובייקט אדפטר מטרתו לתאם בין הדטהסט לדטהבייס
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            try
            {
                //הפעולה פותחת את הדטהבייס ומחזירה את כל הנתונים לתוך טבלה חדשה בדטהסט
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
            return dt;
        }
    }
}
