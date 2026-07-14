using encabezadoParcial2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encabezadoParcial2.Clases
{
    internal class CAsignacion
    {
        private DateTime fecha;
        private IMaquina maquina;
        private CObra obra;
        private IOperador operador;

        public DateTime Fecha { get { return fecha; } private set { fecha = value; } }
        public IMaquina Maquina { get { return maquina; } private set { maquina = value; } }
        public CObra Obra { get { return obra; } private set { obra = value; } }
        public IOperador Operador { get { return operador; } private set { operador = value; } }

        public CAsignacion(DateTime fecha, IMaquina maquina, CObra obra, IOperador operador)
        {
            Fecha = fecha;
            Maquina = maquina;
            Obra = obra;
            Operador = operador;
        }

    }
}
