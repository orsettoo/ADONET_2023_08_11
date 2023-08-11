using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _030_AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var constr = ConfigurationManager.ConnectionStrings["hrConnection"].ConnectionString;
            Console.WriteLine(constr);
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            Console.WriteLine("db open "); // ctrl + d 
            con.Close();
            Console.WriteLine("db close ");
            Console.WriteLine("------------------");
            var dummyStr = ConfigurationManager.ConnectionStrings["dummyCon"].ConnectionString.ToString();
            Console.WriteLine(dummyStr);
            Console.WriteLine("bir tuşa basın");
            Console.ReadLine();
        }
    }
}
    }
}
