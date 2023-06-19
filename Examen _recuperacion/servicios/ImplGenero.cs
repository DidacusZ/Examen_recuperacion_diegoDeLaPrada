using Examen__recuperacion.entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
/*
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
*/

namespace Examen__recuperacion.servicios
{
    internal class ImplGenero : InterfaceGenero
    {
        public void ListarProductos(List<Genero> list)
        {
            Console.WriteLine("\n\tnombre,cantidad,unidad");

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine("\t"+list[i].ToString()); 

            Sms("Plusa para volver al menu");
        }

        public void NuevoProducto(List<Genero> list)
        {
            bool v = false;
            string nombre = CapturaString("Escribe el nombe del producto a agregar");

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Nombre.Equals(nombre)){//comprueba si hay un nombre que coincida

                    Console.WriteLine("\n\tEl producto ya existe");
                    int cantidad = CapturaEntero("Que cantidad de "+ list[i].Nombre+ " en "+ list[i].Unidad+ " quieres agregar: ", 1, 99999);

                    list[i].Cantidad = cantidad + list[i].Cantidad;
                    Sms("Se a agregado la cantidad con exito");
                    v = true;
                    break;
                }
            }

            if (!v)
            {
                Genero genero = new Genero();

                genero.Nombre = nombre;
                genero.Unidad = CapturaString("Introduce la unidad en la que se mide");
                genero.Cantidad = CapturaEntero("Introduce la cantidad que de deseas agregar",1,99999);
                
                list.Add(genero);
                Sms("Se a agregado el nuevo producto al almacen con exito");
            }

            //guardamos cambios en fichero
            FicheroInsert(list);
        }

        public void SalidaProducto(List<Genero> list)
        {
            bool v = false;
            string nombre = CapturaString("Escribe el nombe del producto del que quieres sacar una cantidad");

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Nombre.Equals(nombre))
                {
                    int cantidad = CapturaEntero("Que cantidad de " + list[i].Nombre + " en " + list[i].Unidad + " quieres sacar: ", 1, list[i].Cantidad);

                    list[i].Cantidad = list[i].Cantidad - cantidad;
                    Sms("Se a sacado la cantidad del almacen con exito");
                    v = true;
                    break;
                }
            }

            if (!v)
                Sms("El producto no se encuentra en el almacen");

            //guardamos cambios en fichero
            FicheroInsert(list);
        }


        public void FicheroInsert(List<Genero> list)
        {
            StreamWriter sw = File.CreateText("Almacen.txt");

            //cabecera
            sw.WriteLine("nombre,cantidad,unidad");

            for (int i = 0; i < list.Count; i++)
                sw.WriteLine(list[i].ToString());

            sw.Close();
        }

        public void FicheroCargar(List<Genero> list)
        {
            if (File.Exists("Almacen.txt"))
            {
                StreamReader sr = new StreamReader("Almacen.txt", Encoding.Default);

                List<string> lineas = new List<string>();

                while (!(sr.EndOfStream))//recorre el fichero   
                    lineas.Add(sr.ReadLine());//guarda las lineas en una lista

                sr.Close();

                for (int i = 1; i < lineas.Count; i++)//nos saltamos la cabecera
                {
                    string[] campos = lineas[i].Split(';');//separa cada elemento de la lista por '';'' y lo guarda en un array 

                    Genero genero = new Genero();

                    genero.Nombre = campos[0];
                    genero.Cantidad = Convert.ToInt32(campos[1]);
                    genero.Unidad = campos[2];

                    list.Add(genero);
                }
            }            
        }

        //metodos privados:

        //muestra un mensaje y al pulsar continua
        private void Sms(string txt)
        {
            Console.Write("\n\n\t{0}....",txt);
            Console.ReadKey(true);
        }

        //muestra un mensaje y captura un string
        private string CapturaString(string txt)
        {
            Console.Write("\n\t{0}: ", txt);
            return Console.ReadLine();
        }

        //captura solo valores numericos dentro del rango especificado
        private int CapturaEntero(string txt,int min,int max)
        {
            int valor;
            bool verdad;

            do
            {
                Console.Write("\t{0} [{1}-{2}]: ",txt,min,max);
                verdad = Int32.TryParse(Console.ReadLine(), out valor);//devuelve true cuando es un numero

                if(!verdad)
                    Console.WriteLine("\terror de formato");

                if(verdad&&valor>=min&&valor<=max)
                    return valor;

                if (verdad)
                {
                    verdad = false;
                    Console.WriteLine("\tnumero fuera de rango");
                }                    

            } while (!verdad);

            return valor;
        }
                
    }
}
