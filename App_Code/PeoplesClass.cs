using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

/// <summary>
/// Сводное описание для PeoplesClass
/// </summary>
public class PeoplesClass
{
    List<int> PeopleIDs;
    int counter;

    public int Count
    {
        get
        {
            return PeopleIDs.Count;
        }
    }

    public PeoplesClass()
    {
        //
        // TODO: Add constructor logic here
        //
        PeopleIDs = new List<int>();
        counter = 0;
    }



    public bool isFriendsExist(int ID_1, int ID_2)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";


        //        string queryString = "SELECT ID FROM FriendTable" + " Where( (Friend_1_ID=@Fr_1) AND (Friend_2_ID=@Fr_2) ) or ( (Friend_1_ID=@Fr_2) AND (Friend_2_ID=@Fr_1) )";

        string queryString = "SELECT ID FROM FriendTable Where( (Friend_1_ID=@Fr_1) AND (Friend_2_ID=@Fr_2) )";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@Fr_1", ID_1);//Select Parameter
        oCommand.AddSelectParam("@Fr_2", ID_2);//Select Parameter



        //     oCommand.PrepareSelectQuery(queryString, oConnection.connection);

        SqlDataReader reader = oCommand.ExectuteReader();

        bool returnValue = false;

        if (reader.Read())
        {
            returnValue = true; //найдены друзья  
        }

        oConnection.closeConnection();
        return returnValue;

    }

    /// <summary>
    /// возвращает номера таблиц в которых содержатся номера друзей
    /// </summary>
    /// <param name="PeopleID"></param>
    /// <returns></returns>

    public List<int> GetFriendIDList(int PeopleID)
    {
        List<int> FriendListIDs = new List<int>(); ;//очищаем чтобы заполнить заново

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT ID FROM FriendTable Where(Friend_1_ID=@PeopleID) OR (Friend_2_ID=@PeopleID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@PeopleID", PeopleID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);
            FriendListIDs.Add(id);//считывание в массив юрэлов

        }

        oConnection.closeConnection();

        return FriendListIDs;
    }
    /// <summary>
    /// Возвращает номер друга
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="FriendListID"></param>
    /// <returns></returns>
    public int GetFriendID(int userID, int FriendListID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();
        int returnValue = 0;

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT Friend_1_ID, Friend_2_ID FROM FriendTable Where(ID=@FriendListID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@FriendListID", FriendListID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        if (reader.Read())
        {
            int FirstId = Convert.ToInt32(reader[0]);
            int SecondId = Convert.ToInt32(reader[1]);

            if (userID == FirstId)
                returnValue = SecondId;
            else returnValue = FirstId;

        }

        oConnection.closeConnection();
        return returnValue;

    }

    public string GetPeopleName(int peopleID)
    {
        string name = this.GetPeopleValue(peopleID, "Name") as string;

        return name;
    }

    public string GetPeopleSurname(int peopleID)
    {
        string surname = this.GetPeopleValue(peopleID, "Surname") as string;

        return surname;
    }

    public int GetPeopleWallID(int peopleID)
    {
        int wallID = Convert.ToInt32(this.GetPeopleValue(peopleID, "Wall_ID"));

        return wallID;
    }


    public void ShowFriendsToListBox(int UserID, ListBox listBox)
    {
        listBox.ClearSelection(); // очищаем лист бокс

        List<int> friendListIDs = GetFriendIDList(UserID);



        for (int i = 0; i < friendListIDs.Count; i++)
        {

            int friendID = GetFriendID(UserID, friendListIDs.ElementAt(i));
            string friendName = this.GetPeopleName(friendID);
            string friendSurname = this.GetPeopleSurname(friendID);

            ListItem item = new ListItem();


            item.Text = friendName + " " + friendSurname;
            item.Value = Convert.ToString(friendID);
            listBox.Items.Add(item);
        }
    }

    public void AddFriend(int ID_1, int ID_2)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        TableOpreatorClass TablePerator = new TableOpreatorClass();

        if (isFriendsExist(ID_1, ID_2))
            return;// они уже друзья. Не надо заново добавлять  друзей

        int ID = TablePerator.GenerateNewID("ID", "FriendTable");

        string sqlIns = "INSERT INTO FriendTable( ID, Friend_1_ID, Friend_2_ID ) VALUES (@ID, @Friend_1, @Friend_2 )";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);


        int newIDPeoples = ID_OPerator.createNewTableID("ID", "Peoples");
        if (newIDPeoples == -2)
        {
            //некорректные параметры
        }

        oCommand.AddInsertParameter("@ID", ID);//заносим новый айди
        oCommand.AddInsertParameter("@Friend_1", ID_1);
        oCommand.AddInsertParameter("@Friend_2", ID_2);

        oCommand.ExecuteQuery();
        oConnection.closeConnection();
    }


    public object GetPeopleValue(int PeopleID, String ValueName)
    {
        TableOpreatorClass tempObj = new TableOpreatorClass();

        object returnValue = null;
        returnValue = tempObj.GetValueFromTable(PeopleID, ValueName, "Peoples");

        return returnValue;
    }

    public bool isLoginExist(string Login)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT Phone FROM Peoples";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);

        SqlDataReader reader = oCommand.ExectuteReader();

        bool returnValue = false;

        while (reader.Read())
        {
            string phone = Convert.ToString(reader[0]);

            if (phone == Login)
            {
                //совпадение найдено
                returnValue = true;// такой логин существует
                continue;
            }

        }
        oConnection.closeConnection();
        return returnValue;
    }

    public object GetPrevPeopleValue(String ValueName)//return value from prev people
    {

        return GetPeopleValue(getPrevPeopleID(), ValueName);

    }
    public object GetNextPeopleValue(String ValueName)//return value from next people
    {
        return GetPeopleValue(getNextPeopleID(), ValueName);
    }

    public object GetCurrentPeopleValue(String ValueName)
    {
        return GetPeopleValue(getCurrentPeopleID(), ValueName);
    }

    public void getPeopleIDs(string name, string surname, string tableName)
    {

        if (PeopleIDs != null)
        {
            PeopleIDs = new List<int>(); ;//очищаем чтобы заполнить заново
        }
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT ID FROM " + tableName + " Where(Name=@Name) AND (Surname=@Surname)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@Name", name);//Select Parameter
        oCommand.AddSelectParam("@Surname", surname);//Select Parameter


        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {
            int id = Convert.ToInt32(reader[0]);

            PeopleIDs.Add(id);//считывание в массив юрэлов

        }



        counter = 0;
        oConnection.closeConnection();
    }


    public int getCurrentPeopleID()
    {
        return PeopleIDs.ElementAt(counter);
    }

    public int getNextPeopleID()
    {
        counter++;
        if (counter > this.PeopleIDs.Count - 1)
            counter = 0;
        return PeopleIDs.ElementAt(counter);

    }


    public int getPrevPeopleID()
    {
        counter--;
        if (counter < 0)
            counter = PeopleIDs.Count - 1;
        return PeopleIDs.ElementAt(counter);

    }
}