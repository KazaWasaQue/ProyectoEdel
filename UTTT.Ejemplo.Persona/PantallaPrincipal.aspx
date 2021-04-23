<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaPrincipal.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PantallaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous"><link rel="stylesheet" href="css/mainprincipal.css"/>
</head>
<body>
    <form id="form1" runat="server">
      <nav class="navbar navbar-light bg-light">
  <a class="navbar-brand" href="PersonaPrincipal.aspx">AppProyecto</a>
               
               <div class="navbar-brand">
            
              <asp:Label runat="server" ID="labelwelcome" Text="Welcome:"></asp:Label> 
               
           
            </div>

      <div class="dropdown show">
  <a class="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Salir Del Sistema
  </a>

  <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
    <asp:Button CssClass="dropdown-item" runat="server" ID="btnSalir" Text="Logout" OnClick="btnSalir_Click"/>
  </div>
</div>
               
                
           
</nav>
    
<div class="container mb-5 mt-5">
    <div class="pricing card-deck flex-column flex-md-row mb-3">
        <div class="card card-pricing text-center px-3 mb-4">
            <span class="h6 w-60 mx-auto px-4 py-1 rounded-bottom bg-primary text-white shadow-sm">Registrar Persona</span>
            <div class="bg-transparent card-header pt-4 border-0">
            
            </div>
            <div class="card-body pt-0">
               <h1>Pagina que se encarga de registrar a una persona</h1>
                <asp:Button CssClass="btn btn-outline-secondary mb-3" OnClick="btn_Persona" runat="server" Text="Persona"/>
            </div>
        </div>
        <div class="card card-pricing popular shadow text-center px-3 mb-4">
            <span class="h6 w-60 mx-auto px-4 py-1 rounded-bottom bg-primary text-white shadow-sm">Registrar Usuario</span>
            <div class="bg-transparent card-header pt-4 border-0">
                
            </div>
            <div class="card-body pt-0">
               <h1>Pagina que se encarga de asignar un usuario a una persona</h1>
                <asp:Button OnClick="btn_Usuario" runat="server" CssClass="btn btn-primary mb-3" Text="Usuario"/>
            </div>
        </div>
     
    </div>
</div>
        </form>
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script></body>
</html>
