<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="monitor.aspx.cs" Inherits="WebApplication1.monitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Guarda Nuevo Monitor"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Selecciona la marca:"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Conector:"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="211px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Tamaño:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="212px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Editar" />
&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="Eliminar" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Ver Datos" />
            <br />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField ButtonType="Button" Text="Seleccionar" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
