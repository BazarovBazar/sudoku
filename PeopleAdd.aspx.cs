using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class PeopleAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies[ConstantNames.UserID] != null)
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void ButtonRegistration_Click(object sender, EventArgs e)
    {
        PeoplesClass oPeople = new PeoplesClass();

        bool loginExist = false;

        if (oPeople.isLoginExist(this.TextBoxPhone.Text))
        {

            this.LabelMessage.Text = " логин уже привязан к другой странице. Укажите другой логин.";
            loginExist = true;
        }

        if (this.TextBoxPassw.Text.Length < 5)
        {
            this.LabelMessage.Text = " пароль слишком короткий. введите пароль не менее 5 символов";
            loginExist = true;
        }

        if(!loginExist)
        {
            SQLConnectionClass oConnection = new SQLConnectionClass();

            SQLCommandClass oCommand = new SQLCommandClass();

            string sqlIns = "INSERT INTO Peoples( ID, Name, Surname, Phone, Password) VALUES (@ID, @Name, @Surname, @Phone, @Password)";

            //использовать только в такой последовательности
            oCommand.PrepareInsertQuery(sqlIns, oConnection.connection);


            int newIDPeoples = ID_OPerator.createNewTableID("ID", "Peoples");
            if (newIDPeoples == -2)
            {
                //некорректные параметры
            }

            oCommand.AddInsertParameter("@ID", Convert.ToString(newIDPeoples));//заносим новый айди
            oCommand.AddInsertParameter("@Name", this.TextBoxName.Text);
            oCommand.AddInsertParameter("@Surname", this.TextBoxSurname.Text);
            oCommand.AddInsertParameter("@Phone", this.TextBoxPhone.Text);
            oCommand.AddInsertParameter("@Password", this.TextBoxPassw.Text);

            oCommand.ExecuteQuery();

            oConnection.closeConnection();


            Response.Cookies[ConstantNames.UserID].Value = Convert.ToString(newIDPeoples);//UserID to cookie
            Response.Cookies[ConstantNames.UserID].Expires = DateTime.Now.AddDays(1);

            Response.Redirect("Login.aspx");
        }

    }

    protected void ButtonCancell_Click(object sender, EventArgs e)
    {
        Response.Redirect("Enter.aspx");
    }
}