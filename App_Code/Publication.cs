using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PublicPost
/// </summary>
public class Publication
{
	public Publication()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void InsertNewPublication(int AuthorID/*PeopleID*/, int WallID, string Text, List<int> ImageIDList)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();

        TableValue value1 = new TableValue();
        value1.ValueName = "WallID";
        value1.Value = WallID;


        TableValue value2 = new TableValue();
        value2.ValueName = "UniqueID";
        int PublicationID  = oTable.GenerateNewID("UniqueID", "Publication");
        value2.Value = PublicationID;


        TableValue value3 = new TableValue();
        value3.ValueName = "IDinSequence";
        value3.Value = oTable.GetMaxIDInGroup("IDinSequence","Publication", "WallID", WallID);/*У стенки много публикаций
         Каждая публикация имеет уникальный айди и айди (IDinSequence) в последовательности публикаций со сходным WallID                                                                                      */

        TableValue value4 = new TableValue();
        value4.ValueName = "DateTime";
        value4.Value = DateTime.Now;

        TableValue value5 = new TableValue();
        value5.ValueName = "ImageListID";
        value5.Value = oTable.GenerateNewID("ID", "ImageList");

        TableValue value6 = new TableValue();
        value6.ValueName = "AuthorID";
        value6.Value = AuthorID;

        TableValue value7 = new TableValue();
        value7.ValueName = "Text";
        value7.Value = Text;

        List<TableValue> tableValueList = new List<TableValue>();
        tableValueList.Add(value1);
        tableValueList.Add(value2);
        tableValueList.Add(value3);
        tableValueList.Add(value4);
        tableValueList.Add(value5);
        tableValueList.Add(value6);
        tableValueList.Add(value7);

        oTable.InsertToTable(tableValueList, "Wall");//CreateNewWall


        tableValueList.Clear();

        TableValue value8 = new TableValue();
        value8.ValueName = "ID";
        Wall oWall = new Wall();
        int PublicationListID = oWall.GetPublicationListID(WallID);//узнаем айди списка публикаций
        value8.Value = PublicationListID;

        TableValue value9 = new TableValue();
        value9.ValueName = "PublicationID";
        value9.Value = PublicationID;


        oTable.InsertToTable(tableValueList, "PublicationList");//CreateNewWall

    }

    public void DeletePublication(int UniqueID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();
        oTable.DeleteValueFromTable("UniqueID", UniqueID, "Publication");
    }

    public string GetTextOfPublication(int PublicationID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();
        object oText = oTable.GetValueFromTableByIDName(PublicationID, "UniqueID", "Text", "Publication");
        if (oText == null)
            return"";
        string text = oText.ToString();

        return text;
    }

    public int GetAuthorID(int PublicationID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();
        object oAuthID = oTable.GetValueFromTableByIDName(PublicationID, "UniqueID", "AuthorID", "Publication");
        if (oAuthID == null)
            return -1;

        int AuthID = Convert.ToInt32(oAuthID);

        return AuthID;
    }
/// <summary>
/// returns -1 if list of images is clear
/// </summary>
/// <param name="PublicationID"></param>
/// <returns></returns>
    public int GetImageListID(int PublicationID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();
        object ListID = oTable.GetValueFromTableByIDName(PublicationID, "UniqueID", "ImageListID", "Publication");
        if (ListID == null)
            return -1;

        int listID = Convert.ToInt32(ListID);
        return listID;
    }
}