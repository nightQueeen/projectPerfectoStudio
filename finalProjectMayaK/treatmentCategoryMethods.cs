using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DAL
{
    public class treatmentCategoryMethods
    {
        //---------GET---------
        public static DataTable GetAllCategoryNames() //get all names
        {
            string com = $"SELECT categoryName FROM TreatmentCategory";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetCategoryIDByName(string categoryName) //get id by name
        {
            string com = $"SELECT categoryCode FROM TreatmentCategory WHERE categoryName = {categoryName}";
            return oledbhelper.GetTable(com);
        }

        public static int GetCategoryIDByName2(string categoryName) //get id by name => return int
        {
            string com = $"SELECT categoryCode FROM TreatmentCategory WHERE categoryName = '{categoryName}'";
            DataTable dt = oledbhelper.GetTable(com);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return int.Parse(dr["categoryCode"].ToString());
            }
            return -1;
        }
        //---------ADD---------
        public static void addTreatmentCategory(string categoryName) //add category
        {
            string com = "INSERT INTO TreatmentCategory(categoryName) VALUES ('" + categoryName + "')";
            oledbhelper.Execute(com);
        }
        //---------SET---------
        public static void deleteTreatmentCategory(string categoryName)//delete
        {
            string com = $"DELETE FROM TreatmentCategory WHERE categoryName = {categoryName}";
            oledbhelper.Execute(com);
        }
    }
}
