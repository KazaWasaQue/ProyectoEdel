using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control.Ctrl;

namespace UTTT.Ejemplo.Persona
{
    public partial class Login : System.Web.UI.Page
    {
        private DataContext dcGlobal = new DcGeneralDataContext();
        private bool loginbool = false;
        private bool passwordbool = false;
        private string msgText = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                this.Response.Redirect("~/PantallaPrincipal.aspx", false);
            }
        }
        protected  void btnAceptar_Click(object sender,EventArgs e)
        {
            //validacionServer();
            //if (loginbool && passwordbool)
            //{
                String mensaje = String.Empty;

                if (!this.ValidacionSql(ref mensaje))
                {
                    this.msgWarningCampos.InnerText = mensaje;
                    this.login.Text = string.Empty;
                    this.password.Text = string.Empty;
                    this.msgWarningCampos.Visible = true;
                    return;
                }
                if (!this.ValidacionHtml(ref mensaje))
                {
                    this.msgWarningCampos.InnerText = mensaje;
                    this.login.Text = string.Empty;
                    this.password.Text = string.Empty;
                    this.msgWarningCampos.Visible = true;
                    return;
                }
                List<Usuario> listaus = dcGlobal.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().ToList();
                bool result = listaus.Any(p => p.usuario1 == this.login.Text && p.contrasena == Encriptar(this.password.Text));
                bool resiltstatus = listaus.Any(p => p.usuario1 == this.login.Text && p.contrasena == Encriptar(this.password.Text) && p.statusId == 1);
                if (result)
                {
                    if (resiltstatus)
                    {
                        HttpCookie mycookie = new HttpCookie("Login");
                        mycookie["User"] = this.login.Text;
                        mycookie.Expires = DateTime.Now.AddDays(1d);
                        Response.Cookies.Add(mycookie);
                        Response.Redirect("~/PantallaPrincipal.aspx", false);
                    }
                    else
                    {
                        this.msgWarningCampos.Visible = true;
                        this.msgWarningCampos.InnerHtml = "Usuario Bloqueado-Cancelado";
                    }
                }
                else
                {
                    this.msgWarningCampos.Visible = true;
                    this.msgWarningCampos.InnerHtml = "Usuario Inexistente";
                }
            //}
            //else 
            //{ ]
        }
        protected static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public void validacionServer()
        {
            bool validacionuser = VerifyLettersNumbers(this.login.Text);
            if (validacionuser)
            {
                loginbool = true;
            }
            else
            {
                loginbool = false;
                msgText += "Caracteres Invalidos";
            }
            bool validacionPassword = VerifyLettersNumbersEspecial(this.password.Text);
            if (validacionPassword)
            {
                passwordbool = true;
            }
            else
            {
                passwordbool = false;
                msgText += "Caracteres no validos";
            }
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

            if (ctrsql.sqlInjectionValida(this.login.Text.Trim(), ref _mensajeFuncion, "Usuario", ref this.login))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.password.Text.Trim(), ref _mensajeFuncion, "Contraseña", ref this.password))
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
            if (valida.htmlInjectionValida(this.login.Text.Trim(), ref mensajeFuncion, "Clave Única", ref this.login))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.password.Text.Trim(), ref mensajeFuncion, "Nombre", ref this.password))
            {
                _mensaje = mensajeFuncion;
                return false;
            }

            return true;
        }
        protected static bool VerifyLettersNumbers(string TextMixto)
        {
            string expressionLettersNumbers;
            expressionLettersNumbers = @"^[a-zA-Z0-9]+$";
            if (Regex.IsMatch(TextMixto, expressionLettersNumbers))
            {
                if (Regex.Replace(TextMixto, expressionLettersNumbers, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //[\w\[\]`!@#$%\^&*()={}:;<>+'-]*
        protected static bool VerifyLettersNumbersEspecial(string TextMixto)
        {
            string expressionLettersNumbers;
            expressionLettersNumbers = @"[\w\[\]`!@#$%\^&*()={}:;<>+'-]*";
            if (Regex.IsMatch(TextMixto, expressionLettersNumbers))
            {
                if (Regex.Replace(TextMixto, expressionLettersNumbers, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}