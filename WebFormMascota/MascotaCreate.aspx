<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MascotaCreate.aspx.cs" Inherits="WebFormMascota.MascotaCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Nombre:<asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        </div>
        <p>
            Raza:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            Edad<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="BtGuardar" runat="server" OnClick="BtGuardar_Click" Text="Crear Mascota" />
    </form>
</body>
</html>
