using System;
/*
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace Examen__recuperacion.servicios
{
    internal class ImplMenu : InterfaceMenu
    {
        public int Menu()
        {
            Console.WriteLine("\n\t1. listar productos");
            Console.WriteLine("\t2. nuevo genero ");
            Console.WriteLine("\t3. salida del genero");
            Console.WriteLine("\t0. Salir");
            Console.Write("\n\tElige una opcion: ");
            return Console.ReadKey(true).KeyChar - '0';
        }
    }
}
