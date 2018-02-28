using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/// <summary>
/// Summary description for PeopleID_OPerator
/// </summary>
public class ID_OPerator
{
	public ID_OPerator()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //протестирвать эту функцию
    //если вернулось отрицательное значение, то ошибка
    public static int getMaxID(string IDName, string tableName)// -2 некорректные пареметры
    {
        if (tableName == null || IDName==null)
            return -2;// не задана таблица. не корректные параметры
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT "  + IDName + " FROM " + tableName;



        oCommand.PrepareSelectQuery(queryString, oConnection.connection);

        SqlDataReader reader = oCommand.ExectuteReader();

        int tableID = 0;
        

        int max = -1;//если значение отрицательное то в таблице нет записей
        int tempValue=-2;

        while (reader.Read())
        {
            tableID =Convert.ToInt32(reader[0]);//приведение типов   

            if (tableID > max)
            {//ищем максимальный идентификатор
                max = tableID;
            }
        }
        oConnection.closeConnection();


        return max;// -1 если нет записей, тогда создастся 0
    }

    public static int createNewTableID(string IDName, string tableName)// -2 некорректные пареметры
    {
        int newTableID = -2;
      
        int maxID =  getMaxID(IDName, tableName);//находим максимальное из существующих чисел
        if (maxID == -2)
            return -2;//некорректные параметры
        newTableID = maxID + 1;//генерируем следующее айди
        return newTableID;
    }
}