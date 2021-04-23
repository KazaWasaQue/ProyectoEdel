using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;

namespace UTTT.Ejemplo.Persona
{
    public partial class PantallaCUsuario : System.Web.UI.Page
    {
        private SessionManager session = new SessionManager();
        private DataContext dcTemp = new DcGeneralDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] == null)
            {
                this.Response.Redirect("~/Login.aspx", false);
            }
            try
            {
                Response.Buffer = true;
              
                if (!this.IsPostBack)
                {
                    List<Usuario> lista = dcTemp.GetTable<Usuario>().ToList();
                    Usuario catTemp = new Usuario();
                    catTemp.id = -1;
                    catTemp.usuario1 = "Todos";
                    lista.Insert(0, catTemp);
                    this.ddlUsuario.DataTextField = "usuario1";
                    this.ddlUsuario.DataValueField = "id";
                    this.ddlUsuario.DataSource = lista;
                    this.ddlUsuario.DataBind();

                    List<StatusCuenta> listec = dcTemp.GetTable<StatusCuenta>().ToList();
                    StatusCuenta catTempEc = new StatusCuenta();
                    catTempEc.id = -1;
                    catTempEc.strEstado = "Todos";
                    listec.Insert(0, catTempEc);
                    this.ddlEstadoCuenta.DataTextField = "strEstado";
                    this.ddlEstadoCuenta.DataValueField = "id";
                    this.ddlEstadoCuenta.DataSource = listec;
                    this.ddlEstadoCuenta.DataBind();
                }
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al cargar la página");
            }
        }


        protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.DataSourcePersonaData.RaiseViewChanged();


            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al buscar");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                this.session.Pantalla = "~/PantallaUsuario.aspx";
                Hashtable parametrosRagion = new Hashtable();
                parametrosRagion.Add("idPersona", "0");
                this.session.Parametros = parametrosRagion;
                this.Session["SessionManager"] = this.session;
                this.Response.Redirect(this.session.Pantalla, false);
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al agregar");
            }
        }

        protected void DataSourcePersona_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {

            try
            {
                DataContext dcConsulta = new DcGeneralDataContext();
                bool nombreBool = false;
                bool sexoBool = false;
                bool estadoCivil = false;
                if (!this.txtNombre.Text.Equals(String.Empty))
                {
                    nombreBool = true;
                }
                if (this.ddlUsuario.Text != "-1")
                {
                    sexoBool = true;
                }
                if (this.ddlEstadoCuenta.Text != "-1")
                {
                    estadoCivil = true;
                }
                Expression<Func<UTTT.Ejemplo.Linq.Data.Entity.Usuario, bool>>
                    predicate =
                    (c =>
                    ((sexoBool) ? c.id == int.Parse(this.ddlUsuario.Text) : true) &&
                    ((estadoCivil) ? c.statusId == int.Parse(this.ddlEstadoCuenta.Text) : true) &&
                    ((nombreBool) ? (((nombreBool) ? c.usuario1.Contains(this.txtNombre.Text.Trim()) : false)) : true)
                    );

                predicate.Compile();

                List<UTTT.Ejemplo.Linq.Data.Entity.Usuario> listaPersona =
                    dcConsulta.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().Where(predicate).ToList();
                e.Result = listaPersona;
            }
            catch (Exception _e)
            {
                throw _e;
            }
        }

        protected void dgvPersonas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idUsuario = int.Parse(e.CommandArgument.ToString());
                switch (e.CommandName)
                {
                    case "Editar":
                        this.editar(idUsuario);
                        break;
                    case "Eliminar":
                        this.eliminar(idUsuario);
                        break;
                }
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al seleccionar");
            }
        }



        #region Metodos

        private void editar(int _idPersona)
        {
            try
            {
                Hashtable parametrosRagion = new Hashtable();
                parametrosRagion.Add("idPersona", _idPersona.ToString());
                this.session.Parametros = parametrosRagion;
                this.Session["SessionManager"] = this.session;
                this.session.Pantalla = String.Empty;
                this.session.Pantalla = "~/PantallaUsuario.aspx";
                this.Response.Redirect(this.session.Pantalla, false);

            }
            catch (Exception _e)
            {
                throw _e;
            }
        }

        private void eliminar(int _idUsuario)
        {
            try
            {

                DataContext dcDelete = new DcGeneralDataContext();
                UTTT.Ejemplo.Linq.Data.Entity.Usuario usuario = dcDelete.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().First(
                    c => c.id == _idUsuario);
                dcDelete.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Usuario>().DeleteOnSubmit(usuario);
                dcDelete.SubmitChanges();
                this.showMessage("El registro se agrego correctamente.");
                this.DataSourcePersonaData.RaiseViewChanged();
                List<Usuario> lista = dcTemp.GetTable<Usuario>().ToList();
                Usuario catTemp = new Usuario();
                catTemp.id = -1;
                catTemp.usuario1 = "Todos";
                lista.Insert(0, catTemp);
                this.ddlUsuario.DataTextField = "usuario1";
                this.ddlUsuario.DataValueField = "id";
                this.ddlUsuario.DataSource = lista;
                this.ddlUsuario.DataBind();
            }
            catch (Exception _e)
            {
                throw _e;
            }
        }

       
        protected void GridView_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0)
                || (gv.ShowHeaderWhenEmpty == true))
            {
                //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
        #endregion
    }
}