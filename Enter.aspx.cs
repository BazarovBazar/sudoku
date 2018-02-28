﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;


public partial class Enter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }


    protected void enter(object sender, EventArgs e)//почемуто не переходит на другую страницу
    {

       
        SQLConnectionClass oConnection = new SQLConnectionClass();

        SQLCommandClass oCommand = new SQLCommandClass();

        
//      string sqlIns = "INSERT INTO table (name, information, other) VALUES (@name, @information, @other)";

        string queryString = "SELECT ID, Name, Surname, Phone, Password FROM Peoples Where Phone=@phone";



        oCommand.PrepareSelectQuery(queryString, oConnection.connection);

        oCommand.AddSelectParam("@phone", this.TextBox6.Text);//Для сравнения

        SqlDataReader reader = oCommand.ExectuteReader();

        string phoneNumb;
        string Password;


        while (reader.Read())
        {

            phoneNumb = reader[3] as string;//приведение типов
            Password = reader[4] as string;//приведение типов

            if (TextBox6.Text == phoneNumb)
            {//проверка логина

                if (TextBox5.Text == Password)//проверка пароля
                {
                    //Запоминаем в куки файл
                    Response.Cookies[ConstantNames.UserID].Value = Convert.ToString(reader[0]);//UserID to cookie
                    Response.Cookies[ConstantNames.UserID].Expires = DateTime.Now.AddDays(1);
                    // Response.Redirect("C:\Users\)_(\Documents\Visual Studio 2010\WebSites\WebSite5\main.aspx.cs");
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    //Invalid password
                }
            }

        }

/*
        id = reader.GetValue(0);
        name = reader.GetValue(1);
        surname = reader.GetValue(2);
        age = reader.GetValue(3);
*/ 


//      cmdIns.Parameters.Add("@name", info);

//      cmdIns.ExecuteNonQuery();//выполнить команду

        oConnection.closeConnection();

    }
    protected void ButRegistration_Click(object sender, EventArgs e)
    {
        Response.Redirect("PeopleAdd.aspx");
    }
}