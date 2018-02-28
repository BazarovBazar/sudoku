using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ButExit_Click(object sender, EventArgs e)
    {
        if (Response.Cookies[ConstantNames.UserID] != null)
        {
            Response.Cookies[ConstantNames.UserID].Expires = DateTime.Now.AddDays(-1);
        }
        // Response.Redirect("C:\Users\)_(\Documents\Visual Studio 2010\WebSites\WebSite5\main.aspx.cs");
        Response.Redirect("Enter.aspx");
    }

    protected void ButtNewGame_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sudoku.aspx");
    }
}