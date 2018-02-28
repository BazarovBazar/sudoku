<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enter.aspx.cs" Inherits="Enter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Логин</div>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    телефон или емэйл<br />
    <br />
    Пароль<br />
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Войти" Width="76px" 
        onclick="enter" />
&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="Отмена" Width="76px" />
    <br />
    <asp:Button ID="ButRegistration" runat="server" onclick="ButRegistration_Click" 
        style="margin-left: 7px" Text="Зарегистрироваться" Width="153px" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Height="178px" Width="270px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ID], [Name], [Surname], [Phone], [Password] FROM [Peoples]"></asp:SqlDataSource>
    </form>
</body>
</html>
