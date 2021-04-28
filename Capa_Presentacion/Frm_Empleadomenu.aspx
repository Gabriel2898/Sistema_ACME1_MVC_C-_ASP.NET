<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Empleadomenu.aspx.cs" Inherits="Capa_Presentacion.FrmEmpleadoMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Css/MenuAdmin.css" rel="stylesheet" />
    <link href="Css/estilosGeneral.css" rel="stylesheet" />
</head>
<body>
<form id="frmEmpleado" runat="server" style="margin: auto; text-align: center; width: 260%; max-width: 900px; padding: 0px;">
        <h1>Informacion Laboral</h1>
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
                </Columns>
            </asp:GridView><br />
             
             <h1>Capacitaciones</h1>
              <asp:GridView ID="GrvCapacitacion" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="5"
                >
                <Columns>
                    <asp:TemplateField ItemStyle-Width="350px" HeaderText="DESCRIPCION">
                        <ItemTemplate>
                            <asp:TextBox ID = "txtDescripcion" runat="server" 
                                TextMode= "MultiLine" Rows="5" Columns="1" 
                                Height= "100%" Width="100%" ReadOnly="true"
                                Text='<%# Bind("cap_descripcion")%>'> 
                             </asp:TextBox >
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView><br />

              <h1>Referencias</h1>
              <asp:GridView ID="GrvReferencia" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="5" 
                >
                <Columns>
                    <asp:TemplateField ItemStyle-Width="350px" HeaderText="DESCRIPCION">
                        <ItemTemplate>
                            <asp:TextBox ID = "txtDescripcion" runat="server" 
                                TextMode= "MultiLine" Rows="5" Columns="1" 
                                Height= "100%" Width="100%" ReadOnly="true"
                                Text='<%# Bind("ref_descripcion")%>'> 
                             </asp:TextBox >
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField DataField="tipr_nombre" HeaderText="TIPO"/>
                </Columns>
            </asp:GridView>
             <br />

              <h1>Referencia Familiar</h1>
              <asp:GridView ID="grvFamilia" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="5"
                >
                <Columns>
                     <asp:BoundField DataField="carf_cedula" HeaderText="CEDULA"/>
                     <asp:BoundField DataField="carf_nombre" HeaderText="NOMBRE"/>
                    <asp:BoundField DataField="carf_apellido" HeaderText="APELLIDO"/>
                    <asp:BoundField DataField="carf_edad" HeaderText="EDAD"/>
                    <asp:BoundField DataField="carf_parentesco" HeaderText="PARENTESCO"/>
                </Columns>
            </asp:GridView><br />

             <h1>Usuario</h1>
              <asp:GridView ID="GrvUsuario" runat="server" AutoGenerateColumns="false" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="5"
                >
                <Columns>
                     <asp:BoundField DataField="usu_usuario" HeaderText="USUARIO"/>
                     <asp:BoundField DataField="usu_clave" HeaderText="CLAVE"/>
                    <asp:BoundField DataField="tipu_nombre" HeaderText="TIPO"/>
                </Columns>
            </asp:GridView>

             </div><br /><br /><br />
          <asp:Button ID="btnVolver" runat="server" Text="SALIR" Height="40px" OnClick="btnVolver_Click" CssClass="btnTabla"/>
    </form>

</body>
</html>
