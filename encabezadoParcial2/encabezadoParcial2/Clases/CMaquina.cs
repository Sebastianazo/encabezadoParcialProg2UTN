using encabezadoParcial2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encabezadoParcial2.Clases
{
    internal class CMaquina : IMaquina
    {
        private string codigo;

        private string marca;

        private string modelo;
        public string Codigo { get { return codigo; } private set { codigo = value; } }
        public string Marca { get { return marca; } set { marca = value; } }
        public string Modelo { get { return modelo; } private set { modelo = value; } }

        static private int contadorDeMaquinas;

        public CMaquina(string codigo, string marca, string modelo)
        {
            Codigo = codigo;
            Marca = marca;
            Modelo = modelo;

            contadorDeMaquinas++;
        }
        public virtual void MostrarDatos()
        {
            Console.WriteLine($"Codigo: {Codigo}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
        }

        public static int ContadorDeMaquinas()
        {
            return contadorDeMaquinas;

        }

    }
}
