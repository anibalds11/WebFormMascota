<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MascotaList.aspx.cs" Inherits="WebFormMascota.MascotaList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            MASCOTAS<br />
            <br />
            <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <a runat="server" href="~/MascotaCreate">Crear Mascota</a>
</body>
</html>
