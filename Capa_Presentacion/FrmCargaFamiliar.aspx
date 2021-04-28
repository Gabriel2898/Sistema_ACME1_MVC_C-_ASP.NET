<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmCargaFamiliar.aspx.cs" Inherits="Capa_Presentacion.FrmCargaFamiliar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Css/estilosGeneral.css" rel="stylesheet" />
</head>

<body>
    <form id="frmFamiliar" runat="server" style="margin: auto; text-align: center; width: 220%; max-width: 800px; padding: 0px;">
        <h1>Familiar del Empleado</h1>
            <asp:HiddenField ID="hfFamiliarId" runat="server"/>
            <table id="tbl" border="0">
                <tr>
                    <td><asp:Label ID="lblCedulaPariente" runat="server" Text="Cédula " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtCedulaPariente" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtNombre" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblApellido" runat="server" Text="Apellido " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtApellido" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblParentesco" runat="server" Text="Parentesco " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtParentesco" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEdad" runat="server" Text="Edad " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtEdad" TextMode="Number" runat="server" CssClass="txtTabla"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblCedulaEmpleado" runat="server" Text="Cedula del Empleado " Font-Bold="true" ForeColor="White" /></td>
                    <td colspan="3"><asp:TextBox ID="txtCedulaEmpleado" runat="server" CssClass="txtTabla"></asp:TextBox></td>
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
            <asp:GridView ID="GrvCargaFamiliar" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="7"
                >
                <Columns>
                    <asp:BoundField DataField="carf_cedula" HeaderText="PARIENTE"/>
                    <asp:BoundField DataField="carf_nombre" HeaderText="NOMBRE"/>
                    <asp:BoundField DataField="carf_apellido" HeaderText="APELLIDO"/>
                    <asp:BoundField DataField="carf_parentesco" HeaderText="PARENTESCO"/>
                    <asp:BoundField DataField="carf_edad" HeaderText="EDAD"/>
                    <asp:BoundField DataField="per_cedula" HeaderText="EMPLEADO"/>
                    <asp:BoundField DataField="empr_nombre" HeaderText="EMPRESA"/>
                    <asp:BoundField DataField="dep_nombre" HeaderText="DEPARTAMENTO"/>
                    <asp:BoundField DataField="carg_nombre" HeaderText="CARGO"/>
                    <asp:TemplateField HeaderText="_________________________">
                        <ItemTemplate>
                       <asp:LinkButton ID="linkVer" runat="server" OnClick="LinkVer_Click" CommandArgument='<%# Eval("carf_id")%>' CssClass="lnkGrid">&nbsp;&nbsp;&nbsp;Rellenar Datos&nbsp;&nbsp;&nbsp;</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
             </div><br /><br /><br />
          <asp:Button ID="btnVolver" runat="server" Text="Menu Principal" Height="40px" OnClick="BtnVolver_Click" CssClass="btnTabla"/>
    </form>
</body>
</html>
