using Kraker.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string sqlstr = @"
                   select * from Calisan;
                   select * from Departman;
                   select * from Takim";

        var dt = DB.GetTable("select * from takim");
        Console.WriteLine(dt.Rows.Count);
        
        foreach (DataRow dataRow in dt.Rows)
        {
            Console.WriteLine(dataRow["Adi"]);
        }
        
        
        Console.WriteLine("ok");



    }

    private static void datasetornek()
    {
        string sqlstr = @"
                   select * from Calisan;
                   select * from Departman;
                   select * from Takim";

        DataSet ds = new DataSet();

        var cmd = DB.GetCommand(sqlstr);
        var adap = new SqlDataAdapter(cmd);
        adap.Fill(ds);

        foreach (DataTable dt in ds.Tables)
        {
            Console.WriteLine("----- table - ");
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["Id"]} - {dr["Adi"]}");
            }
        }
    }

    private static void test()
    {
        var con = DB.GetConnection();
        con.Open();
        con.Close();
        var res = DB.ExecuteScalar("select count(*) from calisan");
        Console.WriteLine(res);
    }
}

