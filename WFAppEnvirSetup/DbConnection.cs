using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAppEnvirSetup
{
    public static class DBconnect
    {
        private static DbConnection dbConnect;
        private static DbProviderFactory dbFactory;
        private static string connection = "Data Source=192.168.131.38;Persist Security Info=True;User ID=sa;Password=S3300859!";
        public static void SetConnection()
        {
            dbFactory = dbFactory?? DbProviderFactories.GetFactory("System.Data.SqlClient");
            dbConnect = dbConnect??dbFactory.CreateConnection();
            dbConnect.ConnectionString = connection;
            dbConnect.Open();
        }

        public static List<string> GetData(string sql)
        {
            List<string> list = new List<string>();
            DataTable dtRet = new DataTable();
            using (DbDataAdapter dbDa = dbFactory.CreateDataAdapter())
            { 
                using (DbCommand dbCmd = dbConnect.CreateCommand())
                {
                    dbCmd.CommandText = sql;
                    dbCmd.Transaction = dbConnect.BeginTransaction();
                    //dbCmd.ExecuteReader();
                    dbDa.SelectCommand = dbCmd;
                    dbDa.Fill(dtRet);

                    foreach (DataRow row in dtRet.Rows)
                    {
                        list.Add(row[0].ToString());
                    }
                }
            }

            return list;
        }

        public static void Close()
        {
            if (dbConnect != null)
                dbConnect.Close();
        }
    }
}
