using encabezadoParcial2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encabezadoParcial2.Clases
{
    internal class COperador : IOperador
    {
        private ulong legajo;

        private string apellido;

        private string nombre;

        private string categoria;
        public ulong Legajo { get { return legajo; } private set { legajo = value; } }
        public string Apellido { get { return apellido; } private set { apellido = value; } }
        public string Nombre { get { return nombre; } private set { nombre = value; } }
        public string Categoria { get { return categoria; } private set { categoria = value; } }

        public COperador(ulong legajo, string apellido, string nombre, string categoria)
        {
            Legajo = legajo;
            Apellido = apellido;
            Nombre = nombre;
            Categoria = categoria;
        }
        public void MostrarDatos()
        {
            Console.WriteLine($"Legajo: {Legajo}");
            Console.WriteLine($"Apellido: {Apellido}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Categoria: {Categoria}");
        }

    }
}
