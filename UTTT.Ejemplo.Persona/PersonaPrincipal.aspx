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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <script>
     function RefreshUpdatePanel() {
        __doPostBack('<%= txtNombre.ClientID %>', '');
    };
    </script>
    <title>App Proyecto</title>
</head>
<body>
<form id="form1" runat="server">
    <asp:ScriptManager ID="script1" runat="server" />
        <nav class="navbar navbar-light bg-light">
  <a type="button" class="btn btn-secondary" href="PantallaPrincipal.aspx">Regresar Pantalla de Inicio</a>
               
               <div CssClass="collapse navbar-collapse">
            
              
           
            </div>
               <div class="form-inline my-2 my-lg-0">
        
        
             
        
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
        <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control mr-sm-2"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlSexo_SelectedIndexChanged">
                </asp:DropDownList>
          <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="form-control mr-sm-2"
            AutoPostBack="true"
              >
   

                </asp:DropDownList>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlSexo" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>


               <asp:TextBox ID="txtNombre" runat="server"  onkeyup="RefreshUpdatePanel();" onkeydown="RefreshUpdatePanel();" OnTextChanged="ddlSexo_SelectedIndexChanged"></asp:TextBox>
    
 
                         <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                     ViewStateMode="Disabled" CssClass="btn btn-outline-success my-2 my-sm-0"/>
               
          
          
            </div>
                
           
</nav>
    <div class="container-fluid">

        </div>
    
    <asp:UpdatePanel ID="UpdatePanel20"  runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
    <ContentTemplate>
        
    </ContentTemplate>
    <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtNombre" />
    </Triggers>

</asp:UpdatePanel>


            <h2>Detalle</h2>

            <div class="form-group">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar"
                OnClick="btnAgregar_Click" ViewStateMode="Disabled" CssClass="btn btn-primary" />

            </div>
             <asp:UpdatePanel ID="UpdatePanel5" runat="server">
    <ContentTemplate>
       
        <div class="col-lg-12 ">
            <div class="table-responsive">
            <!-- -----------------------------------------------------------------------------------------------------------------  -->
    <asp:GridView ID="dgvPersonas" runat="server"
                AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DataSourcePersonaData"
                OnRowCommand="dgvPersonas_RowCommand" ViewStateMode="Disabled" Width="100%" CssClass="table table-striped table-bordered table-hover">
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
                    <asp:BoundField DataField="CatEstadoCivil" HeaderText="Estado Civil"
                        SortExpression="CatEstadoCivil" />
                    <asp:BoundField DataField="rfc" HeaderText="RFC"
                        SortExpression="rfc" />

                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="imgEditar" CommandName="Editar" CommandArgument='<%#Bind("id") %>' CssClass="btn btn-primary"><i class='fa fa-pencil-square-o'></i></asp:LinkButton>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar" Visible="True">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="imgEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("id") %>' CssClass="btn btn-danger" Text="Eliminar" OnClientClick="javascript:return confirm('¿Está seguro de querer eliminar el registro seleccionado?', 'Mensaje de sistema')"><i class='fa fa-trash'></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Direccion">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="imgDireccion" CommandName="Direccion" CommandArgument='<%#Bind("id") %>' CssClass="btn btn-info" Text="Direccion" ><i class='fa fa-address-book'></i></asp:LinkButton>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                </Columns>

        </asp:GridView>

            <!------------------------------------------------------------------------------------------------------------------------>
            </div></div>
            
            
            


            <asp:LinqDataSource ID="DataSourcePersonaData" runat="server"
                ContextTypeName="UTTT.Ejemplo.Linq.Data.Entity.DcGeneralDataContext"
                OnSelecting="DataSourcePersona_Selecting"
                Select="new (strNombre, strAPaterno, strAMaterno, CatSexo,fechaNacimiento ,strClaveUnica,numHermanos,carroElectronico,codigoPostal,CatEstadoCivil,rfc,id)"
                TableName="Persona" EntityTypeName="">
            </asp:LinqDataSource>

        </div>
       </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlSexo" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtNombre" />
    </Triggers>
</asp:UpdatePanel>
    </form>
    
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>
  
    <!-- Datatables
    <script src="bootstrap/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bootstrap/vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js">
    </script>
        -->
    <!--
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<= dgvPersonas.ClientID >').dataTable({
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
    -->
</body>

</html>
