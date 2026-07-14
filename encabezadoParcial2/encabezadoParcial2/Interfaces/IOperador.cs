using System;
using System.Collections.Generic;
using System.Linq;

namespace encabezadoParcial2.Interfaces
{
    internal interface IOperador
    {
        ulong Legajo { get; }
        string Apellido { get; }
        string Nombre { get; }
        string Categoria { get; }
        void MostrarDatos();
    }
}
