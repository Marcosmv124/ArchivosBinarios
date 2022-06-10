using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace EjemploArchivoBinario
{
    public class ArchivoBinarioEmpleado
    {
        // Declaración de flujos 
        BinaryWriter bw = null;
        BinaryReader br = null;

        // Campos de la clase 
        string Nombre, Dirección;
        long Telefono;
        int numEmp, diasTrabajados;
        float salarioDiario; 

        public void CreaarArchivo(string Archivo)
        {
            char resp;

            try
            {

                bw = new BinaryWriter(new FileStream(Archivo, FileMode.Create, FileAccess.Write));
                do
                {
                    Console.Clear();
                    Console.Write("Numero de empleado: ");
                    numEmp = int.Parse(Console.ReadLine());
                    Console.Write("Nombre del empleado: ");
                    Nombre = Console.ReadLine();
                    Console.Write("Dirección del empleado: ");
                    Dirección = Console.ReadLine();
                    Console.Write("Telefono de Empleado: ");
                    Telefono = long.Parse(Console.ReadLine());
                    Console.Write("Dias Trabajados del empleado: ");
                    diasTrabajados = Int32.Parse(Console.ReadLine());
                    Console.Write("Salario Diario del Empleado: ");
                    salarioDiario = Single.Parse(Console.ReadLine());

                    // Escribe los datos al archivo
                    bw.Write(numEmp);
                    bw.Write(Nombre);
                    bw.Write(Dirección);
                    bw.Write(Telefono);
                    bw.Write(diasTrabajados);
                    bw.Write(salarioDiario);

                    Console.Write("\n\nDeseas Almacenar otro registro (s/n)?");
                    resp = char.Parse(Console.ReadLine());



                } while ((resp == 'a') || (resp == 's'));
            }
            catch (IOException e)
            {
                Console.WriteLine("\nError : " + e.Message);
                Console.WriteLine("\nRuta : " + e.StackTrace);

            }
            finally
            {
                if (bw != null) bw.Close();
                Console.Write("\nPresione <enter> para terminar la Escritura de datos y regresar al Menu."); 
                            
                Console.ReadKey();
            }
           
        }
        public void MostrarArchivos(string Archivo)
        {
            try
            {
                if (File.Exists(Archivo))
                {
                    // Creación Flujo  para leer datos de archivo
                  
                 br = new BinaryReader(new FileStream(Archivo, FileMode.Open, FileAccess.Read));
                    // Despliegue
                    Console.Clear();
                    do
                    {
                        numEmp = br.ReadInt32();
                        Nombre = br.ReadString();
                        Dirección = br.ReadString();
                        Telefono = br.ReadInt64();
                        diasTrabajados = br.ReadInt32();
                        salarioDiario = br.ReadSingle();

                        // Mostrar los archivos 
                        Console.WriteLine("Numero del empleado;  " + numEmp);
                        Console.WriteLine("Nombre del empleado: " + Nombre);
                        Console.WriteLine("Direcció del empleqado: " + Dirección);
                        Console.WriteLine("Telefono del empleado " + Telefono);
                        Console.WriteLine("Dias Trabajados del empleado " + diasTrabajados);
                        Console.WriteLine("Salario diario del empleado " + salarioDiario);
                        Console.WriteLine("Sueldo total del empleado ", diasTrabajados * salarioDiario
                        );
                        Console.WriteLine("\n");
                    } while (true); 
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\nEl Archivo " + Archivo + " No Existe en el Disco!! ");
                    

                    Console.Write("\nPresione <enter> para Continuar...");
                    Console.ReadKey();
                }
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("\n\nFin del Listado de Empleados");
                Console.Write("\nPresione <enter> para Continuar...");
                Console.ReadKey();
            }
            finally
            {
                if (br != null) br.Close(); //cierra flujo
                Console.Write("\nPresione <enter> para terminar la Lectura de Datos y regresar al Menu. ");
                

                Console.ReadKey();
            }
        }


    }
}
