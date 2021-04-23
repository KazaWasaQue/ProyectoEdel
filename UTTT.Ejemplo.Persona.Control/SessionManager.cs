using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace UTTT.Ejemplo.Persona.Control
{
    public class SessionManager
    {
        private int idPersona;
        private bool accionAgregar = false;
        private bool accionEditar = false;
        private int idManager = 0;
        private int idUsuario;
        private bool accionAgregarUsuario = false;
        private bool accionEditarUsuario = false;
        private int idUserManager = 0;

        public int IdManager
        {
            get { return idManager; }
            set { idManager = value; }
        }
        //---
        public int IdUserManager
        {
            get { return idUserManager; }
            set { idUserManager = value; }
        }
        //--
        public bool AccionEditarUsuario
        {
            get { return accionEditarUsuario; }
            set { accionEditarUsuario = value; }
        }
        public bool AccionEditar
        {
            get { return accionEditar; }
            set { accionEditar = value; }
        }

        public bool AccionAgregar
        {
            get { return accionAgregar; }
            set { accionAgregar = value; }
        }
        //--
        public bool AccionAgregarUsuario
        {
            get { return accionAgregarUsuario; }
            set { accionAgregarUsuario = value; }
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        private String strNombrePersona;

        public String StrNombrePersona
        {
            get { return strNombrePersona; }
            set { strNombrePersona = value; }
        }
        private String pantalla;

        public String Pantalla
        {
            get { return pantalla; }
            set { pantalla = value; }
        }
        private String pantallaUsuario;

        public String PantallaUsuario
        {
            get { return pantallaUsuario; }
            set { pantallaUsuario = value; }
        }
        private Hashtable parametros;

        public Hashtable Parametros
        {
            get
            {
                if (parametros == null)
                {
                    parametros = new Hashtable();
                }
                return parametros;
            }
            set { parametros = value; }
        }

        private Hashtable parametrosUsuario;
        public Hashtable ParametrosUsuario
        {
            get
            {
                if (parametrosUsuario == null)
                {
                    parametrosUsuario = new Hashtable();
                }
                return parametrosUsuario;
            }
            set { parametrosUsuario = value; }
        }
    }
}
