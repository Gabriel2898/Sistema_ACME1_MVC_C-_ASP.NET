<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Capa_Presentacion.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="Css/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="frmLogin" runat="server" class="box">
        <h1>INICIO DE SESIÓN</h1>
            

                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Font-Bold="true" ForeColor="DimGray"></asp:Label>
                     <!--<asp:RegularExpressionValidator ID="regexName" runat="server" ErrorMessage="No se aceptan caracteres extraños" ControlToValidate="txtUsuario" ValidationExpression="^[a-zA-z'.\s]{1,40}$"></asp:RegularExpressionValidator>-->
                
                    <asp:Label ID="msjUsuario" runat="server"  ForeColor="Red"></asp:Label>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Ingrese Solo Letras" SetFocusOnError="True" ValidationExpression="[A-Za-z]*" ForeColor="White">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" Display="Dynamic" ErrorMessage="Ingrese Solo Letras" ForeColor="White">*</asp:RequiredFieldValidator>
                    
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="txtTabla" type="text"></asp:TextBox>
                    
                    <asp:Label ID="lblClave" runat="server" Text="Clave" Font-Bold="true" ForeColor="DimGray"></asp:Label>

                    <asp:Label ID="msjClave" runat="server" ForeColor="Red" ></asp:Label>

                    <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server" CssClass="txtTabla"></asp:TextBox>

                    <asp:Label ID="lblTipo" runat="server" Text="Tipo" Font-Bold="true" ForeColor="DimGray"></asp:Label>
                    <asp:DropDownList ID="dwlTipo" runat="server" Width="172px" />
                    <asp:Label ID="msjTipo" runat="server" ForeColor="Red" ></asp:Label>&nbsp;<asp:Button ID="btnLimpiar" Height="50px" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CssClass="btnTabla" />
                    <asp:Button ID="btnIngresar" Height="50px" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click" CssClass="btnTabla" />

                    <asp:Label ID="msjIniciar" runat="server" ForeColor="Red" ></asp:Label>


      
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="None" ForeColor="White" />


      
       </form>
</body>
</html>
