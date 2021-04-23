<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UTTT.Ejemplo.Persona.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">
 
<!------ Include the above in your HEAD tag ---------->
    <style>
.login-form {
    width: 340px;
    margin: 50px auto;
  	font-size: 15px;
}
.login-form form {
    margin-bottom: 15px;
    background: #f7f7f7;
    box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
    padding: 30px;
}
.login-form h2 {
    margin: 0 0 15px;
}
.form-control, .btn {
    min-height: 38px;
    border-radius: 2px;
}
.btn {        
    font-size: 15px;
    font-weight: bold;
}
</style>
</head>
<body>
       <nav class="navbar navbar-light bg-light">
  <a class="navbar-brand" href="Login.aspx">App Proyecto</a>
               
               

      
               
                
           
</nav>
 
    <div class="login-form">
 <form ID="form1" runat="server">
        <h2 class="text-center">Inicio</h2>       
        <div class="form-group">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="login">
</asp:RequiredFieldValidator>
            <asp:TextBox ID="login" placeholder="Usuario" CssClass="form-control" runat="server">

            </asp:TextBox>
        </div>
        <div class="form-group">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="password">
</asp:RequiredFieldValidator>

            <asp:TextBox type="password" placeholder="Contraseña" ID="password" CssClass="form-control" runat="server"></asp:TextBox>



                <input type="checkbox" onclick="myFunction()">Mostrar Contraseña
                                
        </div>
        <div class="form-group">
            <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" Text="Ingresar" CssClass="btn btn-primary btn-block" runat="server"/>
        </div>
        <div class="form-group">
            <div ID="msgWarningCampos" class="alert alert-warning" role="alert" Text="" value="" runat="server" visible="false">
            </div>
        </div>
        <div class="clearfix">
            <a href="PantallaCorreoContrasena.aspx" class="float-right">Recuperar Contraseña</a>
        </div>
 </form> 
        </div>
    <script>
        
        function myFunction() {
            var x = document.getElementById("password");

            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
}
    </script>
      <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>

</body>
</html>
