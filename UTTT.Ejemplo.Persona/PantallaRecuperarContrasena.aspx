<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PantallaRecuperarContrasena.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PantallaRecuperarContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">

</head>
<body>


    <form id="form1" runat="server">
         <div class="card card-outline-secondary">
                        <div class="card-header">
                            <h3 class="mb-0">Cambiar Contraseña</h3>
                        </div>
                        <div class="card-body">
                            <form class="form" role="form" autocomplete="off">
                                <div class="form-group">
                                    <asp:Label runat="server" ID="labelwelcome" Text="" Visible="false"></asp:Label> 
                                </div>
                                <div class="form-group">
                                    <label for="inputPasswordOld">Nueva Contraseña</label>
                                    
                                    <asp:TextBox runat="server"  type="password" CssClass="form-control" ID="inputPasswordOld"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="inputPasswordNew">Verificar Contraseña</label>
                                    <asp:TextBox runat="server"  type="password" CssClass="form-control" ID="inputPasswordNew"></asp:TextBox>
                                    <input type="checkbox" onclick="myFunction()">Mostrar Contraseña
                                </div>
                               <div ID="msgWarningCampos" class="alert alert-warning" role="alert" Text="" value="" runat="server" visible="false">
                                    
                               </div>
                                <div class="form-group">
                                    <asp:Button ID="btnAceptar" OnClick="btnSend_Click" Text="Actualizar" CssClass="btn btn-success" runat="server"/>
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click"
                                        ONClientClick="return true;"/>
                                </div>
                            </form>
                        </div>
                    </div>
    </form>
    <script>

        function myFunction() {
            var x = document.getElementById("inputPasswordNew");
            var c = document.getElementById("inputPasswordOld");

            if (x.type === "password" || c.type === "password") {
                x.type = "text";
                c.type = "text";
            } else {
                x.type = "password";
                c.type = "password";
            }
}
    </script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-Piv4xVNRyMGpqkS2by6br4gNJ7DXjqk09RmUpJ8jgGtD7zP9yug3goQfGII0yAns" crossorigin="anonymous"></script>

</body>
</html>
