<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmReferencia.aspx.cs" Inherits="Capa_Presentacion.FrmReferencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Css/estilosGeneral.css" rel="stylesheet" />
</head>
<body>
    <form id="frmCargo" runat="server" style="margin: auto; text-align: center; width: 220%; max-width: 800px; padding: 0px;">
        <h1>Referencias de Empleados</h1>
            <asp:HiddenField ID="hfReferenciaId" runat="server"/>
            <table id="tbl" border="0">
                <tr>
                    <td><asp:Label ID="lblReferencia" runat="server" Text="Descripción " Font-Bold="true" ForeColor="white" /></td>
                    <td colspan="3"><asp:TextBox ID="txtReferencia" TextMode="MultiLine" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                    <td rowspan="5"><asp:Button ID="btnTipos" runat="server" Text="Administrar Tipos" Height="40px" OnClick="btnTipos_Click" CssClass="btnTabla" /></td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblTipo" runat="server" Text="Tipo de Referencia " Font-Bold="true" ForeColor="white" /></td>
                    <td colspan="3"><asp:DropDownList ID="ddlTipo" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCedula" runat="server" Text="Cédula del Empleado " Font-Bold="true" ForeColor="white" /></td>
                    <td colspan="3"><asp:TextBox ID="txtCedula" runat="server" CssClass="txtTabla"></asp:TextBox></td>
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
         <div id="containerEmp">
            <asp:GridView ID="GrvReferencia" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7"
                >
                <Columns>
                    <asp:BoundField DataField="ref_descripcion" HeaderText="Referencia" />
                    <asp:BoundField DataField="tipr_nombre" HeaderText="Tipo de Referencia"/>
                    <asp:BoundField DataField="per_cedula" HeaderText="Cedula del Empleado"/>
                    <asp:BoundField DataField="per_primerNombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="per_primerApellido" HeaderText="Apellido"/>
                    <asp:BoundField DataField="empr_nombre" HeaderText="Empresa de Trabajo"/>
                    <asp:BoundField DataField="dep_nombre" HeaderText="Departamento"/>
                    <asp:BoundField DataField="carg_nombre" HeaderText="Cargo"/>
                    <asp:TemplateField HeaderText="_________________________">
                        <ItemTemplate>
                       <asp:LinkButton ID="linkVer" runat="server" OnClick="LinkVer_Click" CommandArgument='<%# Eval("ref_id")%>' CssClass="lnkGrid">&nbsp;&nbsp;&nbsp;Rellenar Datos&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div><br /><br /><br />
          <asp:Button ID="btnVolver" runat="server" Text="Menu Principal" Height="40px" OnClick="BtnVolver_Click" CssClass="btnTabla"/>
    </form>
</body>
</html>
