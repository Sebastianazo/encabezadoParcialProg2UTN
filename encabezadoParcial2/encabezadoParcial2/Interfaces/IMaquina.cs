using System;
using System.Collections.Generic;
using System.Linq;

namespace encabezadoParcial2.Interfaces
{
    internal interface IMaquina
    {
        string Codigo { get; }
        string Marca { get; set; }
        string Modelo { get; }
        void MostrarDatos();
    }
}
