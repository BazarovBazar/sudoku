using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MessageClass
/// </summary>
public class MessageClass//сообщения строго между двумя людьми
{
    List<int> MessagesIDs;

    List<int> ToIDs;
    int ToIDCounter;

    List<int> FromIDs;
    int FromIDCounter;


    int CurrentMessageID;

    int counter;

	public MessageClass()
	{
		//
		// TODO: Add constructor logic here
		//
        MessagesIDs = new List<int>();
        ToIDs = new List<int>();
        counter = 0;
        ToIDCounter = 0;

        FromIDs = new List<int>();
        FromIDCounter = 0;


	}


    /*
     * поиск людей которым пользователь когда либо писал
     */
    public String GetMessageText(int FromID, int ToID, int messageID/*1....N*/)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageText FROM Messages Where(FromUserID=@FromID) and (ToUserID = @ToID) and (MessageID = @MesID) ";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FromID", FromID);//Select Parameter
        oCommand.AddSelectParam("@ToID", ToID);//Select Parameter
        oCommand.AddSelectParam("@MesID", messageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        string messageText = null;
        if (reader.Read())
        {
            messageText = Convert.ToString(reader[0]);

        }

        oConnection.closeConnection();

        return messageText;

    }

    public String GetMessageText(int MessageID)// этот метод удалить
    {

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageText FROM Messages Where(MessageID=@MessageID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@MessageID", MessageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        string messageText = null;
        if(reader.Read())
        {
            messageText = Convert.ToString(reader[0]);

        }

        oConnection.closeConnection();

        return messageText;
    }

    public void getFromIDsByToID(int ToID)//Находим людей отправивших сообщения пользователю
    {

        //сюда записываем айдишника
        FromIDs = new List<int>(); //очищаем чтобы заполнить заново

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT FromUserID FROM Messages Where(ToUserID=@ToID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@ToID", ToID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);
            if (FromIDs.Count > 0)//не первый элемент
            {
                if (FromIDs.Last() != id)//если нет повторения
                {
                    FromIDs.Add(id);//считывание в массив юрэлов
                }
            }
            else
            {
                FromIDs.Add(id);//записываем первый элемент
            }


        }
        this.FromIDCounter = 0; //установка в ноль счетчика. Поскольку ToIDs считываем заново
        oConnection.closeConnection();
    }


    public void getToIDsByFromID(int FromID)//сначала надо вызвать это
    {

        //сюда записываем айдишника
        ToIDs = new List<int>(); //очищаем чтобы заполнить заново

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT ToUserID FROM Messages Where(FromUserID=@FromID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FromID", FromID);//Select Parameter
     
        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);
            if (ToIDs.Count > 0)//не первый элемент
            {
                if (ToIDs.Last() != id)//если нет повторения
                {
                    ToIDs.Add(id);//считывание в массив юрэлов
                }
            }
            else
            {
                ToIDs.Add(id);//записываем первый элемент
            }
           

        }
        this.ToIDCounter = 0; //установка в ноль счетчика. Поскольку ToIDs считываем заново
        oConnection.closeConnection();
    }

    public int GetFromID()
    {
        if (FromIDs.Count == 0)
            return 0;
        int returnValue = 0;

        returnValue = FromIDs.ElementAt(FromIDCounter);
        FromIDCounter++;

        if (FromIDCounter > FromIDs.Count - 1)
            FromIDCounter = 0;
        return returnValue;
    }

    public void DeleteFromID(int id)
    {
        for (int i = 0; i < FromIDs.Count; i++)
        {
            if (FromIDs.ElementAt(i) == id)
            {
                FromIDs.RemoveAt(i);
            }
        }
    }
    public void DeleteToID(int id)
    {
        for (int i = 0; i < ToIDs.Count; i++)
        {
            if (ToIDs.ElementAt(i) == id)
            {
                ToIDs.RemoveAt(i);
            }
        }
    }


    public int FromIDCount
    {
        get { return FromIDs.Count; }
    }


    public int ToIDCount
    {
        get { return ToIDs.Count; }
    }




    public int GetToID()
    {
        if(ToIDs.Count == 0) 
            return 0;
        int returnValue = 0;

        returnValue = ToIDs.ElementAt(ToIDCounter);
        ToIDCounter++;

        return returnValue;
    }

    public int getMaxMessageID(int FromID, int ToID)
    {

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageID FROM Messages Where(FromUserID=@FromID) AND (ToUserID=@ToID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FromID", FromID);//Select Parameter
        oCommand.AddSelectParam("@ToID", ToID);//Select Parameter


        SqlDataReader reader = oCommand.ExectuteReader();

        int max = 0;

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);
            if (max < id)
            {
                max = id;
            }

        }

        oConnection.closeConnection();
        return max;

    }

    /*
     * ищем сообщения диалога пользователя и выбранного человека
    */

    public void AddMessagesIDs(int FromID, int ToID)// сообщения в обратную сторону. call after getMessagesIDs
    {

        if (this.MessagesIDs == null)
        {
            this.MessagesIDs = new List<int>();

        }

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageID FROM Messages Where(FromUserID=@FromID) AND (ToUserID=@ToID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FromID", FromID);//Select Parameter
        oCommand.AddSelectParam("@ToID", ToID);//Select Parameter


        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);

            MessagesIDs.Add(id);//считывание в массив юрэлов

        }

        oConnection.closeConnection();


    }


    public void getMessagesIDs(int FromID, int ToID){
   
        MessagesIDs = new List<int>(); //очищаем чтобы заполнить заново
     
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageID FROM Messages Where(FromUserID=@FromID) AND (ToUserID=@ToID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FromID", FromID);//Select Parameter
        oCommand.AddSelectParam("@ToID", ToID);//Select Parameter


        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);

            MessagesIDs.Add(id);//считывание в массив юрэлов

        }

        counter = 0;
        oConnection.closeConnection();

        this.getNextMessagesIDs(ToID, FromID);//получаем сообщения в обратную сторону

        
    }

    private void getNextMessagesIDs(int FromID, int ToID)
    {
        if (MessagesIDs == null)
            MessagesIDs = new List<int>();

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageID FROM Messages Where(FromUserID=@FromID) AND (ToUserID=@ToID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FromID", FromID);//Select Parameter
        oCommand.AddSelectParam("@ToID", ToID);//Select Parameter


        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);

            MessagesIDs.Add(id);//считывание в массив юрэлов

        }

        counter = 0;
        oConnection.closeConnection();


    }


    public void sendMessageFromUserID(int DialogId,  int FromID, int ToID, String textMessage )
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        string sqlIns = "INSERT INTO Messages(DialogID, FromUserID, ToUserID, MessageID, MessageText) VALUES(@DialogID,@FromID, @ToID, @MessageID, @textMessage ) ";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);

        oCommand.AddInsertParameter("@DialogID", DialogId);
        oCommand.AddInsertParameter("@FromID", FromID);
        oCommand.AddInsertParameter("@ToID", ToID);


        //======это чтобы вычислить айди нового сообщения
        this.getMessagesIDs(FromID, ToID);//получаем номера сообщений в прямую сторону и в обратную сторону
        //айди сообщений получены
      
        int maxMesID = this.GetMaxMessageID();//вычисляем айди нового сообщения. максим + 1.
        //===============================================

        oCommand.AddInsertParameter("@MessageID", maxMesID + 1);//new message id;
        oCommand.AddInsertParameter("@textMessage", textMessage);

       

        oCommand.ExecuteQuery();

        oConnection.closeConnection();

    }

    public int getCurrentMessageID()
    {
        return MessagesIDs.ElementAt(counter);
    }

    public int getNextMessageID()
    {
        counter++;
        if (counter > this.MessagesIDs.Count - 1)
            counter = 0;
        return MessagesIDs.ElementAt(counter);

    }


    public int getPrevMessageID()
    {
        counter--;
        if (counter < 0)
            counter = MessagesIDs.Count - 1;
        return MessagesIDs.ElementAt(counter);

    }

   public int  GetMaxMessageID(){
       int max=0;
       for(int i=0; i <MessagesIDs.Count; i++)
           if (MessagesIDs.ElementAt(i) > max)
           {
               max = MessagesIDs.ElementAt(i);
           }
       return max;
   }

   public int GetMessagesCount()
   {
       return MessagesIDs.Count;
   }

   public void SetToIDCounter(int n)
   {
       if (n < ToIDs.Count)
       {
           this.ToIDCounter = n;
       }
   }
   public void SetFromIDCounter(int n)
   {
       if (n < this.FromIDs.Count)
       {
           this.FromIDCounter = n;
       }
   }


}