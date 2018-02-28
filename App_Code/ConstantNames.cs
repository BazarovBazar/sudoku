using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConstantNames
/// </summary>
public class ConstantNames
{
	public ConstantNames()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static String UserID = "UserID";
    public static String SelectedPeopleID =  "SelectedPeopleID";

    public static String SelectedImageID = "SelectedImageID";
    public static String NextImageID = "NextImageID";
    public static String PrevImageID = "PrevImageID";

    public static String PreviousPageURL = "PreviousPageURL";
    public static int[,] SudokuArray = new int[9,9];

}