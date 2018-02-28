<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PeopleAdd.aspx.cs" Inherits="PeopleAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 376px; height: 17px">
    
        <asp:Label ID="Label1" runat="server" Text="Регистрация нового пользователя"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Имя"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
        </Columns>
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ID], [Name], [Surname], [Phone], [Password] FROM [Peoples]"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Фамилия"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxSurname" runat="server" Height="20px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Пароль"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="TextBoxPassw" runat="server"></asp:TextBox>
    <asp:Label ID="Label5" runat="server" Text="Логин"></asp:Label>
    <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    <br />
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="ButtonRegistration" runat="server" 
            onclick="ButtonRegistration_Click" Text="Зарегистрировать" />
        <asp:Button ID="ButtonCancell" runat="server" style="margin-left: 118px" 
            Text="Отмена" Width="149px" onclick="ButtonCancell_Click" />
    </p>
    </form>
</body>
</html>
