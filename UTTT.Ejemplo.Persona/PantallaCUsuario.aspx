<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaCUsuario.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PantallaCUsuario" %>
  <%@ Register Assembly="ajaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
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
    <title>App Pantalla Usuario</title>
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
        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="form-control mr-sm-2"
            AutoPostBack="true">
                </asp:DropDownList>


          <asp:DropDownList ID="ddlEstadoCuenta" runat="server" CssClass="form-control mr-sm-2"
            AutoPostBack="true"
              >
                </asp:DropDownList>
    
    </ContentTemplate>
    <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlUsuario" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>


                <asp:TextBox ID="txtNombre" runat="server"  onkeyup="RefreshUpdatePanel();" onkeydown="RefreshUpdatePanel();" OnTextChanged="ddlSexo_SelectedIndexChanged"></asp:TextBox>
    
 
          
            </div>
                
           
</nav>
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
    <asp:GridView ID="dgvPersonas" Width="100%" runat="server"
                AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DataSourcePersonaData"
                OnRowCommand="dgvPersonas_RowCommand" ViewStateMode="Disabled" CssClass="table table-striped table-bordered table-hover">
                <AlternatingRowStyle />
                <Columns>
                    <asp:BoundField DataField="usuario1" HeaderText="Usuario"
                        ReadOnly="True" SortExpression="usuario1" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />

                    <asp:BoundField DataField="Persona" HeaderText="Persona" ReadOnly="True"
                        SortExpression="Persona" />
                    <asp:BoundField DataField="StatusCuenta" HeaderText="Status Cuenta" ReadOnly="True"
                        SortExpression="StatusCuenta" />
                                        <asp:BoundField DataField="fecchaIngreso" HeaderText="Feccha Ingreso" ReadOnly="True"
                        SortExpression="fecchaIngreso" />
      

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

                </Columns>

        </asp:GridView>

            <!------------------------------------------------------------------------------------------------------------------------>
            </div>
            </div>
            
            
            


            <asp:LinqDataSource ID="DataSourcePersonaData" runat="server"
                ContextTypeName="UTTT.Ejemplo.Linq.Data.Entity.DcGeneralDataContext"
                OnSelecting="DataSourcePersona_Selecting"
                Select="new (id,usuario1,Persona,StatusCuenta,fecchaIngreso)"
                TableName="Usuario" EntityTypeName="">
            </asp:LinqDataSource>

        </div>
       </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlUsuario" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtNombre" />

    </Triggers>
</asp:UpdatePanel>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>

</body>
</html>
