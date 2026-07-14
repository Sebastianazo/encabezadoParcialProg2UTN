using encabezadoParcial2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encabezadoParcial2
{
    internal class CVista
    {

        CControlador controlador = new CControlador();

        public void menu()
        {
            bool salir = false;

            controlador.cargarDatos();

            do
            {

                

                mostrarTexto("Ingrese una opción: ");
                mostrarTexto("1. Agregar una maquina.");
                mostrarTexto("2. Agregar un operador.");
                mostrarTexto("3. Agregar una obra.");
                mostrarTexto("4. Crear una asignacion.");
                mostrarTexto("5. Mostrar asignaciones por fecha.");
                mostrarTexto("6. Mostrar cantidad de maquinas");
                mostrarTexto("7. Salir");
               
                

                int opcion = opcionElegir(7);

                switch (opcion)
                {
                    case 1:
                        mostrarTexto("1. Maquina normal");
                        mostrarTexto("2. Grua");

                        int tipoMaquina = opcionElegir(2);

                        try
                        {
                            if (tipoMaquina == 1)
                            {
                                mostrarTexto("Ingrese el codigo de la maquina:");
                                string codigo = pedirString();
                                mostrarTexto("Ingrese la marca de la maquina:");
                                string marca = pedirString();
                                mostrarTexto("Ingrese el modelo de la maquina:");
                                string modelo = pedirString();

                                controlador.agregarMaquina(codigo, marca, modelo);
                                mostrarTexto("Maquina agregada correctamente.");

                            }
                            else if (tipoMaquina == 2)
                            {
                                mostrarTexto("Ingrese el codigo de la grua:");
                                string codigo = pedirString();
                                mostrarTexto("Ingrese la marca de la grua:");
                                string marca = pedirString();
                                mostrarTexto("Ingrese el modelo de la grua:");
                                string modelo = pedirString();
                                mostrarTexto("Ingrese la capacidad maxima:");
                                double capacidadMaxima = pedirDouble();

                                controlador.agregarGrua(codigo, marca, modelo, capacidadMaxima);
                                mostrarTexto("Grua agregada correctamente.");

                             }
                        }

                        catch (Exception ex)
                        {
                            mostrarTexto($"Ocurrió un error: {ex.Message}");
                        }

                        break;
                    case 2:
                        
                        mostrarTexto("Ingrese el legajo del operador:");
                        ulong legajo = pedirUlong();
                        mostrarTexto("Ingrese el apellido del operador:");
                        string apellido = pedirString();
                        mostrarTexto("Ingrese el nombre del operador:");
                        string nombre = pedirString();
                        mostrarTexto("Ingrese la categoria del operador:");
                        string categoria = pedirString();

                        try
                        {
                            controlador.agregarOperador(legajo, apellido, nombre, categoria);
                            mostrarTexto("Operador agregado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            mostrarTexto($"Ocurrió un error: {ex.Message}");
                        }

                        break;
                    case 3:
                        
                        mostrarTexto("Ingrese el codigo de la obra:");
                        string codigoObra = pedirString();
                        mostrarTexto("Ingrese el nombre de la obra:");
                        string nombreObra = pedirString();
                        mostrarTexto("Ingrese la ubicacion de la obra:");
                        string ubicacion = pedirString();


                        try
                        {
                            controlador.agregarObra(codigoObra, nombreObra, ubicacion);
                            mostrarTexto("Obra agregada correctamente.");
                        }
                        catch (Exception ex)
                        {
                            mostrarTexto($"Ocurrió un error: {ex.Message}");
                        }

                        break;
                    case 4:
                        
                        mostrarTexto("Ingrese fecha:");
                        DateTime fecha = pedirFecha();
                        mostrarTexto("Ingrese codigo de la maquina:");
                        string codigoMaquina = pedirString();
                        mostrarTexto("Ingrese codigo de la obra:");
                        string obraCod = pedirString();
                        mostrarTexto("Ingrese legajo del operador:");
                        ulong legajoOperador = pedirUlong();


                        try
                        {
                            controlador.agregarAsignacion(fecha, codigoMaquina, obraCod, legajoOperador);
                            mostrarTexto("Asignacion agregada correctamente.");
                        }
                        catch (Exception ex)
                        {
                            mostrarTexto($"Ocurrió un error: {ex.Message}");
                        }

                        break;
                    case 5:

                        mostrarTexto("Ingrese fecha de asignacion:");

                        DateTime fechaAsignacion = pedirFecha();

                        try
                        {
                            List<CAsignacion> asignaciones = controlador.buscarAsignacion(fechaAsignacion);

                            
                            
                                mostrarTexto("Asignaciones para la fecha ingresada:");
                                mostrarTexto("--------------------------------------");

                            foreach (CAsignacion asignacion in asignaciones)
                                {

                                mostrarTexto($"Fecha: {asignacion.Fecha}");

                                mostrarTexto("Maquina: ");

                                asignacion.Maquina.MostrarDatos();

                                mostrarTexto("Operador:");

                                asignacion.Operador.MostrarDatos();

                                mostrarTexto("Obra: ");

                                mostrarTexto($"Codigo de obra: {asignacion.Obra.CodigoDeObra}");
                                mostrarTexto($"Nombre de la obra: {asignacion.Obra.NombreDeObra}");
                                mostrarTexto($"Ubicacion: {asignacion.Obra.Ubicacion}");

                                

                            }
                            Console.ReadKey();

                        }
                        catch (Exception ex)
                        {
                            mostrarTexto($"Ocurrió un error: {ex.Message}");
                        
                }
                        break;
                        case 6:

                        mostrarTexto("--------------------------------------");
                        mostrarTexto("Cantidad de maquinas: ");

                        int cantidad = controlador.cantidadMaquinas();

                        mostrarTexto($"{cantidad}");
                        
                       
                        

                        break;
                        case 7:

                        salir = true;
                        break;




                        // termina el while


                }

            } while (salir == false);

            controlador.guardarDatos();

    
        }


        public int opcionElegir(int cant)
        {
            string numero = Console.ReadLine();
            int resultado;

            while (!int.TryParse(numero, out resultado) || (resultado < 1 || resultado > cant))
            {
                Console.WriteLine($"Ingrese un número válido hasta el {cant}.");
                numero = Console.ReadLine();
            }

            return resultado;
        }

        public uint pedirUint()
        {
            string numero = Console.ReadLine();
            uint resultado;

            while (!uint.TryParse(numero, out  resultado))
            {
                Console.WriteLine("Ingrese un número válido.");
                numero = Console.ReadLine();
            }
            return resultado;
        }

        public void mostrarTexto(string text)
        {
            Console.WriteLine(text);
        }

        public DateTime pedirFecha()
        {
            mostrarTexto("Ingrese una fecha (formato: dd/mm/yyyy):");
            string fecha = Console.ReadLine();
            DateTime resultado;

            while (!DateTime.TryParse(fecha, out resultado))
            {
                Console.WriteLine("Ingrese una fecha válida.");
                fecha = Console.ReadLine();
            }

            resultado = resultado.Date;

            return resultado;
        }

        public string pedirString()
        {
            string resultado = Console.ReadLine() ?? "";

            resultado = resultado.ToUpper();

            return resultado;
        }

        public double pedirDouble()
        {
            string numero = Console.ReadLine();
            double resultado;

            while (!double.TryParse(numero, out resultado))
            {
                Console.WriteLine("Ingrese un número válido.");
                numero = Console.ReadLine();
            }

            return resultado;


        }

        public ulong pedirUlong()
        {

            string numero = Console.ReadLine();
            ulong resultado;

            while (!ulong.TryParse(numero, out resultado))
            {
                Console.WriteLine("Ingrese un número válido.");
                numero = Console.ReadLine();
            }

            return resultado;


        }

      

    }
}
