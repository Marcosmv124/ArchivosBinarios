using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploArchivoBinario;
using System.IO; 

namespace ArchivosBinarios
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Title = "ARCHIVO EMPLEADO"; 
            //declaración variables auxiliares
            string Arch = null;
            int opcion;
            //creación del objeto
            ArchivoBinarioEmpleado A1 = new ArchivoBinarioEmpleado();
            //Menu de Opciones
            do
            {
                Console.Clear();
                Console.WriteLine("\n*** ARCHIVO BINARIO EMPLEADOS***");
                Console.WriteLine("1.- Creación de un Archivo.");
                Console.WriteLine("2.- Lectura de un Archivo.");
                Console.WriteLine("3.- Salida del Programa.");
                Console.Write("\nQue opción deseas: ");
                opcion = Int16.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        //bloque de escritura
                        try
                        {
                            //captura nombre archivo
                            Console.Write("\nAlimenta el Nombre del Archivo a Crear: "); Arch = Console.ReadLine();
                            //verifica si existe el archivo
                            char resp = 's';
                            if (File.Exists(Arch))
                            {
                                Console.Write("\nEl Archivo Existe!!, Deseas Sobreescribirlo (s/n) ? ");

                                resp = Char.Parse(Console.ReadLine());

                            }
                            if ((resp == 's') || (resp == 'S'))
                                A1.CreaarArchivo(Arch);

                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError : " + e.Message);
                            Console.WriteLine("\nRuta : " + e.StackTrace);
                        }
                        break;
                    case 2:
                        //bloque de lectura
                        try
                        {
                            //captura nombre archivo
                            Console.Write("\nAlimenta el Nombre del Archivo que deseas Leer: "); Arch = Console.ReadLine();
                            A1.MostrarArchivos(Arch);

                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError : " + e.Message);
                            Console.WriteLine("\nRuta : " + e.StackTrace);
                        }
                        break;
                    case 3:
                        Console.Write("\nPresione <enter> para Salir del programa. ");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nEsa Opción No Existe!!, Presione  < enter > para Continuar...");
                        break;

                }

            } while (opcion != 3); 

        }
    }
}
