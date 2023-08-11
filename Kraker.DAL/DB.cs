using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Kraker.DAL
{
    public class DB

    {
        public static SqlConnection GetConnection()
        {
            var constr = ConfigurationManager.ConnectionStrings["hrConnection"].ConnectionString;
            Console.WriteLine(constr);
            SqlConnection con = new SqlConnection(constr);
            return con;
        }
        public static SqlCommand GetCommand(string cmdText)
        {
            var cmd =new SqlCommand(cmdText, GetConnection());
            return cmd;
           
        }
        public static object ExecuteScalar(string cmdText)
        {
            object result = null;
            var cmd = GetCommand(cmdText);
            try
            {
                cmd.Connection.Open();
                result = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

            }
            finally { cmd.Connection.Close(); }
            return result;
        }
       public static DataSet GetDataSet(string cmdtext)
        {
            DataSet ds = new DataSet();
            var cmd = GetCommand(cmdtext);
            var adap= new SqlDataAdapter(cmd);
            adap.Fill(ds);
            return ds;
        }
        public static DataTable GetTable(string cmdtext)
        {
            return GetDataSet(cmdtext).Tables[0];
        }
    }
}
