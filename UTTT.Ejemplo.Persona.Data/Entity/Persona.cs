using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTTT.Ejemplo.Persona.Data.Entity
{
    public class Persona
    {
        private int id;
        private String strClaveUnica;
        private String strNombre;
        private String strAPaterno;
        private String strAMaterno;
        private int idCatSexo;
        private CatSexo catSexoTemp;
        private String strValorSexo;
        private String fechaNacimiento;
        private int numHermanos;
        private String carroElectronico;
        private int codigoPostal;
        private String rfc;

        public String StrValorSexo
        {
            get { return strValorSexo; }
            set { strValorSexo = value; }
        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public String StrClaveUnica
        {
            get { return strClaveUnica; }
            set { strClaveUnica = value; }
        }
        
        public String StrNombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }
        
        public String StrAPaterno
        {
            get { return strAPaterno; }
            set { strAPaterno = value; }
        }
        
        public String StrAMaterno
        {
            get { return strAMaterno; }
            set { strAMaterno = value; }
        }
        
        public int IdCatSexo
        {
            get { return idCatSexo; }
            set { idCatSexo = value; }
        }

        public String FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        public int NumHermanos
        {
            get { return numHermanos; }
            set { numHermanos = value; }
        }

        public String CarroElectronico
        {
            get { return CarroElectronico; }
            set { carroElectronico = value; }
        }

        public int CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public String Rfc
        {
            get { return rfc; }
            set { rfc = value; }
        }

        public CatSexo CatSexoTemp
        {
            get { return catSexoTemp; }
            set { catSexoTemp = value; }
        }
      
    }
}
