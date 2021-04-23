<%@ Page EnableEventValidation="false"  Language="C#" AutoEventWireup="true" CodeBehind="PersonaManager.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PersonaManager" debug=false%>
    <%@ Register Assembly="ajaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    
    <form id="form1" runat="server" >
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            
            <div>
                <asp:Label ID="lblAccion" runat="server" Text="Accion" Font-Bold="True"
                
                ></asp:Label>
         <div ID="msgWarningCampos" class="alert alert-warning" role="alert" Text="" value="" runat="server" visible="false">
             
  
</div>
                
            
         
          </div>
              <div>
    
          <div class="form-group "> 
              <label for="ddlSexo">Sexo Y Estado Civil: </label>
              
              <br />
              <ajaxToolkit:ComboBox ID="ddlSexo" runat="server" 
                  AutoPostBack="False"
     DropDownStyle="DropDownList"
     AutoCompleteMode="SuggestAppend"
     CaseSensitive="True"
     CssClass="AquaStyle"
     ItemInsertLocation="Append"
                  > 
</ajaxToolkit:ComboBox>

              <ajaxToolkit:ComboBox ID="ddlEstadoCivil" runat="server" 
                  AutoPostBack="False"
     DropDownStyle="DropDownList"
     AutoCompleteMode="SuggestAppend"
     CaseSensitive="True"
     ItemInsertLocation="Append"
                  > 
</ajaxToolkit:ComboBox>
              
                <div id="errge" style="display:none;" class="alert alert-danger" role="alert" >
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                    <span class="sr-only">Error:</span>
                    Seleccione este campo
                </div>
            
      </div>
    
          </div>
          <div class="form-group"> 
              <label for="txtClaveUnica">Clave unica: </label>
              
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtClaveUnica">
</asp:RequiredFieldValidator> 
              <asp:TextBox ID="txtClaveUnica" runat="server" 
                   ViewStateMode="Disabled" name="txtclave" 
                  CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"
                  MaxLength="3"  ></asp:TextBox>
                  
              <!-- onkeypress="__doPostBack(this.name,'OnKeyPress');" -->
                
                    <div id="errcu" style="display:none;" class="alert alert-danger shadow-sm p-3 mb-5 bg-body rounded" role="alert" >
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                        <span class="sr-only">Error:</span>
                        Campo Incorrecto
                    </div>
                
          
          </div>
          <div>
              <label for="txtNombre">Nombre: </label>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtNombre">
</asp:RequiredFieldValidator>
              <asp:TextBox 
                  ID="txtNombre" runat="server" 
                  MaxLength="15"
                  ViewStateMode="Disabled" name="txtnombre" CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded" ></asp:TextBox>
        
                        <div id="errname" style="display:none;" class="alert alert-danger" role="alert" >
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                            <span class="sr-only">Error:</span>
                            Campo Incorrecto
                          </div>
                 
          </div>
          <div class="form-group"> 
              <label for="txtAPaterno">Apellido Paterno: </label>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtAPaterno">
</asp:RequiredFieldValidator>
              <asp:TextBox 
                  ID="txtAPaterno" runat="server"  
                  MaxLength="15"
                  ViewStateMode="Disabled" name="txtpaterno" CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"></asp:TextBox>
                
                    <div id="errpate" style="display:none;" class="alert alert-danger" role="alert" >
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                        <span class="sr-only">Error:</span>
                        Campo Incorrecto
                      </div>
              
          </div>
          <div class="form-group">
          
              <label for="txtAMaterno">Apellido Materno: </label>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtAMaterno">
</asp:RequiredFieldValidator>
              <asp:TextBox ID="txtAMaterno" runat="server" 
                  ViewStateMode="Disabled" 
                  MaxLength="15"
                  name="txtmaterno"
                  CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"></asp:TextBox>
                 
                    <div id="errap" style="display:none;" class="alert alert-danger" role="alert" >
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                        <span class="sr-only">Error:</span>
                        Campo Incorrecto
                      </div>
               
          </div>

          <div class="form-group">
              <label for="numeroHermanos">Numero Hermanos</label>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="numeroHermanos">
