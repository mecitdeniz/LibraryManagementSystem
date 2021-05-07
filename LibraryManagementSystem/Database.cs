using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public class Database
{
	public  SqlConnection Connection()
	{

        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }
        return connection;
	}
}