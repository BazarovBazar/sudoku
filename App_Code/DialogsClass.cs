using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DialogsClass
/// </summary>
public class DialogsClass
{
	public DialogsClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    List<int> SecondPersonIDs;

    public void readeSecondPersonIDs(int firstPersID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        SecondPersonIDs = new List<int>();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT FromUserID, ToUserID FROM Messages Where(FromUserID=@FirstID) or (ToUserID = @FirstID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FirstID", firstPersID);//Select Parameter
        SqlDataReader reader = oCommand.ExectuteReader();

        int FromID = 0;
        int ToID = 0;


        while (reader.Read())
        {
            FromID = Convert.ToInt32(reader[0]);
            ToID = Convert.ToInt32(reader[1]);

            if (FromID == firstPersID)
            {
                bool isInteraction = false;
                for (int i = 0; i < SecondPersonIDs.Count; i++)
                {
                    if (SecondPersonIDs.ElementAt(i) == ToID)
                    {
                        isInteraction = true;//чтобы не было повторений  
                        continue;
                    }
                }
                if (!isInteraction)
                {

                    SecondPersonIDs.Add(ToID);
                }
            }
            else
            {
                bool isInteraction = false;
                for (int i = 0; i < SecondPersonIDs.Count; i++)
                {
                    if (SecondPersonIDs.ElementAt(i) == FromID)
                    {
                        isInteraction = true;//чтобы не было повторений  
                        continue;
                    }
                }

                if (!isInteraction)
                {
                    SecondPersonIDs.Add(FromID);//сообщение в обратную сторону
                }
                
            }
        }

       oConnection.closeConnection();

        

    }


    //получаем максимальный номер
    public int GetMaxDialogID()
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT DialogID FROM Messages";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);

        SqlDataReader reader = oCommand.ExectuteReader();


        int max = 0;
        int DialogID = -1;

        while (reader.Read())
        {
            DialogID = Convert.ToInt32(reader[0]);
            if (DialogID > max)
            {
                max = DialogID;
            }
        }

        //если диалогов нет то будет нулевым диалогом

        oConnection.closeConnection();

        return max;
    }
    

    public int GetDialogID(int FirstPersonID, int SecondPersonID )//проверить
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT DialogID FROM Messages Where((FromUserID=@FirstID) and (ToUserID = @SecondID) ) or ( (FromUserID = @SecondID) and (ToUserID = @FirstID))";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FirstID", FirstPersonID);//Select Parameter
        oCommand.AddSelectParam("@SecondID", SecondPersonID);//Select Parameter
     
        SqlDataReader reader = oCommand.ExectuteReader();

        int DialogID = -1;

        if (reader.Read())
        {
            DialogID = Convert.ToInt32(reader[0]);

        }

        oConnection.closeConnection();

        return DialogID;
    }

    public int getMaxMessageID(int dialogID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageID FROM Messages Where (DialogID=@DialogID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@DialogID", dialogID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        int maxID = 0;
        int messageID = 0;
        while (reader.Read())
        {
            messageID = Convert.ToInt32(reader[0]);

            if (messageID > maxID)
            {
                maxID = messageID;
            }
        }

        oConnection.closeConnection();

        return maxID;


    }



    /// <summary>
    /// вызывать этот метод
    /// </summary>
    /// <param name="dialogID"></param>
    /// <param name="listBox"></param>
    public void ReadeDialogToListBox(int dialogID, ListBox listBox)
    {
        listBox.ClearSelection(); // очищаем лист бокс
        int maxMesID = getMaxMessageID(dialogID);//считываем сообщения до максимального номера сообщения
       
        for (int i = 0; i < maxMesID + 1; i++)
        {
            string MessageText = ReadeDialogMessage(dialogID, i);
            string personName = ReadePersonName(dialogID, i);
            string personSurname = ReadePersonSurname(dialogID, i);

            if (MessageText == null)
                continue;

            ListItem item = new ListItem();


            item.Text = personName + " " + personSurname + ": " + MessageText;
            item.Value = null;
            listBox.Items.Add(item);
        }       
        
    }

    /// <summary>
    /// вызывать этот метод
    /// </summary>
    /// <param name="firstPersonID"></param>
    /// <param name="listBox"></param>
    public void ReadeLastMessagesOfDialogsToListBox(int firstPersonID, ListBox listBox)
    {
        readeSecondPersonIDs(firstPersonID);

        for(int i=0; i<this.SecondPersonIDs.Count; i++)
        {
            int secondPersID = SecondPersonIDs.ElementAt( i );

            int dialogID = GetDialogID(firstPersonID, secondPersID);

            int MaxMessageID = getMaxMessageID(dialogID);

            string messageText = ReadeDialogMessage(dialogID, MaxMessageID);

            ListItem item = new ListItem();
            item.Text = messageText;
            item.Value = Convert.ToString(secondPersID);

            listBox.Items.Add(item);

        }
    }

    public string ReadePersonName(int dialogID, int messageID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT FromUserID FROM Messages Where (DialogID=@DialogID) and (MessageID = @MessageID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@DialogID", dialogID);//Select Parameter
        oCommand.AddSelectParam("@MessageID", messageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        int PersonID = 0;
        string PersonName = null;

        if (reader.Read())
        {
            PersonID = Convert.ToInt32(reader[0]);

        }
        oConnection.closeConnection();

        PeoplesClass oPeoples = new PeoplesClass();

        PersonName = Convert.ToString( oPeoples.GetPeopleValue(PersonID, "Name") );
       
        return PersonName;


    }


    public string ReadePersonSurname(int dialogID, int messageID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT FromUserID FROM Messages Where (DialogID=@DialogID) and (MessageID = @MessageID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@DialogID", dialogID);//Select Parameter
        oCommand.AddSelectParam("@MessageID", messageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        int PersonID = 0;
        string PersonSurname = null;

        if (reader.Read())
        {
            PersonID = Convert.ToInt32(reader[0]);

        }
        oConnection.closeConnection();

        PeoplesClass oPeoples = new PeoplesClass();

        PersonSurname = Convert.ToString(oPeoples.GetPeopleValue(PersonID, "Surname"));

        return PersonSurname;


    }

    public string ReadeDialogMessage( int dialogID, int messageID){

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        string queryString = "SELECT MessageText FROM Messages Where (DialogID=@DialogID) and (MessageID = @MessageID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@DialogID", dialogID);//Select Parameter
        oCommand.AddSelectParam("@MessageID", messageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        string messageText = null;
        if (reader.Read())
        {
            messageText = Convert.ToString(reader[0]);

        }

        oConnection.closeConnection();

        return messageText;


//      listBox.Items.add
    }
}