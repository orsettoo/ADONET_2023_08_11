using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        DataTable dt = new DataTable();

        var constr = "Data Source=DESKTOP-QPLI3TJ;Initial Catalog=KrakerHR2;Integrated Security=True;";

        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("Select Id,Tamadi from vw_Calisan", con);
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        
        adap.Fill(dt);

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["Id"]+ " - " + dr["Tamadi"]);
        }
    }
}
