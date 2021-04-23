<%@ Page EnableEventValidation="false" Language="C#"  AutoEventWireup="true" CodeBehind="PantallaUsuario.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PantallaUsuario"  debug=false%>
  <%@ Register Assembly="ajaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>App Usuario</title>
 <meta charset="utf-8">
    
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous">


    <link rel="Stylesheet" href="css/manager.css"/>
</head>
<body>
    <div class="container">
        <div class="box">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

         <asp:Label ID="lblAccion" runat="server" Text="Accion" Font-Bold="True"
                
                ></asp:Label>

          <div ID="msgWarningCampos" class="alert alert-warning" role="alert" Text="" value="" runat="server" visible="false">
            
          
          </div>

         <div id="Labelerror" class="alert alert-danger" role="alert" Text="" runat="server" visible="false">
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
            </div>


       <div class="form-group "> 
              <label for="ddlPersona">Persona </label>
              
              <br />
              <ajaxToolkit:ComboBox ID="ddlPersona" runat="server" 
                  AutoPostBack="False"
     DropDownStyle="DropDownList"
     AutoCompleteMode="SuggestAppend"
     CaseSensitive="True"
     CssClass="AquaStyle"
     ItemInsertLocation="Append"
                  > 
</ajaxToolkit:ComboBox>
           <asp:Label ID="labelPersona" runat="server" Text="" Visible="false"></asp:Label>
             
              
                <div id="errge" style="display:none;" class="alert alert-danger" role="alert" >
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                    <span class="sr-only">Error:</span>
                    Seleccione este campo
                </div>
            
      </div>
        <div class="form-group">
            <label for="txtUsuario">Usuario</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtUsuario">
</asp:RequiredFieldValidator> 
              
            <asp:TextBox ID="txtUsuario" runat="server" 
                   ViewStateMode="Disabled"  
                  CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"
                  MaxLength="20"  ></asp:TextBox>
                  
            <div id="errcu" style="display:none;" class="alert alert-danger shadow-sm p-3 mb-5 bg-body rounded" role="alert" >
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                        <span class="sr-only">Error:</span>
                        Campo Incorrecto
                    </div>
        </div>
        <div class="form-group">
            <label for="txtContrasena">Contraseña</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtContrasena">
</asp:RequiredFieldValidator> 
            <asp:TextBox ID="txtContrasena" type="password" runat="server" 
                 CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"
                  MaxLength="20"></asp:TextBox>

                 <div id="errpass" style="display:none;" class="alert alert-danger shadow-sm p-3 mb-5 bg-body rounded" role="alert" >
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                        <span class="sr-only">Error:</span>
                        Campo Incorrecto
                    </div>
        </div>

        <div class="form-group">
            <label for="txtRepetirContraseña">Repetir Contraseña</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtRepetirContraseña">
</asp:RequiredFieldValidator> 
            <asp:TextBox ID="txtRepetirContraseña" type="password" runat="server" 
                 CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"
                  MaxLength="20"></asp:TextBox>
            <input type="checkbox" onclick="myFunction()">Mostrar Contraseña
                
                 <div id="errrepeatpass" style="display:none;" class="alert alert-danger shadow-sm p-3 mb-5 bg-body rounded" role="alert" >
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                        <span class="sr-only">Error:</span>
                        Campo Incorrecto
                    </div>
        </div>

         <div class="form-group">
            <div> <label for="txtDobDat">Fecha de Ingreso:</label>  
                <asp:TextBox ID="txtDobDat" runat="server"></asp:TextBox>  
                <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDobDat" Format="dd/MM/yyyy"> </cc1:CalendarExtender>  
            
                  
            
            </div>
            
                        </div>

               <div class="form-group "> 
              <asp:Label ID="lblestado" runat="server" Text="Estado" Font-Bold="True"></asp:Label>
           
              <br />
              <ajaxToolkit:ComboBox ID="ddlEstado" runat="server" 
                  AutoPostBack="False"
     DropDownStyle="DropDownList"
     AutoCompleteMode="SuggestAppend"
     CaseSensitive="True"
     CssClass="AquaStyle"
     ItemInsertLocation="Append"
                  > 
</ajaxToolkit:ComboBox>

             
              
                <div id="errestadoge" style="display:none;" class="alert alert-danger" role="alert" >
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                    <span class="sr-only">Error:</span>
                    Seleccione este campo
                </div>
            
      </div>
             <div class="form-group">
            <asp:Button ID="btnAceptar"
                        runat="server"
                        Text="Aceptar"
                        ViewStateMode="Disabled"
                OnClick="btnAceptar_Click"
              CssClass="btn btn-success"/>

                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
              ViewStateMode="Disabled"
              CssClass=" btn btn-danger" OnClick="btnCancelar_Click" ONClientClick="return true;"
 />
        </div>
    </form>

        </div>
    </div>
    <script>
        function myFunction() {
            var x = document.getElementById("txtContrasena");
            var c = document.getElementById("txtRepetirContraseña");

            if (x.type === "password" || c.type === "password") {
                x.type = "text";
                c.type = "text";
            } else {
                x.type = "password";
                c.type = "password";
            }
        }
    </script>
        <script type="text/javascript" src="javaScripFile.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</body>
</html>
