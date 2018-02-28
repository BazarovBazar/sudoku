<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sudoku.aspx.cs" Inherits="Sudoku" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 264px;
            height: 285px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="cell11" runat="server" BorderColor="Blue" Columns="1" Font-Overline="True" ForeColor="#FF0066" Height="16px" Width="16px" OnTextChanged="cell_TextChanged" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="cell12" runat="server" BorderColor="Blue" Width="16px" OnTextChanged="cell_TextChanged" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="cell13" runat="server" BorderColor="Blue" Width="16px" OnTextChanged="cell_TextChanged" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="cell14" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell15" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell16" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell17" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell18" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell19" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell21" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell22" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell23" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell24" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell25" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell26" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell27" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell28" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell29" runat="server" BackColor="White" BorderColor="#0000CC" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell31" runat="server" BorderColor="Blue" Height="16px" OnTextChanged="cell_TextChanged" Width="16px" AutoPostBack="True"></asp:TextBox>
        <asp:TextBox ID="cell32" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell33" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell34" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell35" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell36" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell37" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell38" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell39" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell41" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell42" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell43" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell44" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell45" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell46" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell47" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell48" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell49" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell51" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell52" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell53" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell54" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell55" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell56" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell57" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell58" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell59" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell61" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell62" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell63" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell64" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell65" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell66" runat="server" BorderColor="Lime" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell67" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell68" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell69" runat="server" BorderColor="#CC0000" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell71" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell72" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell73" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell74" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell75" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell76" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell77" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell78" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell79" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell81" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell82" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell83" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell84" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell85" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell86" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell87" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell88" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell89" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <br />
        <asp:TextBox ID="cell91" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell92" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell93" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell94" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell95" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell96" runat="server" BorderColor="Red" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell97" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell98" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <asp:TextBox ID="cell99" runat="server" BorderColor="Blue" Width="16px" AutoPostBack="True" OnTextChanged="cell_TextChanged"></asp:TextBox>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Уровень: "></asp:Label>
            <asp:DropDownList ID="DropDownListOfLavels" runat="server" AutoPostBack="True" Height="19px" OnSelectedIndexChanged="DropDownListOfLavels_SelectedIndexChanged" Width="59px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="ButtonStart" runat="server" OnClick="ButtonStart_Click" Text="Старт" Width="109px" />
        </p>
    </form>
</body>
</html>
