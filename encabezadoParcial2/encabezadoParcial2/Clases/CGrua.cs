using encabezadoParcial2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace encabezadoParcial2.Clases
{
    internal class CGrua : CMaquina
    {

        private double capacidadDeToneladas;


        public double CapacidadDeToneladas { get { return capacidadDeToneladas; } set { capacidadDeToneladas = value; } }

        public CGrua(string codigo, string marca, string modelo, double capacidadDeToneladas) : base(codigo, marca, modelo)  
        {
  
            CapacidadDeToneladas = capacidadDeToneladas;
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Codigo: {Codigo}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Capacidad de Toneladas: {CapacidadDeToneladas}");
        }
      

    }
}
