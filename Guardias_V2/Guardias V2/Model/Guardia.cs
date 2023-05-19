using System;
using System.Collections.Generic;
using System.Text;

namespace Guardias_V2.Model
{
    public class Guardia
    {
        public int PK_TBL_GUA_GUARDIA { get; set; }
        public string FECHA { get; set; }
        public int FK_TBL_GUA_EMPELADO { get; set; }
        public string IDENTIFICACION_EMPLEADO { get; set; }
        public string NOMBRE_EMPLEADO { get; set; }
        public string APELLIDO1_EMPLEADO { get; set; }
    }
}
