using System;
using System.Collections.Generic;
using System.Text;

namespace Guardias_V2.Model
{
    public class Empleado
    {
        public int PK_TBL_GUA_EMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO1 { get; set; }
        public string APELLIDO2 { get; set; }
        public string IDENTIFICACION { get; set; }
        public string TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }
    }
}
