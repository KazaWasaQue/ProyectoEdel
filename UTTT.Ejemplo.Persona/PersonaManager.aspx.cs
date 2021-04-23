#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Collections;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Globalization;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
#endregion

namespace UTTT.Ejemplo.Persona
{
    public partial class PersonaManager : System.Web.UI.Page
    {
        #region Variables

        private SessionManager session = new SessionManager();
        private int idPersona = 0;
        private UTTT.Ejemplo.Linq.Data.Entity.Persona baseEntity;
        private DataContext dcGlobal = new DcGeneralDataContext();
        private DataContext dcGlobalEC = new DcGeneralDataContext();
        private int tipoAccion = 0;
        private string msgText = "";
        Int32 rslcount = 0;
        //True y False
        private bool datasd = false;
        private bool datacu = false;
        private bool datana = false;
        private bool dataap = false;
        private bool dataam = false;
        private bool datahe = false;
        private bool datace = false;
        private bool datarc = false;
        private bool datacp = false;
        private bool datafn = false;
        private bool dataev = false;
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] == null)
            {
                this.Response.Redirect("~/Login.aspx", false);
            }
            //I am writing this article on 9th January 2015  
            //Selection Date Start from 09th Jan 2005  
            //Current date can be select but not future date.  
            Calendar1.EndDate = DateTime.Now;
            //Calendar1.SelectedDate = DateTime.Now;
            /*
            var ctrlName = Request.Params[Page.postEventSourceID];
            var args = Request.Params[Page.postEventArgumentID];

            if (ctrlName == txtClaveUnica.UniqueID && args == "OnKeyPress")
            {
                validarClaveUnica(ctrlName, args);
            }
            */
        
            IDictionaryEnumerator allCaches = HttpRuntime.Cache.GetEnumerator();

            while (allCaches.MoveNext())
            {
                Cache.Remove(allCaches.Key.ToString());
            }
            try
            {


                this.Response.Buffer = true;
                this.session = (SessionManager)this.Session["SessionManager"];
                this.idPersona = this.session.Parametros["idPersona"] != null ?
                    int.Parse(this.session.Parametros["idPersona"].ToString()) : 0;
                if (this.idPersona == 0)
                {
                    this.baseEntity = new Linq.Data.Entity.Persona();
                    this.tipoAccion = 1;
                }
                else
                {
                    this.baseEntity = dcGlobal.GetTable<Linq.Data.Entity.Persona>().First(c => c.id == this.idPersona);
                    this.tipoAccion = 2;
                }

                if (!this.IsPostBack)
                {
                    List<UTTT.Ejemplo.Linq.Data.Entity.CatEstadoCivil> listados = dcGlobalEC.GetTable<CatEstadoCivil>().ToList();
                    CatEstadoCivil catEC = new CatEstadoCivil();
                    this.ddlEstadoCivil.DataTextField = "strValorEstadoCivil";
                    this.ddlEstadoCivil.DataValueField = "id";
                    this.ddlEstadoCivil.DataSource = listados;
                    this.ddlEstadoCivil.DataBind();

                    List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().ToList();
                    CatSexo catTemp = new CatSexo();
                    this.ddlSexo.DataTextField = "strValor";
                    this.ddlSexo.DataValueField = "id";
                    this.ddlSexo.DataSource = lista;
                    this.ddlSexo.DataBind();
                    if (this.session.Parametros["baseEntity"] == null)
                    {
                        this.session.Parametros.Add("baseEntity", this.baseEntity);
                    }
                    /*
                    List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().ToList();
                    CatSexo catTemp = new CatSexo();
                    this.ddlSexo.DataTextField = "strValor";
                    this.ddlSexo.DataValueField = "id";
                    this.ddlSexo.DataSource = lista;
                    this.ddlSexo.DataBind();

                  

                    */
                   

          

                    if (this.idPersona == 0)
                    {
                        this.lblAccion.Text = "Agregar";
                    }
                    else
                    {
                        this.lblAccion.Text = "Editar";
                        this.txtNombre.Text = this.baseEntity.strNombre;
                        this.txtAPaterno.Text = this.baseEntity.strAPaterno;
                        this.txtAMaterno.Text = this.baseEntity.strAMaterno;
                        this.txtClaveUnica.Text = this.baseEntity.strClaveUnica;
                        this.txtDobDat.Text = this.baseEntity.fechaNacimiento;
                        this.numeroHermanos.Text = this.baseEntity.numHermanos.ToString();
                        this.correoElectronico.Text = this.baseEntity.carroElectronico;
                        this.codigoPostal.Text = this.baseEntity.codigoPostal.ToString();
                        this.rfc.Text = this.baseEntity.rfc;

                        this.setItem(ref this.ddlSexo, baseEntity.CatSexo.strValor);
                        this.setItemCV(ref this.ddlEstadoCivil, baseEntity.CatEstadoCivil.strValorEstadoCivil);
                    }
                }

            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al cargar la página");
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            ValidacionesServer();

            if (datasd && datacu && datana && dataam && dataap && datahe && datace && datarc && datacp && datafn && dataev)
            {
                try
                {


                    DataContext dcGuardar = new DcGeneralDataContext();
                    UTTT.Ejemplo.Linq.Data.Entity.Persona persona = new Linq.Data.Entity.Persona();
                    
                    if (this.idPersona == 0)
                    {
                        persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                        persona.strNombre = this.txtNombre.Text.Trim();
                        persona.strAPaterno = this.txtAPaterno.Text.Trim();
                        persona.idCatSexo = int.Parse(this.ddlSexo.Text);
                        persona.fechaNacimiento = this.txtDobDat.Text.Trim();
                        persona.numHermanos = int.Parse(this.numeroHermanos.Text);
                        persona.carroElectronico = this.correoElectronico.Text.Trim();
                        persona.codigoPostal = int.Parse(this.codigoPostal.Text);
                        persona.idCatEstadoCivil = int.Parse(this.ddlEstadoCivil.Text);
                        persona.rfc = this.rfc.Text.Trim();
                        persona.strAMaterno = this.txtAMaterno.Text.Trim();
                        String mensaje = String.Empty;


                        if (!this.ValidacionSql(ref mensaje))
                        {
                            this.msgError.InnerText = mensaje;
                            this.txtClaveUnica.Text = string.Empty;
                            this.txtNombre.Text = string.Empty;
                            this.txtAPaterno.Text = string.Empty;
                            this.txtAMaterno.Text = string.Empty;
                            this.numeroHermanos.Text = string.Empty;
                            this.correoElectronico.Text = string.Empty;
                            this.rfc.Text = string.Empty;
                            this.codigoPostal.Text = string.Empty;

                            this.msgError.Visible = true;
                            return;
                        }
                        if (!this.ValidacionHtml(ref mensaje))
                        {
                            this.msgError.InnerText = mensaje;
                            this.txtClaveUnica.Text = string.Empty;
                            this.txtNombre.Text = string.Empty;
                            this.txtAPaterno.Text = string.Empty;
                            this.txtAMaterno.Text = string.Empty;
                            this.numeroHermanos.Text = string.Empty;
                            this.correoElectronico.Text = string.Empty;
                            this.rfc.Text = string.Empty;
                            this.codigoPostal.Text = string.Empty;
                            
                            this.msgError.Visible = true;
                            return;
                        }
                        dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().InsertOnSubmit(persona);
                        dcGuardar.SubmitChanges();
                        this.showMessage("El registro se agrego correctamente.");
                        this.Response.Redirect("~/PersonaPrincipal.aspx", false);

                    }
                    if (this.idPersona > 0)
                    {
                        persona = dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().First(c => c.id == idPersona);
                        persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                        persona.strNombre = this.txtNombre.Text.Trim();
                        persona.strAMaterno = this.txtAMaterno.Text.Trim();
                        persona.strAPaterno = this.txtAPaterno.Text.Trim();
                        persona.idCatSexo = int.Parse(this.ddlSexo.Text);
                        persona.fechaNacimiento = this.txtDobDat.Text.Trim();
                        persona.numHermanos = int.Parse(this.numeroHermanos.Text);
                        persona.carroElectronico = this.correoElectronico.Text.Trim();
                        persona.codigoPostal = int.Parse(this.codigoPostal.Text);
                        persona.idCatEstadoCivil = int.Parse(this.ddlEstadoCivil.Text);
                        persona.rfc = this.rfc.Text.Trim();
                        String mensaje = String.Empty;



                        if (!this.ValidacionSql(ref mensaje))
                        {
                            this.msgError.InnerText = mensaje;
                            this.txtClaveUnica.Text = string.Empty;
                            this.txtNombre.Text = string.Empty;
                            this.txtAPaterno.Text = string.Empty;
                            this.txtAMaterno.Text = string.Empty;
                            this.numeroHermanos.Text = string.Empty;
                            this.correoElectronico.Text = string.Empty;
                            this.rfc.Text = string.Empty;
                            this.codigoPostal.Text = string.Empty;

                            this.msgError.Visible = true;
                            return;
                        }
                        if (!this.ValidacionHtml(ref mensaje))
                        {
                            this.msgError.InnerText = mensaje;
                            this.txtClaveUnica.Text = string.Empty;
                            this.txtNombre.Text = string.Empty;
                            this.txtAPaterno.Text = string.Empty;
                            this.txtAMaterno.Text = string.Empty;
                            this.numeroHermanos.Text = string.Empty;
                            this.correoElectronico.Text = string.Empty;
                            this.rfc.Text = string.Empty;
                            this.codigoPostal.Text = string.Empty;

                            this.msgError.Visible = true;
                            return;
                        }


                        dcGuardar.SubmitChanges();
                        this.showMessage("El registro se edito correctamente.");
                        this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                    }
                }
                catch (Exception _e)
                {
                    ctrlEmail ctrlmail = new ctrlEmail();
                    ctrlmail.sendEmail(_e.Message);
                    //this.showMessageException(_e.Message);
                    this.Response.Redirect("~/Error404/ErrorPage.html", false);
                }
                //return;
            }
            else
            {
                this.msgWarningCampos.Visible = true;
                this.msgWarningCampos.InnerHtml = msgText;
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            try
            {
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }
        protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idSexo = int.Parse(this.ddlSexo.Text);
                Expression<Func<CatSexo, bool>> predicateSexo = c => c.id == idSexo;
                predicateSexo.Compile();
                List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().Where(predicateSexo).ToList();
                CatSexo catTemp = new CatSexo();
                this.ddlSexo.DataTextField = "strValor";
                this.ddlSexo.DataValueField = "id";
                this.ddlSexo.DataSource = lista;
                this.ddlSexo.DataBind();
            }
            catch (Exception)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        #endregion

        public bool ValidacionSql(ref String _mensaje)
        {
            ctrlSQL ctrsql = new ctrlSQL();
            String _mensajeFuncion = String.Empty;

            if (ctrsql.sqlInjectionValida(this.txtClaveUnica.Text.Trim(), ref _mensajeFuncion, "Clave Única", ref this.txtClaveUnica))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.txtNombre.Text.Trim(), ref _mensajeFuncion, "Nombre", ref this.txtNombre))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.txtAPaterno.Text.Trim(), ref _mensajeFuncion, "Apellido Paterno", ref this.txtAPaterno))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.txtAMaterno.Text.Trim(), ref _mensajeFuncion, "Apellido Materno", ref this.txtAMaterno))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.numeroHermanos.Text.Trim(), ref _mensajeFuncion, "Numero de hermanos", ref this.numeroHermanos))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.correoElectronico.Text.Trim(), ref _mensajeFuncion, "Correo Electronico", ref this.correoElectronico))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.codigoPostal.Text.Trim(), ref _mensajeFuncion, "Codigo Postal", ref this.codigoPostal))
            {
                _mensaje = _mensajeFuncion;
                return false;
            }
            if (ctrsql.sqlInjectionValida(this.rfc.Text.Trim(), ref _mensajeFuncion, "RFC", ref this.rfc))
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
            if (valida.htmlInjectionValida(this.txtClaveUnica.Text.Trim(), ref mensajeFuncion, "Clave Única", ref this.txtClaveUnica))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.txtNombre.Text.Trim(), ref mensajeFuncion, "Nombre", ref this.txtNombre))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.txtAPaterno.Text.Trim(), ref mensajeFuncion, "Apellido Paterno", ref this.txtAPaterno))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.txtAMaterno.Text.Trim(), ref mensajeFuncion, "Apellido Materno", ref this.txtAMaterno))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.numeroHermanos.Text.Trim(), ref mensajeFuncion, "Numero de hermanos", ref this.numeroHermanos))
            {
                _mensaje = mensajeFuncion;
                return false;
            }

            if (valida.htmlInjectionValida(this.correoElectronico.Text.Trim(), ref mensajeFuncion, "Correo", ref this.correoElectronico))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.codigoPostal.Text.Trim(), ref mensajeFuncion, "Codigo Postal", ref this.codigoPostal))
            {
                _mensaje = mensajeFuncion;
                return false;
            }
            if (valida.htmlInjectionValida(this.rfc.Text.Trim(), ref mensajeFuncion, "RFC", ref this.rfc))
            {
                _mensaje = mensajeFuncion;
                return false;
            }

            return true;
        }

        #region Validaciones
        //Validacion de numeros
        protected void ValidacionesServer()
        {
            //Combo Box
            bool ddlSexoValidation = VerifyNumericValue(this.ddlSexo.Text);
            if (ddlSexoValidation == false)
            {
                datasd = false;
                msgText += "Comvo Imvalido </br>";
            }
            else
            {
                datasd = true;
            }

            bool ddlEstadoValidation = VerifyNumericValue(this.ddlEstadoCivil.Text);
            if(ddlEstadoValidation == false)
            {
                dataev = false;
            }
            else
            {
                dataev = true;
            }
           
            //Clave Unica
            bool claveValidation = VerifyNumericValue(this.txtClaveUnica.Text);
            if (claveValidation == false)
            {
                msgText += "Caracteres Incorrectos Clave Unica</br>";
                datacu = false;
            }
            if (claveValidation == true)
            {
                if (int.Parse(this.txtClaveUnica.Text) > 100 && int.Parse(this.txtClaveUnica.Text) < 1000)
                {
                    datacu = true;
                }
                else
                {
                    msgText += "Numero de Caracteres Invalido Clave Unica</br>";
                    datacu = false;
                }
            }
            //Nombre
            bool nombreValidation = VerifyLetters(this.txtNombre.Text);
            if (nombreValidation == false)
            {
                msgText += "Caracteres Incorrectos Nombre </br>";
                datana = false;
            }
            if (nombreValidation == true)
            {
                if (this.txtNombre.Text.Length < 3 || this.txtNombre.Text.Length >= 16)
                {
                    msgText += "Numero de caracteres invalidos Nombre </br>";
                    datana = false;
                }
                else
                {
                    datana = true;
                }
            }
            //Apellido Materno
            bool ApellidoMaternoValidation = VerifyLetters(this.txtAMaterno.Text);
            if (ApellidoMaternoValidation == false)
            {
                msgText += "Caracteres Incorrectos Apellido Materno </br>";
                dataam = false;
            }
            if (ApellidoMaternoValidation == true)
            {
                if (this.txtAMaterno.Text.Length <= 2 || this.txtAMaterno.Text.Length >= 16)
                {
                    msgText += "Numero de caracteres invalidos Apellido Materno </br>";
                    dataam = false;
                }
                else
                {
                    dataam = true;
                }
            }
            //Apellido Paterno
            bool ApellidoPaternoValidation = VerifyLetters(this.txtAPaterno.Text);
            if (ApellidoPaternoValidation == false)
            {
                msgText += "Caracteres Incorrectos Apellido Paterno </br>";
                dataap = false;
            }
            if (ApellidoPaternoValidation == true)
            {
                if (this.txtAPaterno.Text.Length <= 2 || this.txtAPaterno.Text.Length >= 16)
                {
                    msgText += "Numero de caracteres invalidos Apellido Paterno </br>";
                    dataap = false;
                }
                else
                {
                    dataap = true;
                }
            }
            //Numero Hermanos
            bool NumeroHermanosValidation = VerifyNumericValue(this.numeroHermanos.Text);
            if (NumeroHermanosValidation == false)
            {
                datahe = false;
                msgText += "Caracteres Invalidos Numeros Hermanos </br>";
            }
            if (NumeroHermanosValidation == true)
            {
                if (this.numeroHermanos.Text.Length >= 3)
                {
                    msgText += "Numero de Caracteres Invalidos </br>";
                    datahe = false;
                }
                else
                {
                    datahe = true;
                }
            }
            //Email
            bool emailValidation = VerifyEmailID(this.correoElectronico.Text);
            if (emailValidation == false)
            {
                msgText += " Campo Email Incorrecto </br>";
                datace = false;
            }
            else
            {
                datace = true;
            }
            //RFC
            bool rfcValidation = VerifyLettersNumbers(this.rfc.Text);
            if (rfcValidation == false)
            {
                msgText += "Caracteres Incorrectos RFC </br>";
                datarc = false;
            }
            if (rfcValidation == true)
            {
                if (this.rfc.Text.Length <= 12 || this.rfc.Text.Length >= 14)
                {
                    msgText += "Numero de Caracteres Invalidos RFC </br>";
                    datarc = false;
                }
                else
                {
                    datarc = true;
                }
            }
            
            //Codigo Postal
            bool codigoPostalValidation = VerifyNumericValue(this.codigoPostal.Text);
            if (codigoPostalValidation == false)
            {
                datacp = false;
                msgText += "Caracteres Invalidos Codigo Postal </br>";
            }
            if (codigoPostalValidation == true)
            {
                if (int.Parse(this.codigoPostal.Text) > 10000 && int.Parse(this.codigoPostal.Text) < 100000)
                {
                    datacp = true;
                }
                else
                {
                    msgText += "Numero de Caracteres Invalidos Codigo Postal </br>";
                    datacp = false;
                }
            }
            //Fecha de Nacimiento

            bool fechaValidation = VerifyDate(this.txtDobDat.Text);
            Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

            //Verify whether date entered in dd/MM/yyyy format.
            bool isValid = regex.IsMatch(txtDobDat.Text.Trim());

            //Verify whether entered date is Valid date.

            DateTime dt;
            isValid = DateTime.TryParseExact(txtDobDat.Text, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
            if (!isValid)
            {
                msgText += "Caracteteres Imcorrectos Fecha Formato: 00/00/0000";
                datafn = false;
            }
            else
            {

                datafn = true;
            }


        }
        //Validacion Numeros
        protected bool VerifyNumericValue(string ValueToCheck)
        {
            Int32 numval;
            bool rslt = false;

            rslt = Int32.TryParse(ValueToCheck, out numval);

            return rslt;
        }
        //Validacion del Correo
        protected static bool VerifyEmailID(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
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
        //Validacion Letras
        protected static bool VerifyLetters(string Texto)
        {
            string expressionLetters;
            expressionLetters = @"^[a-zA-Z]+$";
            if (Regex.IsMatch(Texto, expressionLetters))
            {
                if (Regex.Replace(Texto, expressionLetters, string.Empty).Length == 0)
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
        //Validacion Letras y Numeros
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
        #endregion

        #region Metodos

        public void setItem(ref AjaxControlToolkit.ComboBox _control, String _value)
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
        public void setItemCV(ref AjaxControlToolkit.ComboBox _control, String _value)
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
        #endregion
       
        }
    
}