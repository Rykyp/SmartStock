using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Core
{
    internal class Utilidades;
    
        namespace SmartStock.Core
    {
        public static class Utilidades
        {
            /// <summary>
            /// Calcula el impuesto sobre un precio.
            /// </summary>
            public static decimal CalcularImpuesto(decimal precio)
            {
                return precio * 0.21m;
            }
            /// <summary>
            /// Valida el formato del ID.
            /// </summary>
            public static bool ValidarFormatoId(string id)
            {
                return id.Length >= 3;
            }
        }
    }

}

