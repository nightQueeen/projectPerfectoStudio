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
        public static DataTable GetTreatmentCategoryName()
        {
            string com = $"select categoryName from TreatmentCategory";
            return oledbhelper.GetTable(com);
        }

        //---------ADD---------
        public static void addTreatmentCategory(string categoryName)
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
