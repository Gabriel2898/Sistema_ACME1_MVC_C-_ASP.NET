<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmDepartamento.aspx.cs" Inherits="Capa_Presentacion.FrmDepartamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Css/estilosGeneral.css" rel="stylesheet" />
</head>
<body>
    
     <form id="frmDepartamento" runat="server" style="margin: auto; text-align: center; width: 90%; max-width: 650px; padding: 0px;">
        <h1>Departamentos de la Empresa</h1>
            <asp:HiddenField ID="hfDepartamentoId" runat="server"/>
            <table id="tbl" border="0">
                <tr>
                    <td><asp:Label ID="lblDepartamento" runat="server" Text="Descripción " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtDepartamento" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEmpresa" runat="server" Text="Empresa " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:DropDownList ID="ddlEmpresa" runat="server" /></td>
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
            <asp:GridView ID="GrvDepartamento" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7"
                >
                <Columns>
                    <asp:BoundField DataField="dep_nombre" HeaderText="DEPARTAMENTO"/>
                    <asp:BoundField DataField="empr_ruc" HeaderText="RUC EMPRESARIAL" />
                    <asp:BoundField DataField="empr_nombre" HeaderText="NOMBRE DE LA EMPRESA" />
                    <asp:TemplateField>
                        <ItemTemplate>
                       <asp:LinkButton ID="linkVer" runat="server" OnClick="LinkVer_Click" CommandArgument='<%# Eval("dep_id")%>' CssClass="lnkGrid">&nbsp;&nbsp;&nbsp;Rellenar Datos&nbsp;&nbsp;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div><br /><br /><br />
          <asp:Button ID="btnVolver" runat="server" Text="Menu Principal" Height="40px" OnClick="BtnVolver_Click" CssClass="btnTabla"/>
    </form>

</body>
</html>
