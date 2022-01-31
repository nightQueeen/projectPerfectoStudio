using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DAL
{
    public class treatmentMethods2
    {
        //---------GET---------
        public static DataTable GetTreatmentInfoByID(int treatmentID)
        {
            string com = $"select * from Treatment where treatmentCode={treatmentID}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetTreatmentPriceByID(int treatmentID)
        {
            string com = $"select treatmentPrice from Treatment where treatmentCode={treatmentID}";
            return oledbhelper.GetTable(com);
        }

        //---------ADD---------
        public static void addTreatment(int treatmentPrice, int treatmentLength)
        {
            string com = "INSERT INTO Treatment(treatmentPrice, treatmentLength) VALUES ('" + treatmentPrice + "','" + treatmentLength + "')";
            oledbhelper.Execute(com);
        }
        //---------SET---------
        public static void deleteTreatmentByName(string tratmentName)//delete tratment
        {
            string com = $"DELETE FROM Treatment WHERE tratmentName = {tratmentName}";
            oledbhelper.Execute(com);
        }
    }
}
