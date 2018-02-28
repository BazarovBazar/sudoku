using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for ImageClass
/// </summary>
public class ImageClass
{
   
    int counter;
    List<string> imageUrls;
    public int userID { get; set; }

    List<Image> imagesOnPage;

    List<int> ImgIDs;
    int ImgIDCounter;
	public ImageClass()
	{
		//
		// TODO: Add constructor logic here
		//
        counter = 0;
        imageUrls = new List<string>();
        ImgIDs = new List<int>();
	}



    public void readeImageIDsOfPeople(int PeopleID)
    {
        ImgIDCounter = 0;
        this.readeImageIDs(PeopleID, this.ImgIDs);

        ImgIDCounter = ImgIDs.Count - 1;
    }


    /// <summary>
    /// Установка счетчика в ImgID
    /// </summary>
    /// <param name="ImgID"></param>
    public void SetImgIDCounterToImgID(int ImgID)
    {
        int BeginImgID = this.getCurrentImageID();//начальный айди
        while (ImgID != this.getNextImageID())
        {
            if (BeginImgID == this.getCurrentImageID())
                break;
        }
    }

    /// <summary>
    /// if List of ID clear returns -1
    /// </summary>
    /// <returns></returns>

    public int getCurrentImageID()
    {
        if (ImgIDs.Count == 0)
            return -1;

        return ImgIDs.ElementAt(ImgIDCounter);//getCurrentImageID
    }

    /// <summary>
    /// if List of ID clear returns -1
    /// </summary>
    /// <returns></returns>

    public int getNextImageID()
    {
        ImgIDCounter++;// ImgIDs.Count == 1 ImgIDCounter = 0
        if (ImgIDs.Count == 0)
            return -1;
        if (ImgIDCounter >= ImgIDs.Count)
        {
            ImgIDCounter = 0;
        }

        return ImgIDs.ElementAt(ImgIDCounter);
    }
    /// <summary>
    /// if List of ID clear returns -1
    /// </summary>
    /// <returns></returns>
    public int getPrevImageID()
    {
        if (ImgIDs.Count <= 0)
            return -1;// когда список пуст

        ImgIDCounter--;

        if( ImgIDCounter < 0 )
        {
            ImgIDCounter = ImgIDs.Count - 1;
        }

        return ImgIDs.ElementAt(ImgIDCounter);
    }




    public void GetImagesOfPerson(int PersonID)
    {
        

    }

    public int GetMaxImageID()// -1 если не найден ни один айди
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();
       
        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT ImageID FROM Images";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);

       
        SqlDataReader reader = oCommand.ExectuteReader();

        int maxID = -1;
        int imageID = 0;
        while (reader.Read())
        {

            if ( (reader[0] != null) &&( ! Convert.IsDBNull( reader[0]) ) )
            {
                imageID = Convert.ToInt32(reader[0]);//
                if (maxID < imageID)
                    maxID = imageID;
            }
        }
 
        oConnection.closeConnection();

        return maxID;

    }

    public int GenerateNewImageID()
    {
        int newImageID = this.GetMaxImageID();
        if (newImageID == -1)
        {
            newImageID = 0;//создаем самый первый айди
        }

        return newImageID + 1;
    }

    public void InsertNewImage(string path_Url, int PeopleID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        string sqlIns = "INSERT INTO Images(ImageID, PeopleID, imgURL_Path ) VALUES(@ImageID, @PeopleID, @ImagePathUrl) ";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);

        int NewImageID = this.GenerateNewImageID();

        oCommand.AddInsertParameter("@ImageID", NewImageID);
        oCommand.AddInsertParameter("@PeopleID", PeopleID);
        oCommand.AddInsertParameter("@ImagePathUrl", path_Url);     


        oCommand.ExecuteQuery();

        oConnection.closeConnection();


    }

    public void InsertNewImage(Image image, int PeopleID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        string sqlIns = "INSERT INTO Images(ImageID, PeopleID, imgURL_Path, Image) VALUES(@ImageID, @PeopleID, @ImagePathUrl, @Image) ";

        //использовать только в такой последовательности
        oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);

        int NewImageID = this.GenerateNewImageID();

        oCommand.AddInsertParameter("@ImageID", NewImageID);
        oCommand.AddInsertParameter("@PeopleID", PeopleID);
        
        oCommand.AddInsertParameter("@ImagePathUrl", image.ImageUrl);

        oCommand.AddInsertParameter("@Image", image);

        oCommand.ExecuteQuery();

        oConnection.closeConnection();


    }


    public void readeImageURls( int UserID, string tableName) //reade from database to List
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();
        userID = UserID;

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT PeopleID, imgURL_Path FROM " + tableName + " Where PeopleID=@PeopleID";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@PeopleID", UserID);//Select Parameter
        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {

            imageUrls.Add(reader[1] as string);//считывание в массив юрэлов
           
        }


        counter = 0;
        oConnection.closeConnection();
    }

    public int GetLikeCounterOfImage(int ImageID)
    {
        int likeCounter = 0;

        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT LikeCounter FROM Images Where ( ImageID = @ImageID )";
        /*
         * command.CommandText = "UPDATE Student(LastName, FirstName, Address, City) 
           VALUES (@ln, @fn, @add, @cit) WHERE LastName='" + lastName + 
                                   "' AND FirstName='" +  firstName+"'";
         */


        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@ImageID", ImageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        if(reader.Read())
        {
            if (reader[0] != DBNull.Value)
            {
                likeCounter = Convert.ToInt32(reader[0]);//считывание в массив юрэлов
            }
        }

        return likeCounter;
        oConnection.closeConnection();

    }

    public string readeImageURl( int ImageID, int PeopleID) //reade from database to List
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        string returnValue = null;

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT imgURL_Path FROM Images Where (ImageID = @ImageID) AND ( PeopleID=@PeopleID )";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@PeopleID", PeopleID);//Select Parameter
        oCommand.AddSelectParam("@ImageID", ImageID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        while (reader.Read())
        {

            returnValue = (reader[0] as string);//считывание в массив юрэлов

        }

        oConnection.closeConnection();
        return returnValue;
    }


    public void readeImageIDs(int PeopleID, List<int> ImageIDsOut)
    {

//        ImageIDsOut = new List<int>();
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT ImageID FROM Images Where PeopleID=@PeopleID";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@PeopleID", PeopleID);//Select Parameter
        SqlDataReader reader = oCommand.ExectuteReader();



        while (reader.Read())
        {

            if (reader[0] != DBNull.Value)
            {

                ImageIDsOut.Add(Convert.ToInt32(reader[0]));//считывание в массив юрэлов
            }
        }

        oConnection.closeConnection();


    }

    public string getNextImageUrl()
    {
        counter++;
        if (counter > imageUrls.Count-1)
            counter = 0;
        return imageUrls.ElementAt(counter);

    }

    public string getCurrentImageURL()
    {
        if (imageUrls.Count < 1)
            return null;

        return imageUrls.ElementAt(counter);
    }

    public string getPrevImageUrl()
    {
        counter--;
        if(counter<0)
            counter = imageUrls.Count-1;
        return imageUrls.ElementAt(counter);
    }

}