<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCargo.aspx.cs" Inherits="Capa_Presentacion.FrmCargo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Css/estilosGeneral.css" rel="stylesheet" />
</head>
<body>
    <form id="frmCargo" runat="server" style="margin: auto; text-align: center; width: 90%; max-width: 650px; padding: 0px;">
        <h1>Cargo</h1>
            <asp:HiddenField ID="hfCargoId" runat="server"/>
            <table id="tbl" border="0">
                <tr>
                    <td><asp:Label ID="lblCargo" runat="server" Text="Descripción " Font-Bold="true" ForeColor="white" /></td>
                    <td colspan="3"><asp:TextBox ID="txtCargo" runat="server" CssClass="txtTabla"></asp:TextBox></td>
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
            <asp:GridView ID="GrvCargo" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7"
                >
                <Columns>
                    <asp:BoundField DataField="carg_nombre" HeaderText="CARGO U OCUPACIÓN"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                       <asp:LinkButton ID="linkVer" runat="server" OnClick="LinkVer_Click" CommandArgument='<%# Eval("carg_id")%>' CssClass="lnkGrid">&nbsp;&nbsp;&nbsp;Rellenar Campos&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div><br /><br /><br />
          <asp:Button ID="btnVolver" runat="server" Text="Menu Principal" Height="40px" OnClick="BtnVolver_Click" CssClass="btnTabla"/>
    </form>
</body>
</html>
