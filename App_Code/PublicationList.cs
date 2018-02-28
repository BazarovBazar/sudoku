using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PublicationList
/// </summary>
public class PublicationList
{
	public PublicationList()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<int> GetPublicationIDs(int publicationListID)
    {
        List<int> returnValue = new List<int>();

        TableOpreatorClass oTable = new TableOpreatorClass();
        bool flag = true;
        while(flag)
        {
            object id = oTable.GetValueFromTable(publicationListID, "PublicationID", "PublicationList");
            if (id == null)
            {
                flag = false;
                continue;
            }
            int ID = Convert.ToInt32(id);
            returnValue.Add(ID);
        }

        return returnValue; 
    }

    public void DeletePublicationList(int ID)
    {
        TableOpreatorClass oTable = new TableOpreatorClass();
        oTable.DeleteValueFromTable("ID", ID, "PublicationList");
    }


}