</asp:RequiredFieldValidator>
            <asp:TextBox ID="numeroHermanos"
                MaxLength="2"
                runat="server"  CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded" ></asp:TextBox>

                <div id="errnh" style="display:none;" class="alert alert-danger" role="alert" >
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                    <span class="sr-only">Error:</span>
                    Campo Incorrecto
                  </div>
          
          </div>

          <div class="form-group">
              <label for="correoElectronico">Correo Electronico</label>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="correoElectronico">
</asp:RequiredFieldValidator>
            <asp:TextBox ID="correoElectronico"
                runat="server" CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"></asp:TextBox>
           
            <div id="errce" style="display:none;" class="alert alert-danger" role="alert" >
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                <span class="sr-only">Error:</span>
                Campo Incorrecto
              
           </div>
          </div>

          <div class="form-group">
            <label for="rfc">RFC</label>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="rfc">
</asp:RequiredFieldValidator>
            <asp:TextBox ID="rfc" runat="server"
                MaxLength="13"
                CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded"></asp:TextBox>

 
            <div id="errrfc" style="display:none;" class="alert alert-danger" role="alert" >
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
                <span class="sr-only">Error:</span>
                Campo Incorrecto
              </div>
          
          </div>
        
          <div class="form-group">
            <label for="codigoPostal">Codigo Postal</label>
<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="codigoPostal">
</asp:RequiredFieldValidator>
            <asp:TextBox ID="codigoPostal" 
                MaxLength="5"
                runat="server" CssClass="form-control shadow-sm p-3 mb-5 bg-body rounded" onpaste="return false"></asp:TextBox>
                <div id="errcp" class="alert alert-danger shadow-sm p-3 mb-5 bg-body rounded" role="alert" style="display:none;">
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                    <span class="sr-only">Error:</span>
                    Campo Imcorrecto
                </div>
          </div>
               
   
          <div class="form-group">
            <div> <label for="txtDobDat">Fecha de Nacimiento</label>  
                <asp:TextBox ID="txtDobDat" runat="server"></asp:TextBox>  
                <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDobDat" Format="dd/MM/yyyy"> </cc1:CalendarExtender>  
            
                    <div id="errfecha" class="alert alert-danger" role="alert" style="display:none;">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">Error:</span>
                        Fecha Incorrecta debes ser mayor de 18, Formato: 00/00/0000 dia/mes/año
                      </div>
            
            </div>
            
                        </div>
                       
                        <div id="warcampo" class="alert alert-danger" role="alert" style="display:none;">
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only">Error:</span>
                            Rellene Todos los Campos o Verifique los Campos
                          </div>
          
            <div id="msgError" class="alert alert-danger" role="alert" Text="" runat="server" visible="false">
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true" ></span>
            </div>

                
      <div class="form-group">
       <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" 
              onclick="btnAceptar_Click" ViewStateMode="Disabled"
              CssClass="btn btn-success" />
          <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
              onclick="btnCancelar_Click " ViewStateMode="Disabled"
              CssClass=" btn btn-danger" ONClientClick="return true;"
 />
          
      </div>
      </form>      
        <div class="input-group">

        </div>
      
      </div>
    </div>
    
    <script type="text/javascript" src="Scripts/validaciones.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.min.js" integrity="sha384-+YQ4JLhjyBLPDQt//I+STsc9iw4uQqACwlvpslubQzn4u2UU2UFM80nGisd026JF" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script>
     /*
        $(function () {
            $("#ddlSexo").change(function () {
                alert("Changed");
                // call webmethod in here
                $.ajax({
        type: "POST",
        url: "PersonaManager.aspx/consultaGlobalSexo",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            var ddlCustomers = $("[id*=ddlSexo]");
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(r.d, function () {
                ddlCustomers.append($("<option></option>").val(this['Value']).html(this['Text']));
            });
        }
    });
            });
        })
        */
          $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url is the path of our web method (Page name/function name)
                url: "PersonaManager.aspx/CatSexoDropDownList",
                data: "{}",
                dataType: "json",
                //called on jquery ajax call success
                success: function (result) {
                    $('#ddlDepartments').empty();
                    $('#ddlDepartments').append("<option value='0'>--Select--</option>");
                    $.each(result.d, function (key, value) {
                        $("#ddlDepartments").append($("<option></option>").val(value.Id).html(value.StrValor));
                    });
                },
                //called on jquery ajax call failure
                error: function ajaxError(result) {
                    alert(result.status + ' : ' + result.statusText);
                }
            });
        });
        </script>
</body>
</html>