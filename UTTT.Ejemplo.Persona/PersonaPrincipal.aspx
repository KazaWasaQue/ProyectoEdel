<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonaPrincipal.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PersonaPrincipal" Debug="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">

    <!-- Datatables-->
    <link href="bootstrap/vendors/datatables.net-bs4/css/dataTables.bootstrap4.min.css"
        rel="stylesheet" />
    <title>App Proyecto</title>
</head>
<body>
<form id="form1" runat="server">
        <nav class="navbar navbar-light bg-light">
  <a class="navbar-brand" href="PersonaPrincipal.aspx">AppProyecto</a>
               
               <div CssClass="collapse navbar-collapse">
            
              
            
            </div>
               <div class="form-inline my-2 my-lg-0">
        
        
              <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control mr-sm-2">
                </asp:DropDownList>
        
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control mr-sm-2" 
                    ViewStateMode="Disabled" placeholder="Nombre" ></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" ViewStateMode="Disabled" CssClass="btn btn-outline-success my-2 my-sm-0"/>
               
          
            </div>
                
           
</nav>
        <div class="container-fluid">


            


            <h2>Detalle</h2>

            
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar"
                OnClick="btnAgregar_Click" ViewStateMode="Disabled" CssClass="btn btn-primary" />

            <asp:GridView ID="dgvPersonas" runat="server"
                AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DataSourcePersonaData"
                OnRowCommand="dgvPersonas_RowCommand" ViewStateMode="Disabled" CssClass="table table-striped">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="strClaveUnica" HeaderText="Clave Unica"
                        ReadOnly="True" SortExpression="strClaveUnica" />
                    <asp:BoundField DataField="strNombre" HeaderText="Nombre" ReadOnly="True"
                        SortExpression="strNombre" />
                    <asp:BoundField DataField="strAPaterno" HeaderText="APaterno" ReadOnly="True"
                        SortExpression="strAPaterno" />
                    <asp:BoundField DataField="strAMaterno" HeaderText="AMaterno" ReadOnly="True"
                        SortExpression="strAMaterno" />
                    <asp:BoundField DataField="CatSexo" HeaderText="Sexo"
                        SortExpression="CatSexo" />
                    <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nacimiento"
                        SortExpression="fechaNacimiento" />
                    <asp:BoundField DataField="numHermanos" HeaderText="numero Hermanos"
                        SortExpression="numHermanos" />
                    <asp:BoundField DataField="carroElectronico" HeaderText="Correo Electronico"
                        SortExpression="carroElectronico" />
                    <asp:BoundField DataField="codigoPostal" HeaderText="Codigo Postal"
                        SortExpression="codigoPostal" />
                    <asp:BoundField DataField="rfc" HeaderText="RFC"
                        SortExpression="rfc" />

                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="imgEditar" CommandName="Editar" CommandArgument='<%#Bind("id") %>' CssClass="btn btn-primary" Text="Editar"/>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar" Visible="True">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="imgEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("id") %>' CssClass="btn btn-danger" Text="Eliminar" OnClientClick="javascript:return confirm('¿Está seguro de querer eliminar el registro seleccionado?', 'Mensaje de sistema')" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Direccion">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="imgDireccion" CommandName="Direccion" CommandArgument='<%#Bind("id") %>' CssClass="btn btn-info" Text="Direccion" />
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>



            <asp:LinqDataSource ID="DataSourcePersonaData" runat="server"
                ContextTypeName="UTTT.Ejemplo.Linq.Data.Entity.DcGeneralDataContext"
                OnSelecting="DataSourcePersona_Selecting"
                Select="new (strNombre, strAPaterno, strAMaterno, CatSexo,fechaNacimiento ,strClaveUnica,numHermanos,carroElectronico,codigoPostal,rfc,id)"
                TableName="Persona" EntityTypeName="">
            </asp:LinqDataSource>

        </div>

    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>

    <!-- Datatables-->
    <script src="bootstrap/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bootstrap/vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js">
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= dgvPersonas.ClientID %>').dataTable({
                "aLengthMenu": [[10, 50, 75, -1], [10, 50, 75, "All"]],
                "iDisplayLength": 10,
                "order": [[2, "asc"]],
                stateSave: true,
                stateSaveCallback: function (settings, data) {
                    localStorage.setItem
                        ('DataTables_' + settings.sInstance, JSON.stringify(data));
                },
                stateLoadCallback: function (settings) {
                    return JSON.parse
                        (localStorage.getItem('DataTables_' + settings.sInstance));
                }
            });
        });
    </script>

</body>

</html>
