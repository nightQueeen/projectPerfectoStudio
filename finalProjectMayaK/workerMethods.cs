using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace DAL
{
    public class workerMethods
    {
        //---------GET---------
        public static DataTable GetWorkers() //get all names
        {
            string com = $"SELECT workerName FROM Worker";
            return oledbhelper.GetTable(com);
        }
        public static DataTable GetWorkerByTreatmentCode(int treatmentCode) //get names by profession
        {
            string com = $"select workerName from workerName where treatmentCode={treatmentCode}";
            return oledbhelper.GetTable(com);
        }

        //---------ADD---------
        public static void addWorker(string workerName) //add
        {
            string com = "INSERT INTO Worker(workerName) VALUES ('" + workerName + "')";
            oledbhelper.Execute(com);
        }
        //---------SET---------
        public static void deleteWorker(string workerName)//delete worker
        {
            string com = $"DELETE FROM Worker WHERE workerName = {workerName}";
            oledbhelper.Execute(com);
        }
    }
}
