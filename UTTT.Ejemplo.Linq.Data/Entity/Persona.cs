﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTTT.Ejemplo.Linq.Data.Entity
{
    public partial class Persona
    {

        public override string ToString()
        {
            var c = this.strNombre + " " + this.strAPaterno + " " + this.strAMaterno;
            return c;
        }
    }
}
