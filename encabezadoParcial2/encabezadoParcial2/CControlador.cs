using encabezadoParcial2.Clases;
using encabezadoParcial2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace encabezadoParcial2
{
    internal class CControlador
    {
        
        List<IOperador> operadores = new List<IOperador>();
        List<IMaquina> maquinas = new List<IMaquina>();
        List<CAsignacion> asignaciones = new List<CAsignacion>();
        List<CObra> obras = new List<CObra>();

        private readonly string archivo1 = "datosOperadores.txt";
        private readonly string archivo2 = "datosMaquinas.txt";
        private readonly string archivo3 = "datosObras.txt";
        private readonly string archivo4 = "datosAsignaciones.txt";

        public void agregarMaquina(string codigo, string marca, string modelo)
        {
            // verificar si existe

            foreach (IMaquina maquina in maquinas)
            {
                if (maquina.Codigo == codigo)
                {
                    throw new Exception("La maquina ya existe.");
                }
            }

            IMaquina nueva = new CMaquina(codigo, marca, modelo);
            maquinas.Add(nueva);
        }

        public void agregarGrua(string codigo, string marca, string modelo, double capacidadDeToneladas)
        {
            
            foreach (IMaquina maquina in maquinas)
            {
                if (maquina.Codigo == codigo)
                {
                    throw new Exception("La grua ya existe.");
                }
            }

            IMaquina nueva = new CGrua(codigo, marca, modelo, capacidadDeToneladas);
            maquinas.Add(nueva);
        }

        public void agregarOperador(ulong legajo, string apellido, string nombre, string categoria)
        {
            foreach (IOperador operador in operadores)
            {
                if (operador.Legajo == legajo)
                {
                    throw new Exception("El operador ya existe.");
                }

            }

            if ( !(categoria == "A" || categoria == "B" || categoria == "C" ))
            {
                throw new Exception("La categoria no es valida, tiene que ser A, B o C");
            }

            IOperador nuevo = new COperador(legajo, nombre, apellido, categoria);
            operadores.Add(nuevo);
        }

        public void agregarObra(string codigo, string nombreObra, string ubicacion)
        {
            foreach (CObra obra in obras)
            {
                if (obra.CodigoDeObra == codigo)
                {
                    throw new Exception("La obra ya existe.");
                }

            }

            CObra obraNueva = new CObra(codigo, nombreObra, ubicacion);

            obras.Add(obraNueva);



        }
        // podria usar linq si pero me parece mas vistoso usar foreach
        public void agregarAsignacion(DateTime fecha, string codigoMaquina, string codigoObra, ulong legajoOperador)
        {
            IMaquina nuevaMaquina = null;
            IOperador nuevoOperador = null;
            CObra nuevaObra = null;

            // verificar existencia
            foreach (IMaquina maquina in maquinas)
            {
                if ((maquina.Codigo == codigoMaquina))
                {
                    nuevaMaquina = maquina;
                    break;
                }
            }

            foreach (IOperador operador in operadores)
            {
                if ((operador.Legajo == legajoOperador))
                {
                    nuevoOperador = operador;
                    break;
                }
            }

            foreach (CObra obra in obras)
            {
                if ((obra.CodigoDeObra == codigoObra))
                {
                    nuevaObra = obra;
                    break;
                }
            }

            // comprobar 

            if (nuevaMaquina == null)
            {
                throw new Exception("No se encontro la maquina.");
            }

            if (nuevoOperador == null)
            {
                throw new Exception("no se encontro operador.");
            }

            if (nuevaObra == null)
            {
                throw new Exception("No se encontro la obra");
            }

            // maquina ya asignada

            foreach (CAsignacion asignacion in asignaciones)
            {
                if (asignacion.Maquina.Codigo == codigoMaquina && asignacion.Fecha.Date == fecha.Date)
                {
                    throw new Exception("La maquina ya esta asignada en este dia.");
                }
            }

            // logica de negocio 

            if (nuevoOperador.Categoria == "B")
            {
                
                if (nuevaMaquina is CGrua)
                {
                    throw new Exception("Los operadores de Categoría B no pueden manejar Grúas.");
                }
            }

            // no se donde deberia ir que sea pesado
            if (nuevoOperador.Categoria == "C" || nuevaMaquina.Modelo.Contains("PESADO"))
            {
                if (nuevaMaquina is CGrua)
                {
                    throw new Exception("Los operadores de Categoría C no pueden manejar Grúas o Modelos pesados.");
                }
 
            }


            CAsignacion nuevaAsignacion = new CAsignacion(fecha, nuevaMaquina, nuevaObra, nuevoOperador);
            asignaciones.Add(nuevaAsignacion);
            

         



        }

        public List <CAsignacion> buscarAsignacion(DateTime fecha)
        {
            List<CAsignacion> asignacionesEncontradas = new List<CAsignacion>();


            foreach (CAsignacion asignacion in asignaciones)
            {
                if (asignacion.Fecha.Date == fecha.Date)
                {
                    asignacionesEncontradas.Add(asignacion);

                }


            }
            if (!(asignacionesEncontradas.Count > 0))
            {
                throw new Exception("No se encontraron asignaciones con esa fecha.");
            }

            return asignacionesEncontradas;


        }

        public List <CAsignacion> listarAsignaciones()
        {
            asignaciones = asignaciones
                .OrderBy(a => a.Fecha.Date)
                .ThenBy(a => a.Operador.Nombre)
                .ToList();

            return asignaciones;
        }

        public int cantidadMaquinas()
        {

            int cantidad = CMaquina.ContadorDeMaquinas();

            return cantidad;

        }

        public void guardarDatos()
        {

            //string archivo1 = "datosOperadores.txt";
            //string archivo2 = "datosMaquinas.txt";
            //string archivo3 = "datosObras.txt";
            //string archivo4 = "datosAsignaciones.txt";



            // guardar operadores
            using (StreamWriter escribir = new StreamWriter(archivo1))
            {
               foreach(IOperador operador in operadores)
                {
                    escribir.WriteLine($"{operador.Legajo};{operador.Apellido};{operador.Nombre};{operador.Categoria}");
                }

            }

            // guardar maquinas
            using (StreamWriter escribir = new StreamWriter(archivo2))
            {
                foreach (IMaquina maquina in maquinas)
                {
                    if (maquina is CGrua grua)
                    {
                        escribir.WriteLine($"GRUA;{maquina.Codigo};{maquina.Marca};{maquina.Modelo};{grua.CapacidadDeToneladas}");
                    } else
                    {
                        escribir.WriteLine($"COMUN;{maquina.Codigo};{maquina.Marca};{maquina.Modelo}");
                    }  
                }

            }

            // guardar obras
            using (StreamWriter escribir = new StreamWriter(archivo3))
            {
                foreach (CObra obra in obras)
                {
                    escribir.WriteLine($"{obra.CodigoDeObra};{obra.NombreDeObra};{obra.Ubicacion}");
                }

            }

            // guardar asignaciones
            using (StreamWriter escribir = new StreamWriter(archivo4))
            {
                foreach (CAsignacion asignacion in asignaciones)
                {
                    escribir.WriteLine($"{asignacion.Fecha.Date};{asignacion.Maquina.Codigo};{asignacion.Obra.CodigoDeObra};{asignacion.Operador.Legajo}");
                }

            }



        }

        int contarGruas()
        {
            int total = 0;
            foreach(IMaquina maquina in maquinas)
            {
                if (maquina is CGrua grua)
                {
                    total++;
                }

            }

            return total;

        }

        // return asignaciones.Where(a => a.Fecha.Date == fecha.Date && a.Operador.Categoria == "C").ToList();


        // recuperar datos

        public void cargarDatos()
        {
            //string archivo1 = "datosOperadores.txt";
           // string archivo2 = "datosMaquinas.txt";
           // string archivo3 = "datosObras.txt";
           // string archivo4 = "datosAsignaciones.txt";

            operadores.Clear();
            maquinas.Clear();
            obras.Clear();
            asignaciones.Clear();

            if (File.Exists(archivo1))
            {
                string[] lineas = File.ReadAllLines(archivo1);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    ulong legajo = ulong.Parse(datos[0]);
                    string apellido = datos[1];
                    string nombre = datos[2];
                    string categoria = datos[3];

                    agregarOperador(legajo, apellido, nombre, categoria);
                }
            }
            


            if (File.Exists(archivo2))
            {
                string[] lineas = File.ReadAllLines(archivo2);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    string tipo = datos[0];


                    if (tipo == "GRUA")
                    {
                        string codigo = datos[1];
                        string marca = datos[2];
                        string modelo = datos[3];
                        double capacidad = double.Parse(datos[4]);
                        agregarGrua(codigo, marca, modelo, capacidad);
                    }
                    else if (tipo == "COMUN")
                    {
                        string codigo = datos[1];
                        string marca = datos[2];
                        string modelo = datos[3];

                        agregarMaquina(codigo, marca, modelo);

                    }

                }
            }
            


            if (File.Exists(archivo3))
            {
                string[] lineas = File.ReadAllLines(archivo3);
                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    string codigo = datos[0];
                    string nombreObra = datos[1];
                    string ubicacion = datos[2];

                    agregarObra(codigo, nombreObra, ubicacion);

                }
            }
            
                


            if (File.Exists(archivo4))
            {
                string[] lineas = File.ReadAllLines(archivo4);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(';');
                    DateTime fecha = DateTime.Parse(datos[0]);
                    string codMaquina = datos[1];
                    string codObra = datos[2];
                    ulong legajoOp = ulong.Parse(datos[3]);

                    agregarAsignacion(fecha, codMaquina, codObra, legajoOp);

                }
            }
            

        }



    }
}
