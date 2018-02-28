using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for Comment
/// </summary>
/// 

// SELECT count(*) FROM comment WHERE comment.page=page_id.

public class Comment
{

    List<int> ImageIDsOfPeople;
    int IDcounter;

	public Comment()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// установка IDCounter в соответствие с текущим ImageID
    /// </summary>
    /// <param name="ImageID"></param>
    public void SetImageIDCounter(int ImageID)
    {
        int beginIDCounter = IDcounter;
        while(ImageID != this.GetNextImageIDofPeople() )
        {
            if (IDcounter == beginIDCounter)
                break;
        }
    }

    public void DeleteImgComment(int ImgCommentID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();
        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "DELETE FROM ImageComment WHERE ImgCommentID=@ImgCommentID";

        oCommand.PrepareDeleteQuery(queryString, oConnection.connection);
        oCommand.AddDeleteParam("@ImgCommentID", ImgCommentID);

        oCommand.ExecuteDeleteQuery();
       
        //Command.ExecuteNonQuery();
        /* To Future:
         * Delete smiles, stickers, images
        */

        oConnection.closeConnection();

    }

    public int GetImgCommentID(int ID, int imgID )
    {
        int returnVal = 0;

        SQLConnectionClass oConnection = new SQLConnectionClass();
        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT ImgCommentID FROM ImageComment Where (ID=@ID) AND (ImageID=@ImageID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@ID", ID);//Select Parameter
        oCommand.AddSelectParam("@ImageID", imgID);//Select Parameter
        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {

            if ((reader[0] != null) && (!Convert.IsDBNull(reader[0])))
            {
                returnVal = Convert.ToInt32(reader[0]);//
            }
        }

        oConnection.closeConnection();
        return returnVal;
    }

    public int GetMaxID( int ImageID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT ID FROM ImageComment Where ImageID=@ImageID";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@ImageID", ImageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        int maxID = -1;//если в таблице совсем нет записей
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

    public int GenerateNewID(int ImageID)
    {
        int newID = this.GetMaxID(ImageID);
        if (newID == -1)//если таблица пустая
        {
            newID = 0;//создаем самый первый айди
        }

        return newID + 1;
    }
    /// <summary>
    /// Это метод используется чаще всего
    /// </summary>
    /// <param name="ImageID"></param>
    /// <param name="CommentPeopleID"></param>
    /// <param name="text"></param>

    public void AddCommentToImage(int ImageID, int CommentPeopleID, string text )
    {
        if (text == null || text == "")
            return;//если пустая строка то не добавляем

        SQLConnectionClass oConnection = new SQLConnectionClass();
        SQLCommandClass oCommand = new SQLCommandClass();
        TableOpreatorClass TablePerator = new TableOpreatorClass();

        int ID = this.GenerateNewID(ImageID);//Последовательность номеров для каждой картинки

        TableOpreatorClass oTable = new TableOpreatorClass();
        int ImgCommentID = oTable.GenerateNewID("ImgCommentID", "ImageComment");//Уникальный номер для каждой картинки

        string sqlIns = "INSERT INTO ImageComment( ID, ImgCommentID, ImageID, CommentPeopleID, Text ) VALUES (@ID ,@ImgComID, @ImageID, @CommentPeopleID, @Text )";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);


        oCommand.AddInsertParameter("@ID", ID);//заносим новый айди
        oCommand.AddInsertParameter("@ImgComID", ImgCommentID);//заносим новый айди
        oCommand.AddInsertParameter("@ImageID", ImageID);
        oCommand.AddInsertParameter("@CommentPeopleID", CommentPeopleID);
        oCommand.AddInsertParameter("@Text", text );

        oCommand.ExecuteQuery();
        oConnection.closeConnection();
    }
    /// <summary>
    /// Чтение в переменную обьекта класса Comment.
    /// </summary>
    /// <param name="PeopleID"></param>
    public void ReadeImageIDsOfPeople(int PeopleID)
    {
        ImageIDsOfPeople = new List<int>();
        ImageClass oImage = new ImageClass();
        oImage.readeImageIDs(PeopleID, ImageIDsOfPeople);
        this.IDcounter = 0;

    }

    public int GetNextImageIDofPeople()
    {
        if (ImageIDsOfPeople == null)
            return -1;

        if (ImageIDsOfPeople.Count == 0)
            return -1;
        
        this.IDcounter++;
        if (this.IDcounter == this.ImageIDsOfPeople.Count)
            this.IDcounter = 0;

        return ImageIDsOfPeople.ElementAt(IDcounter);

    }

    public int GetPrevImageIDOfPeople()
    {
        if (ImageIDsOfPeople == null)
            return -1;

        if (ImageIDsOfPeople.Count == 0)
            return -1;
        this.IDcounter--;
        if (this.IDcounter < 0 )
            this.IDcounter = this.ImageIDsOfPeople.Count - 1;
        return ImageIDsOfPeople.ElementAt(IDcounter);        
    }

    public int GetCurrentImageIDOfPeople()
    {
        if (ImageIDsOfPeople == null)
            return -1;

        if (ImageIDsOfPeople.Count == 0)
            return -1;

       return ImageIDsOfPeople.ElementAt(IDcounter);
    }



    
    public string selectImageCommentText(int ImageID, int ID)
    {
        string returnValue = null;

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();


        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";



        string queryString = "SELECT CommentPeopleID, Text FROM ImageComment Where (ID = @ID) AND (ImageID = @ImageID)";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@ImageID", ImageID);//Select Parameter
        oCommand.AddSelectParam("@ID", ID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        if (reader.Read())
        {

            int CommentPeopleID = Convert.ToInt32(reader[0]);

            PeoplesClass oPeople = new PeoplesClass();

            string comPeopleSurname = oPeople.GetPeopleSurname(CommentPeopleID);
            string comPeopleName = oPeople.GetPeopleName(CommentPeopleID);
            string comText = Convert.ToString(reader[1]);

            returnValue = comPeopleSurname + comPeopleName + ": " + comText;

            //исключено что строка пустая

        }

        oConnection.closeConnection();

        return returnValue;//null если нет записей в таблице
    }

    public string GetImageCommentsToListBox( int ImageID, ListBox listBox)
    {
        string returnValue = null;

        if (ImageID < 0)
            return returnValue;

        listBox.Items.Clear();

        string comText;

        int id = 1;// может прерываться, возможны точки разрыва
        bool flag = true;

        TableOpreatorClass oTable = new TableOpreatorClass();

        int maxID = oTable.GetMaxID("ID", "ImageComment");

        while (flag)
        {
            comText = this.selectImageCommentText(ImageID, id);


            int imgCommentID = this.GetImgCommentID(id, ImageID);//???????
            if (id > maxID)
            {
                id++;
                flag = false;
            }

            if (comText == null)// Если ничего не прочитано
            {
                id++;
            }
            else
            {

                ListItem listItem = new ListItem();
                listItem.Text = comText;
                listItem.Value = Convert.ToString( imgCommentID );
                listBox.Items.Add(listItem);
                id++;
            }
        }
        
        return returnValue;
    }
}