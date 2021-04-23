<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaCorreoContrasena.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PantallaCorreoContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">

<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" >
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
        <link rel="Stylesheet" href="css/mainpassword.css"/>

</head>
<body>
    <nav class="navbar navbar-light bg-light">
  <a class="navbar-brand" href="Login.aspx">Regresar</a>
               
               

      
               
                
           
</nav>
        <div class="form-gap"></div>
<div class="container">
         
	<div class="row">
		<div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
              <div class="panel-body">
                <div class="text-center">
                  <h3><i class="fa fa-lock fa-4x"></i></h3>
                  <h2 class="text-center">Olvidaste Tu Contraseña?</h2>
                  <p>Introduzca Su correo</p>
                  <div class="panel-body">
    
                    <form id="form1" runat="server" role="form" autocomplete="off" class="form" method="post">
    
                      <div class="form-group">
                        <div class="input-group">
                          <span class="input-group-addon"><i class="glyphicon glyphicon-envelope color-blue"></i></span>
                           

                            <asp:TextBox ID="email" placeholder="Correo Electronico" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvemail" runat="server"

                ErrorMessage="Campo Incorrecto" ControlToValidate="email"

                ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                      <div class="form-group">
                              <div class="form-group">
            <div ID="msgWarningCampos" class="alert alert-warning" role="alert" Text="" value="" runat="server" visible="false">
            </div>
        </div>
                        <asp:Button Text="Enviar Contraseña" OnClick="btnBuscar_Click" CssClass="btn btn-lg btn-primary btn-block" runat="server" ID="btnAceptar"/>
                      </div>
                      
                    </form>
    
                  </div>
                </div>
              </div>
            </div>
          </div>
	</div>
</div>
</body>
</html>
