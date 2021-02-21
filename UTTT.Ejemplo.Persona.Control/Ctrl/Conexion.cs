using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace UTTT.Ejemplo.Persona.Control.Ctrl
{
    public class Conexion
    {
        #region Variables
     
        #endregion

        #region Constructores
        public Conexion()
        {
        }       
        #endregion


        public SqlConnection sqlConnection()
        {
            try
            {
                //Data Source=DESKTOP-3UNHNT8;Initial Catalog=Manual;Integrated Security=True
                SqlConnection conexion = new SqlConnection("data source=ManualProyecto.mssql.somee.com;Initial Catalog=ManualProyecto;persist Security info=True;user id=alexuwu_SQLLogin_1;password = jsz55va48s;");
                return conexion;
            }
            catch (Exception _e)
            { 
            
            }
            return null;
        }
    }
}
