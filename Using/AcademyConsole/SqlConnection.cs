using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyConsole
{
    public class SqlDBConnection : IDisposable
    {
        public SqlConnection conncetion { get; set; }
        public bool IsDisposed { get; private set; } = false;
        public string TableName { get; set; }

        public SqlDBConnection(string tableName)
        {
            TableName = tableName;

            conncetion = new SqlConnection("");
            //conncetion.Open();

            System.Console.WriteLine(tableName);
        }

        public void Show()
        {
            System.Console.WriteLine("Dispose Status {0}", IsDisposed);
        }


        public void Dispose()
        {
            IsDisposed = true;
            if (conncetion != null)
            {
                if(conncetion.State is not ConnectionState.Closed){
                    conncetion.Close();
                }

                conncetion.Dispose();
                //conncetion = null;

            }
        }
    }
}
