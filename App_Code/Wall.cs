using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Wall
/// Класс полностью не тестировался
/// </summary>
public class Wall
{
	public Wall()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int GetPublicationListID(int WallID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();

        int returnValue = Convert.ToInt32( oTable.GetValueFromTable(WallID, "PublicationListID", "Wall") );
        return returnValue;
    }

    public DateTime GetDateTime(int WallID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();

        DateTime returnValue = Convert.ToDateTime(oTable.GetValueFromTable(WallID, "DateTime", "Wall"));

        return returnValue;
    }

    public int InsertNewWall()//returns new wall ID
    {
        TableOpreatorClass oTable = new TableOpreatorClass();

        TableValue value1 = new TableValue();
        value1.ValueName = "ID";
        int ID = oTable.GenerateNewID("ID", "Wall");
        value1.Value = ID;

        int returnValue = ID;

        TableValue value2 = new TableValue();
        value2.ValueName = "PublicationListID";
        ID = oTable.GenerateNewID("ID","PublicationList");
        value2.Value = ID;

        TableValue value3 = new TableValue();
        value3.ValueName = "DateTime";
        value3.Value = DateTime.Now;

        List<TableValue> tableValueList = new List<TableValue>();
        tableValueList.Add(value1);
        tableValueList.Add(value2);
        tableValueList.Add(value3);

        oTable.InsertToTable(tableValueList,"Wall");//CreateNewWall

        return returnValue;
    }
    /// <summary>
    /// returns -1, if publication list of wall is not exist))
    /// </summary>
    /// <param name="WallID"></param>
    /// <returns></returns>
    public int GetPublicationList_ID_ofWall(int WallID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();
        object ID = oTable.GetValueFromTable(WallID, "PublicationListID", "Wall");
        if (ID == null)
            return -1;
        int returnValue = Convert.ToInt32( ID );
        return returnValue;
    }

    public void DeleteWall(int WallID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();
        oTable.DeleteValueFromTable("ID",WallID,"Wall");
    }

    public void SendNewPublication(int AuthorID/*PeopleID*/, int WallID, string Text, List<int> ImageIDList )
    {
        int PublicationListID = this.GetPublicationListID( WallID );

        Publication oPublication = new Publication();
        oPublication.InsertNewPublication(AuthorID, WallID, Text, ImageIDList);
    }


    /// <summary>
    /// копирует только несколько первых фраз от каждой публикации в листбокс
    /// </summary>
    /// <param name="WallID"></param>
    /// <param name="listBox"></param>
    /// <returns></returns>
    public int ReadePublicationsToListBox(int WallID, ListBox listBox)
    {
        if (listBox == null) return 1;//инициализируйте listBox;
        Publication oPublication = new Publication();

        int PublicationListID = this.GetPublicationList_ID_ofWall(WallID);//use of WallID

        PublicationList oPubList = new PublicationList();

        List<int> pubIDsList = oPubList.GetPublicationIDs(PublicationListID);// List of IDs of Publications. Use of PublicationListID

        foreach(int idOfPublication in pubIDsList)
        {
            /*oPublication. Get Text of Publication
            Get List of image ids of publication
            Get like list 
            Get Reading counter
             */

            /*в лист бокс считываем первые несколько фраз из каждой публикации */
            ListItem listItem = new ListItem();

            listItem.Text = oPublication.GetTextOfPublication(idOfPublication).Substring(0,20) + "..."; //копируем строку не полностью а только первые пятьдесят символов     
            listItem.Value = idOfPublication.ToString();

            listBox.Items.Add(listItem);
        }
        return 0;
    }

 }