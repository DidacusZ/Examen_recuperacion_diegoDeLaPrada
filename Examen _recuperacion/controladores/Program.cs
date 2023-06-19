//diego de la prada
using Examen__recuperacion.entidades;
using Examen__recuperacion.servicios;
using System;
using System.Collections.Generic;
/*
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace Examen__recuperacion
{
    internal class Program
    {
        static void Main(string[] args)
        {     
            try//lo meto todo en el try-catch por si hay algun error en la implementacion,menu...
            {
                //variable
                int opcion;

                //implementaciones
                InterfaceMenu menu = new ImplMenu();
                InterfaceGenero implGenero = new ImplGenero();

                //lista
                List<Genero> listaProductos = new List<Genero>();

                //cargamos la lista
                implGenero.FicheroCargar(listaProductos);

                do
                {
                    Console.Clear();
                    opcion = menu.Menu();
                    Console.Clear();

                    switch (opcion)
                    {
                        //listar
                        case 1:
                            implGenero.ListarProductos(listaProductos);
                            break;

                        //nuevo
                        case 2:
                            implGenero.NuevoProducto(listaProductos);
                            break;

                        //salida
                        case 3:
                            implGenero.SalidaProducto(listaProductos);
                            break;
                    }

                } while (opcion != 0);

                //al salir guarda la lista en el fichero
                //implGenero.FicheroInsert(listaProductos);

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\tERROR GENERAL");
            }            
        }
    }
}
