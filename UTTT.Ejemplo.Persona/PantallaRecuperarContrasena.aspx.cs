using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control.Ctrl;

namespace UTTT.Ejemplo.Persona
{
    public partial class PantallaRecuperarContrasena : System.Web.UI.Page
    {
        string User;
        private DataContext dcGuardar = new DcGeneralDataContext();
        private UTTT.Ejemplo.Linq.Data.Entity.Usuario usuario = new Linq.Data.Entity.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            User = Request.QueryString["Uid"];
            if(User != null)
            {
                this.labelwelcome.Visible = true;
                this.labelwelcome.Text = "Usuario: " + " " + DesEncriptar(User.ToString());
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void btnSend_Click(object sender,EventArgs e)
        {
            String mensaje = String.Empty;

            if (!this.ValidacionSql(ref mensaje))
            {
                this.msgWarningCampos.InnerText = mensaje;
                this.inputPasswordOld.Text = string.Empty;
                this.inputPasswordNew.Text = string.Empty;
                this.msgWarningCampos.Visible = true;
                return;
            }
            if (!this.ValidacionHtml(ref mensaje))
            {
                this.msgWarningCampos.InnerText = mensaje;
                this.inputPasswordOld.Text = string.Empty;
                this.inputPasswordNew.Text = string.Empty;
                this.msgWarningCampos.Visible = true;
                return;
            }
            var usuarios = DesEncriptar(User = Request.QueryString["Uid"]);
            
            if (this.inputPasswordOld.Text != "" && this.inputPasswordNew.Text != "" && this.inputPasswordOld.Text == this.inputPasswordNew.Text)
            {
                if (this.inputPasswordOld.Text.Length > 6 && this.inputPasswordOld.Text.Length < 20)
                {
                    usuario = dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().First(c => c.usuario1 == usuarios);
                    usuario.contrasena = Encriptar(this.inputPasswordOld.Text);
                    dcGuardar.SubmitChanges();
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    this.msgWarningCampos.Visible = true;
                    this.msgWarningCampos.InnerText = "La contraseña debe de contener minimo 7 caraceteres";
                }
            }
            else
            {
                this.msgWarningCampos.Visible = true;
                this.msgWarningCampos.InnerText = "Contraseñas no coincidentes";
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            try
            {
                Response.Redirect("~/Login.aspx");
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }
        protected static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        protected static string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        private bool ValidacionSql(ref String _mensaje)
        {
            ctrlSQL ctrsql = new ctrlSQL();
            String _mensajeFuncion = String.Empty;

            if (ctrsql.sqlInjectionValida(this.inputPasswordOld.Text.Trim(), ref _mensajeFuncion, "Usuario", ref this.inputPasswordOld))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.inputPasswordNew.Text.Trim(), ref _mensajeFuncion, "Contraseña", ref this.inputPasswordNew))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }

            return true;
        }
        private bool ValidacionHtml(ref String _mensaje)
        {
            ctrlSQL valida = new ctrlSQL();
            String mensajeFuncion = String.Empty;
            if (valida.htmlInjectionValida(this.inputPasswordOld.Text.Trim(), ref mensajeFuncion, "Clave Única", ref this.inputPasswordOld))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.inputPasswordNew.Text.Trim(), ref mensajeFuncion, "Nombre", ref this.inputPasswordNew))
            {
                _mensaje = mensajeFuncion;
                return false;
            }

            return true;
        }

    }
}