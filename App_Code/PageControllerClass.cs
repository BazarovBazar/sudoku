using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;



using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for PageControllerClass
/// </summary>
public class PageControllerClass
{
	public PageControllerClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    
    private static string NextPage;
    private static string PreviousPage;
    



    public void GoToPage(string pageName)
    {
        TextWriter writer;
//        HttpResponse Response = new HttpResponse(writer);
//        Response.Redirect( pageName );
    }

    public void GoToPrevPage() {
    
    }

    
}