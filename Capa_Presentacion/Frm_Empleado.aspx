<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Empleado.aspx.cs" Inherits="Capa_Presentacion.Menu_Empleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
 <form id="frmEmpleado" runat="server" style="margin: auto; text-align: center; width: 280%; max-width: 900px; padding: 0px;">
        <h1>Empleados</h1>
            <table id="tbl" border="1">
                 <tr>
                    <td><asp:Label ID="lblCedula" runat="server" Text="Cedula " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtCedula" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNombre1" runat="server" Text="Primer Nombre " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtNombre1" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNombre2" runat="server" Text="Segundo Nombre " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtNombre2" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblApellido1" runat="server" Text="Primer Apellido " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtApellido1" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblApellido2" runat="server" Text="Segundo Apellido " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtApellido2" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDireccion" runat="server" Text="Dirección " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtDireccion" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTelefono" runat="server" Text="Teléfono " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtTelefono" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCorreo" runat="server" Text="Correo " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:TextBox ID="txtCorreo" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblDepartamento" runat="server" Text="Departamento " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:DropDownList ID="ddlDepartamento" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCargo" runat="server" Text="Cargo " Font-Bold="true" ForeColor="DimGray" /></td>
                    <td colspan="3"><asp:DropDownList ID="ddlCargo" runat="server" /></td>
                </tr>
                <tr>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnGuardar" runat="server" Text="GUARDAR" OnClick="btnGuardar_Click" CssClass="btnTabla"/></td>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnBorrar" runat="server" Text="BORRAR" OnClick="btnBorrar_Click" CssClass="btnTabla" /></td>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnActualizar" runat="server" Text="ACTUALIZAR" OnClick="btnActualizar_Click" CssClass="btnTabla"/></td>
                    <td style="text-align:center; border:0px;"><asp:Button ID="btnLimpiar" runat="server" Text="LIMPIAR" OnClick="btnLimpiar_Click" CssClass="btnTabla"/></td>
                </tr> 
                <tr><td colspan="5" style="border:0px;"></td></tr>
               <tr>
                   <td colspan="5" style="border:0px;"><asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Text=""></asp:Label></td>
               </tr>
            </table>
        
            <br />
         <div id="containerEmp">
            <asp:GridView ID="GrvEmpleado" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="5"
                >
                <Columns>
                    <asp:BoundField DataField="per_primerNombre" HeaderText="NOMBRES"/>
                    <asp:BoundField DataField="per_segundoNombre" HeaderText=""/>
                    <asp:BoundField DataField="per_primerApellido" HeaderText="APELLIDOS"/>
                    <asp:BoundField DataField="per_segundoApellido" HeaderText=""/>
                     <asp:BoundField DataField="per_direccion" HeaderText="DIRECCION"/>
                     <asp:BoundField DataField="per_telefono" HeaderText="TELEFONO"/>
                     <asp:BoundField DataField="per_correo" HeaderText="CORREO"/>
                    <asp:BoundField DataField="empr_nombre" HeaderText="EMPRESA"/>
                    <asp:BoundField DataField="dep_nombre" HeaderText="DEPARTAMENTO"/>
                    <asp:BoundField DataField="carg_nombre" HeaderText="CARGO"/>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                       <asp:LinkButton ID="linkVer" runat="server" OnClick="linkVer_Click" CommandArgument='<%# Eval("per_cedula")%>' CssClass="lnkGrid">&nbsp;&nbsp;&nbsp;Rellenar Campos&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div><br />
          <asp:Button ID="btnVolver" runat="server" Text="REGRESAR AL MENU PRINCIPAL" Height="40px" OnClick="btnVolver_Click" CssClass="btnTabla"/>
    </form>
</body>
</html>
