<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="ButtNewGame" runat="server" OnClick="ButtNewGame_Click" Text="Новая игра" Width="118px" />
        <br />
        <asp:Button ID="ButtLoadGame0" runat="server" Text="Настройки" Width="118px" />
        <br />
        <asp:Button ID="ButtLoadGame1" runat="server" Text="Загрузить игру" Width="118px" />
        <br />
        <asp:Button ID="ButtLoadGame" runat="server" Text="Загрузить игру" Width="118px" />
        <br />
        <asp:Button ID="ButExit" runat="server" OnClick="ButExit_Click" Text="Выйти" Width="118px" />
    </form>
</body>
</html>
