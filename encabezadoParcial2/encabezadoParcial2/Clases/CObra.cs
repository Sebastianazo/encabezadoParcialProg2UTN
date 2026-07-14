using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encabezadoParcial2.Clases
{
    internal class CObra
    {
        private string codigoDeObra;

        private string nombreDeObra;

        private string ubicacion;

        public string CodigoDeObra { get { return codigoDeObra; } private set { codigoDeObra = value; } }
        public string NombreDeObra { get { return nombreDeObra; } set { nombreDeObra = value; } }
        public string Ubicacion { get { return ubicacion; } set { ubicacion = value; } }

        public CObra(string codigoDeObra, string nombreDeObra, string ubicacion)
        {
            CodigoDeObra = codigoDeObra;
            NombreDeObra = nombreDeObra;
            Ubicacion = ubicacion;
        }

      

    }
}
