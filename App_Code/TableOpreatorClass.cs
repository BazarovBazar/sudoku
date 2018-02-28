using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TableOpreatorClass
/// </summary>
public class TableOpreatorClass
{
	public TableOpreatorClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int GetMaxID(string IDName, string TableName)// -1 если не найден ни один айди
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT " + IDName + " FROM " + TableName;

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);


        SqlDataReader reader = oCommand.ExectuteReader();

        int maxID = -1;
        int ID = 0;
        while (reader.Read())
        {

            if ((reader[0] != null) && (!Convert.IsDBNull(reader[0])))
            {
                 ID = Convert.ToInt32(reader[0]);//
                if (maxID < ID)
                    maxID = ID;
            }
        }

        oConnection.closeConnection();

        return maxID;

    }

    public void SelectFromTable(List<TableValue> SelectedValues, List<TableValue> WhereValues, string TableName)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string SelectString = null;
        string WhereString = null;

        foreach (TableValue element in SelectedValues)//Select Values
        {
            if(element == SelectedValues.ElementAt( SelectedValues.Count - 1 ) )//Если элемент последний то запятые не ставим
            {
                SelectString += element.ValueName;
            }
            else//Если элемент не последний то ставим запятые
            {
                SelectString += element.ValueName + ",";
            }
        }

        foreach( TableValue element in WhereValues )
        {
            if (element == WhereValues.ElementAt( WhereValues.Count - 1 ))
            {
                WhereString += element.ValueName + "=@" + element.ValueName;
            }
            else
            {
                WhereString += element.ValueName + "=@" + element.ValueName + ",";//Where ID = @ID
            }
        }

        string queryString = "SELECT " + "(" + SelectString + ") FROM " + TableName + "(" + WhereString + " ) ";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);


        foreach(TableValue element in WhereValues )// WhereValues
        {
            oCommand.AddSelectParam("@" + element.ValueName, element.Value );//Add Select Parameter
        }

        SqlDataReader reader = oCommand.ExectuteReader();

        object returnValue = null;

        if (reader.Read())
        {
            returnValue = reader[0] as object;
        }

        oConnection.closeConnection();
    }

    public void InsertToTable( List<TableValue> InsertValues, string TableName)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        string string1 = null;
        string string2 = null;

        for (int i = 0; i < InsertValues.Count; i++)
        {
            if(i == InsertValues.Count - 1)//если является последним элементом, то не надо ставить запятую
            {
                string1 += InsertValues.ElementAt(i).ValueName;
                string2 += "@" + InsertValues.ElementAt(i).ValueName;
            }
            else{//не последний элемент, то ставим запятую
                string1 += InsertValues.ElementAt(i).ValueName + ",";
                string2 += "@" + InsertValues.ElementAt(i).ValueName + ",";
            }
        }

        string sqlIns = "INSERT INTO " + TableName + "( " + string1 + " ) VALUES(" + string2 + ")";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);

        //AddInsertParameters
        foreach (TableValue element in InsertValues)
        {
            oCommand.AddInsertParameter("@" + element.ValueName, element.Value);
        }

        oCommand.ExecuteQuery();
        oConnection.closeConnection();
    }


    public int GenerateNewID(string IDName, string TableName)
    {
        int newID = this.GetMaxID(IDName, TableName);
        if (newID == -1)//если таблица пустая
        {
            newID = 0;//создаем самый первый айди
        }

        return newID + 1;
    }

    public void SetValueToTable(int ID, String ColumnName, object InsertValue, string tableName)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        string sqlIns = "INSERT INTO " + tableName + "( " + ColumnName + " ) VALUES(@Value) where( ID=@ID )";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);


        oCommand.AddInsertParameter("@Value", InsertValue);
        oCommand.AddInsertParameter("@ID", ID);


        oCommand.ExecuteQuery();

        oConnection.closeConnection();

    }

    public int GetMaxIDInGroup(string IDName, string tableName, string GroupIDName , int GroupID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT " + IDName + " FROM " + tableName + " Where " + GroupIDName + "=@GroupID" ;

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@GroupID", GroupID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        int maxID = -1;

        while (reader.Read())
        {

            int readVal = Convert.ToInt32( reader[0] );
            if (readVal > maxID)
                maxID = readVal;
        }

        oConnection.closeConnection();

        return maxID;
    }



    public object GetValueFromTable( int ID ,String ColumnName,string tableName){

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT "+ColumnName+ " FROM " + tableName + " Where ID =@ID ";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@ID", ID);//Select Parameter
       
        SqlDataReader reader = oCommand.ExectuteReader();

        object returnValue=null;

        if(reader.Read())
        {
 
            returnValue = reader[0] as object;
        }

        oConnection.closeConnection();
        return returnValue;
    }

    public object GetValueFromTableByIDName(int ID, string IDName, String ColumnName, string tableName)
    {

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT " + ColumnName + " FROM " + tableName + " Where " +IDName+ "=@ID ";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@ID", ID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        object returnValue = null;

        if (reader.Read())
        {

            returnValue = reader[0] as object;
        }

        oConnection.closeConnection();
        return returnValue;
    }

    /// <summary>
    /// Deletes value with ID from table
    /// </summary>
    /// <param name="IDColumnName"></param>
    /// <param name="ID"></param>
    /// <param name="TableName"></param>
    public void DeleteValueFromTable(string IDColumnName, int ID, string TableName)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();
        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "DELETE FROM " + TableName + "WHERE " + IDColumnName + "=@ID";

        oCommand.PrepareDeleteQuery(queryString, oConnection.connection);
        oCommand.AddDeleteParam("@ID", ID);

        oCommand.ExecuteDeleteQuery();

        //Command.ExecuteNonQuery();
        /* To Future:
         * Delete smiles, stickers, images
        */

        oConnection.closeConnection();

    }
}