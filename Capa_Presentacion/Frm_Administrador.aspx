<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Administrador.aspx.cs" Inherits="Capa_Presentacion.Frm_Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Css/MenuAdmin.css" rel="stylesheet" />
</head>
<body>
<form id="frmMenu" runat="server">

        <div id="menu">
            <ul>
                <li><a href="#">Empresa</a>
                    <ul>
                        <li><a href="FrmEmpresa.aspx">Agregar Empresa</a></li>
                    </ul>
                </li>
                <li><a href="#">Departamentos</a>
                    <ul>
                        <li><a href="FrmDepartamento.aspx">Agregar Departamento</a></li>
                    </ul>
                </li>
                <li><a href="#">Cargos</a>
                    <ul>
                        <li><a href="FrmCargo.aspx">Agregar Cargo</a></li>
                    </ul>
                </li>
                <li><a href="#">Empleados</a>
                    <ul>
                        <li><a href="FrmEmpleado.aspx">Agregar Empleado</a></li>
                        <li><a href="FrmReferencia.aspx">Agregar Referencias</a></li>
                        <!--<li><a href="FrmCapacitacion.aspx">Capacitaciones</a></li>-->
                        <li><a href="FrmCargaFamiliar.aspx">Referencia Familiar</a></li>
                    </ul>
                </li>
                <li><a href="#">Usuarios</a>
                    <ul>
                        <li><a href="FrmUsuario.aspx">Agregar Usuario</a></li>
                        <li><a href="FrmTipoUsuario.aspx">Agregar Rol De Usuario</a></li>
                    </ul>
                </li>
                <li><a href="#">Sesión</a>
                    <ul>
                        <li><a href="index.aspx">Salir</a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </form>
</body>
</html>
