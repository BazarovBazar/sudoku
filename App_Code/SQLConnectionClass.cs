using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for SQLConnectionClass
/// </summary>
public class SQLConnectionClass
{

    public SqlConnection connection;

    public int closeConnection()
    {
        connection.Close();
        return 0;
    }

	public SQLConnectionClass()//Constructor
	{
		//
		// TODO: Add constructor logic here
		//
        connection = new SqlConnection();


 //       connection.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = ..\App_Data\Database.mdf; Integrated Security = True";

         connection.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\)_(\source\repos\WebSite1\WebSite1\App_Data\Database.mdf; Integrated Security = True";


        if (connection.State == ConnectionState.Open)
          {
              connection.Close();
          }
          connection.Close();
        connection.Open();
        
	}

   

}   