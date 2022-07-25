<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="marca.aspx.cs" Inherits="WebApplication1.Marca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<link rel="apple-touch-icon" sizes="180x180" href="vendors/images/apple-touch-icon.png">
	<link rel="icon" type="image/png" sizes="32x32" href="vendors/images/favicon-32x32.png">
	<link rel="icon" type="image/png" sizes="16x16" href="vendors/images/favicon-16x16.png">

	<!-- Mobile Specific Metas -->
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<!-- Google Font -->
	<link href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700;800&display=swap" rel="stylesheet">
	<!-- CSS -->
	<link rel="stylesheet" type="text/css" href="vendors/styles/core.css">
	<link rel="stylesheet" type="text/css" href="vendors/styles/icon-font.min.css">
	<link rel="stylesheet" type="text/css" href="src/plugins/datatables/css/dataTables.bootstrap4.min.css">
	<link rel="stylesheet" type="text/css" href="src/plugins/datatables/css/responsive.bootstrap4.min.css">
	<link rel="stylesheet" type="text/css" href="vendors/styles/style.css">
</head>
<body>
    <form id="form1" runat="server">

       <div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Guardar Nueva Marca"></asp:Label>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server" style="margin-bottom: 0px" Width="316px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Extra:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="313px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
        &nbsp;&nbsp;&nbsp;
           <asp:Button ID="Button3" runat="server" Text="Editar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="Button4" runat="server" Text="Elimar" />
           <br />
           <br />
           <br />
           <asp:Button ID="Button2" runat="server" Text="Ver Datos" />
           <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                   <asp:ButtonField ButtonType="Button" Text="Seleccionar" />
               </Columns>
               <EditRowStyle BackColor="#2461BF" />
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#EFF3FB" />
               <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
               <SortedAscendingCellStyle BackColor="#F5F7FB" />
               <SortedAscendingHeaderStyle BackColor="#6D95E1" />
               <SortedDescendingCellStyle BackColor="#E9EBEF" />
               <SortedDescendingHeaderStyle BackColor="#4870BE" />
           </asp:GridView>
           <br />
        </div>
				</div>
			</div>
       
    </form>
</body>
    	<!-- js -->
	<script src="vendors/scripts/core.js"></script>
	<script src="vendors/scripts/script.min.js"></script>
	<script src="vendors/scripts/process.js"></script>
	<script src="vendors/scripts/layout-settings.js"></script>
	<script src="src/plugins/apexcharts/apexcharts.min.js"></script>
	<script src="src/plugins/datatables/js/jquery.dataTables.min.js"></script>
	<script src="src/plugins/datatables/js/dataTables.bootstrap4.min.js"></script>
	<script src="src/plugins/datatables/js/dataTables.responsive.min.js"></script>
	<script src="src/plugins/datatables/js/responsive.bootstrap4.min.js"></script>
	<script src="vendors/scripts/dashboard.js"></script>
</html>
