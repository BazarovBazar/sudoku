using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;

/// <summary>
/// Summary description for UserCounters
/// </summary>
public class UserCounters//не протестирован
{
    public UserCounters()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void createNewUserIDCounter(int userID, string counterName, int value)//работает строго с таблицей UserCounters
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        string sqlIns = "INSERT INTO UserCounters( UserID, "+counterName +" ) "+" VALUES(@UserID, @Value )";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);


        int newIDPeoples = ID_OPerator.createNewTableID("ID", "Peoples");
        if (newIDPeoples == -2)
        {
            //некорректные параметры
        }
        oCommand.AddInsertParameter("@UserID", userID);//заносим новый айди
        oCommand.AddInsertParameter("@Name", value);

        oCommand.ExecuteQuery();

        oConnection.closeConnection();
     
    }


    public void SetCounterValue(int userID, string counterName) { }

    public int GetCounterValue(int userID, string counterName )//работает строго с таблицей UserCounters
    {
        if ( counterName == null )
            return -2;// не задана таблица. не корректные параметры
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT userID, "+ counterName +  " FROM UserCounters where userID = @userID";


        oCommand.PrepareSelectQuery(queryString, oConnection.connection);

        oCommand.AddSelectParam("@phone", userID);//Для сравнения



        SqlDataReader reader = oCommand.ExectuteReader();

        int UserID = 0;
        int counter = 0;
      

        UserID = Convert.ToInt32(reader[0]);//приведение типов   

        counter = Convert.ToInt32(reader[1]);

        oConnection.closeConnection();

        return UserID;
    }

    public void increaseCounter(int userID, string counterName) { }

}