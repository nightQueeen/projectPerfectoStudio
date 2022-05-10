using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DAL
{
    public class treatmentTypeMethods
    { 
        //---------GET---------
        public static DataTable GetAllTypeNames()
        {
            string com = $"select typeName from TreatmentType";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetTreatmentInfoByID(int treatmentID)
        {
            string com = $"SELECT * FROM TreatmentType WHERE treatmentTypeCode={treatmentID}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetTreatmentPriceByID(int treatmentID)
        {
            string com = $"SELECT price FROM TreatmentType WHERE treatmentTypeCode={treatmentID}";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetTreatmentTypeByCategoryID(int categoryID)//sdfgbhnjm
        {
            string com = $"SELECT typeName FROM TreatmentType WHERE categoryCode={categoryID}";
            return oledbhelper.GetTable(com);
        }

        //---------ADD---------
        public static void addTreatment(int categoryCode, string typeName, int treatmentLength, int price)
        {
            string com = "INSERT INTO TreatmentType(categoryCode, typeName, treatmentLength, price) VALUES ('" + categoryCode + "','" + typeName + "','" + treatmentLength + "','" + price + "')";
            oledbhelper.Execute(com);
        }
        //---------SET---------
        public static void deleteTreatmentByID(int treatmentID)//delete tratment
        {
            string com = $"DELETE FROM TreatmentType WHERE treatmentTypeCode = {treatmentID}";
            oledbhelper.Execute(com);
        }
    }
}
