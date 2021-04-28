<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEmpresa.aspx.cs" Inherits="Capa_Presentacion.FrmEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <link href="Css/estilosGeneral.css" rel="stylesheet" />
</head>
<body>
     <form id="frmEmpresa" runat="server" style="margin: auto; text-align: center; width: 90%; max-width: 650px; padding: 0px;">
        <h1>Información de la Empresa</h1>
            <asp:HiddenField ID="hfEmpresaId" runat="server"/>
            <table id="tbl" border="0">
                <tr>
                    <td><asp:Label ID="lblRuc" runat="server" Text="Ruc " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtRuc" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtNombre" runat="server"  CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTelefono" runat="server" Text="Teléfono " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtTelefono" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDireccion" runat="server" Text="Dirección " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtDireccion" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" OnClick="BtnGuardar_Click" CssClass="btnTabla"/></td>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnBorrar" runat="server" Text="BORRAR" OnClick="BtnBorrar_Click" CssClass="btnTabla" /></td>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" OnClick="BtnActualizar_Click" CssClass="btnTabla"/></td>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnLimpiar" runat="server" Text="LIMPIAR" OnClick="BtnLimpiar_Click" CssClass="btnTabla"/></td>
                </tr> 
                <tr><td colspan="5" style="border:0px;"></td></tr>
               <tr>
                   <td colspan="5" style="border:0px;"><asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Text=""></asp:Label></td>
               </tr>
            </table>
        
            <br />
         <div id="container">
            <asp:GridView ID="GrvEmpresa" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7"
                >
                <Columns>
                    <asp:BoundField DataField="empr_ruc" HeaderText="RUC"/>
                    <asp:BoundField DataField="empr_nombre" HeaderText="NOMBRE" />
                    <asp:BoundField DataField="empr_telefono" HeaderText="TELEFONO" />
                    <asp:BoundField DataField="empr_direccion" HeaderText="DIRECCION" />
                    <asp:TemplateField>
                        <ItemTemplate>
                       <asp:LinkButton ID="linkVer" runat="server" OnClick="LinkVer_Click" CommandArgument='<%# Eval("empr_id")%>' CssClass="lnkGrid">&nbsp;&nbsp;&nbsp;RellenarCampos&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div><br /><br /><br />
          <asp:Button ID="btnVolver" runat="server" Text="Menu Principal" Height="40px" OnClick="BtnVolver_Click" CssClass="btnTabla"/>
    </form>
</body>
</html>
