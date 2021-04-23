using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;
using System.Configuration;
using System.Globalization;

namespace UTTT.Ejemplo.Persona
{
    public partial class PantallaUsuario : System.Web.UI.Page
    {
        private SessionManager session = new SessionManager();
        private int idUsuario = 0;
        private UTTT.Ejemplo.Linq.Data.Entity.Usuario baseEntity;
        private int tipoAccion = 0;
        private string msgText = "";
        Int32 rslcount = 0;
        private DataContext dcGlobal = new DcGeneralDataContext();

        private bool datausuario = false;
        private bool datapassword = false;
        private bool datarepeatpass = false;
        private bool dataddlpersona = false;
        private bool dataddlestado = false;
        private bool datafi = false;
        private SqlConnection con = new SqlConnection(@"data source=ManualProyecto.mssql.somee.com;Initial Catalog=ManualProyecto;persist Security info=True;user id=alexuwu_SQLLogin_1;password = jsz55va48s;");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] == null)
            {
                this.Response.Redirect("~/Login.aspx", false);
            }
            IDictionaryEnumerator allCaches = HttpRuntime.Cache.GetEnumerator();

            while (allCaches.MoveNext())
            {
                Cache.Remove(allCaches.Key.ToString());
            }
            Calendar1.EndDate = DateTime.Now;
            try
            {

           

                this.Response.Buffer = true;
                this.session = (SessionManager)this.Session["SessionManager"];
                this.idUsuario = this.session.Parametros["idPersona"] != null ?
                    int.Parse(this.session.Parametros["idPersona"].ToString()) : 0;
                if (this.idUsuario == 0)
                {
                    this.baseEntity = new Linq.Data.Entity.Usuario();
                    this.tipoAccion = 1;
                }
                else
                {
                    this.baseEntity = dcGlobal.GetTable<Linq.Data.Entity.Usuario>().First(c => c.id == this.idUsuario);
                    this.tipoAccion = 2;
                }
                if (!this.IsPostBack) {
                    SqlCommand cmd = new SqlCommand("select d.id, strNombre from Usuario u right join Persona d on u.personaId = d.id where u.personaId is null ", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.ddlPersona.DataTextField = "strNombre";
                    this.ddlPersona.DataValueField = "id";
                    this.ddlPersona.DataSource = dt;
                    this.ddlPersona.DataBind();

                    List<StatusCuenta> listasc = dcGlobal.GetTable<StatusCuenta>().ToList();
                    this.ddlEstado.DataTextField = "strEstado";
                    this.ddlEstado.DataValueField = "id";
                    this.ddlEstado.DataSource = listasc;
                    this.ddlEstado.DataBind();
                    if (this.session.Parametros["baseEntity"] == null)
                {
                    this.session.Parametros.Add("baseEntity", this.baseEntity);
                }

                if (this.idUsuario == 0)
                {
                    this.lblAccion.Text = "Agregar Usuario";
                    this.ddlEstado.Visible = false;
                    this.lblestado.Visible = false;
                }
                else
                {
                    
                    this.ddlPersona.Visible = false;
                    this.labelPersona.Visible = true;
                    this.lblAccion.Text = "Editar Usuario";
                    this.txtUsuario.Text = this.baseEntity.usuario1;
                    this.txtContrasena.Text = DesEncriptar(this.baseEntity.contrasena);
                    this.labelPersona.Text = baseEntity.Persona.strNombre +" "+ baseEntity.Persona.strAPaterno +" "+ baseEntity.Persona.strAMaterno;
                    this.txtDobDat.Text = this.baseEntity.fecchaIngreso;
                    this.setItem(ref this.ddlEstado, baseEntity.StatusCuenta.strEstado);
                    //this.setItem(ref this.ddlPersona, baseEntity.Persona.strNombre);
                }
                    /*
                    List<UTTT.Ejemplo.Linq.Data.Entity.Persona> listapersona = dcGlobal.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().ToList();
                    List<Usuario> listausuario = dcGlobal.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().ToList();
                    this.ddlPersona.DataTextField = "strNombre";
                    this.ddlPersona.DataValueField = "id";
                    this.ddlPersona.DataSource = from u in listausuario
                                                 join p in listapersona on u.personaId equals p.id
                                                 into a from b in a.DefaultIfEmpty()
                                                 where u.personaId is null
                                                 select new
                                                 {
                                                     id = b.id,
                                                     strNombre = b.strNombre
                    this.ddlPersona.DataBind();                             };
                    */
                    //http://localhost:36683/PantallaUsuario.aspx
                }
            }
            catch (Exception _e)
            {
                //this.showMessage("Ha ocurrido un problema al cargar la página");
                this.showMessageException(_e.Message);
                //this.Response.Redirect("~/PantallaCUsuario.aspx", false);
            }

    }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            ValidacionesServer();
            if (dataddlpersona && datausuario && datapassword && datafi) {

                try
                {
                    DataContext dcGuardar = new DcGeneralDataContext();
                    UTTT.Ejemplo.Linq.Data.Entity.Usuario usuario = new Linq.Data.Entity.Usuario();

                    if (this.idUsuario == 0)
                    {

                        usuario.usuario1 = this.txtUsuario.Text.Trim();
                        usuario.contrasena = Encriptar(this.txtContrasena.Text.Trim());
                        usuario.personaId = int.Parse(this.ddlPersona.Text);
                        //usuario. = this.txtDobDat.Text.Trim();
                        usuario.fecchaIngreso = this.txtDobDat.Text.Trim();

                        usuario.statusId = 1;

                        String mensaje = String.Empty;

                        if (!this.ValidacionSql(ref mensaje))
                        {
                            this.Labelerror.InnerText = mensaje;
                            this.txtUsuario.Text = string.Empty;
                            this.txtContrasena.Text = string.Empty;
                            this.txtRepetirContraseña.Text = string.Empty;
                            this.Labelerror.Visible = true;
                            return;
                        }
                        if (!this.ValidacionHtml(ref mensaje))
                        {
                            this.Labelerror.InnerText = mensaje;
                            this.txtUsuario.Text = string.Empty;
                            this.txtContrasena.Text = string.Empty;
                            this.txtRepetirContraseña.Text = string.Empty;
                            this.Labelerror.Visible = true;
                            return;
                        }

                        dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().InsertOnSubmit(usuario);
                        dcGuardar.SubmitChanges();
                        this.showMessage("El registro se edito correctamente.");
                        this.Response.Redirect("~/PantallaCUsuario.aspx", false);
                    }
                    if (this.idUsuario > 0)
                    {
                         usuario = dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().First(c => c.id == idUsuario);

                        usuario.usuario1 = this.txtUsuario.Text.Trim();
                        usuario.contrasena = Encriptar(this.txtContrasena.Text.Trim());
                        usuario.statusId = int.Parse(this.ddlEstado.Text);
                        usuario.fecchaIngreso = this.txtDobDat.Text.Trim();
                        String mensaje = String.Empty;

                        if (!this.ValidacionSql(ref mensaje))
                        {
                            this.Labelerror.InnerText = mensaje;
                            this.txtUsuario.Text = string.Empty;
                            this.txtContrasena.Text = string.Empty;
                            this.txtRepetirContraseña.Text = string.Empty;
                            this.Labelerror.Visible = true;
                            return;
                        }
                        if (!this.ValidacionHtml(ref mensaje))
                        {
                            this.Labelerror.InnerText = mensaje;
                            this.txtUsuario.Text = string.Empty;
                            this.txtContrasena.Text = string.Empty;
                            this.txtRepetirContraseña.Text = string.Empty;
                            this.Labelerror.Visible = true;
                            return;
                        }
                        dcGuardar.SubmitChanges();

                        this.showMessage("El registro se edito correctamente.");
                        this.Response.Redirect("~/PantallaCUsuario.aspx", false);
                    }
                }
                catch (Exception _e)
                {
                    ctrlEmail ctrlmail = new ctrlEmail();
                    ctrlmail.sendEmail(_e.Message);
                    this.showMessageException(_e.Message);
                    this.msgWarningCampos.Visible = true;
                    msgText +="Usuario Existente<br /> ";
                    this.msgWarningCampos.InnerHtml = msgText;
                    //this.Response.Redirect("~/Error404/ErrorPage.html", false);
                }
            }
            else
            {
                this.msgWarningCampos.Visible = true;
                this.msgWarningCampos.InnerHtml = msgText;
            } 

           
        }

        protected void ValidacionesServer()
        {
            if(this.idUsuario == 0){
                bool validateDdlPersobnna = VerifyNumericValue(this.ddlPersona.Text);
                if (validateDdlPersobnna)
                {
                    dataddlpersona = true;
                }
                else
                {
                    dataddlpersona = false;
                    msgText += "No";
                }
                bool validateUsuario = VerifyLettersNumbers(this.txtUsuario.Text);

                if (validateUsuario)
                {
                    List<Usuario> listaus = dcGlobal.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().ToList();
                    bool result = listaus.Any(p => p.usuario1 == this.txtUsuario.Text);
                    if (result)
                    {
                        datausuario = false;
                        msgText += "Usuario Existente <br />";
                    }
                    else
                    {
                        datausuario = true;

                    }

                }
                else
                {
                    datausuario = false;
                    msgText += "Caracteres Invalidos Usuario<br />";
                }
            }
            if(this.idUsuario > 0)
            {
                dataddlpersona = true;
                    datausuario = true;
                

            }

            if (this.txtContrasena.Text.Length > 6 && this.txtContrasena.Text.Length < 20)
            {
                if (this.txtContrasena.Text.Equals(this.txtRepetirContraseña.Text))
                {
                    datapassword = true;
                }
                else
                {
                    datapassword = false;
                    msgText += "Contraseña no concuerda <br />";
                }
            }
            else
            {
                datapassword = false;
                msgText += "Minimo 7 caracteres <br />";
            }
            bool fechaValidation = VerifyDate(this.txtDobDat.Text);
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            //Verify whether date entered in dd/MM/yyyy format.
            bool isValid = regex.IsMatch(txtDobDat.Text.Trim());

            //Verify whether entered date is Valid date.

            DateTime dt;
            isValid = DateTime.TryParseExact(txtDobDat.Text, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (!isValid)
            {
                msgText += "Caracteteres Imcorrectos Fecha Formato: 00/00/0000 <br />";
                datafi = false;
            }
            else
            {
                datafi = true;
            }
        }
        public bool ValidacionSql(ref String _mensaje)
        {
            ctrlSQL ctrsql = new ctrlSQL();
            String _mensajeFuncion = String.Empty;

            if (ctrsql.sqlInjectionValida(this.txtUsuario.Text.Trim(), ref _mensajeFuncion, "Usuario", ref this.txtUsuario))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.txtContrasena.Text.Trim(), ref _mensajeFuncion, "Contraseña", ref this.txtContrasena))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.txtRepetirContraseña.Text.Trim(), ref _mensajeFuncion, "Repetir Contraseña", ref this.txtRepetirContraseña))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }

            return true;
        }
        public bool ValidacionHtml(ref String _mensaje)
        {
            ctrlSQL valida = new ctrlSQL();
            String mensajeFuncion = String.Empty;
            
            if (valida.htmlInjectionValida(this.txtUsuario.Text.Trim(), ref mensajeFuncion, "Nombre", ref this.txtUsuario))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.txtContrasena.Text.Trim(), ref mensajeFuncion, "Apellido Paterno", ref this.txtContrasena))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.txtRepetirContraseña.Text.Trim(), ref mensajeFuncion, "Apellido Materno", ref this.txtRepetirContraseña))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            return true;
        }
        protected static string Encriptar( string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        protected static string DesEncriptar( string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            try
            {
                this.Response.Redirect("~/PantallaCUsuario.aspx", false);
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }
        protected bool VerifyNumericValue(string ValueToCheck)
        {
            Int32 numval;
            bool rslt = false;

            rslt = Int32.TryParse(ValueToCheck, out numval);

            return rslt;
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
        //Fecha Validatiom
        protected static bool VerifyDate(string date)
        {
            string expressionDate;
            expressionDate = "^(?:[012]?[0 - 9] | 3[01])[./ -](?:0?[1 - 9] | 1[0 - 2])[./-] (?:[0-9]{2}){1,2}$";
            if (Regex.IsMatch(date, expressionDate))
            {
                if (Regex.Replace(date, expressionDate, string.Empty).Length == 0)
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
        protected void setItem(ref AjaxControlToolkit.ComboBox _control, String _value)
        {
            foreach (ListItem item in _control.Items)
            {
                if (item.Value == _value)
                {
                    item.Selected = true;
                    break;
                }
            }
            _control.Items.FindByText(_value).Selected = true;
        }

    }
}