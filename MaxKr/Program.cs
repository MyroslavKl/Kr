
using MaxKr;
using Microsoft.Data.SqlClient;
using System;

public class Program {
    public static void Main(string[] args)
    {
        string connectionString = "Data Source=DESKTOP-B6DS7BT\\SQLEXPRESS;Initial Catalog=CityInfo;TrustServerCertificate=True;Trusted_connection = True;";
        SqlConnection connection = new SqlConnection(connectionString);
        Execution execute = new(connection);

        //execute.Add(1,"Lviv",3000000);
        //execute.Update(2000);
        execute.ReadAll();
        execute.Filter(1000,1100);
        //execute.Remove(1);
    }
}