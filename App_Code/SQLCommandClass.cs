using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Summary description for SQLCommandClass
/// </summary>
public class SQLCommandClass
{

    private SqlCommand cmdIns;


    private SqlCommand cmdSelect;

	public SQLCommandClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void PrepareSelectQuery(string sqlSel, SqlConnection connection)
    {
        cmdSelect = new SqlCommand(sqlSel, connection);
       

    }

    public void PrepareDeleteQuery(string sqlDel, SqlConnection connection)
    {
        cmdSelect = new SqlCommand(sqlDel, connection);
    }

    public void ExecuteDeleteQuery()
    {
        cmdSelect.ExecuteNonQuery();
    }

    public SqlDataReader ExectuteReader()
    {

        return cmdSelect.ExecuteReader();
    }

    public void PrepareInsertQuery(string sqlIns, //Insert Query
                                   SqlConnection connection)
    {

        cmdIns = new SqlCommand(sqlIns, connection);

    }

    public void AddInsertParameter(String Name, object value){

        cmdIns.Parameters.Add(Name, value);
    
    }

    public void AddSelectParam(String Name, object value){

        cmdSelect.Parameters.AddWithValue( Name,value );

    }

    public void AddDeleteParam(String Name, object value)
    {

        cmdSelect.Parameters.AddWithValue(Name, value);

    }


    public void ExecuteQuery(){

        cmdIns.ExecuteNonQuery();//выполнить команду

        cmdIns.Parameters.Clear();
        cmdIns.CommandText = "SELECT @@IDENTITY";


        // Get the last inserted id.
        //      int insertID = Convert.ToInt32(cmdIns.ExecuteScalar());

        cmdIns.Dispose();
        cmdIns = null;

    }
}