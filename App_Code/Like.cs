using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Like
/// </summary>
public class Like
{
	public Like()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void AddNewLike(string groupTableName/*Images, Posts or other*/, int groupID/*ImageID, PostID*/, int PeopleID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();

        List<TableValue> insertValues = new List<TableValue>();
        
        TableValue tabValue = new TableValue();
        tabValue.ValueName = "GroupTableName";
        tabValue.Value = groupTableName;
        insertValues.Add(tabValue);

        TableValue tabValue1 = new TableValue();
        tabValue1.ValueName = "GroupID";
        tabValue1.Value = groupID;
        insertValues.Add(tabValue1);


        TableValue tabValue2 = new TableValue();
        tabValue2.ValueName = "PeopleID";
        tabValue2.Value = PeopleID;
        insertValues.Add(tabValue2);

        TableValue tabValue3 = new TableValue();
        tabValue3.ValueName = "UniqueID";
        tabValue3.Value = oTable.GetMaxID("UniqueID", "Like");
        insertValues.Add(tabValue3);

        TableValue tabValue4 = new TableValue();
        tabValue4.ValueName = "IDinGroup";
        tabValue4.Value = oTable.GetMaxIDInGroup("IDinGroup","Like","GroupID", groupID);
        insertValues.Add(tabValue4);

        oTable.InsertToTable( insertValues, "Like");
    }


    // считаем количество лайков для картинки или для поста
    public int GetLikeCount(int GroupID/*ImageID or PublicID*/, string GroupTableName/*Images or Publics*/)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

         string queryString = "SELECT IDinGroup FROM Like WHERE( GroupTableName=@GroupTableName ) and ( GroupID=@GroupID )";
//        string queryString = "SELECT GroupID FROM Like";// WHERE( GroupTableName=@GroupTableName ) and ( GroupID=@GroupID )";

        oCommand.PrepareSelectQuery(queryString, oConnection.connection);
        oCommand.AddSelectParam("@GroupTableName", GroupTableName);//Select Parameter
        oCommand.AddSelectParam("@GroupID", GroupID);//Select Parameter

        SqlDataReader reader = oCommand.ExectuteReader();

        int likeCount = 0; 
        while (reader.Read())
        {
            likeCount++;// считаем количество лайков для картинки или для поста
        }

        oConnection.closeConnection();

        return likeCount;
        
    }

    public void DeleteLike(string GroupName/*Images or other*/, int groupID/*ImageID or other*/, int PeopleID)
    {
        SQLConnectionClass oConnection = new SQLConnectionClass();
        SQLCommandClass oCommand = new SQLCommandClass();

        //      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "DELETE FROM Like WHERE  (GroupTableName=@GroupName) and (GroupID=@GroupID) and (PeopleID=@PeopleID)";

        oCommand.PrepareDeleteQuery(queryString, oConnection.connection);
        oCommand.AddDeleteParam("@GroupName", GroupName);
        oCommand.AddDeleteParam("@GroupID", groupID);
        oCommand.AddDeleteParam("@PeopleID", PeopleID);

        oCommand.ExecuteDeleteQuery();

        //Command.ExecuteNonQuery();
        /* To Future:
         * Delete smiles, stickers, images
        */

        oConnection.closeConnection();

    }

    public List<string> getPeoplesNamesOfLike(int LikeID/*Unique ID*/)
    {
        List<string> list = new List<string>();
 
        return list;
    }
    
}