

using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        var constr = "Data Source=DESKTOP-QPLI3TJ;Initial Catalog=KrakerHR2;Integrated Security=True;";

        SqlConnection con = new SqlConnection(constr);
        //con.ConnectionString = constr;


        SqlCommand cmd = new SqlCommand("Select * from vw_Calisan", con);
        //cmd.CommandText = "Select * from Calisan";
        //cmd.Connection = con;	

        try
        {
            con.Open();
            Console.WriteLine("bağlatı açıldı");
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["Id"]} - {dr["TamAdi"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("hata oldu");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
            Console.WriteLine("bağlatı kapandı");
        }

    }
}