using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Persona.Control.Ctrl;

namespace UTTT.Ejemplo.Persona
{
    public partial class PantallaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Login"]!= null)
            {
                this.labelwelcome.Visible = true;
                this.labelwelcome.Text = "Bienvenido: " + " "+Request.Cookies["Login"]["User"].ToString();
            }
            else
            {
                this.Response.Redirect("~/Login.aspx", false);
            }
            
        }

        protected void btn_Persona(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);

            }
            catch (Exception)
            {
                this.showMessage("A Ocurrido un problema");
            }
        }

        protected void btn_Usuario(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("~/PantallaCUsuario.aspx", false);
            }
            catch (Exception _e)
            {
                this.showMessage("A Ocurrido un problema");
            }

        }

        protected void btnSalir_Click(object sender,EventArgs e)
        {
            HttpCookie mycookie = new HttpCookie("Login");
            mycookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(mycookie);
            this.Response.Redirect("~/Login.aspx", false);

        }
    }
}